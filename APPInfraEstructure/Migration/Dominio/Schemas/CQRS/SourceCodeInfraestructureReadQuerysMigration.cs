using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Collections.Specialized;
using System.Data.Common;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadQuerysMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureReadQuerysMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using Dominio.Entitys.{_entity.EntityName};");
            sb.AppendLine("using Shered.DB;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Dynamic;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Output.Querys.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}ReadQuery : QueryBase");
            sb.AppendLine("    {");

            sb.AppendLine($"        public QueryModel {_entity.EntityName}Query({CQRSParam.I.NameSpaceCommandsRead}.{_entity.EntityName}{CommandType.Read}Command Command)");
            sb.AppendLine("        {");
            sb.AppendLine($"            this.Parameters = null;");
            sb.AppendLine($"            var whereClauses = new List<string>();");
            sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
            sb.AppendLine($"            var parametersDict = (IDictionary<string, object>)parameters;");


            var columnsString = string.Join(", ", _entity.AddColumns.Select(x => x.Name));
            sb.AppendLine($"            this.Query = $@\" select {columnsString} from {_entity.EntityName} \";");


            foreach (var item in _entity.AddColumns)
            {
                if (item.getCsharpType() == "string")
                {
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{item.Name})) parametersDict[\"{item.Name}\"] = $\"%{{Command.{item.Name}}}%\";");
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{item.Name})) whereClauses.Add($\"{item.Name} like @{item.Name}\");");
                }
                else if (item.getCsharpType() == "int")
                {
                    sb.AppendLine($"if (Command.{item.Name}.HasValue) parametersDict[\"{item.Name}\"] = Command.{item.Name}.Value;");
                    sb.AppendLine($"if (Command.{item.Name}.HasValue) whereClauses.Add($\"{item.Name} = @{item.Name}\");");
                }
            }

            sb.AppendLine("            if (whereClauses.Any()) ");
            sb.AppendLine("            this.Query += \" WHERE \" + string.Join(\" AND \", whereClauses); ");

            // Paginação
            sb.AppendLine("            int page = Command.Paginacao?.Page ?? 1;");
            sb.AppendLine("            int pageSize = Command.Paginacao?.PageSize ?? 20;");
            sb.AppendLine("            int offset = (page - 1) * pageSize;");
            sb.AppendLine("            parametersDict[\"Offset\"] = offset;");
            sb.AppendLine("            parametersDict[\"PageSize\"] = pageSize;");
            sb.AppendLine("            Query += \" ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY\"; ");

            sb.AppendLine($"            this.Parameters = parameters;");
            sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
            sb.AppendLine("        }");


            foreach (var column in _entity.AddColumns.Where(x => x.IsFK))
            {
                sb.AppendLine($"        public QueryModel {_entity.EntityName}{column.Name}Query({CQRSParam.I.NameSpaceCommandsPatterns}.SearchFKCommand Command)");
                sb.AppendLine("        {");

                columnsString = string.Join(", ", column.EntityFK.AddColumns.Where(x => x.DisplayFK).Select(x => x.Name));
                sb.AppendLine($"            this.Query = $@\" select {columnsString} from {column.EntityFK.EntityName} \";");
                sb.AppendLine($"            this.Parameters = null;");
                sb.AppendLine($"            var whereClauses = new List<string>();");

                sb.AppendLine("            if (!string.IsNullOrEmpty(Command.searchFK)) ");
                sb.AppendLine("            {");
                sb.AppendLine("                 if (int.TryParse(Command.searchFK, out int numero)) ");
                sb.AppendLine("                 {");

                sb.AppendLine($"                      this.Parameters = new {{ {column.ColumnReference} = numero}}; ");
                sb.AppendLine($"                      whereClauses.Add($\" {column.ColumnReference} = @{column.ColumnReference}\"); ");
                sb.AppendLine("                 }");
                sb.AppendLine("                 else ");
                sb.AppendLine("                 {");

                sb.AppendLine("                      this.Parameters = new { ");
                foreach (var item in column.EntityFK.AddColumns.Where(x => x.DisplayFK))
                    sb.AppendLine($"                       {item.Name} = $\"%{{Command.searchFK}}%\", ");
                sb.AppendLine("                      }; ");

                foreach (var item in column.EntityFK.AddColumns.Where(x => x.DisplayFK))
                    sb.AppendLine($"                      whereClauses.Add($\" {item.Name} like @{item.Name} \"); ");

                sb.AppendLine("                 }");
                sb.AppendLine("            }");

                sb.AppendLine("            if (whereClauses.Any()) ");
                sb.AppendLine("            this.Query += \" WHERE \" + string.Join(\" OR \", whereClauses); ");

                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters); ");
                sb.AppendLine("        }");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;

        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return new StringBuilder();
            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");
            return sb;
        }
    }
}