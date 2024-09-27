using System.Data.Common;
using System.Text;
using Migration.Dominio;
using static Dapper.SqlMapper;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeEntityMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeEntityMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();
            sb.Append($@"
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.{_entity.EntityName}
                {{
                    public partial class {_entity.EntityName}Entity
                    {{
            ");

            // atributos
            foreach (var column in _entity.AddColumns)
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");

            // construtor 
            sb.AppendLine(@$" public {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Select(c => c.getCsharpType() + " " + c.getParameterConstructor()))} ){{");
            foreach (var column in _entity.AddColumns)
                sb.AppendLine($" {column.Name} = {column.getParameterConstructor()}; ");
            sb.AppendLine("}");

            sb.Append($@"
                public bool isValid()
                {{
                    return true;
                }}
            }}
        }}");
            return sb.ToString();
        }
        protected override string GenerateCustonCode()
        {
            var sb = new StringBuilder();

            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}Entity");
            sb.AppendLine("{");

            // Fecha a classe
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}