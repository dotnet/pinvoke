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
    /// Generates an <see cref="IntPtr"/> overload of a method that accepts native pointers.
    /// </summary>
    public class OfferIntPtrOverloadGenerator : ICodeGenerator
    {
        private static readonly TypeSyntax VoidStar = SyntaxFactory.ParseTypeName("void*");

        private static readonly TypeSyntax IntPtrTypeSyntax = SyntaxFactory.ParseTypeName("System.IntPtr");

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferIntPtrOverloadGenerator"/> class.
        /// </summary>
        /// <param name="data">Generator attribute data.</param>
        public OfferIntPtrOverloadGenerator(AttributeData data)
        {
        }

        /// <inheritdoc />
        public Task<IReadOnlyList<MemberDeclarationSyntax>> GenerateAsync(MemberDeclarationSyntax applyTo, Document document, IProgressAndErrors progress, CancellationToken cancellationToken)
        {
            var type = (ClassDeclarationSyntax)applyTo;
            var result = new List<MemberDeclarationSyntax>();
            var generatedType = type
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>());
            var methodsWithNativePointers =
                from method in type.Members.OfType<MethodDeclarationSyntax>()
                where WhereIsPointerParameter(method.ParameterList.Parameters).Any()
                select method;

            foreach (var method in methodsWithNativePointers)
            {
                var intPtrOverload = method
                    .WithParameterList(TransformParameterList(method.ParameterList))
                    .WithModifiers(RemoveModifier(method.Modifiers, SyntaxKind.ExternKeyword))
                    .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>())
                    .WithLeadingTrivia(method.GetLeadingTrivia())
                    .WithBody(CallNativePointerOverload(method))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));
                generatedType = generatedType.AddMembers(intPtrOverload);
            }

            result.Add(generatedType);
            return Task.FromResult<IReadOnlyList<MemberDeclarationSyntax>>(result);
        }

        private static IEnumerable<ParameterSyntax> WhereIsPointerParameter(IEnumerable<ParameterSyntax> parameters)
        {
            return from p in parameters
                   where p.Type is PointerTypeSyntax
                   select p;
        }

        private static ParameterListSyntax TransformParameterList(ParameterListSyntax list)
        {
            var resultingList = list.ReplaceNodes(
                WhereIsPointerParameter(list.Parameters),
                (n1, n2) => n2.WithType(IntPtrTypeSyntax));
            return resultingList;
        }

        private static SyntaxTokenList RemoveModifier(SyntaxTokenList list, params SyntaxKind[] modifiers)
        {
            return SyntaxFactory.TokenList(list.Where(t => Array.IndexOf(modifiers, t.Kind()) < 0));
        }

        private static ArgumentSyntax IntPtrOverloadParameterToArgument(ParameterSyntax p)
        {
            var refOrOut = p.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.RefKeyword) || m.IsKind(SyntaxKind.OutKeyword));
            ExpressionSyntax argRef = SyntaxFactory.IdentifierName(p.Identifier);
            if (p.Type is PointerTypeSyntax)
            {
                argRef =
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            argRef,
                            SyntaxFactory.IdentifierName(nameof(IntPtr.ToPointer))),
                        SyntaxFactory.ArgumentList());
                if (!p.Type.WithoutTrivia().IsEquivalentTo(VoidStar))
                {
                    argRef = SyntaxFactory.CastExpression(p.Type, argRef);
                }
            }

            return SyntaxFactory.Argument(argRef)
                .WithRefOrOutKeyword(refOrOut);
        }

        private static BlockSyntax CallNativePointerOverload(MethodDeclarationSyntax nativePointerOverload)
        {
            var invocationExpression = SyntaxFactory.InvocationExpression(
                SyntaxFactory.IdentifierName(nativePointerOverload.Identifier.ValueText),
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(
                        from p in nativePointerOverload.ParameterList.Parameters
                        select IntPtrOverloadParameterToArgument(p))));

            StatementSyntax statement;
            if (nativePointerOverload.ReturnType != null)
            {
                statement = SyntaxFactory.ReturnStatement(invocationExpression);
            }
            else
            {
                statement = SyntaxFactory.ExpressionStatement(invocationExpression);
            }

            return SyntaxFactory.Block(statement);
        }
    }
}
