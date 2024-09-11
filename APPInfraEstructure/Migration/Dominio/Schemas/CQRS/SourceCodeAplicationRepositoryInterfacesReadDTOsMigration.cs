using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesReadDTOsMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a struct
            sb.AppendLine($"namespace Repositorio.Outputs.DTOs.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public struct {_entity.EntityName}DTO");
            sb.AppendLine("    {");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.GetCsharpType()} {column.Name} {{ get; set; }}");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}