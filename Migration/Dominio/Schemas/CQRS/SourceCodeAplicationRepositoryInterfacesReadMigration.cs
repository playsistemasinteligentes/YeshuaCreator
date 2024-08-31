using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesReadMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesReadMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();

            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.Type} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}