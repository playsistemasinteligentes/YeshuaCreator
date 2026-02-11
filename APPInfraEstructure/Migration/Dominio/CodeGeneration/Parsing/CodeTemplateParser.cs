using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dominio.CodeGeneration.Parsing
{
    public sealed class CodeTemplate
    {
        public CompilationUnitSyntax Root { get; }
        public TypeDeclarationSyntax Type { get; }

        public CodeTemplate(
            CompilationUnitSyntax root,
            TypeDeclarationSyntax type)
        {
            Root = root;
            Type = type;
        }
    }

    public class CodeTemplateParser
    {
        public CodeTemplate Parse(string source)
        {
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = tree.GetCompilationUnitRoot();

            var type = root
                .DescendantNodes()
                .OfType<TypeDeclarationSyntax>()
                .FirstOrDefault()
                ?? throw new InvalidOperationException("Template sem class/struct.");

            return new CodeTemplate(root, type);
        }
    }
}
