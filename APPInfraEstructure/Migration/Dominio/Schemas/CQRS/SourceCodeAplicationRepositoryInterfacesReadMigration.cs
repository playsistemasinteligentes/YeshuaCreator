using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesReadMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesReadMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
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

            //--trocar ICommand comando por um DTO apenas pra não gerar dependencia do Repositorio para o command

            sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{CommandType.Read}DTO> get{_entity.EntityName}(object command);");
            sb.AppendLine($"        public {_entity.EntityName}DTO getById();");

            foreach (var column in _entity.AddColumns.Where(x => x.IsFK))
                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command);");

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return new StringBuilder();

            sb.AppendLine($"namespace RepositoryInterfaces.Read.Repository.{_entity.EntityName}");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"public partial class I{_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");
            sb.AppendLine("}");
            return sb;
        }
    }
}