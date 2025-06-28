using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using Repositorio.Outputs.DTOs.Y_Tenant_Configuration;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Services;
using Shered.DB.Connection;
using Shered.Services;
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

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();


            sb.AppendLine("using Shered.Services;");
            sb.AppendLine("using RepositoryInterfaces.Services;");


            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class IndependenceInjection");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapIndependenceInjection(WebApplicationBuilder builder)");
            sb.AppendLine("{");



            sb.AppendLine("builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork, Shered.DB.Connection.UnitOfWork>();");
            sb.AppendLine("builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));");
            sb.AppendLine("builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();");





            // ingeção dependencia 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine("");

                if (entity.CachedTable)
                {
                    // assim é generico    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));
                    // assim seria individual por consulta  por enquanto ficara generico 
                    //builder.Services.AddSingleton<ICacheService<Y_Tenant_ConfigurationDTO>, MemoryCacheService<Y_Tenant_ConfigurationDTO>>();
                    //builder.Services.AddSingleton<ICacheService<IEnumerable<Y_Tenant_ConfigurationDTO>>, MemoryCacheService<IEnumerable<Y_Tenant_ConfigurationDTO>>>();
                    //builder.Services.AddSingleton<ICacheService<IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>>, MemoryCacheService<IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>>>();


                    sb.AppendLine($"builder.Services.AddTransient<Repositorio.Inputs.Repositorio.{entity.EntityName}.I{entity.EntityName}WriteRepository, Input.Repository.{entity.EntityName}.{entity.EntityName}WriteRepository>();");
                    //sb.AppendLine($"builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.{entity.EntityName}.I{entity.EntityName}ReadRepository, Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");

                    // clase concreta 
                    sb.AppendLine($"builder.Services.AddTransient<Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");

                    // decorator 

                    // Registra o decorador como implementação da interface
                    sb.AppendLine($"    builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.{entity.EntityName}.I{entity.EntityName}ReadRepository>(sp =>");
                    sb.AppendLine($"    {{");
                    // fixos
                    sb.AppendLine($"    var inner = sp.GetRequiredService<Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");
                    sb.AppendLine($"    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.DTOs.{entity.EntityName}.{entity.EntityName}DTO >>();");
                    sb.AppendLine($"    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.DTOs.{entity.EntityName}.{entity.EntityName}DTO>>>();");

                    foreach (var column in entity.AddColumns.Where(x => x.IsFK))
                        sb.AppendLine($"        var cacheFK{column.Name} = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.DTOs.{entity.EntityName}.{entity.EntityName}{column.Name}DTO>>>();");

                    // fixo acrecentar quando tiver mais consultas
                    sb.Append($"    return new Read.ConcreteRepository.Y_Tenant_Configuration.Y_Tenant_ConfigurationReadRepositoryCacheDecorator(inner,cacheById,cacheAll");

                    foreach (var column in entity.AddColumns.Where(x => x.IsFK))
                        sb.Append($",cacheFK{column.Name}");
                    sb.AppendLine("    );");

                    sb.AppendLine("});");


                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver>();");
                    foreach (var column in entity.AddColumns.Where(x => x.IsFK))
                    {
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver>();");
                    }

                    break;
                }


                sb.AppendLine($"builder.Services.AddTransient<Repositorio.Inputs.Repositorio.{entity.EntityName}.I{entity.EntityName}WriteRepository, Input.Repository.{entity.EntityName}.{entity.EntityName}WriteRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.{entity.EntityName}.I{entity.EntityName}ReadRepository, Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver>();");
                foreach (var column in entity.AddColumns.Where(x => x.IsFK))
                {
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver>();");
                }
            }
            foreach (var hub in _migration.Hubs)
            {
                foreach (var servico in hub.Services)
                {
                    foreach (var method in servico.Methods)
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversHubServiceMethod}.{servico.Name.SourceType()}{method.Name.SourceType()}{CommandType.ServiceMethod}Receiver>();");
                    }
                }
            }


            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }
    }
}