using Dominio.Migration;
using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Net.Http;
using System.Text;
using static Dapper.SqlMapper;
using static Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase;
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



            sb.AppendLine(@$"
                    builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork, Shered.DB.Connection.UnitOfWork>();
                    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));
                    builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();
                    builder.Services.AddTransient<Dominio.Interfaces.ILogger, Shered.Logger.Logger>();
            ");



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


                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceIRepositoryWrite}.I{entity.EntityName}WriteRepository, Input.Repository.{entity.EntityName}.{entity.EntityName}WriteRepository>();");
                    //sb.AppendLine($"builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.{entity.EntityName}.I{entity.EntityName}ReadRepository, Read.ConcreteRepository.{entity.EntityName}.{entity.EntityName}ReadRepository>();");

                    // clase concreta 
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceReadRepository}.{entity.EntityName}ReadRepository>();");

                    // decorator 

                    // Registra o decorador como implementação da interface
                    sb.AppendLine($"    builder.Services.AddTransient<{CQRSParam.I.NameSpaceIRepositoryRead}.I{entity.EntityName}ReadRepository>(sp =>");
                    sb.AppendLine($"    {{");
                    // fixos
                    sb.AppendLine($"    var inner = sp.GetRequiredService<{CQRSParam.I.NameSpaceReadRepository}.{entity.EntityName}ReadRepository>();");
                    sb.AppendLine($"    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.{entity.EntityName}DTO >>();");
                    sb.AppendLine($"    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.{entity.EntityName}DTO>>>();");

                    foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                        sb.AppendLine($"        var cacheFK{column.Name} = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.{entity.EntityName}{column.Name}DTO>>>();");

                    // fixo acrecentar quando tiver mais consultas
                    sb.Append($"    return new {CQRSParam.I.NameSpaceReadRepository}.{entity.EntityName}ReadRepositoryCacheDecorator(inner,cacheById,cacheAll");

                    foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                        sb.Append($",cacheFK{column.Name}");
                    sb.AppendLine("    );");

                    sb.AppendLine("});");


                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver>();");
                    foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                    {
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver>();");
                    }
                }

                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceIRepositoryWrite}.I{entity.EntityName}WriteRepository, Input.Repository.{entity.EntityName}.{entity.EntityName}WriteRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceIRepositoryRead}.I{entity.EntityName}ReadRepository, {CQRSParam.I.NameSpaceReadRepository}.{entity.EntityName}ReadRepository>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceIQueryRead}.I{entity.EntityName}QueryRead, {CQRSParam.I.NameSpaceQueryRead}.{entity.EntityName}QueryRead>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceIQueryWrite}.I{entity.EntityName}QueryWrite, {CQRSParam.I.NameSpaceQueryWrite}.{entity.EntityName}QueryWrite>();");

                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver>();");
                sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver>();");
                foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver>();");
                }

                foreach (var query in entity.Queries.OfType<IQueryWithMeta>())
                {
                    foreach (var wh in query.Meta.WhereParameters)
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadQuery}{wh.Key}Receiver>();");

                    foreach (var wh in query.Meta.WhereContextParameters)
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadQuery}{wh.Key}Receiver>();");

                }

            }
            foreach (var group in _migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var useCase in subGroup.UseCaseCommand)
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceCommandReceiversUseCase}.{useCase.Name.SourceType()}Handler>();");

                        //strategy 
                        foreach (var strategy in useCase.Estrategys)
                        {
                            var paths = new ExportPathsSourceCodeAplicationCommandReceiversUseCase();



                            List<CodigoGerado> CodigoGerado = new List<CodigoGerado>();
                            SourceCodeAplicationCommandReceiversUseCase strategys = new SourceCodeAplicationCommandReceiversUseCase(useCase, strategy, paths, ref CodigoGerado);
                            bool contexto = false;
                            if (strategy.Type.Name == "INotification")
                                contexto = true;
                            foreach (var code in CodigoGerado.Where(x => x.CommandType == CommandType.DependencyIngection))
                            {
                                var linhas = code.Conteudo.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var linha in linhas)
                                    sb.AppendLine($"builder.Services.AddTransient<{linha}>();");
                            }
                        }
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