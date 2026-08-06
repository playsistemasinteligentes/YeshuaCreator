using Dominio.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Net.Http;
using System.Text;
using static Dapper.SqlMapper;
using static Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureDependencInjectionInjectionMigration : SourceCodeBase
    {
        private readonly Migration.MigrationBase _migration;
        private readonly InfraEstrutctureType _InfraEstrutctureType;


        public SourceCodeInfraestructureDependencInjectionInjectionMigration(Migration.MigrationBase migration, InfraEstrutctureType InfraEstrutctureType) : base()
        {
            _migration = migration;
            _InfraEstrutctureType = InfraEstrutctureType;
        }
        public SourceCodeInfraestructureDependencInjectionInjectionMigration(Migration.MigrationBase migration) : base()
        {
            _migration = migration;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using Shered.Services;");
            sb.AppendLine("using RepositoryInterfaces.Services;");
            sb.AppendLine("using Command.Patterns;");
            sb.AppendLine("using Command.Interfaces;");
            sb.AppendLine("using RepositoryInterfaces.Patterns.Saga;");
            sb.AppendLine("using Command.Receivers.Migration.Saga;");
            sb.AppendLine("using Command.Patterns.OutBox;");
            sb.AppendLine("using Command.Receivers;");

            sb.AppendLine("using RepositoryInterfaces.Patterns.UnitOfWork;");
            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using Aplication.Interfaces.Services;");






            sb.AppendLine("namespace Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class DependencInjection");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapDependencInjection(WebApplicationBuilder builder)");
            sb.AppendLine("{");

            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                    builder.Services.AddScoped<UnitOfWork>();");
            sb.AppendLine("                    builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork>(sp =>");
            sb.AppendLine("                        new InstrumentedUnitOfWork(");
            sb.AppendLine("                            sp.GetRequiredService<UnitOfWork>(),");
            sb.AppendLine("                            sp.GetRequiredService<Dominio.Interfaces.ILogger>(),");
            sb.AppendLine("                            sp.GetRequiredService<IExecutionContext>()");
            sb.AppendLine("                        ));");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));");
            sb.AppendLine("                    builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();");
            sb.AppendLine("                    builder.Services.AddTransient<Dominio.Interfaces.ILogger, Shered.Logger.Logger>();");
            sb.AppendLine("                    builder.Services.AddTransient<ISagaExecutor, SagaExecutor>();");
            sb.AppendLine("                    // pendencia: a configuracao de saga nao deve depender de Project no motor; essa decisao precisa vir do Studio/contexto da DSL.");
            sb.AppendLine("                    builder.Services.AddScoped<OutboxService>();");
            sb.AppendLine("");
        

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



            var sagas = _migration.UseCaseGroup
                .SelectMany(group => group.UseCaseSubGroup)
                .SelectMany(subGroup => subGroup.Saga)
                .ToList();

            if (sagas.Any())
            {
                foreach (var saga in sagas)
                {
                    // pendencia: separar dependencias entre projetos de Studio quando houver mais de um contexto ativo; hoje a geracao de DI de saga pode puxar registries de outro projeto.
                    // pendencia: a decisao agora vem da DSL; o motor so inclui saga quando o modelo a declara. Ainda falta separar melhor o catalogo de aplicacoes.

                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceDominioSaga}.{saga.Name.SourceType()}Saga>();");
                    sb.AppendLine($"builder.Services.AddTransient<{CQRSParam.I.NameSpaceSagaHandlerResolver}.{saga.Name.SourceType()}SagaHandlerResolver>();");

                    foreach (var stepGroup in saga.SagaStepGroup)
                    {
                        foreach (var step in stepGroup.Steps)
                        {
                            sb.AppendLine($"builder.Services.AddTransient<{$"{step.Name.SourceType()}Handler"}>();");
                        }
                    }
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
                            SourceCodeAplicationHandlesAndResolvers strategys = new SourceCodeAplicationHandlesAndResolvers(useCase, strategy, paths, ref CodigoGerado, CommandType.UseCaseCommandHandler);
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




            //UseCaseCommand _Method = new UseCaseCommand($"{this.UseCaseSubGroup.Last().Saga.Last().SagaStepGroup.Last().LastStep.Name._value}{"OutBoxPollingWorker"}");


            var exchanges = new Dictionary<string, ExchangeDefinition>();

            foreach (var group in _migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var saga in subGroup.Saga)
                    {
                        foreach (var stepGroup in saga.SagaStepGroup)
                        {
                            foreach (var step in stepGroup.Steps)
                            {
                                var topologies = step.LstQueueTopology;

                                if (topologies == null || !topologies.Any())
                                    continue;

                                foreach (var topology in topologies)
                                {
                                    if (topology.Exchanges == null)
                                        continue;

                                    foreach (var ex in topology.Exchanges)
                                    {
                                        if (!exchanges.TryGetValue(ex.Name, out var existing))
                                        {
                                            existing = new ExchangeDefinition
                                            {
                                                Name = ex.Name,
                                                Type = ex.Type,
                                                Bindings = new List<QueueBindingDefinition>()
                                            };

                                            exchanges.Add(ex.Name, existing);
                                        }

                                        foreach (var bind in ex.Bindings)
                                        {
                                            // evita duplicação
                                            if (!existing.Bindings.Any(b =>
                                                b.QueueName == bind.QueueName &&
                                                b.RoutingKey == bind.RoutingKey))
                                            {
                                                existing.Bindings.Add(new QueueBindingDefinition
                                                {
                                                    QueueName = bind.QueueName,
                                                    RoutingKey = bind.RoutingKey
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            sb.AppendLine("public static Command.Interfaces.Patterns.Queue.QueueTopology GetQueueTopology()");
            sb.AppendLine("{");

            sb.AppendLine("return new Command.Interfaces.Patterns.Queue.QueueTopology");
            sb.AppendLine("{");
            sb.AppendLine("    Exchanges = new List<Command.Interfaces.Patterns.Queue.ExchangeDefinition>");
            sb.AppendLine("    {");

            foreach (var ex in exchanges.Values)
            {
                sb.AppendLine("        new Command.Interfaces.Patterns.Queue.ExchangeDefinition");
                sb.AppendLine("        {");
                sb.AppendLine($"            Name = \"{ex.Name}\",");
                sb.AppendLine($"            Type = \"{ex.Type}\",");
                sb.AppendLine("            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>");
                sb.AppendLine("            {");

                foreach (var bind in ex.Bindings)
                {
                    sb.AppendLine("                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition");
                    sb.AppendLine("                {");
                    sb.AppendLine($"                    QueueName = \"{bind.QueueName}\",");
                    sb.AppendLine($"                    RoutingKey = \"{bind.RoutingKey}\"");
                    sb.AppendLine("                },");
                }

                sb.AppendLine("            }");
                sb.AppendLine("        },");
            }

            sb.AppendLine("    }");
            sb.AppendLine("};");
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
