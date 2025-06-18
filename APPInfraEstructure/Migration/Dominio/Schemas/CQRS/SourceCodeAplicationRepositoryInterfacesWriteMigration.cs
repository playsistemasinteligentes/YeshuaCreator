using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesWriteMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesWriteMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
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
            sb.AppendLine($"        void Update({_entity.EntityName}Entity {_entity.EntityName.ToLower()});");
            sb.AppendLine($"        void Delete({_entity.EntityName}Entity {_entity.EntityName.ToLower()});");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return new StringBuilder();
            sb.AppendLine($"namespace Repositorio.Inputs.Repositorio.{_entity.EntityName}");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"public partial interface  I{_entity.EntityName}");
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