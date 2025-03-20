using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureReadConcreteRepositoryMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine("using Dapper;");
            sb.AppendLine($"using Output.Querys.{_entity.EntityName};");
            sb.AppendLine($"using Repositorio.Outputs.DTOs.{_entity.EntityName};");
            sb.AppendLine($"using RepositoryInterfaces.Read.Repository.{_entity.EntityName};");
            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Read.ConcreteRepository.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}ReadRepository : I{_entity.EntityName}ReadRepository");
            sb.AppendLine("    {");
            sb.AppendLine("        protected readonly IDbConnection _connection;");
            sb.AppendLine();
            sb.AppendLine($"        public {_entity.EntityName}ReadRepository(SqlFactory factory)");
            sb.AppendLine("        {");
            sb.AppendLine("            _connection = factory.SqlConnection();");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> get{_entity.EntityName}(object command)");
            sb.AppendLine("         {");
            sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandsRead}.{_entity.EntityName}{CommandType.Read}Command c)");
            sb.AppendLine("            {");
            sb.AppendLine($"                return get{_entity.EntityName}(c);");
            sb.AppendLine("            }");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");

            sb.AppendLine($"        private IEnumerable<{_entity.EntityName}DTO> get{_entity.EntityName}({CQRSParam.I.NameSpaceCommandsRead}.{_entity.EntityName}{CommandType.Read}Command command)");
            sb.AppendLine("        {");
            sb.AppendLine($"            List<{_entity.EntityName}DTO> lista;");
            sb.AppendLine($"            var query = new {_entity.EntityName}ReadQuery().{_entity.EntityName}Query(command);");
            sb.AppendLine();
            sb.AppendLine("            using (_connection)");
            sb.AppendLine("            {");
            sb.AppendLine($"                lista = _connection.Query<{_entity.EntityName}DTO>(query.Query,query.Parameters) as List<{_entity.EntityName}DTO>;");
            sb.AppendLine("            }");
            sb.AppendLine("            return lista;");
            sb.AppendLine("        }");
            sb.AppendLine();

            foreach (var column in _entity.AddColumns.Where(x => x.IsFK))
            {

                sb.AppendLine($"        private IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(Command.Patterns.Command.SearchFKCommand command)");
                sb.AppendLine("        {");
                sb.AppendLine($"            List<{_entity.EntityName}{column.Name}DTO> lista;");
                sb.AppendLine($"            var query = new {_entity.EntityName}ReadQuery().{_entity.EntityName}{column.Name}Query(command);");
                sb.AppendLine();
                sb.AppendLine("            using (_connection)");
                sb.AppendLine("            {");
                sb.AppendLine($"                lista = _connection.Query<{_entity.EntityName}{column.Name}DTO>(query.Query,query.Parameters) as List<{_entity.EntityName}{column.Name}DTO>;");
                sb.AppendLine("            }");
                sb.AppendLine("            return lista;");
                sb.AppendLine("        }");
                sb.AppendLine();

                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command)");
                sb.AppendLine("        {");

                sb.AppendLine($"            if (command is Command.Patterns.Command.SearchFKCommand c)");
                sb.AppendLine("            {");
                sb.AppendLine($"                return get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(c);");
                sb.AppendLine("            }");
                sb.AppendLine("            throw new NotImplementedException();");

                sb.AppendLine("        }");
                sb.AppendLine();







            }


            sb.AppendLine($"        public {_entity.EntityName}DTO getById()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine($"        public {_entity.EntityName}DTO GetById()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            return sb;

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