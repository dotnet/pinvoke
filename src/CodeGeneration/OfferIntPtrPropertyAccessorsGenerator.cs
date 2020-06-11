// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
    /// Generates property accessors that expose native pointer fields
    /// as <see cref="IntPtr"/> properties.
    /// </summary>
    public class OfferIntPtrPropertyAccessorsGenerator : ICodeGenerator
    {
        private static readonly TypeSyntax VoidStar = SyntaxFactory.ParseTypeName("void*");

        private static readonly TypeSyntax IntPtrTypeSyntax = SyntaxFactory.ParseTypeName("System.IntPtr");

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferIntPtrPropertyAccessorsGenerator"/> class.
        /// </summary>
        /// <param name="data">Generator attribute data.</param>
        public OfferIntPtrPropertyAccessorsGenerator(AttributeData data)
        {
        }

        /// <inheritdoc />
        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(TransformationContext context, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            var applyTo = context.ProcessingNode;
            var compilation = context.Compilation;
            var applyToStruct = applyTo as StructDeclarationSyntax;
            var applyToClass = applyTo as ClassDeclarationSyntax;
            var applyToType = applyTo as TypeDeclarationSyntax;

            var generatedMembers = SyntaxFactory.List<MemberDeclarationSyntax>();
            var nativePointerFields = from field in applyToType.Members.OfType<FieldDeclarationSyntax>()
                                      where field.Declaration.Type is PointerTypeSyntax && field.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword))
                                      select field;
            foreach (var field in nativePointerFields)
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    generatedMembers = generatedMembers.Add(
                    SyntaxFactory.PropertyDeclaration(IntPtrTypeSyntax, variable.Identifier.ValueText + "_IntPtr")
                        .WithModifiers(field.Modifiers)
                        //// get { return new IntPtr(this.field); }
                        //// set { this.field = (byte*)value.ToPointer(); }
                        .AddAccessorListAccessors(
                            SyntaxFactory.AccessorDeclaration(
                                SyntaxKind.GetAccessorDeclaration,
                                SyntaxFactory.Block(
                                    SyntaxFactory.ReturnStatement(
                                        SyntaxFactory.ObjectCreationExpression(IntPtrTypeSyntax)
                                            .AddArgumentListArguments(SyntaxFactory.Argument(ThisDot(variable.Identifier)))))),
                            SyntaxFactory.AccessorDeclaration(
                                SyntaxKind.SetAccessorDeclaration,
                                SyntaxFactory.Block(
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            ThisDot(variable.Identifier),
                                            TypedAs(
                                                SyntaxFactory.InvocationExpression(
                                                    SyntaxFactory.MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        SyntaxFactory.IdentifierName("value"),
                                                        SyntaxFactory.IdentifierName(nameof(IntPtr.ToPointer))),
                                                    SyntaxFactory.ArgumentList()),
                                                field.Declaration.Type)))))));
                }
            }

            var generatedType = (TypeDeclarationSyntax)applyToStruct?.WithMembers(generatedMembers)
                    .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>())
                ?? applyToClass?.WithMembers(generatedMembers)
                    .WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());
            return Task.FromResult(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(generatedType));
        }

        private static MemberAccessExpressionSyntax ThisDot(SyntaxToken memberName)
        {
            return ThisDot(SyntaxFactory.IdentifierName(memberName.ValueText));
        }

        private static MemberAccessExpressionSyntax ThisDot(SimpleNameSyntax memberName)
        {
            return SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.ThisExpression(),
                memberName);
        }

        private static ExpressionSyntax TypedAs(ExpressionSyntax expression, TypeSyntax requiredType)
        {
            return VoidStar.Equals(requiredType)
                ? expression
                : SyntaxFactory.CastExpression(requiredType, expression);
        }
    }
}
