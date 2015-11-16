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
            foreach (var namespaceDeclaration in namespaceDeclarations)
            {
                if (namespaceDeclaration == null || namespaceDeclaration.Name.ToString() != "PInvoke") return;

                var classDeclarations = namespaceDeclaration.Members
                    .OfType<ClassDeclarationSyntax>()
                    .ToArray();
                for (var index = 0; index < classDeclarations.Length; index++)
                {
                    var classDeclaration = classDeclarations[index];

                    var modifiers = classDeclaration.Modifiers;
                    var staticKeyword = modifiers.SingleOrDefault(x => x.IsKind(SyntaxKind.StaticKeyword));
                    if (staticKeyword != default(SyntaxToken))
                    {
                        modifiers.Remove(staticKeyword);
                    }

                    var interfaceIdentifier = SyntaxFactory.IdentifierName($"I{classDeclaration.Identifier.Text}Mockable");

                    var baseList = classDeclaration.BaseList ?? SyntaxFactory.BaseList();
                    baseList = baseList.AddTypes(
                        SyntaxFactory.SimpleBaseType(
                            interfaceIdentifier
                                .WithLeadingTrivia(WhitespaceCharacter)
                                .WithTrailingTrivia(WhitespaceCharacter)));

                    var newClassDeclaration = SyntaxFactory.ClassDeclaration(
                        classDeclaration.AttributeLists,
                        modifiers,
                        classDeclaration.Identifier,
                        classDeclaration.TypeParameterList,
                        baseList,
                        classDeclaration.ConstraintClauses,
                        classDeclaration.Members);
                    compilationUnit = compilationUnit.ReplaceNode(classDeclaration, newClassDeclaration);
                    classDeclaration = newClassDeclaration;

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

                    var methodDeclarations = classDeclaration.Members
                        .OfType<MethodDeclarationSyntax>()
                        .ToArray();
                    for (int i = 0; i < methodDeclarations.Length; i++)
                    {
                        var methodDeclaration = methodDeclarations[i];
                        var externMethodKeyword = methodDeclaration.Modifiers
                            .SingleOrDefault(x => x.IsKind(SyntaxKind.ExternKeyword));
                        var staticMethodKeyword = methodDeclaration.Modifiers
                            .SingleOrDefault(x => x.IsKind(SyntaxKind.StaticKeyword));
                        if (externMethodKeyword == default(SyntaxToken) || staticMethodKeyword == default(SyntaxToken))
                        {
                            continue;
                        }

                        var invokeMethodIdentifier =
                            SyntaxFactory.IdentifierName($"Invoke{methodDeclaration.Identifier.Text}");

                        classDeclaration = DecorateClassWithWrapperFunction(methodDeclaration, invokeMethodIdentifier, classDeclaration);

                        interfaceDeclaration = DecorateInterfaceWithWrapperFunction(methodDeclaration, invokeMethodIdentifier, interfaceDeclaration);
                    }

                    if (interfaceDeclaration.Members.Count > 0)
                    {
                        WriteInterfaceToFile(file, interfaceDeclaration);
                    }
                    if (classDeclaration.Members.Count > 0)
                    {
                        File.WriteAllText(
                            file,
                            classDeclaration.ToFullString());
                    }
                }
            }
        }

        private static void WriteInterfaceToFile(string file, InterfaceDeclarationSyntax interfaceDeclaration)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(file);

            var fileDirectory = Path.GetDirectoryName(file);
            Debug.Assert(fileDirectory != null, "fileDirectory != null");

            File.WriteAllText(
                Path.Combine(
                    fileDirectory,
                    $"I{baseFileName}Mockable.cs"),
                interfaceDeclaration.ToFullString());
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
                SyntaxFactory.Token(SyntaxKind.EqualsGreaterThanToken),
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.IdentifierName(methodDeclaration.Identifier),
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList(arguments))));

            var wrapperMethodDeclaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(),
                methodDeclaration.ReturnType,
                default(ExplicitInterfaceSpecifierSyntax),
                invokeMethodIdentifier.Identifier,
                methodDeclaration.TypeParameterList,
                methodDeclaration.ParameterList,
                methodDeclaration.ConstraintClauses,
                default(BlockSyntax),
                arrowBody);

            classDeclaration = classDeclaration
                .AddMembers(
                    wrapperMethodDeclaration
                        .WithTrailingTrivia(NewLineCharacter)
                        .WithLeadingTrivia(NewLineCharacter));
            return classDeclaration;
        }
    }
}
