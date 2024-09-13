using System.Data.Common;
using System.Text;
using Migration.Dominio;
using static Dapper.SqlMapper;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeEntityMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeEntityMigration(string filePath, Entity entity)
            : base(filePath)
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
    }
}