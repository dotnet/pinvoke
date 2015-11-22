using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
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
            Console.WriteLine("Loading solution");

            var currentDirectory = Environment.CurrentDirectory;

            var workspace = MSBuildWorkspace.Create();

            var solutionRoot = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(currentDirectory))), "src");
            var solution = workspace.OpenSolutionAsync(Path.Combine(solutionRoot, "PInvoke.sln")).Result;
            var projects = GetProjectsFromSolution(solution);
            for (var i = 0; i < projects.Length; i++)
            {
                var project = projects[i];
                Console.WriteLine($"Processing project {project.Name}");

                foreach (var file in project.Documents
                    .Select(x => x.FilePath)
                    .Where(x => x.EndsWith(".cs")))
                {
                    Console.WriteLine($"\tProcessing {Path.GetFileName(file)}");
                    ProcessSourceCodes(workspace, ref solution, ref project, file);
                }

                projects = GetProjectsFromSolution(solution);
            }

            if (!workspace.TryApplyChanges(solution))
            {
                Console.Error.WriteLine("Solution save failed.");
            }
            else
            {
                Console.WriteLine("Solution save succeeded!");
            }

            Console.ReadLine();
        }

        private static Project[] GetProjectsFromSolution(Solution solution)
        {
            return solution.Projects
                .OrderBy(x => x.Name)
                .ToArray();
        }

        private static void ProcessSourceCodes(Workspace workspace, ref Solution solution, ref Project project, string file)
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
                    var className = classDeclaration.Identifier.Text;
                    if (className.EndsWith("Mockable") || className.EndsWith("Extensions"))
                    {
                        Console.WriteLine($"\tSkipping class {className} because it is a mockable or an extension method.");
                        continue;
                    }

                    var methodDeclarations = classDeclaration.Members
                        .OfType<MethodDeclarationSyntax>()
                        .Where(a => a.AttributeLists.Any(
                                b => b.Attributes.Any(
                                    c => c.Name.ToString() == "DllImport"))
                                    && IsNotPublicStaticExternMethod(a))
                        .ToArray();
                    if (methodDeclarations.Length <= 0)
                    {
                        Console.WriteLine($"\tSkipping class {className} because it has no public static extern methods with DllImport attributes.");
                        continue;
                    }

                    var newInterfaceModifier =
                        SyntaxFactory.IdentifierName($"I{classDeclaration.Identifier.Text}Mockable");
                    var newClassModifier = SyntaxFactory.IdentifierName($"{classDeclaration.Identifier.Text}Mockable");

                    PrepareClassCacheEntry(newClassModifier, classDeclaration, newInterfaceModifier);
                    PrepareInterfaceCacheEntry(newInterfaceModifier);

                    var newClassDeclaration = ClassCache[newClassModifier.Identifier.Text];
                    var newInterfaceDeclaration = InterfaceCache[newInterfaceModifier.Identifier.Text];

                    foreach (var methodDeclaration in methodDeclarations)
                    {
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

                        var usings = new[]
                            {
                                SyntaxFactory.UsingDirective(
                                    SyntaxFactory.Token(SyntaxKind.StaticKeyword),
                                    null,
                                    SyntaxFactory.IdentifierName(classDeclaration.Identifier
                                        .WithLeadingTrivia()
                                        .WithTrailingTrivia())
                                        .WithLeadingTrivia(WhitespaceCharacter))
                                    .WithLeadingTrivia(TabCharacter)
                                    .WithTrailingTrivia(NewLineCharacter)
                            };

                        AddPathToProject(workspace, ref solution, ref project, $"{baseFileName}Mockable.cs",
                            CreateNewEmptyNamespaceDeclaration(namespaceDeclaration, usings)
                                .AddMembers(newClassDeclaration)
                                .ToFullString());
                        AddPathToProject(workspace, ref solution, ref project, $"I{baseFileName}Mockable.cs",
                            CreateNewEmptyNamespaceDeclaration(namespaceDeclaration, usings)
                                .AddMembers(newInterfaceDeclaration)
                                .ToFullString());
                    }
                }
            }
        }

        private static Document GetExistingDocument(Project project, string path)
        {
            return project.Documents.FirstOrDefault(x => x.Name == Path.GetFileName(path));
        }

        private static void AddPathToProject(Workspace workspace, ref Solution solution, ref Project project, string fileName, string contents)
        {
            var document = GetExistingDocument(project, fileName);
            if (document == null)
            {
                Console.WriteLine($"\t - Adding {fileName} to project");
                document = project.AddDocument(fileName,
                    contents,
                    null,
                    Path.Combine(Path.GetDirectoryName(project.FilePath), fileName));
                project = document.Project;
                solution = project.Solution;
            }
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
            NamespaceDeclarationSyntax namespaceDeclaration,
            IEnumerable<UsingDirectiveSyntax> usings = null)
        {
            var namespaceUsings = namespaceDeclaration.Usings;
            if (usings != null)
            {
                namespaceUsings = namespaceUsings.AddRange(usings);
            }

            var newNamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(
                namespaceDeclaration.NamespaceKeyword,
                namespaceDeclaration.Name,
                namespaceDeclaration.OpenBraceToken,
                namespaceDeclaration.Externs,
                namespaceUsings,
                SyntaxFactory.List<MemberDeclarationSyntax>(),
                namespaceDeclaration.CloseBraceToken,
                namespaceDeclaration.SemicolonToken);
            return newNamespaceDeclaration;
        }

        private static bool IsNotPublicStaticExternMethod(MethodDeclarationSyntax methodDeclaration)
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
                        null,
                        x.Modifiers.FirstOrDefault(z => z.IsKind(SyntaxKind.RefKeyword) || z.IsKind(SyntaxKind.OutKeyword)),
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
