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
            sb.AppendLine("using Dominio.Entitys.Clinica;");
            sb.AppendLine("using Shered.DB;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Output.Querys.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine("    public class ClinicaReadQuery : QueryBase");
            sb.AppendLine("    {");
            sb.AppendLine("        public QueryModel SelectAllClinicaQuery()");
            sb.AppendLine("        {");

            // Cria a string de colunas a partir da lista de colunas
            var columnsString = string.Join(", ", _entity.AddColumns);
            sb.AppendLine($"            this.Query = $@\" select {columnsString} from {_entity.EntityName} \";");

            sb.AppendLine("            return new QueryModel(this.Query, null);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }
    }

}