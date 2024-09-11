using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesWriteMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesWriteMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using Dominio.Entitys.{_entity.EntityName};");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a interface
            sb.AppendLine($"namespace Repositorio.Inputs.Repositorio.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial interface I{_entity.EntityName}WriteRepository");
            sb.AppendLine("    {");
            sb.AppendLine($"        void Insert({_entity.EntityName}Entity {_entity.EntityName.ToLower()});");
            sb.AppendLine($"        void InsertSmall({_entity.EntityName}Entity {_entity.EntityName.ToLower()});");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}