using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationCommandCommandsMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine("namespace Comandos.Commands");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public class {_entity.EntityName}Command : ICommand");
            sb.AppendLine("    {");

            // Adiciona as propriedades
            foreach (var column in _entity.AddColumns)
            {
                // Garante que o nome e o tipo da coluna sejam válidos
                if (string.IsNullOrWhiteSpace(column.GetCsharpType()) || string.IsNullOrWhiteSpace(column.Name))
                    throw new InvalidOperationException("Column type or name cannot be null or empty.");

                sb.AppendLine($"        public {column.GetCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}