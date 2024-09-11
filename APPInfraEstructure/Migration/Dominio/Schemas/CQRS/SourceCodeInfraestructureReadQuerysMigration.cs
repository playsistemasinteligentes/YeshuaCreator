using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadQuerysMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureReadQuerysMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using Dominio.Entitys.{_entity.EntityName};");
            sb.AppendLine("using Shered.DB;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Output.Querys.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}ReadQuery : QueryBase");
            sb.AppendLine("    {");
            sb.AppendLine($"        public QueryModel SelectAll{_entity.EntityName}Query()");
            sb.AppendLine("        {");

            var columnsString = string.Join(", ", _entity.AddColumns.Select(x => x.Name));
            sb.AppendLine($"            this.Query = $@\" select {columnsString} from {_entity.EntityName} \";");

            sb.AppendLine("            return new QueryModel(this.Query, null);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }
    }

}