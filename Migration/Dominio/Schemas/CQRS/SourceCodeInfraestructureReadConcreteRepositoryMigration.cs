using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureReadConcreteRepositoryMigration(string filePath, Entity entity)
            : base(filePath)
        {
            _entity = entity;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine("using Dapper;");
            sb.AppendLine("using Output.Querys.Clinica;");
            sb.AppendLine("using Repositorio.Outputs.DTOs.Clinica;");
            sb.AppendLine("using RepositoryInterfaces.Read.Repository.Clinica;");
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
            sb.AppendLine("    public class ClinicaReadRepository : IClinicaReadRepositorys");
            sb.AppendLine("    {");
            sb.AppendLine("        protected readonly IDbConnection _connection;");
            sb.AppendLine();
            sb.AppendLine("        public ClinicaReadRepository(SqlFactory factory)");
            sb.AppendLine("        {");
            sb.AppendLine("            _connection = factory.SqlConnection();");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> getAllClinicas()");
            sb.AppendLine("        {");
            sb.AppendLine($"            List<{_entity.EntityName}DTO> lista;");
            sb.AppendLine("            var query = new ClinicaReadQuery().SelectAllClinicaQuery();");
            sb.AppendLine();
            sb.AppendLine("            using (_connection)");
            sb.AppendLine("            {");
            sb.AppendLine($"                lista = _connection.Query<{_entity.EntityName}DTO>(query.Query) as List<{_entity.EntityName}DTO>;");
            sb.AppendLine("            }");
            sb.AppendLine("            return lista;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public {_entity.EntityName}DTO getById()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}