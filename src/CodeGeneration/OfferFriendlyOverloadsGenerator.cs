// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
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
            NativeBytePointerToByteArray = 0x2,
        }

        /// <inheritdoc />
        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(MemberDeclarationSyntax applyTo, Document document, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            var type = (ClassDeclarationSyntax)applyTo;
            var generatedType = type
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>());
            var methodsWithNativePointers =
                from method in type.Members.OfType<MethodDeclarationSyntax>()
                where WhereIsPointerParameter(method.ParameterList.Parameters).Any() || method.ReturnType is PointerTypeSyntax
                select method;

            foreach (var method in methodsWithNativePointers)
            {
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
                    .WithParameterList(TransformParameterList(method.ParameterList, flags))
                    .WithBody(CallNativePointerOverload(method, flags));
                generatedType = generatedType.AddMembers(intPtrOverload);

                var nativePointerParameters = method.ParameterList.Parameters.Where(p => p.Type is PointerTypeSyntax);
                var byteArrayInParameters = nativePointerParameters.Where(IsByteStarInParameter);
                if (byteArrayInParameters.Any())
                {
                    flags = GeneratorFlags.NativePointerToIntPtr | GeneratorFlags.NativeBytePointerToByteArray;
                    var byteArrayAndIntPtrOverload = transformedMethodBase
                        .WithParameterList(TransformParameterList(method.ParameterList, flags))
                        .WithBody(CallNativePointerOverload(method, flags));
                    generatedType = generatedType.AddMembers(byteArrayAndIntPtrOverload);

                    // If there are native pointers that aren't byte*, it would produce a unique method signature
                    // for a method that only converts the byte* parameters and leaves other native pointers alone.
                    if (nativePointerParameters.Except(byteArrayInParameters).Any())
                    {
                        flags = GeneratorFlags.NativeBytePointerToByteArray;
                        var byteArrayOverload = transformedMethodBase
                            .WithParameterList(TransformParameterList(method.ParameterList, flags))
                            .WithBody(CallNativePointerOverload(method, flags));
                        generatedType = generatedType.AddMembers(byteArrayOverload);
                    }
                }
            }

            return Task.FromResult(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(generatedType));
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

        private static ParameterListSyntax TransformParameterList(ParameterListSyntax list, GeneratorFlags flags)
        {
            var resultingList = list.ReplaceNodes(
                WhereIsPointerParameter(list.Parameters),
                (n1, n2) =>
                {
                    bool changeToByteArray = flags.HasFlag(GeneratorFlags.NativeBytePointerToByteArray) && IsByteStarInParameter(n2);
                    bool changeToIntPtr = flags.HasFlag(GeneratorFlags.NativePointerToIntPtr);
                    return changeToByteArray ? TransformParameterDefaultValue(n2.WithType(ByteArray))
                        : changeToIntPtr ? TransformParameterDefaultValue(n2.WithType(IntPtrTypeSyntax))
                        : n2;
                });
            return resultingList;
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

        private static BlockSyntax CallNativePointerOverload(MethodDeclarationSyntax nativePointerOverload, GeneratorFlags flags)
        {
            var byteArrayTransformParameters =
                (from p in nativePointerOverload.ParameterList.Parameters
                 where flags.HasFlag(GeneratorFlags.NativeBytePointerToByteArray) && IsByteStarInParameter(p)
                 select p).ToList();
            var parametersRequiringCasts =
                from p in nativePointerOverload.ParameterList.Parameters
                where flags.HasFlag(GeneratorFlags.NativePointerToIntPtr)
                where p.Type is PointerTypeSyntax && (p.Modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword) || m.IsKind(SyntaxKind.RefKeyword)) || !p.Type.Equals(VoidStar))
                where !byteArrayTransformParameters.Contains(p)
                group p by p.Type into paramsByType
                select paramsByType;

            var redirectedParameters = new Dictionary<ParameterSyntax, IdentifierNameSyntax>();

            var block = SyntaxFactory.Block();

            foreach (var byteStarParam in byteArrayTransformParameters)
            {
                redirectedParameters.Add(byteStarParam, SyntaxFactory.IdentifierName("p" + byteStarParam.Identifier.ValueText));
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
                        select SyntaxFactory.Argument(redirectedParameters[p]).WithRefOrOutKeyword(refOrOut))));

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

            if (byteArrayTransformParameters.Any())
            {
                StatementSyntax outermost = block;
                foreach (var p in byteArrayTransformParameters)
                {
                    var nameOfPointerLocal = redirectedParameters[p].Identifier;
                    var nameOfArrayParameter = SyntaxFactory.IdentifierName(p.Identifier);
                    var fixedArrayDecl = SyntaxFactory.VariableDeclarator(nameOfPointerLocal)
                        .WithInitializer(SyntaxFactory.EqualsValueClause(nameOfArrayParameter));
                    outermost = SyntaxFactory.FixedStatement(
                        SyntaxFactory.VariableDeclaration(ByteStar).AddVariables(fixedArrayDecl),
                        outermost);
                }

                block = SyntaxFactory.Block(outermost);
            }

            return block;
        }
    }
}
