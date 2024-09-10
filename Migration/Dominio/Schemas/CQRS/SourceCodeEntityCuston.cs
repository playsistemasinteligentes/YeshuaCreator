using System.Text;
using Migration.Dominio;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeEntityCuston : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeEntityCuston(string filePath, Entity entity, bool isCuston = false)
            : base(filePath, isCuston)
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

            // Fecha a classe
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}