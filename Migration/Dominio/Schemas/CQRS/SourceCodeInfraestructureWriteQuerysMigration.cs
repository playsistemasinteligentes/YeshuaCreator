using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureWriteQuerysMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureWriteQuerysMigration(string filePath, Entity entity)
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
            sb.AppendLine($"namespace Input.Querys.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}WriteQuery : QueryBase");
            sb.AppendLine("    {");
            sb.AppendLine($"        public QueryModel Inserir{_entity.EntityName}Query({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");

            var columnsString = string.Join(", ", _entity.AddColumns.Select(x => x.Name));
            var parametersString = string.Join(", ", _entity.AddColumns.Select(c => $"@{c.Name}"));

            sb.AppendLine($"            this.Query = $@\" INSERT INTO {_entity.EntityName} ({columnsString}) VALUES({parametersString}) \";");

            // Adiciona parâmetros
            sb.AppendLine("            this.Parameters = new");
            sb.AppendLine("            {");
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"                {column.Name} = Clinica.{column.Name}.Value,");
            }
            sb.AppendLine("            };");
            sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }

    }

}