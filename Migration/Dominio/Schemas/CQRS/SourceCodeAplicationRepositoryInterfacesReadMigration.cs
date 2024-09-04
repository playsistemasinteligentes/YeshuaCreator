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
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using Repositorio.Outputs.DTOs.{_entity.EntityName};");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a interface
            sb.AppendLine($"namespace RepositoryInterfaces.Read.Repository.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public interface I{_entity.EntityName}ReadRepository");
            sb.AppendLine("    {");
            sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAll{_entity.EntityName}s();");
            sb.AppendLine($"        public {_entity.EntityName}DTO GetById();");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}