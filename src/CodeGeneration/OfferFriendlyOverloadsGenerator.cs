// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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

    /// <summary>
    /// Generates <see cref="IntPtr"/> and/or <c>byte[]</c> overloads
    /// of a method that accepts native pointers.
    /// </summary>
    public class OfferFriendlyOverloadsGenerator : ICodeGenerator
    {
        private static readonly TypeSyntax VoidStar = SyntaxFactory.ParseTypeName("void*");

        private static readonly TypeSyntax ByteStar = SyntaxFactory.ParseTypeName("byte*");

        private static readonly TypeSyntax ByteArray = SyntaxFactory.ParseTypeName("byte[]");

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
            NativePointerToIntPtr = 0x1,
            NativePointerToFriendly = 0x2,
        }

        /// <inheritdoc />
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(MemberDeclarationSyntax applyTo, Document document, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
            var type = (ClassDeclarationSyntax)applyTo;
            var generatedType = type
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>());
            var methodsWithNativePointers =
                from method in type.Members.OfType<MethodDeclarationSyntax>()
                where WhereIsPointerParameter(method.ParameterList.Parameters).Any() || method.ReturnType is PointerTypeSyntax
                select method;

            foreach (var method in methodsWithNativePointers)
            {
                var nativePointerParameters = method.ParameterList.Parameters.Where(p => p.Type is PointerTypeSyntax);

                var refOrArrayAttributedParameters =
                    from parameter in nativePointerParameters
                    let attributes = parameter.AttributeLists.SelectMany(al => al.Attributes)
                    let friendlyAttribute = attributes.FirstOrDefault(attribute => (attribute.Name as SimpleNameSyntax)?.Identifier.ValueText == "Friendly")
                    where friendlyAttribute != null
                    let friendlyFlagsExpression = friendlyAttribute.ArgumentList.Arguments.First().Expression
                    let friendlyFlags = (FriendlyFlags)(int)semanticModel.GetConstantValue(friendlyFlagsExpression).Value
                    select new
                    {
                        Parameter = parameter,
                        Flags = friendlyFlags
                    };
                var parametersToFriendlyTransform = refOrArrayAttributedParameters.ToDictionary(p => p.Parameter, p => p.Flags);

                // Consider undecorated byte* parameters to have a Friendly attribute by default.
                var byteArrayInParameters = nativePointerParameters.Where(IsByteStarInParameter);
                foreach (var p in byteArrayInParameters)
                {
                    if (!parametersToFriendlyTransform.ContainsKey(p))
                    {
                        parametersToFriendlyTransform[p] = FriendlyFlags.Array | FriendlyFlags.Bidirectional;
                    }
                }

                var transformedMethodBase = method
                    .WithReturnType(TransformReturnType(method.ReturnType))
                    .WithIdentifier(TransformMethodName(method))
                    .WithModifiers(RemoveModifier(method.Modifiers, SyntaxKind.ExternKeyword))
                    .WithAttributeLists(FilterAttributes(method.AttributeLists))
                    .WithLeadingTrivia(method.GetLeadingTrivia().Where(t => !t.IsDirective))
                    .WithTrailingTrivia(method.GetTrailingTrivia().Where(t => !t.IsDirective))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
                    .WithExpressionBody(null);

                var flags = GeneratorFlags.NativePointerToIntPtr;
                var intPtrOverload = transformedMethodBase
                    .WithParameterList(TransformParameterList(method.ParameterList, flags, parametersToFriendlyTransform))
                    .WithBody(CallNativePointerOverload(method, flags, parametersToFriendlyTransform));
                generatedType = generatedType.AddMembers(intPtrOverload);

                if (parametersToFriendlyTransform.Count > 0)
                {
                    flags = GeneratorFlags.NativePointerToIntPtr | GeneratorFlags.NativePointerToFriendly;
                    var byteArrayAndIntPtrOverload = transformedMethodBase
                        .WithParameterList(TransformParameterList(method.ParameterList, flags, parametersToFriendlyTransform))
                        .WithBody(CallNativePointerOverload(method, flags, parametersToFriendlyTransform));
                    generatedType = generatedType.AddMembers(byteArrayAndIntPtrOverload);

                    // If there are native pointers that aren't "friendly", it would produce a unique method signature
                    // for a method that only converts the friendly parameters and leaves other native pointers alone.
                    if (nativePointerParameters.Except(parametersToFriendlyTransform.Keys).Any())
                    {
                        flags = GeneratorFlags.NativePointerToFriendly;
                        var friendlyOverload = transformedMethodBase
                            .WithParameterList(TransformParameterList(method.ParameterList, flags, parametersToFriendlyTransform))
                            .WithBody(CallNativePointerOverload(method, flags, parametersToFriendlyTransform));
                        generatedType = generatedType.AddMembers(friendlyOverload);
                    }
                }
            }

            return SyntaxFactory.SingletonList<MemberDeclarationSyntax>(generatedType);
        }

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

        private static ParameterListSyntax TransformParameterList(ParameterListSyntax list, GeneratorFlags generatorFlags, IReadOnlyDictionary<ParameterSyntax, FriendlyFlags> parametersToFriendlyTransform)
        {
            var resultingList = list.ReplaceNodes(
                WhereIsPointerParameter(list.Parameters),
                (n1, n2) =>
                {
                    // Remove all attributes
                    n2 = n2.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());

                    FriendlyFlags friendlyFlags;
                    if (generatorFlags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.TryGetValue(n1, out friendlyFlags))
                    {
                        var pointerType = (PointerTypeSyntax)n2.Type;
                        var alteredParameter = n2.WithDefault(null);
                        if (friendlyFlags.HasFlag(FriendlyFlags.Array))
                        {
                            alteredParameter = alteredParameter
                                .WithType(SyntaxFactory.ArrayType(pointerType.ElementType, OneDimensionalUnspecifiedLengthArray));
                        }
                        else
                        {
                            if (friendlyFlags.HasFlag(FriendlyFlags.Optional))
                            {
                                alteredParameter = alteredParameter
                                    .WithType(SyntaxFactory.NullableType(pointerType.ElementType));
                            }

                            if (friendlyFlags.HasFlag(FriendlyFlags.Out))
                            {
                                SyntaxKind modifier = friendlyFlags.HasFlag(FriendlyFlags.Optional) || friendlyFlags.HasFlag(FriendlyFlags.In)
                                     ? SyntaxKind.RefKeyword
                                     : SyntaxKind.OutKeyword;
                                if (!friendlyFlags.HasFlag(FriendlyFlags.Optional))
                                {
                                    alteredParameter = alteredParameter
                                        .WithType(pointerType.ElementType);
                                }

                                alteredParameter = alteredParameter
                                    .AddModifiers(SyntaxFactory.Token(modifier));
                            }
                            else if (!friendlyFlags.HasFlag(FriendlyFlags.Optional))
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

        private static BlockSyntax CallNativePointerOverload(MethodDeclarationSyntax nativePointerOverload, GeneratorFlags flags, IReadOnlyDictionary<ParameterSyntax, FriendlyFlags> parametersToFriendlyTransform)
        {
            Func<ParameterSyntax, IdentifierNameSyntax> getLocalSubstituteName = p => SyntaxFactory.IdentifierName(p.Identifier.ValueText + "Local");
            var invocationArguments = new Dictionary<ParameterSyntax, ArgumentSyntax>();
            foreach (var p in nativePointerOverload.ParameterList.Parameters)
            {
                var refOrOut = p.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.RefKeyword) || m.IsKind(SyntaxKind.OutKeyword));
                invocationArguments[p] = SyntaxFactory
                    .Argument(SyntaxFactory.IdentifierName(p.Identifier))
                    .WithRefOrOutKeyword(refOrOut);
            }

            var prelude = new List<StatementSyntax>();
            var postlude = new List<StatementSyntax>();
            var fixedStatements = new List<FixedStatementSyntax>();

            foreach (var parameter in nativePointerOverload.ParameterList.Parameters.Where(p => p.Type is PointerTypeSyntax))
            {
                var parameterName = SyntaxFactory.IdentifierName(parameter.Identifier);
                var localVarName = getLocalSubstituteName(parameter);
                FriendlyFlags friendlyFlags;
                if (flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.TryGetValue(parameter, out friendlyFlags))
                {
                    if (friendlyFlags.HasFlag(FriendlyFlags.Array))
                    {
                        var fixedArrayDecl = SyntaxFactory.VariableDeclarator(localVarName.Identifier)
                            .WithInitializer(SyntaxFactory.EqualsValueClause(parameterName));
                        fixedStatements.Add(SyntaxFactory.FixedStatement(
                            SyntaxFactory.VariableDeclaration(parameter.Type).AddVariables(fixedArrayDecl),
                            SyntaxFactory.Block()));

                        invocationArguments[parameter] = invocationArguments[parameter].WithExpression(localVarName);
                    }
                    else
                    {
                        if (friendlyFlags.HasFlag(FriendlyFlags.Optional))
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

                            if (friendlyFlags.HasFlag(FriendlyFlags.Out))
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
                        else if (friendlyFlags.HasFlag(FriendlyFlags.Out))
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
                    if (parameter.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword)))
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
                    else
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

            if (fixedStatements.Count > 0)
            {
                StatementSyntax outermost = block;
                foreach (var statement in fixedStatements)
                {
                    outermost = statement.WithStatement(outermost);
                }

                block = SyntaxFactory.Block(outermost);
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
