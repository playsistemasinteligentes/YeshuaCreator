using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Net.Http;
using System.Text;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureAPIIndependenceInjectionMigration : SourceCodeBase
    {
        private readonly Migration.MigrationBase _migration;



        public SourceCodeInfraestructureAPIIndependenceInjectionMigration(Migration.MigrationBase migration)
            : base()
        {
            _migration = migration;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class IndependenceInjection");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapIndependenceInjection(WebApplicationBuilder builder)");
            sb.AppendLine("{");

            // ingeção dependencia 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine("");
                sb.AppendLine($"builder.Services.AddTransient<Repositorio.Inputs.Repositorio.{entity.EntityName}.I{entity.EntityName}WriteRepository, Input.Repository.{entity.EntityName}.{entity.EntityName}WriteRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.{entity.EntityName}.I{entity.EntityName}ReadRepository, Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver>();");
            }


            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString();
        }
        protected override string GenerateCustonCode()
        {
            return "";
        }
    }
}