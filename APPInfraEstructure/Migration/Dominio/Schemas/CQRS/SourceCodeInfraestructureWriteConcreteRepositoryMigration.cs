using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureWriteConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureWriteConcreteRepositoryMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Dapper;");
            sb.AppendLine($"using Dominio.Entitys.{_entity.EntityName};");
            sb.AppendLine($"using Input.Querys.{_entity.EntityName};");
            sb.AppendLine($"using Repositorio.Inputs.Repositorio.{_entity.EntityName};");
            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Input.Repository.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}WriteRepository : I{_entity.EntityName}WriteRepository");
            sb.AppendLine("    {");
            sb.AppendLine("        private readonly IDbConnection _Connection;");
            sb.AppendLine();
            sb.AppendLine($"        public {_entity.EntityName}WriteRepository(SqlFactory factory)");
            sb.AppendLine("        {");
            sb.AppendLine("            _Connection = factory.SqlConnection();");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public void Insert({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            sb.AppendLine($"            var query = new {_entity.EntityName}WriteQuery().Inserir{_entity.EntityName}Query({_entity.EntityName});");

            var incremento = _entity.AddColumns.Where(x => x.AutoIncremento).FirstOrDefault();
            if (incremento != null)
                sb.AppendLine($"        {_entity.EntityName}.{incremento.Name} =  _Connection.ExecuteScalar<{incremento.getCsharpType()}>(query.Query, query.Parameters);");
            else
                sb.AppendLine("                _Connection.Execute(query.Query, query.Parameters);");

            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public void Update({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            sb.AppendLine($"            var query = new {_entity.EntityName}WriteQuery().Update{_entity.EntityName}Query({_entity.EntityName});");
            sb.AppendLine("            using (var conn = _Connection) ");
            sb.AppendLine("            {");
            sb.AppendLine("                _Connection.Execute(query.Query, query.Parameters);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine($"        public void Delete({_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            sb.AppendLine($"            var query = new {_entity.EntityName}WriteQuery().Delete{_entity.EntityName}Query({_entity.EntityName});");
            sb.AppendLine("            using (var conn = _Connection) ");
            sb.AppendLine("            {");
            sb.AppendLine("                _Connection.Execute(query.Query, query.Parameters);");
            sb.AppendLine("            }");
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