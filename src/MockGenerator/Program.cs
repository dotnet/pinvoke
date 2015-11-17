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
            foreach (var namespaceDeclaration in namespaceDeclarations)
            {
                if (namespaceDeclaration == null || namespaceDeclaration.Name.ToString() != "PInvoke") return;

                var classDeclarations = namespaceDeclaration.Members
                    .OfType<ClassDeclarationSyntax>()
                    .ToArray();
                for (var index = 0; index < classDeclarations.Length; index++)
                {
                    var classDeclaration = classDeclarations[index];

                    var newInterfaceModifier = SyntaxFactory.IdentifierName($"I{classDeclaration.Identifier.Text}Mockable");
                    var newClassModifier = SyntaxFactory.IdentifierName($"{classDeclaration.Identifier.Text}Mockable");

                    var baseList = classDeclaration.BaseList ?? SyntaxFactory.BaseList();
                    baseList = baseList.AddTypes(
                        SyntaxFactory.SimpleBaseType(
                            newInterfaceModifier
                                .WithLeadingTrivia(WhitespaceCharacter)
                                .WithTrailingTrivia(WhitespaceCharacter)));
                    
                    var newNamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(
                        namespaceDeclaration.NamespaceKeyword,
                        namespaceDeclaration.Name,
                        namespaceDeclaration.OpenBraceToken,
                        namespaceDeclaration.Externs,
                        namespaceDeclaration.Usings,
                        SyntaxFactory.List<MemberDeclarationSyntax>(),
                        namespaceDeclaration.CloseBraceToken,
                        namespaceDeclaration.SemicolonToken);

                    var newClassNamespaceDeclaration = newNamespaceDeclaration;
                    var newInterfaceNamespaceDeclaration = newNamespaceDeclaration;

                    var newClassDeclaration = SyntaxFactory.ClassDeclaration(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(
                            SyntaxFactory
                                .Token(SyntaxKind.PublicKeyword)
                                .WithTrailingTrivia(WhitespaceCharacter)),
                        newClassModifier
                            .Identifier
                            .WithTrailingTrivia(WhitespaceCharacter)
                            .WithLeadingTrivia(WhitespaceCharacter),
                        null,
                        null,
                        SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
                        SyntaxFactory.List<MemberDeclarationSyntax>());
                    var newInterfaceDeclaration = SyntaxFactory.InterfaceDeclaration(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(
                            SyntaxFactory
                                .Token(SyntaxKind.PublicKeyword)
                                .WithTrailingTrivia(WhitespaceCharacter)),
                        newInterfaceModifier
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
                        newClassNamespaceDeclaration.Members.Add(classDeclaration);

                        newInterfaceDeclaration = DecorateInterfaceWithWrapperFunction(
                            methodDeclaration,
                            invokeMethodIdentifier,
                            newInterfaceDeclaration);
                        newInterfaceNamespaceDeclaration.Members.Add(newInterfaceDeclaration);
                    }

                    if (newInterfaceDeclaration.Members.Count > 0)
                    {
                        WriteInterfaceToFile(file, newInterfaceNamespaceDeclaration);
                    }
                    if (classDeclaration.Members.Count > 0)
                    {
                        WriteClassToFile(file, newClassNamespaceDeclaration);
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
            string fileDirectory;
            var baseFileName = GetBaseFileName(file, out fileDirectory);

            File.WriteAllText(
                Path.Combine(
                    fileDirectory,
                    $"I{baseFileName}Mockable.cs"),
                interfaceNamespaceDeclaration.ToFullString());
        }

        private static void WriteClassToFile(string file, NamespaceDeclarationSyntax classNamespaceDeclaration)
        {
            string fileDirectory;
            var baseFileName = GetBaseFileName(file, out fileDirectory);

            File.WriteAllText(
                Path.Combine(
                    fileDirectory,
                    $"{baseFileName}Mockable.cs"),
                classNamespaceDeclaration.ToFullString());
        }

        private static string GetBaseFileName(string file, out string fileDirectory)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(file);

            fileDirectory = Path.GetDirectoryName(file);
            Debug.Assert(fileDirectory != null, "fileDirectory != null");
            return baseFileName;
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
