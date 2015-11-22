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
    using Microsoft.CodeAnalysis.MSBuild;

    class Program
    {
        static readonly SyntaxTrivia WhitespaceCharacter = SyntaxFactory.Whitespace(" ");
        static readonly SyntaxTrivia TabCharacter = SyntaxFactory.Whitespace("\t");
        static readonly SyntaxTrivia NewLineCharacter = SyntaxFactory.Whitespace("\n");

        private static readonly IDictionary<string, ClassDeclarationSyntax> ClassCache;
        private static readonly IDictionary<string, InterfaceDeclarationSyntax> InterfaceCache;

        static Program()
        {
            ClassCache = new Dictionary<string, ClassDeclarationSyntax>();
            InterfaceCache = new Dictionary<string, InterfaceDeclarationSyntax>();
        }

        private static void Main()
        {
            Run();
        }

        private static void Run()
        {
            var currentDirectory = Environment.CurrentDirectory;

            var workspace = MSBuildWorkspace.Create();

            var solutionRoot = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(currentDirectory))), "src");
            var solution = workspace.OpenSolutionAsync(Path.Combine(solutionRoot, "PInvoke.sln")).Result;
            var projects = solution.Projects.ToArray();
            for (var i = 0; i < projects.Length; i++)
            {
                var project = projects[i];
                foreach (var file in project.Documents
                    .Select(x => x.FilePath)
                    .Where(x => x.EndsWith(".cs")))
                {
                    ProcessSourceCodes(ref solution, ref project, file);
                }
            }

            workspace.TryApplyChanges(solution);
        }

        private static void ProcessSourceCodes(ref Solution solution, ref Project project, string file)
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
                foreach (var classDeclaration in classDeclarations)
                {
                    if (classDeclaration.Identifier.Text.EndsWith("Mockable"))
                    {
                        continue;
                    }

                    var newInterfaceModifier =
                        SyntaxFactory.IdentifierName($"I{classDeclaration.Identifier.Text}Mockable");
                    var newClassModifier = SyntaxFactory.IdentifierName($"{classDeclaration.Identifier.Text}");

                    PrepareClassCacheEntry(newClassModifier, classDeclaration, newInterfaceModifier);
                    PrepareInterfaceCacheEntry(newInterfaceModifier);

                    var newClassDeclaration = ClassCache[newClassModifier.Identifier.Text];
                    var newInterfaceDeclaration = InterfaceCache[newInterfaceModifier.Identifier.Text];

                    var methodDeclarations = classDeclaration.Members
                        .OfType<MethodDeclarationSyntax>()
                        .Where(a => a.AttributeLists.Any(b => b.Attributes.Any(c => c.Name.ToString() == "DllImport")))
                        .ToArray();
                    foreach (var methodDeclaration in methodDeclarations)
                    {
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
                        ClassCache[newClassModifier.Identifier.Text] = newClassDeclaration;

                        newInterfaceDeclaration = DecorateInterfaceWithWrapperFunction(
                            methodDeclaration,
                            invokeMethodIdentifier,
                            newInterfaceDeclaration);
                        InterfaceCache[newInterfaceModifier.Identifier.Text] = newInterfaceDeclaration;

                        string fileDirectory;
                        var baseFileName = GetBaseFileName(file, out fileDirectory);

                        var mockableInterfacePath = Path.Combine(
                                fileDirectory,
                                $"I{baseFileName}Mockable.cs");
                        File.WriteAllText(
                            mockableInterfacePath,
                            CreateNewEmptyNamespaceDeclaration(namespaceDeclaration)
                                .AddMembers(newInterfaceDeclaration)
                                .ToFullString());

                        var mockableClassPath = Path.Combine(
                                fileDirectory,
                                $"{baseFileName}Mockable.cs");
                        File.WriteAllText(
                            mockableClassPath,
                            CreateNewEmptyNamespaceDeclaration(namespaceDeclaration)
                                .AddMembers(newClassDeclaration)
                                .ToFullString());

                        project = project.AddDocument(Path.GetFileName(mockableClassPath), File.ReadAllText(mockableClassPath)).Project;
                        project = project.AddDocument(Path.GetFileName(mockableInterfacePath), File.ReadAllText(mockableInterfacePath)).Project;
                        solution = project.Solution;
                    }

                    if (methodDeclarations.Length <= 0)
                    {
                        continue;
                    }

                    var staticModifier = classDeclaration.Modifiers.SingleOrDefault(x => x.IsKind(SyntaxKind.StaticKeyword));
                    if (staticModifier == default(SyntaxToken))
                    {
                        continue;
                    }

                    compilationUnit = compilationUnit.ReplaceNode(
                        classDeclaration,
                        classDeclaration.WithModifiers(
                            classDeclaration.Modifiers.Remove(staticModifier)));
                    File.WriteAllText(file, compilationUnit.ToFullString());
                }
            }
        }

        private static string GetProjectFile(string file)
        {
            var folder = Path.GetDirectoryName(file);
            var projectFile = (string)null;
            while (folder != null)
            {
                var projectFiles = Directory.GetFiles(folder, "*.csproj");
                if (projectFiles.Any())
                {
                    projectFile = projectFiles.Single();
                    break;
                }

                folder = Path.GetDirectoryName(folder);
            }

            return projectFile;
        }

        private static void PrepareInterfaceCacheEntry(IdentifierNameSyntax newInterfaceModifier)
        {
            if (!InterfaceCache.ContainsKey(newInterfaceModifier.Identifier.Text))
            {
                InterfaceCache.Add(newInterfaceModifier.Identifier.Text,
                    SyntaxFactory.InterfaceDeclaration(
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
                        SyntaxFactory.List<MemberDeclarationSyntax>())
                        .WithLeadingTrivia(TabCharacter)
                        .WithTrailingTrivia(NewLineCharacter));
            }
        }

        private static void PrepareClassCacheEntry(IdentifierNameSyntax newClassModifier,
            ClassDeclarationSyntax classDeclaration,
            IdentifierNameSyntax newInterfaceModifier)
        {
            if (!ClassCache.ContainsKey(newClassModifier.Identifier.Text))
            {
                var baseList = classDeclaration.BaseList ?? SyntaxFactory.BaseList();
                ClassCache.Add(newClassModifier.Identifier.Text,
                    SyntaxFactory.ClassDeclaration(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(
                            SyntaxFactory
                                .Token(SyntaxKind.PublicKeyword)
                                .WithTrailingTrivia(WhitespaceCharacter),
                            SyntaxFactory
                                .Token(SyntaxKind.PartialKeyword)
                                .WithTrailingTrivia(WhitespaceCharacter)),
                        newClassModifier.Identifier
                            .WithTrailingTrivia(WhitespaceCharacter)
                            .WithLeadingTrivia(WhitespaceCharacter),
                        null,
                        baseList.AddTypes(
                            SyntaxFactory.SimpleBaseType(
                                newInterfaceModifier
                                    .WithLeadingTrivia(WhitespaceCharacter)
                                    .WithTrailingTrivia(WhitespaceCharacter))),
                        SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
                        SyntaxFactory.List<MemberDeclarationSyntax>())
                        .WithLeadingTrivia(TabCharacter)
                        .WithTrailingTrivia(NewLineCharacter));
            }
        }

        private static NamespaceDeclarationSyntax CreateNewEmptyNamespaceDeclaration(
            NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var newNamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(
                namespaceDeclaration.NamespaceKeyword,
                namespaceDeclaration.Name,
                namespaceDeclaration.OpenBraceToken,
                namespaceDeclaration.Externs,
                namespaceDeclaration.Usings,
                SyntaxFactory.List<MemberDeclarationSyntax>(),
                namespaceDeclaration.CloseBraceToken,
                namespaceDeclaration.SemicolonToken);
            return newNamespaceDeclaration;
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
            var dllImport = methodDeclaration.AttributeLists
                .First(x => x.OpenBracketToken.HasLeadingTrivia);
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
                        .WithTrailingTrivia(
                            NewLineCharacter,
                            TabCharacter)
                        .WithLeadingTrivia(dllImport.OpenBracketToken.LeadingTrivia));
            return interfaceDeclaration;
        }

        private static ClassDeclarationSyntax DecorateClassWithWrapperFunction(MethodDeclarationSyntax methodDeclaration,
            IdentifierNameSyntax invokeMethodIdentifier,
            ClassDeclarationSyntax classDeclaration)
        {
            var dllImport = methodDeclaration.AttributeLists
                .First(x => x.OpenBracketToken.HasLeadingTrivia);
            var arguments = methodDeclaration.ParameterList
                .Parameters
                .Select((x, i) =>
                {
                    var identifierName = SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName(x.Identifier));
                    if (i > 0)
                    {
                        identifierName = identifierName.WithLeadingTrivia(WhitespaceCharacter);
                    }

                    return identifierName;
                });

            var arrowBody = SyntaxFactory.ArrowExpressionClause(
                SyntaxFactory.Token(SyntaxKind.EqualsGreaterThanToken)
                    .WithLeadingTrivia(
                        NewLineCharacter, 
                        TabCharacter, 
                        TabCharacter, 
                        TabCharacter)
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
                        .WithTrailingTrivia(
                            NewLineCharacter, 
                            TabCharacter)
                        .WithLeadingTrivia(dllImport.OpenBracketToken.LeadingTrivia));
            return classDeclaration;
        }
    }
}
