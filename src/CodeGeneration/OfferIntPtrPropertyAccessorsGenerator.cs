// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

/// <summary>
/// Generates property accessors that expose native pointer fields
/// as <see cref="IntPtr"/> properties.
/// </summary>
internal class OfferIntPtrPropertyAccessorsGenerator : IGenerator
{
    private static readonly TypeSyntax VoidStar = ParseTypeName("void*");

    private static readonly TypeSyntax IntPtrTypeSyntax = ParseTypeName("System.IntPtr");

    /// <summary>
    /// Initializes a new instance of the <see cref="OfferIntPtrPropertyAccessorsGenerator"/> class.
    /// </summary>
    public OfferIntPtrPropertyAccessorsGenerator()
    {
    }

    public SyntaxList<MemberDeclarationSyntax> Generate(TransformationContext context, CancellationToken cancellationToken)
    {
        TypeDeclarationSyntax? applyTo = context.ProcessingNode;
        Compilation? compilation = context.Compilation;
        var applyToStruct = applyTo as StructDeclarationSyntax;
        var applyToClass = applyTo as ClassDeclarationSyntax;

        SyntaxList<MemberDeclarationSyntax> generatedMembers = List<MemberDeclarationSyntax>();
        System.Collections.Generic.IEnumerable<FieldDeclarationSyntax>? nativePointerFields = from field in applyTo.Members.OfType<FieldDeclarationSyntax>()
                                  where field.Declaration.Type is PointerTypeSyntax && field.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword))
                                  select field;
        foreach (FieldDeclarationSyntax? field in nativePointerFields)
        {
            foreach (VariableDeclaratorSyntax? variable in field.Declaration.Variables)
            {
                generatedMembers = generatedMembers.Add(
                PropertyDeclaration(IntPtrTypeSyntax, variable.Identifier.ValueText + "_IntPtr")
                    .WithModifiers(field.Modifiers)
                    //// get { return new IntPtr(this.field); }
                    //// set { this.field = (byte*)value.ToPointer(); }
                    .AddAccessorListAccessors(
                        AccessorDeclaration(
                            SyntaxKind.GetAccessorDeclaration,
                            Block(
                                ReturnStatement(
                                    ObjectCreationExpression(IntPtrTypeSyntax)
                                        .AddArgumentListArguments(Argument(ThisDot(variable.Identifier)))))),
                        AccessorDeclaration(
                            SyntaxKind.SetAccessorDeclaration,
                            Block(
                                ExpressionStatement(
                                    AssignmentExpression(
                                        SyntaxKind.SimpleAssignmentExpression,
                                        ThisDot(variable.Identifier),
                                        TypedAs(
                                            InvocationExpression(
                                                MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    IdentifierName("value"),
                                                    IdentifierName(nameof(IntPtr.ToPointer))),
                                                ArgumentList()),
                                            field.Declaration.Type)))))));
            }
        }

        TypeDeclarationSyntax? generatedType = (TypeDeclarationSyntax?)applyToStruct?.WithMembers(generatedMembers)
                .WithAttributeLists(List<AttributeListSyntax>())
            ?? applyToClass?.WithMembers(generatedMembers)
                .WithAttributeLists(List<AttributeListSyntax>());
        return generatedType is not null ? SingletonList<MemberDeclarationSyntax>(generatedType) : List<MemberDeclarationSyntax>();
    }

    private static MemberAccessExpressionSyntax ThisDot(SyntaxToken memberName)
    {
        return ThisDot(IdentifierName(memberName.ValueText));
    }

    private static MemberAccessExpressionSyntax ThisDot(SimpleNameSyntax memberName)
    {
        return MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            ThisExpression(),
            memberName);
    }

    private static ExpressionSyntax TypedAs(ExpressionSyntax expression, TypeSyntax requiredType)
    {
        return VoidStar.Equals(requiredType)
            ? expression
            : CastExpression(requiredType, expression);
    }
}
