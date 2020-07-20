// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CodeGeneration.Roslyn;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Generates <see cref="IntPtr"/> and/or <c>byte[]</c> overloads
    /// of a method that accepts native pointers.
    /// </summary>
    public class OfferFriendlyOverloadsGenerator : ICodeGenerator
    {
        private static readonly TypeSyntax VoidStar = SyntaxFactory.ParseTypeName("void*");

        private static readonly TypeSyntax ByteStar = SyntaxFactory.ParseTypeName("byte*");

        private static readonly TypeSyntax ByteArray = SyntaxFactory.ParseTypeName("byte[]");

        private static readonly TypeSyntax SpanOfByte = ParseTypeName("System.Span<byte>");

        private static readonly TypeSyntax IntPtrTypeSyntax = SyntaxFactory.ParseTypeName("System.IntPtr");

        private static readonly SyntaxList<ArrayRankSpecifierSyntax> OneDimensionalUnspecifiedLengthArray =
            SyntaxFactory.SingletonList(
                SyntaxFactory.ArrayRankSpecifier(
                    SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                        SyntaxFactory.OmittedArraySizeExpression()
                        .WithOmittedArraySizeExpressionToken(
                            SyntaxFactory.Token(
                                SyntaxKind.OmittedArraySizeExpressionToken))))
                .WithOpenBracketToken(
                    SyntaxFactory.Token(
                        SyntaxKind.OpenBracketToken))
                .WithCloseBracketToken(
                    SyntaxFactory.Token(
                        SyntaxKind.CloseBracketToken)));

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferFriendlyOverloadsGenerator"/> class.
        /// </summary>
        /// <param name="data">Generator attribute data.</param>
        public OfferFriendlyOverloadsGenerator(AttributeData data)
        {
        }

        [Flags]
        private enum GeneratorFlags
        {
            None = 0x0,

            /// <summary>
            /// Generates the parameter types and code to translate an <see cref="IntPtr"/> into a native pointer.
            /// </summary>
            NativePointerToIntPtr = 0x1,

            /// <summary>
            /// Generates the parameter types and code to translate more friendly parameters (e.g. arrays, ref/in/out modifiers, etc.) into a native pointer.
            /// </summary>
            NativePointerToFriendly = 0x2,

            /// <summary>
            /// When producing an array-accepting overload, use an array type instead of a Span{T} or ReadOnlySpan{T}.
            /// </summary>
            /// <remarks>
            /// Since Span{T} and ReadOnlySpan{T} implicitly accepts an array, generating explicit array overloads only serves to avoid binary breaking changes
            /// from removal of the array overloads when we switched to Span{T} as the preferred type.
            /// </remarks>
            UseArrays = 0x4,
        }

        /// <inheritdoc />
        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(TransformationContext context, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            var applyTo = context.ProcessingNode;
            var compilation = context.Compilation;
            var semanticModel = compilation.GetSemanticModel(applyTo.SyntaxTree);
            var obsoleteAttribute = compilation.GetTypeByMetadataName("System.ObsoleteAttribute");

            var type = (ClassDeclarationSyntax)applyTo;
            var generatedType = type
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>());
            var methodsWithNativePointers =
                from method in type.Members.OfType<MethodDeclarationSyntax>()
                where !method.AttributeLists.SelectMany(al => al.Attributes).Any(att => att.Name is SimpleNameSyntax sn && sn.Identifier.ValueText == "NoFriendlyOverloads")
                where WhereIsPointerParameter(method.ParameterList.Parameters).Any() || method.ReturnType is PointerTypeSyntax
                select method;

            foreach (var method in methodsWithNativePointers)
            {
                var methodSymbol = semanticModel.GetDeclaredSymbol(method, cancellationToken);
                var nativePointerParameters = method.ParameterList.Parameters.Where(p => p.Type is PointerTypeSyntax);

                var refOrArrayAttributedParameters =
                    from parameter in nativePointerParameters
                    let attributes = parameter.AttributeLists.SelectMany(al => al.Attributes)
                    let friendlyAttribute = attributes.FirstOrDefault(attribute => (attribute.Name as SimpleNameSyntax)?.Identifier.ValueText == "Friendly")
                    where friendlyAttribute != null
                    let friendlyFlagsExpression = friendlyAttribute.ArgumentList.Arguments.First().Expression
                    let arrayLengthParameterExpression = friendlyAttribute.ArgumentList.Arguments.FirstOrDefault(arg => arg.NameEquals is { } ne && ne.Name.Identifier.ValueText == nameof(FriendlyAttribute.ArrayLengthParameter))?.Expression
                    let friendlyFlags = (FriendlyFlags)(int)semanticModel.GetConstantValue(friendlyFlagsExpression).Value
                    select new
                    {
                        Parameter = parameter,
                        Friendly = new FriendlyAttribute(friendlyFlags)
                        {
                            ArrayLengthParameter = arrayLengthParameterExpression is object ? (int)semanticModel.GetConstantValue(arrayLengthParameterExpression).Value : -1,
                        },
                    };
                var parametersToFriendlyTransform = refOrArrayAttributedParameters.ToDictionary(p => p.Parameter, p => p.Friendly);

                // Consider undecorated byte* parameters to have a Friendly attribute by default.
                var byteArrayInParameters = nativePointerParameters.Where(IsByteStarInParameter);
                foreach (var p in byteArrayInParameters)
                {
                    if (!parametersToFriendlyTransform.ContainsKey(p))
                    {
                        parametersToFriendlyTransform[p] = new FriendlyAttribute(FriendlyFlags.Array | FriendlyFlags.Bidirectional);
                    }
                }

                var leadingTrivia = Trivia(
                    DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia).AddContent(
                        XmlText("/// "),
                        XmlEmptyElement("inheritdoc").AddAttributes(XmlCrefAttribute(NameMemberCref(IdentifierName(method.Identifier), ToCref(method.ParameterList)))),
                        XmlText().AddTextTokens(XmlTextNewLine(TriviaList(), "\r\n", "\r\n", TriviaList()))));

                var transformedMethodBase = method
                    .WithReturnType(TransformReturnType(method.ReturnType))
                    .WithIdentifier(TransformMethodName(method))
                    .WithModifiers(RemoveModifier(method.Modifiers, SyntaxKind.ExternKeyword))
                    .WithAttributeLists(FilterAttributes(method.AttributeLists))
                    .WithLeadingTrivia(leadingTrivia)
                    .WithTrailingTrivia(method.GetTrailingTrivia().TakeWhile(t => !t.IsDirective))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
                    .WithExpressionBody(null);

                var flags = GeneratorFlags.NativePointerToIntPtr;
                var intPtrOverload = transformedMethodBase
                    .WithParameterList(TransformParameterList(method.ParameterList, flags, parametersToFriendlyTransform, null, null))
                    .WithBody(CallNativePointerOverload(semanticModel, methodSymbol, method, flags, parametersToFriendlyTransform, null));
                generatedType = generatedType.AddMembers(intPtrOverload);

                if (parametersToFriendlyTransform.Count > 0)
                {
                    void AddOverload(GeneratorFlags flags)
                    {
                        // Consider removing or modifying length parameters if appropriate.
                        Dictionary<int, ParameterSyntax> indexesOfParameterToRemove = null;
                        List<int> indexesOfParametersToMakeOutOnly = null;
                        if ((flags & GeneratorFlags.UseArrays) == GeneratorFlags.None)
                        {
                            foreach (var parameter in method.ParameterList.Parameters)
                            {
                                if (parametersToFriendlyTransform.TryGetValue(parameter, out FriendlyAttribute friendly) && (friendly.Flags & FriendlyFlags.Array) == FriendlyFlags.Array && friendly.ArrayLengthParameter >= 0)
                                {
                                    var lenParam = method.ParameterList.Parameters[friendly.ArrayLengthParameter];
                                    if (!(lenParam.Type is PointerTypeSyntax))
                                    {
                                        if (lenParam.Modifiers.Count == 0)
                                        {
                                            if (indexesOfParameterToRemove is null)
                                            {
                                                indexesOfParameterToRemove = new Dictionary<int, ParameterSyntax>();
                                            }

                                            indexesOfParameterToRemove.Add(friendly.ArrayLengthParameter, parameter);
                                        }
                                        else if (lenParam.Modifiers.Any(SyntaxKind.RefKeyword))
                                        {
                                            if (indexesOfParametersToMakeOutOnly is null)
                                            {
                                                indexesOfParametersToMakeOutOnly = new List<int>();
                                            }

                                            indexesOfParametersToMakeOutOnly.Add(friendly.ArrayLengthParameter);
                                        }
                                    }
                                }
                            }
                        }

                        var overload = transformedMethodBase
                            .WithParameterList(TransformParameterList(method.ParameterList, flags, parametersToFriendlyTransform, indexesOfParameterToRemove?.Keys, indexesOfParametersToMakeOutOnly))
                            .WithBody(CallNativePointerOverload(semanticModel, methodSymbol, method, flags, parametersToFriendlyTransform, indexesOfParameterToRemove));
                        generatedType = generatedType.AddMembers(overload);
                    }

                    void AddOverloads(GeneratorFlags flags)
                    {
                        AddOverload(flags);

                        // If there are native pointers that represent arrays, it would produce a unique method signature
                        // for a method to accept array parameter types in addition to the Span<T> that the preferred overload would use.
                        if (parametersToFriendlyTransform.Values.Any(f => (f.Flags & FriendlyFlags.Array) == FriendlyFlags.Array))
                        {
                            AddOverload(flags | GeneratorFlags.UseArrays);
                        }
                    }

                    AddOverloads(GeneratorFlags.NativePointerToIntPtr | GeneratorFlags.NativePointerToFriendly);

                    // If there are native pointers that aren't "friendly", it would produce a unique method signature
                    // for a method that only converts the friendly parameters and leaves other native pointers alone.
                    if (nativePointerParameters.Except(parametersToFriendlyTransform.Keys).Any())
                    {
                        AddOverloads(GeneratorFlags.NativePointerToFriendly);
                    }
                }
            }

            return Task.FromResult(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(generatedType));
        }

        private static CrefParameterListSyntax ToCref(ParameterListSyntax parameterList) => CrefParameterList().AddParameters(parameterList.Parameters.Select(ToCref).ToArray());

        private static CrefParameterSyntax ToCref(ParameterSyntax parameter)
            => CrefParameter(
                parameter.Modifiers.Any(SyntaxKind.RefKeyword) ? Token(SyntaxKind.RefKeyword) :
                parameter.Modifiers.Any(SyntaxKind.OutKeyword) ? Token(SyntaxKind.OutKeyword) :
                default,
                parameter.Type);

        private static SyntaxList<AttributeListSyntax> FilterAttributes(SyntaxList<AttributeListSyntax> attributeLists)
        {
            var result = SyntaxFactory.List<AttributeListSyntax>();
            foreach (var list in attributeLists)
            {
                var filteredList = FilterAttributes(list);
                if (filteredList.Attributes.Count > 0)
                {
                    result = result.Add(filteredList);
                }
            }

            return result;
        }

        private static AttributeListSyntax FilterAttributes(AttributeListSyntax list)
        {
            return SyntaxFactory.AttributeList().AddAttributes((
                from attribute in list.Attributes
                let name = attribute.Name as SimpleNameSyntax
                where name?.Identifier.ValueText == "Obsolete"
                select attribute).ToArray());
        }

        private static bool IsByteStarInParameter(ParameterSyntax parameter)
        {
            return IsByteStar(parameter.Type) && !parameter.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword) || m.IsKind(SyntaxKind.RefKeyword));
        }

        private static bool IsByteStar(TypeSyntax typeSyntax)
        {
            var nativePointerType = typeSyntax as PointerTypeSyntax;
            var predefinedElementType = nativePointerType?.ElementType as PredefinedTypeSyntax;
            return predefinedElementType?.Keyword.IsKind(SyntaxKind.ByteKeyword) ?? false;
        }

        private static TypeSyntax MakeSpanOfT(TypeSyntax typeArgument) => QualifiedName(IdentifierName("System"), GenericName(Identifier("Span")).AddTypeArgumentListArguments(typeArgument));

        private static TypeSyntax MakeReadOnlySpanOfT(TypeSyntax typeArgument) => QualifiedName(IdentifierName("System"), GenericName(Identifier("ReadOnlySpan")).AddTypeArgumentListArguments(typeArgument));

        private static IEnumerable<ParameterSyntax> WhereIsPointerParameter(IEnumerable<ParameterSyntax> parameters)
        {
            return from p in parameters
                   where p.Type is PointerTypeSyntax
                   select p;
        }

        private static SyntaxToken TransformMethodName(MethodDeclarationSyntax method)
        {
            // When the method overload being generated has exactly the same parameter types
            // as the original (because the transformation is only in the return type),
            // we must give the method a new name.
            return WhereIsPointerParameter(method.ParameterList.Parameters).Any()
                ? method.Identifier
                : SyntaxFactory.Identifier(method.Identifier.ValueText + "_IntPtr");
        }

        private static TypeSyntax TransformReturnType(TypeSyntax returnType) => returnType is PointerTypeSyntax ? IntPtrTypeSyntax : returnType;

        private static ParameterListSyntax TransformParameterList(ParameterListSyntax list, GeneratorFlags generatorFlags, IReadOnlyDictionary<ParameterSyntax, FriendlyAttribute> parametersToFriendlyTransform, IEnumerable<int> indexesOfParameterToRemove, List<int> indexesOfParametersToMakeOutOnly)
        {
            var resultingList = list.ReplaceNodes(
                WhereIsPointerParameter(list.Parameters),
                (n1, n2) =>
                {
                    // Remove all attributes
                    n2 = n2.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());

                    FriendlyAttribute friendly;
                    if (generatorFlags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.TryGetValue(n1, out friendly))
                    {
                        var pointerType = (PointerTypeSyntax)n2.Type;
                        var alteredParameter = n2.WithDefault(null);
                        if (friendly.Flags.HasFlag(FriendlyFlags.Array))
                        {
                            alteredParameter = alteredParameter
                                .WithType(
                                    (generatorFlags & GeneratorFlags.UseArrays) == GeneratorFlags.UseArrays
                                        ? SyntaxFactory.ArrayType(pointerType.ElementType, OneDimensionalUnspecifiedLengthArray)
                                        : ((friendly.Flags & FriendlyFlags.Bidirectional) == FriendlyFlags.In ? MakeReadOnlySpanOfT(pointerType.ElementType) : MakeSpanOfT(pointerType.ElementType)));
                        }
                        else
                        {
                            if (friendly.Flags.HasFlag(FriendlyFlags.Optional))
                            {
                                alteredParameter = alteredParameter
                                    .WithType(SyntaxFactory.NullableType(pointerType.ElementType));
                            }

                            if (friendly.Flags.HasFlag(FriendlyFlags.Out))
                            {
                                SyntaxKind modifier = friendly.Flags.HasFlag(FriendlyFlags.Optional) || friendly.Flags.HasFlag(FriendlyFlags.In)
                                     ? SyntaxKind.RefKeyword
                                     : SyntaxKind.OutKeyword;
                                if (!friendly.Flags.HasFlag(FriendlyFlags.Optional))
                                {
                                    alteredParameter = alteredParameter
                                        .WithType(pointerType.ElementType);
                                }

                                alteredParameter = alteredParameter
                                    .AddModifiers(SyntaxFactory.Token(modifier));
                            }
                            else if (!friendly.Flags.HasFlag(FriendlyFlags.Optional))
                            {
                                alteredParameter = alteredParameter
                                    .WithType(pointerType.ElementType);
                            }
                        }

                        return alteredParameter;
                    }
                    else if (generatorFlags.HasFlag(GeneratorFlags.NativePointerToIntPtr))
                    {
                        return n2
                            .WithType(IntPtrTypeSyntax)
                            .WithDefault(null);
                    }
                    else
                    {
                        return n2;
                    }
                });

            // Modify array length parameters where appropriate
            if (indexesOfParametersToMakeOutOnly is object)
            {
                foreach (int i in indexesOfParametersToMakeOutOnly)
                {
                    resultingList = resultingList.ReplaceNode(resultingList.Parameters[i], resultingList.Parameters[i].WithModifiers(default));
                }
            }

            // If the friendly attributes and the overload we're generating indicate that we should remove parameters, do so now.
            if (indexesOfParameterToRemove is object)
            {
                foreach (int i in indexesOfParameterToRemove.OrderByDescending(i => i))
                {
                    resultingList = resultingList.RemoveNode(resultingList.Parameters[i], SyntaxRemoveOptions.KeepNoTrivia);
                }
            }

            return resultingList;
        }

        private static ParameterSyntax ConvertPointerToRefParameter(ParameterSyntax parameter)
        {
            var pointerType = (PointerTypeSyntax)parameter.Type;
            return parameter
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.RefKeyword))
                .WithType(pointerType.ElementType);
        }

        private static ParameterSyntax ConvertPointerToNullableParameter(ParameterSyntax parameter)
        {
            var pointerType = (PointerTypeSyntax)parameter.Type;
            return parameter
                .WithType(SyntaxFactory.NullableType(pointerType.ElementType));
        }

        private static SyntaxTokenList RemoveModifier(SyntaxTokenList list, params SyntaxKind[] modifiers)
        {
            return SyntaxFactory.TokenList(list.Where(t => Array.IndexOf(modifiers, t.Kind()) < 0));
        }

        private static BlockSyntax CallNativePointerOverload(SemanticModel semanticModel, IMethodSymbol methodSymbol, MethodDeclarationSyntax nativePointerOverload, GeneratorFlags flags, IReadOnlyDictionary<ParameterSyntax, FriendlyAttribute> parametersToFriendlyTransform, Dictionary<int, ParameterSyntax> indexesOfParametersToRemove)
        {
            Func<ParameterSyntax, IdentifierNameSyntax> getLocalSubstituteName = p => SyntaxFactory.IdentifierName(p.Identifier.ValueText + "Local");
            var invocationArguments = new Dictionary<ParameterSyntax, ArgumentSyntax>();
            for (int i = 0; i < nativePointerOverload.ParameterList.Parameters.Count; i++)
            {
                var p = nativePointerOverload.ParameterList.Parameters[i];
                if (indexesOfParametersToRemove is object && indexesOfParametersToRemove.TryGetValue(i, out ParameterSyntax arrayParameter))
                {
                    // We may have to cast this to uint depending on the receiving type.
                    var uintSymbol = semanticModel.Compilation.GetTypeByMetadataName("System.UInt32");
                    bool isUint = methodSymbol?.Parameters[i].Type?.Equals(uintSymbol) ?? false;
                    var memberAccess = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(arrayParameter.Identifier), IdentifierName("Length"));
                    invocationArguments[p] = Argument(isUint ? (ExpressionSyntax)CastExpression(PredefinedType(Token(SyntaxKind.UIntKeyword)), memberAccess) : memberAccess);
                }
                else
                {
                    var refOrOut = p.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.RefKeyword) || m.IsKind(SyntaxKind.OutKeyword));
                    invocationArguments[p] = SyntaxFactory
                        .Argument(SyntaxFactory.IdentifierName(p.Identifier))
                        .WithRefOrOutKeyword(refOrOut);
                }
            }

            var prelude = new List<StatementSyntax>();
            var postlude = new List<StatementSyntax>();
            var fixedStatements = new List<FixedStatementSyntax>();

            bool emptyStackArrayRequired = false;
            const string EmptyStackArrayLocal = "__EmptyArray";
            const string EmptyStackArrayLocalPointer = "pEmptyArray";

            foreach (var parameter in nativePointerOverload.ParameterList.Parameters.Where(p => p.Type is PointerTypeSyntax))
            {
                var parameterName = SyntaxFactory.IdentifierName(parameter.Identifier);
                var localVarName = getLocalSubstituteName(parameter);
                FriendlyAttribute friendly;
                if (flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.TryGetValue(parameter, out friendly))
                {
                    if (friendly.Flags.HasFlag(FriendlyFlags.Array))
                    {
                        if (!friendly.Flags.HasFlag(FriendlyFlags.Optional) && !flags.HasFlag(GeneratorFlags.UseArrays))
                        {
                            emptyStackArrayRequired = true;
                        }

                        var fixedArrayDecl = SyntaxFactory.VariableDeclarator(localVarName.Identifier)
                            .WithInitializer(SyntaxFactory.EqualsValueClause(parameterName));
                        fixedStatements.Add(SyntaxFactory.FixedStatement(
                            SyntaxFactory.VariableDeclaration(parameter.Type).AddVariables(fixedArrayDecl),
                            SyntaxFactory.Block()));

                        if (!friendly.Flags.HasFlag(FriendlyFlags.Optional) && !flags.HasFlag(GeneratorFlags.UseArrays))
                        {
                            // We have to be careful to not pass a null pointer in. If the Span we have has length == 0, we must use a pointer to our 1 byte memory.
                            invocationArguments[parameter] = invocationArguments[parameter].WithExpression(
                                ConditionalExpression(
                                    BinaryExpression(SyntaxKind.NotEqualsExpression, localVarName, LiteralExpression(SyntaxKind.NullLiteralExpression)),
                                    localVarName,
                                    CastExpression(parameter.Type, IdentifierName(EmptyStackArrayLocalPointer))));
                        }
                        else
                        {
                            invocationArguments[parameter] = invocationArguments[parameter].WithExpression(localVarName);
                        }
                    }
                    else
                    {
                        if (friendly.Flags.HasFlag(FriendlyFlags.Optional))
                        {
                            var nullableType = (PointerTypeSyntax)parameter.Type;
                            var hasValueExpression = SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName(parameter.Identifier),
                                SyntaxFactory.IdentifierName(nameof(Nullable<int>.HasValue)));
                            var valueExpression = SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName(parameter.Identifier),
                                SyntaxFactory.IdentifierName(nameof(Nullable<int>.Value)));
                            var defaultExpression = SyntaxFactory.DefaultExpression(nullableType.ElementType);
                            var varStatement = SyntaxFactory.VariableDeclaration(nullableType.ElementType).AddVariables(
                                SyntaxFactory.VariableDeclarator(localVarName.Identifier)
                                    .WithInitializer(SyntaxFactory.EqualsValueClause(
                                        SyntaxFactory.ConditionalExpression(
                                            hasValueExpression,
                                            valueExpression,
                                            defaultExpression))));
                            prelude.Add(SyntaxFactory.LocalDeclarationStatement(varStatement));

                            if (friendly.Flags.HasFlag(FriendlyFlags.Out))
                            {
                                // someParam = someParamLocal;
                                var assignBackToParameter = SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    parameterName,
                                    localVarName);
                                var conditionalStatement = SyntaxFactory.IfStatement(
                                    hasValueExpression,
                                    SyntaxFactory.ExpressionStatement(assignBackToParameter));
                                postlude.Add(conditionalStatement);
                            }

                            invocationArguments[parameter] = invocationArguments[parameter].WithExpression(
                                SyntaxFactory.ConditionalExpression(
                                    hasValueExpression,
                                    SyntaxFactory.PrefixUnaryExpression(SyntaxKind.AddressOfExpression, localVarName),
                                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)));
                        }
                        else if (friendly.Flags.HasFlag(FriendlyFlags.Out))
                        {
                            var fixedDecl = SyntaxFactory.VariableDeclarator(localVarName.Identifier)
                                .WithInitializer(SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.PrefixUnaryExpression(
                                        SyntaxKind.AddressOfExpression,
                                        parameterName)));
                            fixedStatements.Add(SyntaxFactory.FixedStatement(
                                SyntaxFactory.VariableDeclaration(parameter.Type).AddVariables(fixedDecl),
                                SyntaxFactory.Block()));

                            invocationArguments[parameter] = invocationArguments[parameter].WithExpression(localVarName);
                        }
                        else
                        {
                            invocationArguments[parameter] = invocationArguments[parameter]
                                .WithExpression(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.AddressOfExpression, parameterName));
                        }
                    }
                }
                else if (flags.HasFlag(GeneratorFlags.NativePointerToIntPtr))
                {
                    var varStatement = SyntaxFactory.VariableDeclaration(parameter.Type);
                    var declarator = SyntaxFactory.VariableDeclarator(localVarName.Identifier);
                    if (parameter.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword) || m.IsKind(SyntaxKind.RefKeyword)))
                    {
                        var assignment = SyntaxFactory.AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            parameterName,
                            SyntaxFactory.ObjectCreationExpression(
                                IntPtrTypeSyntax,
                                SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(localVarName))),
                                null));
                        postlude.Add(SyntaxFactory.ExpressionStatement(assignment));
                    }

                    if (!parameter.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword)))
                    {
                        var voidStarPointer = SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName(parameter.Identifier),
                                SyntaxFactory.IdentifierName(nameof(IntPtr.ToPointer))),
                            SyntaxFactory.ArgumentList());
                        var typedPointer = parameter.Type.Equals(VoidStar)
                            ? (ExpressionSyntax)voidStarPointer
                            : SyntaxFactory.CastExpression(parameter.Type, voidStarPointer);

                        declarator = declarator.WithInitializer(SyntaxFactory.EqualsValueClause(typedPointer));
                    }

                    varStatement = varStatement.AddVariables(declarator);
                    prelude.Add(SyntaxFactory.LocalDeclarationStatement(varStatement));

                    invocationArguments[parameter] = invocationArguments[parameter].WithExpression(localVarName);
                }
            }

            var invocationExpression = SyntaxFactory.InvocationExpression(
                SyntaxFactory.IdentifierName(nativePointerOverload.Identifier.ValueText),
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(
                        from p in nativePointerOverload.ParameterList.Parameters
                        select invocationArguments[p])));

            IdentifierNameSyntax resultVariableName = null;
            StatementSyntax invocationStatement;
            if (nativePointerOverload.ReturnType != null && (nativePointerOverload.ReturnType as PredefinedTypeSyntax)?.Keyword.Kind() != SyntaxKind.VoidKeyword)
            {
                resultVariableName = SyntaxFactory.IdentifierName("result"); // TODO: ensure this is unique.
                invocationStatement = SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(nativePointerOverload.ReturnType)
                        .AddVariables(
                            SyntaxFactory.VariableDeclarator(resultVariableName.Identifier)
                                .WithInitializer(SyntaxFactory.EqualsValueClause(invocationExpression))));
            }
            else
            {
                invocationStatement = SyntaxFactory.ExpressionStatement(invocationExpression);
            }

            var block = SyntaxFactory.Block()
                .AddStatements(prelude.ToArray())
                .AddStatements(invocationStatement)
                .AddStatements(postlude.ToArray());

            if (resultVariableName != null)
            {
                ExpressionSyntax returnedValue = nativePointerOverload.ReturnType is PointerTypeSyntax
                    ? (ExpressionSyntax)SyntaxFactory.ObjectCreationExpression(
                        IntPtrTypeSyntax,
                        SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(resultVariableName))),
                        null)
                    : resultVariableName;
                block = block.AddStatements(SyntaxFactory.ReturnStatement(returnedValue));
            }

            if (emptyStackArrayRequired)
            {
                fixedStatements.Add(FixedStatement(
                    VariableDeclaration(PointerType(PredefinedType(Token(SyntaxKind.VoidKeyword))))
                    .AddVariables(VariableDeclarator(EmptyStackArrayLocalPointer).WithInitializer(EqualsValueClause(IdentifierName(EmptyStackArrayLocal)))), Block()));
            }

            if (fixedStatements.Count > 0)
            {
                StatementSyntax outermost = block;
                foreach (var statement in fixedStatements)
                {
                    outermost = statement.WithStatement(outermost);
                }

                block = SyntaxFactory.Block(outermost);
            }

            if (emptyStackArrayRequired)
            {
                // Span<byte> __EmptyArray = stackalloc byte[1];
                var statement = LocalDeclarationStatement(VariableDeclaration(SpanOfByte).AddVariables(VariableDeclarator(EmptyStackArrayLocal).WithInitializer(
                    EqualsValueClause(StackAllocArrayCreationExpression(ArrayType(PredefinedType(Token(SyntaxKind.ByteKeyword))).AddRankSpecifiers(ArrayRankSpecifier(SingletonSeparatedList<ExpressionSyntax>(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(1))))))))));
                block = block.InsertNodesBefore(block.Statements.First(), new SyntaxNode[] { statement });
            }

            return block;
        }

        private static TValue GetValueOrDefault<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            TValue entry;
            return dictionary.TryGetValue(key, out entry) ? entry : defaultValue;
        }
    }
}
