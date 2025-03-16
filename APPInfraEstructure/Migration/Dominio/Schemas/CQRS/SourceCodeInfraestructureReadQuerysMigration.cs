using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Collections.Specialized;
using System.Data.Common;
using System.Diagnostics;
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
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Output.Querys.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}ReadQuery : QueryBase");
            sb.AppendLine("    {");

            sb.AppendLine($"        public QueryModel {_entity.EntityName}Query({CQRSParam.I.NameSpaceCommandsRead}.{_entity.EntityName}{CommandType.Read}Command Command)");
            sb.AppendLine("        {");

            var columnsString = string.Join(", ", _entity.AddColumns.Select(x => x.Name));
            sb.AppendLine($"            this.Query = $@\" select {columnsString} from {_entity.EntityName} \";");

            sb.AppendLine("            return new QueryModel(this.Query, null);");
            sb.AppendLine("        }");


            foreach (var column in _entity.AddColumns.Where(x => x.IsFK))
            {
                sb.AppendLine($"        public QueryModel {_entity.EntityName}{column.Name}Query(Command.Patterns.Command.SearchFKCommand Command)");
                sb.AppendLine("        {");

                columnsString = string.Join(", ", column.EntityFK.AddColumns.Where(x => x.DisplayFK).Select(x => x.Name));
                sb.AppendLine($"            this.Query = $@\" select {columnsString} from {column.EntityFK.EntityName} \";");

                sb.AppendLine("            return new QueryModel(this.Query, null);");
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