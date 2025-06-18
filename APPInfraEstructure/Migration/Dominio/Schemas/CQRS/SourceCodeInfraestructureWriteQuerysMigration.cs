using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureWriteQuerysMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureWriteQuerysMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
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

            var columnsString = string.Join(", ", _entity.AddColumns.Where(x => !x.AutoIncremento).Select(x => x.Name));
            var parametersString = string.Join(", ", _entity.AddColumns.Where(x => !x.AutoIncremento).Select(c => $"@{c.Name}"));

            var incremento = _entity.AddColumns.Where(x => x.AutoIncremento).FirstOrDefault();
            if (incremento != null)
                sb.AppendLine($"            this.Query = $@\" INSERT INTO {_entity.EntityName} ({columnsString}) OUTPUT INSERTED.{incremento.Name} VALUES({parametersString}) \";");
            else
                sb.AppendLine($"            this.Query = $@\" INSERT INTO {_entity.EntityName} ({columnsString}) OUTPUT INSERTED.ID VALUES({parametersString}) \";");

            // Adiciona parâmetros
            sb.AppendLine("            this.Parameters = new");
            sb.AppendLine("            {");
            foreach (var column in _entity.AddColumns.Where(x => !x.AutoIncremento))
                sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
            sb.AppendLine("            };");
            sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
            sb.AppendLine("        }");

            // update 
            sb.AppendLine($"        public QueryModel Update{_entity.EntityName}Query({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");

            parametersString = string.Join(", ", _entity.AddColumns.Where(x => !x.IsKey).Select(c => $"{c.Name} = @{c.Name}"));
            var parametersWhere = string.Join(", ", _entity.AddColumns.Where(x => x.IsKey).Select(c => $"{c.Name} = @{c.Name}"));
            sb.AppendLine($"            this.Query = $@\" UPDATE {_entity.EntityName} SET {parametersString} WHERE {parametersWhere} \";");

            sb.AppendLine("            this.Parameters = new");
            sb.AppendLine("            {");
            foreach (var column in _entity.AddColumns.Where(x => !x.IsKey))
                sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");

            foreach (var column in _entity.AddColumns.Where(x => x.IsKey))
                sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
            sb.AppendLine("            };");
            sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
            sb.AppendLine("        }");


            //delete 
            sb.AppendLine($"        public QueryModel Delete{_entity.EntityName}Query({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");

            parametersString = string.Join("AND ", _entity.AddColumns.Where(x => x.IsKey).Select(c => $"{c.Name} = @{c.Name}"));
            sb.AppendLine($"            this.Query = $@\" DELETE FROM {_entity.EntityName} WHERE {parametersString} \";");

            sb.AppendLine("            this.Parameters = new");
            sb.AppendLine("            {");
            foreach (var column in _entity.AddColumns.Where(x => x.IsKey))
                sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
            sb.AppendLine("            };");
            sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
            sb.AppendLine("        }");






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