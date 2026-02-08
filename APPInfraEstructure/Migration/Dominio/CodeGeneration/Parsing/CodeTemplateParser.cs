using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Migration.CodeGeneration.Templates
{
    public class CommandTemplate
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<PropertyTemplate> Properties { get; } = new();
    }

    public class PropertyTemplate
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Attributes { get; } = new();

        public bool HasAttribute(string attr)
            => Attributes.Any(a => a.Contains(attr));
    }

    public class CommandTemplateParser
    {
        public CommandTemplate Parse(string sourceCode)
        {
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetCompilationUnitRoot();

            var ns = root.DescendantNodes()
                .OfType<NamespaceDeclarationSyntax>()
                .FirstOrDefault();
            
            var type = root.DescendantNodes()
                .OfType<TypeDeclarationSyntax>()
                .FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Nenhuma classe ou struct encontrada no template.");


            var template = new CommandTemplate
            {
                Namespace = ns?.Name.ToString(),
                Name = type.Identifier.Text
            };

            foreach (var prop in type.Members.OfType<PropertyDeclarationSyntax>())
            {
                var p = new PropertyTemplate
                {
                    Name = prop.Identifier.Text,
                    Type = prop.Type.ToString()
                };

                foreach (var attr in prop.AttributeLists.SelectMany(a => a.Attributes))
                {
                    p.Attributes.Add(attr.Name.ToString());
                }

                template.Properties.Add(p);
            }

            return template;
        }
    }
}
