using Dominio.CodeGeneration.Parsing;
using Dominio.CodeGeneration.Replication;
using Dominio.CodeGeneration.Templates;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Dominio;

namespace Migration.Dominio.CodeGeneration.Generation.Command
{
    public class CrudCommandGeneration
    {
        private readonly CodeTemplateParser _parser = new();
        private readonly CodeTemplateReplicator _replicator = new();

        public string Generate(Entity entity, CommandType commandType, string column)
        {
            var templateSource =
            //EmbeddedTemplateLoader.Load("Command.NameCrudCommand.cs");
            EmbeddedTemplateLoader.Load("Command.IClinicaRepositoryInterfacesRead.cs");



            var template = _parser.Parse(templateSource);

            var properties = BuildProperties(entity, commandType, column);

            var interfaceName =
                commandType == CommandType.Read || commandType == CommandType.ReadFK
                    ? "ICommandRead"
                    : "ICommand";

            var commandName =
                $"{entity.EntityName}{commandType}{column}Command";

            var unit = _replicator.Replicate(
                template,
                CQRSParam.I.NameSpaceCommandWrite,
                commandName,
                interfaceName,
                properties);

            return unit.ToFullString();
        }

        private IEnumerable<PropertyDeclarationSyntax> BuildProperties(
            Entity entity,
            CommandType commandType,
            string column)
        {
            if (commandType == CommandType.ReadFK)
            {
                var fk = entity.AddColumns
                    .First(x => x.Name == column)
                    .EntityFK;

                foreach (var col in fk.AddColumns.Where(x => x.DisplayFK))
                {
                    yield return CreateProperty(
                        col.getCsharpType(true, true),
                        col.Name);
                }
                yield break;
            }

            foreach (var col in entity.AddColumns.Where(x => !x.IsBackEndField))
            {
                var type =
                    commandType == CommandType.Read && col.Enum != null
                        ? "List<int>"
                        : col.getCsharpType(
                            commandType != CommandType.Read,
                            true);

                yield return CreateProperty(type, col.Name);
            }

            if (commandType == CommandType.Read)
            {
                yield return CreateProperty("Pagination", "Paginacao");
            }
        }

        private PropertyDeclarationSyntax CreateProperty(string type, string name)
        {
            return SyntaxFactory.PropertyDeclaration(
                    SyntaxFactory.ParseTypeName(type),
                    name)
                .AddModifiers(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(
                        SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(
                            SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(
                        SyntaxKind.SetAccessorDeclaration)
                        .WithSemicolonToken(
                            SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        }
    }
}
