using System.ComponentModel.Design;
using System.Data.Common;
using System.Text;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using static System.Net.Mime.MediaTypeNames;
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

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.Append($@"
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace {CQRSParam.I.NameSpaceEntitys}
                {{
                    public partial class {_entity.EntityName}Entity
                    {{
            ");

            // atributos
            foreach (var column in _entity.AddColumns)
                sb.AppendLine($"    public {column.getCsharpType(true)} {column.Name} {{ get; set; }}");

            //stndard Atributos
            sb.AppendLine("    private List<string> _erroMensagem = null;");

            // construtor 
            sb.AppendLine(@$" public {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Select(c => c.getCsharpType(true) + " " + c.getParameterConstructor()))} ){{");
            foreach (var column in _entity.AddColumns)
                if (column.getCsharpType() == "DateTime")
                    sb.AppendLine($" {column.Name} = ({column.getParameterConstructor()} < (new DateTime(1800, 1, 1))) ? DateTime.Now : {column.getParameterConstructor()}; ");
                else
                    sb.AppendLine($" {column.Name} = {column.getParameterConstructor()}; ");
            sb.AppendLine("}");

            sb.AppendLine("public bool isValidData()");
            sb.AppendLine("{");
            sb.AppendLine("_erroMensagem = new List<string>();");

            foreach (var column in _entity.AddColumns.Where(x => x.IsNotNull))
            {
                if (column.getCsharpType() == "string")
                    sb.AppendLine($"   if(string.IsNullOrEmpty({column.Name}))");
                if (column.getCsharpType() == "DateTime")
                    sb.AppendLine($"   if ({column.Name} == null || {column.Name} < (new DateTime(1800, 1, 1)))");

                if (column.getCsharpType() == "int" || column.getCsharpType() == "Float" || column.getCsharpType() == "Decimal")
                    sb.AppendLine($"   if ({column.Name} == null)");

                sb.AppendLine($"   this._erroMensagem.Add(\"{column.Description} deve ser informado.\");");
            }

            sb.AppendLine("return _erroMensagem.Count() <= 0;");
            sb.AppendLine("}");

            sb.Append($@"
                public bool isValid{CommandType.Insert}()
                {{
                    return isValidData();
                }}
                public bool isValid{CommandType.Update}()
                {{
                    return isValidData();
                }}
                public bool isValid{CommandType.Delete}()
                {{
                    return true;
                }}
                public List<string> getErroMensagens()
                {{
                    return this._erroMensagem;
                }}
            }}
        }}");
            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            sb.Append($@"
                namespace Dominio.Entitys.{_entity.EntityName}
                {{
            ");

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}Entity");
            sb.AppendLine("{");

            // Fecha a classe
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
    }
}