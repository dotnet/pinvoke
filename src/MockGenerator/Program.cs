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

                    var interfaceName = SyntaxFactory
                        .IdentifierName($"I{classDeclaration.Identifier.Text}Mockable")
                        .WithLeadingTrivia(SyntaxFactory.Whitespace(" "))
                        .WithTrailingTrivia(SyntaxFactory.Whitespace(" "));

                    var baseList = classDeclaration.BaseList ?? SyntaxFactory.BaseList();
                    baseList = baseList.AddTypes(
                        SyntaxFactory.SimpleBaseType(interfaceName));

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


                }
            }
        }
    }
}
