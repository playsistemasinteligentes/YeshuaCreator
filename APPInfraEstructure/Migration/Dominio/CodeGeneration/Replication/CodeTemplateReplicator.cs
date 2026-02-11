using Dominio.CodeGeneration.Parsing;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dominio.CodeGeneration.Replication
{
    public class CodeTemplateReplicator
    {
        public CompilationUnitSyntax Replicate(
            CodeTemplate template,
            string @namespace,
            string name,
            string @interface,
            IEnumerable<PropertyDeclarationSyntax> properties)
        {
            var newType = template.Type
                .WithIdentifier(SyntaxFactory.Identifier(name))
                .WithMembers(
                    SyntaxFactory.List<MemberDeclarationSyntax>(properties))
                .WithBaseList(
                    SyntaxFactory.BaseList(
                        SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                            SyntaxFactory.SimpleBaseType(
                                SyntaxFactory.ParseTypeName(@interface)))));

            var ns = SyntaxFactory.NamespaceDeclaration(
                    SyntaxFactory.ParseName(@namespace))
                .AddMembers(newType);

            return SyntaxFactory.CompilationUnit()
                .WithUsings(template.Root.Usings)
                .AddMembers(ns)
                .NormalizeWhitespace();
        }
    }
}
