using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Text;
using System.Threading.Channels;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureQueryWriteMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly bool _isInterface;
        public SourceCodeInfraestructureQueryWriteMigration(Entity entity, bool isInterface)
            : base()
        {
            _entity = entity;
            _isInterface = isInterface;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            if (_isInterface)
            {
                sb.AppendLine($"using Shered.DB;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceiEntitys};");

                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceIQueryWrite}");
                sb.AppendLine("{");
                sb.AppendLine();
                sb.AppendLine($"    public interface I{_entity.EntityName}QueryWrite ");
                sb.AppendLine("     {");
                sb.AppendLine($"        public QueryModel Inserir{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName});");

                // update 
                sb.AppendLine($"        public QueryModel Update{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName});");

                foreach (var column in _entity.AddColumns.Where(x => !x.IsKey && !x.IsBackEndField))
                    sb.AppendLine($"        public QueryModel Update{column.Name}(I{_entity.EntityName}Entity entity);");
                //delete 
                sb.AppendLine($"        public QueryModel Delete{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName});");

                sb.AppendLine("    }");
                sb.AppendLine("}");
            }
            else
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine("using Shered.DB;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandWrite};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIQueryWrite};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIterfaceAplicationServices};");

                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine();
                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceQueryWrite}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}QueryWrite : QueryBase, I{_entity.EntityName}QueryWrite");
                sb.AppendLine("    {");

                sb.AppendLine($"        protected readonly ICurrentUser _currentUser;");

                sb.AppendLine($"        public {_entity.EntityName}QueryWrite(ICurrentUser currentUser)");
                sb.AppendLine("        {");
                sb.AppendLine($"            _currentUser = currentUser;");
                sb.AppendLine("        }");

                sb.AppendLine($"        public QueryModel Inserir{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName})");
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
                    if (column.IsValueDefault)
                    {
                        if (column.ValueDefault.StartsWith("#"))
                            sb.AppendLine($"                {column.Name} = {(column.ValueDefault.Substring(1))},");
                        else
                            sb.AppendLine($"                {column.Name} = {(column.ValueDefault == "''" ? "\"\"" : column.ValueDefault)},");
                    }
                    else
                        sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");

                sb.AppendLine("            };");
                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                sb.AppendLine("        }");

                // update 
                sb.AppendLine($"        public QueryModel Update{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName})");
                sb.AppendLine("        {");


                parametersString = string.Join(", ", _entity.AddColumns.Where(x => !x.IsKey && !x.IsBackEndField && x.Name != "Deleted" && x.Name != "TenantID").Select(c => $"{c.Name} = @{c.Name}"));
                var parametersWhere = string.Join(", ", _entity.AddColumns.Where(x => x.IsKey && !x.IsBackEndField).Select(c => $"{c.Name} = @{c.Name}"));
                sb.AppendLine($"            this.Query = $@\" UPDATE {_entity.EntityName} SET {parametersString} WHERE {parametersWhere} \";");

                sb.AppendLine("            this.Parameters = new");
                sb.AppendLine("            {");

                // debito   incluir beckend fiel
                foreach (var column in _entity.AddColumns.Where(x => !x.IsKey && !x.IsBackEndField && x.Name != "Deleted" && x.Name != "TenantID"))
                {
                    if (column.Name == "UserId")
                        sb.AppendLine($"                {column.Name} = _currentUser.UserId,");
                    else
                        sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
                }
                foreach (var column in _entity.AddColumns.Where(x => x.IsKey))
                    sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
                sb.AppendLine("            };");
                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                sb.AppendLine("        }");


                foreach (var column in _entity.AddColumns.Where(x => !x.IsKey && !x.IsBackEndField))
                {
                    sb.AppendLine($"        public QueryModel Update{column.Name}(I{_entity.EntityName}Entity entity)");
                    sb.AppendLine("        {");
                    parametersWhere = string.Join(", ", _entity.AddColumns.Where(x => x.IsKey && !x.IsBackEndField).Select(c => $"{c.Name} = @{c.Name}"));
                    sb.AppendLine($"            this.Query = $@\" UPDATE {_entity.EntityName} SET {column.Name} = @{column.Name} WHERE {parametersWhere} \";");

                    sb.AppendLine("            this.Parameters = new");
                    sb.AppendLine("            {");
                    sb.AppendLine($"                {column.Name} = entity.{column.Name},");
                    foreach (var col in _entity.AddColumns.Where(x => x.IsKey))
                        sb.AppendLine($"                {col.Name} = entity.{col.Name},");
                    sb.AppendLine("            };");
                    sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                    sb.AppendLine("        }");
                }



                //delete 
                sb.AppendLine($"        public QueryModel Delete{_entity.EntityName}Query(I{_entity.EntityName}Entity {_entity.EntityName})");
                sb.AppendLine("        {");

                parametersString = string.Join("AND ", _entity.AddColumns.Where(x => x.IsKey && !x.IsBackEndField).Select(c => $"{c.Name} = @{c.Name}"));
                sb.AppendLine($"            this.Query = $@\" DELETE FROM {_entity.EntityName} WHERE {parametersString} \";");
                // debito incluir isbackendfield where 
                sb.AppendLine("            this.Parameters = new");
                sb.AppendLine("            {");
                foreach (var column in _entity.AddColumns.Where(x => x.IsKey))
                    sb.AppendLine($"                {column.Name} = {_entity.EntityName}.{column.Name},");
                sb.AppendLine("            };");
                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                sb.AppendLine("        }");


                sb.AppendLine("    }");
                sb.AppendLine("}");
            }
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