using Dominio.CodeGeneration.Parsing;
using Dominio.CodeGeneration.Replication;
using Dominio.CodeGeneration.Templates;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dominio.CodeGeneration.Generation
{
    public sealed class WorkerGeneration
    {
        private readonly CodeTemplateParser _parser = new();
        private readonly CodeTemplateReplicator _replicator = new();

        public string Generate(
            string workerName,
            string @namespace,
            string commandInterface,
            TimeSpan interval)
        {
            var templateSource =
                EmbeddedTemplateLoader.Load("Worker.WorkerTemplate.cs");

            var template = _parser.Parse(templateSource);

            var updatedType = ReplaceConstructor(
                template.Type,
                workerName,
                commandInterface,
                interval);

            var ns = SyntaxFactory.NamespaceDeclaration(
                    SyntaxFactory.ParseName(@namespace))
                .AddMembers(updatedType);

            return SyntaxFactory.CompilationUnit()
                .WithUsings(template.Root.Usings)
                .AddMembers(ns)
                .NormalizeWhitespace()
                .ToFullString();
        }

        private static ClassDeclarationSyntax ReplaceConstructor(
            TypeDeclarationSyntax type,
            string workerName,
            string commandInterface,
            TimeSpan interval)
        {
            var classDecl = (ClassDeclarationSyntax)type
                .WithIdentifier(SyntaxFactory.Identifier(workerName));

            var ctor = classDecl.Members
                .OfType<ConstructorDeclarationSyntax>()
                .First();

            var newCtor =
                ctor.WithIdentifier(SyntaxFactory.Identifier(workerName))
                    .WithParameterList(
                        SyntaxFactory.ParameterList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.Parameter(
                                        SyntaxFactory.Identifier("command"))
                                    .WithType(
                                        SyntaxFactory.ParseTypeName(commandInterface)))))
                    .WithInitializer(
                        SyntaxFactory.ConstructorInitializer(
                            SyntaxKind.BaseConstructorInitializer,
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SeparatedList(new[]
                                {
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            SyntaxFactory.Literal(workerName))),

                                    SyntaxFactory.Argument(
                                        SyntaxFactory.ParseExpression(
                                            $"TimeSpan.FromSeconds({interval.TotalSeconds})"))
                                }))));

            var members = classDecl.Members
                .Where(m => m is not ConstructorDeclarationSyntax)
                .ToList();

            members.Add(newCtor);

            return classDecl.WithMembers(
                SyntaxFactory.List<MemberDeclarationSyntax>(members));
        }
    }
}
