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

        [Flags]
        private enum ParameterOptions
        {
            /// <summary>
            /// For native pointers, assume the pointer is to the first element in an array.
            /// </summary>
            IsArray = 0x1,

            /// <summary>
            /// Consider that data is passed to the receiving function via this parameter.
            /// </summary>
            IsIn = 0x2,

            /// <summary>
            /// Consider that data is returned from the receiving function via this parameter.
            /// </summary>
            IsOut = 0x4,

            /// <summary>
            /// Consider that data is passed and returned to and from the receiving function via this parameter.
            /// </summary>
            IsBidirectional = IsIn | IsOut,

            ShouldBeRef = IsBidirectional,
            ShouldBeArray = IsArray,
            ShouldBeNullable = IsIn,
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
                    let isArrayAttribute = attributes.FirstOrDefault(attribute => (attribute.Name as SimpleNameSyntax)?.Identifier.ValueText == "IsArray")
                    where isArrayAttribute != null
                    let inAttribute = attributes.FirstOrDefault(attribute => (attribute.Name as SimpleNameSyntax)?.Identifier.ValueText == "In")
                    let isArrayArg = isArrayAttribute.ArgumentList.Arguments.FirstOrDefault()?.Expression
                    let isArray = isArrayArg != null ? semanticModel.GetConstantValue(isArrayArg) : true
                    select new
                    {
                        Parameter = parameter,
                        Options = (isArray.HasValue ? ((bool)isArray.Value ? ParameterOptions.IsArray : 0) : ParameterOptions.IsArray)
                                | (inAttribute != null ? ParameterOptions.IsIn : ParameterOptions.IsBidirectional)
                    };
                var byteArrayInParameters = nativePointerParameters.Where(IsByteStarInParameter);
                var parametersToFriendlyTransform = refOrArrayAttributedParameters.ToDictionary(p => p.Parameter, p => p.Options);
                foreach (var p in byteArrayInParameters)
                {
                    if (!parametersToFriendlyTransform.ContainsKey(p))
                    {
                        parametersToFriendlyTransform[p] = ParameterOptions.IsArray;
                    }
                }

                var transformedMethodBase = method
                    .WithReturnType(TransformReturnType(method.ReturnType))
                    .WithIdentifier(TransformMethodName(method))
                    .WithModifiers(RemoveModifier(method.Modifiers, SyntaxKind.ExternKeyword))
                    .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>())
                    .WithLeadingTrivia(method.GetLeadingTrivia().Where(t => !t.IsDirective))
                    .WithTrailingTrivia(method.GetTrailingTrivia().Where(t => !t.IsDirective))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));

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

        private static ParameterListSyntax TransformParameterList(ParameterListSyntax list, GeneratorFlags flags, IReadOnlyDictionary<ParameterSyntax, ParameterOptions> parametersToFriendlyTransform)
        {
            var resultingList = list.ReplaceNodes(
                WhereIsPointerParameter(list.Parameters),
                (n1, n2) =>
                {
                    bool changeToArray = flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(n1) && parametersToFriendlyTransform[n1] == ParameterOptions.ShouldBeArray;
                    bool changeToNullable = flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(n1) && parametersToFriendlyTransform[n1] == ParameterOptions.ShouldBeNullable;
                    bool changeToRef = flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(n1) && parametersToFriendlyTransform[n1] == ParameterOptions.ShouldBeRef;
                    bool changeToIntPtr = flags.HasFlag(GeneratorFlags.NativePointerToIntPtr);
                    return changeToArray ? TransformParameterDefaultValue(ConvertPointerToArrayParameter(n2))
                        : changeToRef ? TransformParameterDefaultValue(ConvertPointerToRefParameter(n2))
                        : changeToNullable ? TransformParameterDefaultValue(ConvertPointerToNullableParameter(n2))
                        : changeToIntPtr ? TransformParameterDefaultValue(n2.WithType(IntPtrTypeSyntax))
                        : n2;
                });
            return resultingList;
        }

        private static ParameterSyntax ConvertPointerToArrayParameter(ParameterSyntax parameter)
        {
            var pointerType = (PointerTypeSyntax)parameter.Type;
            return parameter
                .WithType(SyntaxFactory.ArrayType(pointerType.ElementType, OneDimensionalUnspecifiedLengthArray));
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

        private static ParameterSyntax TransformParameterDefaultValue(ParameterSyntax parameter)
        {
            // Just neutralize the default parameter since null can't be assigned to IntPtr,
            // and to avoid method overload ambiguities when parameters are omitted.
            return parameter.WithDefault(null);

            // We could translate the null to default(IntPtr) like this:
            ////return parameter.Default?.Value.Kind() == SyntaxKind.NullLiteralExpression
            ////    ? parameter.WithDefault(SyntaxFactory.EqualsValueClause(SyntaxFactory.DefaultExpression(IntPtrTypeSyntax)))
            ////    : parameter;
        }

        private static SyntaxTokenList RemoveModifier(SyntaxTokenList list, params SyntaxKind[] modifiers)
        {
            return SyntaxFactory.TokenList(list.Where(t => Array.IndexOf(modifiers, t.Kind()) < 0));
        }

        private static BlockSyntax CallNativePointerOverload(MethodDeclarationSyntax nativePointerOverload, GeneratorFlags flags, IReadOnlyDictionary<ParameterSyntax, ParameterOptions> parametersToFriendlyTransform)
        {
            var arrayTransformParameters =
                (from p in nativePointerOverload.ParameterList.Parameters
                 where flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(p) && parametersToFriendlyTransform[p] == ParameterOptions.ShouldBeArray
                 select p).ToList();
            var refTransformParameters =
                (from p in nativePointerOverload.ParameterList.Parameters
                 where flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(p) && parametersToFriendlyTransform[p] == ParameterOptions.ShouldBeRef
                 select p).ToList();
            var nullableTransformParameters =
                (from p in nativePointerOverload.ParameterList.Parameters
                 where flags.HasFlag(GeneratorFlags.NativePointerToFriendly) && parametersToFriendlyTransform.ContainsKey(p) && parametersToFriendlyTransform[p] == ParameterOptions.ShouldBeNullable
                 select p).ToList();
            var parametersRequiringCasts =
                from p in nativePointerOverload.ParameterList.Parameters
                where flags.HasFlag(GeneratorFlags.NativePointerToIntPtr)
                where p.Type is PointerTypeSyntax && (p.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword) || m.IsKind(SyntaxKind.RefKeyword)) || !p.Type.Equals(VoidStar))
                where !arrayTransformParameters.Contains(p) && !refTransformParameters.Contains(p) && !nullableTransformParameters.Contains(p)
                group p by p.Type into paramsByType
                select paramsByType;

            var redirectedParameters = new Dictionary<ParameterSyntax, IdentifierNameSyntax>();
            var invocationArguments = new Dictionary<ParameterSyntax, ExpressionSyntax>();

            var block = SyntaxFactory.Block();

            foreach (var arrayPointerParam in arrayTransformParameters)
            {
                redirectedParameters.Add(arrayPointerParam, SyntaxFactory.IdentifierName("p" + arrayPointerParam.Identifier.ValueText));
            }

            foreach (var refPointerParam in refTransformParameters)
            {
                redirectedParameters.Add(refPointerParam, SyntaxFactory.IdentifierName("p" + refPointerParam.Identifier.ValueText));
            }

            foreach (var nullableParam in nullableTransformParameters)
            {
                redirectedParameters.Add(nullableParam, SyntaxFactory.IdentifierName(nullableParam.Identifier.ValueText + "Local"));
            }

            foreach (var pType in parametersRequiringCasts)
            {
                var varStatement = SyntaxFactory.VariableDeclaration(pType.Key);
                foreach (var p in pType)
                {
                    var identifierName = SyntaxFactory.IdentifierName(p.Identifier.ValueText + "Local");
                    var declarator = SyntaxFactory.VariableDeclarator(identifierName.Identifier);
                    redirectedParameters.Add(p, identifierName);
                    if (!p.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword)))
                    {
                        var voidStarPointer = SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName(p.Identifier),
                                SyntaxFactory.IdentifierName(nameof(IntPtr.ToPointer))),
                            SyntaxFactory.ArgumentList());
                        var typedPointer = p.Type.Equals(VoidStar)
                            ? (ExpressionSyntax)voidStarPointer
                            : SyntaxFactory.CastExpression(p.Type, voidStarPointer);

                        declarator = declarator.WithInitializer(SyntaxFactory.EqualsValueClause(typedPointer));
                    }

                    varStatement = varStatement.AddVariables(declarator);
                    block = block.AddStatements(SyntaxFactory.LocalDeclarationStatement(varStatement));
                }
            }

            foreach (var parameter in nullableTransformParameters)
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
                    SyntaxFactory.VariableDeclarator(redirectedParameters[parameter].Identifier)
                        .WithInitializer(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.ConditionalExpression(
                                hasValueExpression,
                                valueExpression,
                                defaultExpression))));
                block = block.AddStatements(SyntaxFactory.LocalDeclarationStatement(varStatement));

                var argument = SyntaxFactory.ConditionalExpression(
                    hasValueExpression,
                    SyntaxFactory.PrefixUnaryExpression(SyntaxKind.AddressOfExpression, redirectedParameters[parameter]),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));
                invocationArguments.Add(parameter, argument);
            }

            foreach (var p in nativePointerOverload.ParameterList.Parameters)
            {
                if (!redirectedParameters.ContainsKey(p))
                {
                    redirectedParameters.Add(p, SyntaxFactory.IdentifierName(p.Identifier));
                }
            }

            var invocationExpression = SyntaxFactory.InvocationExpression(
                SyntaxFactory.IdentifierName(nativePointerOverload.Identifier.ValueText),
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(
                        from p in nativePointerOverload.ParameterList.Parameters
                        let refOrOut = p.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.RefKeyword) || m.IsKind(SyntaxKind.OutKeyword))
                        let argumentExpression = GetValueOrDefault(invocationArguments, p, redirectedParameters[p])
                        select SyntaxFactory.Argument(argumentExpression).WithRefOrOutKeyword(refOrOut))));

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

            block = block.AddStatements(invocationStatement);

            foreach (var p in parametersRequiringCasts.SelectMany(g => g))
            {
                if (p.Modifiers.Any(m => m.IsKind(SyntaxKind.RefKeyword) || m.IsKind(SyntaxKind.OutKeyword)))
                {
                    var assignment = SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName(p.Identifier),
                        SyntaxFactory.ObjectCreationExpression(
                            IntPtrTypeSyntax,
                            SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(redirectedParameters[p]))),
                            null));
                    block = block.AddStatements(SyntaxFactory.ExpressionStatement(assignment));
                }
            }

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

            if (arrayTransformParameters.Any())
            {
                StatementSyntax outermost = block;
                foreach (var p in arrayTransformParameters)
                {
                    var nameOfPointerLocal = redirectedParameters[p].Identifier;
                    var nameOfArrayParameter = SyntaxFactory.IdentifierName(p.Identifier);
                    var fixedArrayDecl = SyntaxFactory.VariableDeclarator(nameOfPointerLocal)
                        .WithInitializer(SyntaxFactory.EqualsValueClause(nameOfArrayParameter));
                    outermost = SyntaxFactory.FixedStatement(
                        SyntaxFactory.VariableDeclaration(p.Type).AddVariables(fixedArrayDecl),
                        outermost);
                }

                block = SyntaxFactory.Block(outermost);
            }

            if (refTransformParameters.Any())
            {
                StatementSyntax outermost = block;
                foreach (var p in refTransformParameters)
                {
                    var nameOfPointerLocal = redirectedParameters[p].Identifier;
                    var nameOfRefParameter = SyntaxFactory.IdentifierName(p.Identifier);
                    var fixedArrayDecl = SyntaxFactory.VariableDeclarator(nameOfPointerLocal)
                        .WithInitializer(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.PrefixUnaryExpression(
                                SyntaxKind.AddressOfExpression,
                                nameOfRefParameter)));
                    outermost = SyntaxFactory.FixedStatement(
                        SyntaxFactory.VariableDeclaration(p.Type).AddVariables(fixedArrayDecl),
                        outermost);
                }

                block = SyntaxFactory.Block(outermost);
            }

            return block;
        }

        private static TValue GetValueOrDefault<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue entry;
            return dictionary.TryGetValue(key, out entry) ? entry : defaultValue;
        }
    }
}
