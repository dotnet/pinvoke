using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    using System.Diagnostics;
    using System.IO;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    class Program
    {
        static readonly SyntaxTrivia WhitespaceCharacter = SyntaxFactory.Whitespace(" ");
        static readonly SyntaxTrivia TabCharacter = SyntaxFactory.Whitespace("\t");
        static readonly SyntaxTrivia NewLineCharacter = SyntaxFactory.Whitespace("\n");

        static void Main(string[] args)
        {
            var currentDirectory = Environment.CurrentDirectory;

            var solutionRoot = Path.Combine(currentDirectory, "..", "..", "..");
            foreach (var file in Directory.GetFiles(solutionRoot, "*.cs", SearchOption.AllDirectories))
            {
                ProcessSourceCodes(file);
            }
        }

        private static void ProcessSourceCodes(string file)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));

            var compilationUnit = syntaxTree.GetRoot() as CompilationUnitSyntax;
            if (compilationUnit == null || compilationUnit.Members.Count == 0) return;

            var namespaceDeclarations = compilationUnit.Members.OfType<NamespaceDeclarationSyntax>();
            foreach (var classNamespaceDeclaration in namespaceDeclarations)
            {
                if (classNamespaceDeclaration == null || classNamespaceDeclaration.Name.ToString() != "PInvoke") return;

                var classDeclarations = classNamespaceDeclaration.Members
                    .OfType<ClassDeclarationSyntax>()
                    .ToArray();
                for (var index = 0; index < classDeclarations.Length; index++)
                {
                    var classDeclaration = classDeclarations[index];
                    var newClassDeclaration = classDeclaration;
                    var previousClassMemberCount = newClassDeclaration.Members.Count;

                    var modifiers = newClassDeclaration.Modifiers;
                    var staticKeyword = modifiers.SingleOrDefault(x => x.IsKind(SyntaxKind.StaticKeyword));
                    if (staticKeyword != default(SyntaxToken))
                    {
                        modifiers = modifiers.Remove(staticKeyword);
                    }

                    var interfaceIdentifier = SyntaxFactory.IdentifierName($"I{newClassDeclaration.Identifier.Text}Mockable");

                    var baseList = newClassDeclaration.BaseList ?? SyntaxFactory.BaseList();
                    baseList = baseList.AddTypes(
                        SyntaxFactory.SimpleBaseType(
                            interfaceIdentifier
                                .WithLeadingTrivia(WhitespaceCharacter)
                                .WithTrailingTrivia(WhitespaceCharacter)));
                    
                    var interfaceNamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(
                        classNamespaceDeclaration.NamespaceKeyword,
                        classNamespaceDeclaration.Name,
                        classNamespaceDeclaration.OpenBraceToken,
                        classNamespaceDeclaration.Externs,
                        classNamespaceDeclaration.Usings,
                        SyntaxFactory.List<MemberDeclarationSyntax>(),
                        classNamespaceDeclaration.CloseBraceToken,
                        classNamespaceDeclaration.SemicolonToken);

                    var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(
                            SyntaxFactory
                                .Token(SyntaxKind.PublicKeyword)
                                .WithTrailingTrivia(WhitespaceCharacter)),
                        interfaceIdentifier
                            .Identifier
                            .WithTrailingTrivia(WhitespaceCharacter)
                            .WithLeadingTrivia(WhitespaceCharacter),
                        null,
                        null,
                        SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
                        SyntaxFactory.List<MemberDeclarationSyntax>());

                    var methodDeclarations = newClassDeclaration.Members
                        .OfType<MethodDeclarationSyntax>()
                        .ToArray();
                    for (int i = 0; i < methodDeclarations.Length; i++)
                    {
                        var methodDeclaration = methodDeclarations[i];

                        if (IsPublicStaticExternMethod(methodDeclaration))
                        {
                            continue;
                        }

                        var invokeMethodIdentifier =
                            SyntaxFactory.IdentifierName($"Invoke{methodDeclaration.Identifier.Text}");

                        newClassDeclaration = DecorateClassWithWrapperFunction(
                            methodDeclaration, 
                            invokeMethodIdentifier, 
                            newClassDeclaration);

                        interfaceDeclaration = DecorateInterfaceWithWrapperFunction(
                            methodDeclaration,
                            invokeMethodIdentifier,
                            interfaceDeclaration);
                        interfaceNamespaceDeclaration.Members.Add(interfaceDeclaration);
                    }
                    
                    newClassDeclaration = SyntaxFactory.ClassDeclaration(
                        newClassDeclaration.AttributeLists,
                        modifiers,
                        newClassDeclaration.Identifier
                            .WithLeadingTrivia(WhitespaceCharacter),
                        newClassDeclaration.TypeParameterList,
                        baseList,
                        newClassDeclaration.ConstraintClauses,
                        newClassDeclaration.Members);
                    compilationUnit = compilationUnit.ReplaceNode(classDeclaration, newClassDeclaration);

                    if (interfaceDeclaration.Members.Count > 0)
                    {
                        WriteInterfaceToFile(file, interfaceNamespaceDeclaration);
                    }
                    if (newClassDeclaration.Members.Count > previousClassMemberCount)
                    {
                        File.WriteAllText(
                            file,
                            compilationUnit.ToFullString());
                    }
                }
            }
        }

        private static bool IsPublicStaticExternMethod(MethodDeclarationSyntax methodDeclaration)
        {
            var externMethodKeyword = methodDeclaration.Modifiers
                .SingleOrDefault(x => x.IsKind(SyntaxKind.ExternKeyword));
            var staticMethodKeyword = methodDeclaration.Modifiers
                .SingleOrDefault(x => x.IsKind(SyntaxKind.StaticKeyword));
            var publicMethodKeyword = methodDeclaration.Modifiers
                .SingleOrDefault(x => x.IsKind(SyntaxKind.PublicKeyword));
            return externMethodKeyword == default(SyntaxToken) || staticMethodKeyword == default(SyntaxToken) || publicMethodKeyword == default(SyntaxToken);
        }

        private static void WriteInterfaceToFile(string file, NamespaceDeclarationSyntax interfaceNamespaceDeclaration)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(file);

            var fileDirectory = Path.GetDirectoryName(file);
            Debug.Assert(fileDirectory != null, "fileDirectory != null");

            File.WriteAllText(
                Path.Combine(
                    fileDirectory,
                    $"I{baseFileName}Mockable.cs"),
                interfaceNamespaceDeclaration.ToFullString());
        }

        private static InterfaceDeclarationSyntax DecorateInterfaceWithWrapperFunction(
            MethodDeclarationSyntax methodDeclaration,
            IdentifierNameSyntax invokeMethodIdentifier,
            InterfaceDeclarationSyntax interfaceDeclaration)
        {
            var interfaceMethodDeclaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(),
                methodDeclaration.ReturnType,
                default(ExplicitInterfaceSpecifierSyntax),
                invokeMethodIdentifier.Identifier,
                methodDeclaration.TypeParameterList,
                methodDeclaration.ParameterList,
                methodDeclaration.ConstraintClauses,
                default(BlockSyntax),
                SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            interfaceDeclaration = interfaceDeclaration
                .AddMembers(
                    interfaceMethodDeclaration
                        .WithTrailingTrivia(NewLineCharacter)
                        .WithLeadingTrivia(NewLineCharacter));
            return interfaceDeclaration;
        }

        private static ClassDeclarationSyntax DecorateClassWithWrapperFunction(MethodDeclarationSyntax methodDeclaration,
            IdentifierNameSyntax invokeMethodIdentifier,
            ClassDeclarationSyntax classDeclaration)
        {
            var arguments = methodDeclaration.ParameterList
                .Parameters
                .Select(x => SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName(x.Identifier)));

            var arrowBody = SyntaxFactory.ArrowExpressionClause(
                SyntaxFactory.Token(SyntaxKind.EqualsGreaterThanToken)
                    .WithLeadingTrivia(NewLineCharacter, TabCharacter)
                    .WithTrailingTrivia(WhitespaceCharacter),
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.IdentifierName(methodDeclaration.Identifier),
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList(arguments))));

            var wrapperMethodDeclaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword)
                        .WithTrailingTrivia(WhitespaceCharacter)),
                methodDeclaration.ReturnType,
                default(ExplicitInterfaceSpecifierSyntax),
                invokeMethodIdentifier.Identifier,
                methodDeclaration.TypeParameterList,
                methodDeclaration.ParameterList,
                methodDeclaration.ConstraintClauses,
                default(BlockSyntax),
                arrowBody,
                SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            classDeclaration = classDeclaration
                .AddMembers(
                    wrapperMethodDeclaration
                        .WithTrailingTrivia(NewLineCharacter)
                        .WithLeadingTrivia(NewLineCharacter));
            return classDeclaration;
        }
    }
}
