using Migration.Dominio;
using System.Text;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly CommandType _commandType;
        private readonly string _nameSpace;
        public SourceCodeAplicationCommandCommandsMigration(Entity entity, CommandType commandType, string nameSpace)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
            _nameSpace = nameSpace;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public class {_entity.EntityName}{_commandType}Command : ICommand");
            sb.AppendLine("    {");

            // Adiciona as propriedades
            foreach (var column in _entity.AddColumns)
            {
                // Garante que o nome e o tipo da coluna sejam válidos
                if (string.IsNullOrWhiteSpace(column.getCsharpType()) || string.IsNullOrWhiteSpace(column.Name))
                    throw new InvalidOperationException("Column type or name cannot be null or empty.");

                sb.AppendLine($"        public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }


        protected override string GenerateCustonCode()
        {
            return "";
        }
    }

}