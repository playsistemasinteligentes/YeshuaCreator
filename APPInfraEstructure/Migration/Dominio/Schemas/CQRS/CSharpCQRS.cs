using Dominio.Migration;
using Dominio.Saga.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Dominio.TiposPrimitivos;
using Interfaces.Schemas;
using Interfaces.Schemas.CQRS;
using Microsoft.VisualBasic.FileIO;
using Migration.Dominio.Schemas.CQRS;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class CSharpCQRS : ICSharpCQRS
    {
        public CSharpCQRS(string name, string solutionDirectory)
        {
            _name = name;
            _solutionDirectory = solutionDirectory;
        }

        public string _name { get; set; }
        public string _solutionDirectory { get; set; }

        public void AppAplicationGenerateCommand(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppAplicationGenerateCommandCommands(Migration.MigrationBase migration)
        {

            #region Migrations 
            // crud 
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandCommandsCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(entity, CommandType.Crud, CQRSParam.I.NameSpaceCommandWrite, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }
            // Read form sorche
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandCommandsRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(entity, CommandType.Read, CQRSParam.I.NameSpaceCommandRead, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }
            // Read FKs
            foreach (var entity in migration.Entitys)
            {
                foreach (var colunm in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    var filePath = Path.Combine(GetPathAppAplicationCommandCommandsRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{colunm.Name}Commands.cs");
                    var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{colunm.Name}Commands.cs");
                    var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(entity, CommandType.ReadFK, CQRSParam.I.NameSpaceCommandRead, colunm.Name);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                }
            }

            foreach (var entity in migration.Entitys)
            {
                foreach (var colunm in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    var filePath = Path.Combine(GetPathAppAplicationCommandCommandsRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{colunm.Name}Commands.cs");
                    var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{colunm.Name}Commands.cs");
                    var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(entity, CommandType.ReadFK, CQRSParam.I.NameSpaceCommandRead, colunm.Name);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                }
            }


            foreach (var _entity in migration.Entitys)
            {
                foreach (var query in _entity.Queries.OfType<IQueryWithMeta>())
                {
                    foreach (var wh in query.Meta.WhereParameters)
                    {
                        Dominio.Schemas.CQRS.Abstraction.Command command = new Dominio.Schemas.CQRS.Abstraction.Command();
                        command.Namespace = CQRSParam.I.NameSpaceCommandRead;
                        command.Name = $"{_entity.EntityName}{wh.Key}";
                        command.Inherits = "ICommandRead";

                        Dominio.Schemas.CQRS.Abstraction.CommandField field = new Dominio.Schemas.CQRS.Abstraction.CommandField();
                        foreach (var cond in wh.Value)
                        {
                            field = new Dominio.Schemas.CQRS.Abstraction.CommandField();
                            field.TypeField = cond.FieldType;
                            field.Name = cond.Field;
                            command.Fields.Add(field);
                        }

                        var filePath = Path.Combine(GetPathAppAplicationCommandCommandsRead("Migration"), $"{_entity.EntityName}\\{_entity.EntityName}{wh.Key}Commands.cs");
                        var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsRead("Custon"), $"{_entity.EntityName}\\{_entity.EntityName}{wh.Key}Commands.cs");
                        var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(command);
                        sourceCodeMigration.WriteCode(_entity, filePath, filePathCuston);

                    }

                    foreach (var wh in query.Meta.WhereContextParameters)
                    {
                        Dominio.Schemas.CQRS.Abstraction.Command command = new Dominio.Schemas.CQRS.Abstraction.Command();
                        command.Namespace = CQRSParam.I.NameSpaceCommandRead;
                        command.Name = $"{_entity.EntityName}{wh.Key}";
                        command.Inherits = "ICommandRead";

                        Dominio.Schemas.CQRS.Abstraction.CommandField field = new Dominio.Schemas.CQRS.Abstraction.CommandField();
                        //foreach (var cond in wh.Value)
                        //{
                        //field = new Dominio.Schemas.CQRS.Abstraction.CommandField();
                        //field.TypeField = cond.FieldType;
                        //field.Name = cond.Field;
                        //command.Fields.Add(field);
                        //}

                        var filePath = Path.Combine(GetPathAppAplicationCommandCommandsRead("Migration"), $"{_entity.EntityName}\\{_entity.EntityName}{wh.Key}Commands.cs");
                        var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsRead("Custon"), $"{_entity.EntityName}\\{_entity.EntityName}{wh.Key}Commands.cs");
                        var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(command);
                        sourceCodeMigration.WriteCode(_entity, filePath, filePathCuston);

                    }
                }
            }



            #endregion  

            foreach (var group in migration.UseCaseGroup)
            {
                string funcaoAtual = new StackTrace().GetFrame(1).GetMethod().Name;

                var filePath = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents("Migration"), $"{group.Name}\\{group.Name.SourceType()}HubCommands.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents("Custon"), $"{group.Name}\\{group.Name.SourceType()}HubCommands.cs");
                var sourceCodeMigrationHub = new SourceCodeAplicationCommandCommandsUseCaseGroup(group);
                //sourceCodeMigrationHub.WriteCode(filePath, filePathCuston);

                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    
                    foreach (var saga in subGroup.Saga)
                    {
                        foreach (var stepGroup in saga.SagaStepGroup)
                        {
                            foreach (var step in stepGroup.Steps)
                            {
                                //01// if (step.OutBoxPollingWorker != null)
                                //01// {
                                //01//     filePath = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.OutBoxPollingWorker.Name.SourceType()}Commands.cs");
                                //01//     filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.OutBoxPollingWorker.Name.SourceType()}Commands.cs");
                                //01//     sourceCodeMigrationHub = new SourceCodeAplicationCommandCommandsUseCaseGroup(step.OutBoxPollingWorker, CommandType.WorkerListenerHandler);
                                //01//     sourceCodeMigrationHub.WriteCode(null, filePath, filePathCuston);
                                //01// }
                                //01// 
                                //01// if (step.QueueListenerWorker != null)
                                //01// {
                                //01//     filePath = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.QueueListenerWorker.Name.SourceType()}Commands.cs");
                                //01//     filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.QueueListenerWorker.Name.SourceType()}Commands.cs");
                                //01//     sourceCodeMigrationHub = new SourceCodeAplicationCommandCommandsUseCaseGroup(step.QueueListenerWorker, CommandType.WorkerListenerHandler);
                                //01//     sourceCodeMigrationHub.WriteCode(null, filePath, filePathCuston);
                                //01// }
                                //01// 
                                //01// if (step.InBoxPollingWorker != null)
                                //01// {
                                //01//     filePath = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.InBoxPollingWorker.Name.SourceType()}Commands.cs");
                                //01//     filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.InBoxPollingWorker.Name.SourceType()}Commands.cs");
                                //01//     sourceCodeMigrationHub = new SourceCodeAplicationCommandCommandsUseCaseGroup(step.InBoxPollingWorker, CommandType.WorkerListenerHandler);
                                //01//     sourceCodeMigrationHub.WriteCode(null, filePath, filePathCuston);
                                //01// }
                            }
                        }
                    }

                    foreach (var method in subGroup.UseCaseCommand)
                    {
                        filePath = Path.Combine(GetPathAppAplicationCommandCommandsUseCases("Migration"), $"{group.Name}\\{subGroup.Name}\\{method.Name.SourceType()}Commands.cs");
                        filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsUseCases("Custon"), $"{group.Name}\\{subGroup.Name}\\{method.Name.SourceType()}Commands.cs");
                        sourceCodeMigrationHub = new SourceCodeAplicationCommandCommandsUseCaseGroup(method, CommandType.UseCaseCommandHandler);
                        sourceCodeMigrationHub.WriteCode(null, filePath, filePathCuston);
                    }
                }

                foreach (var agent in group.Agents)
                {
                    filePath = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents("Migration"), $"{group.Name}\\{agent.Name.SourceType()}\\{agent.Name.SourceType()}HubAgentCommands.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents("Custon"), $"{group.Name}\\{agent.Name.SourceType()}\\{agent.Name.SourceType()}HubAgentCommands.cs");
                    var sourceCodeMigrationAgent = new SourceCodeAplicationCommandCommandsHubAgents(agent);
                    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);

                    foreach (var InteractionMenu in agent.Menus)
                    {
                        foreach (var option in InteractionMenu.Options)
                        {
                            //var filePath = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents(), $"Migration\\{hub.Name}\\{agent.Name.SourceType()}\\{option.Value.SourceType()}Commands.cs");
                            //var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents(), $"Custon\\{hub.Name}\\{agent.Name.SourceType()}\\{option.Value.SourceType()}Commands.cs");
                            //var sourceCodeMigration = new SourceCodeAplicationCommandCommandsHubAgentsOptions(option.Key, option.Value);
                            //sourceCodeMigration.WriteCode(filePath, filePathCuston);
                        }
                    }
                }
            }
        }

        public void AppAplicationGenerateCommandReceivers(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Insert}Receivers.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Insert}Receivers.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Insert, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Update}Receivers.cs");
                filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Update}Receivers.cs");
                sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Update, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Delete}Receivers.cs");
                filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Delete}Receivers.cs");
                sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Delete, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppAplicationCommandReceiversRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Read}Receivers.cs");
                filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Read}Receivers.cs");
                sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Read, CQRSParam.I.NameSpaceCommandReceiversRead, string.Empty);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    filePath = Path.Combine(GetPathAppAplicationCommandReceiversRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{column.Name}Receivers.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadFK}{column.Name}Receivers.cs");
                    sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.ReadFK, CQRSParam.I.NameSpaceCommandReceiversRead, column.Name);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                }

                foreach (var query in entity.Queries.OfType<IQueryWithMeta>())
                {

                    foreach (var where in query.Meta.WhereParameters)
                    {
                        filePath = Path.Combine(GetPathAppAplicationCommandReceiversRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadQuery}{where.Key}Receivers.cs");
                        filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadQuery}{where.Key}Receivers.cs");
                        sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.ReadQuery, CQRSParam.I.NameSpaceCommandReceiversRead, query, where.Key);
                        sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                    }
                    foreach (var where in query.Meta.WhereContextParameters)
                    {
                        filePath = Path.Combine(GetPathAppAplicationCommandReceiversRead("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadQuery}{where.Key}Receivers.cs");
                        filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversRead("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.ReadQuery}{where.Key}Receivers.cs");
                        sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.ReadQuery, CQRSParam.I.NameSpaceCommandReceiversRead, query, where.Key);
                        sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                    }
                }
            }



            var sagas = migration.UseCaseGroup
                .SelectMany(g => g.UseCaseSubGroup)
                .SelectMany(sg => sg.Saga)
                .ToList();

            if (sagas.Count() > 0)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"SagaResolverRegistry.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"SagaResolverRegistry.cs");
                var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(sagas);
                sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston, null);
            }



            foreach (var group in migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {

                    foreach (var saga in subGroup.Saga)
                    {
                        var steps = saga.SagaStepGroup
                                    .SelectMany(g => g.Steps)
                                    .ToList();

                        if (steps != null)
                        {
                            var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"{saga.Name}\\{saga.Name}SagaHandlerResolver.cs");
                            var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"{saga.Name}\\{saga.Name}SagaHandlerResolver.cs");
                            var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(saga, steps);
                            sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);

                            filePath = Path.Combine(GetPathAppDominioSaga("Migration"), $"{saga.Name}\\{saga.Name}Saga.cs");
                            filePathCuston = Path.Combine(GetPathAppDominioSaga("Custon"), $"{saga.Name}\\{saga.Name}Saga.cs");
                            sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(saga, CommandType.SagaBase);
                            sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);

                            filePath = Path.Combine(GetPathAppDominioSaga("Migration"), $"{saga.Name}\\{saga.Name}SagaStep.cs");
                            filePathCuston = Path.Combine(GetPathAppDominioSaga("Custon"), $"{saga.Name}\\{saga.Name}SagaStep.cs");
                            sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(saga, CommandType.SagaStepBase);
                            sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);



                        }

                        foreach (var stepGroup in saga.SagaStepGroup)
                        {
                            foreach (var step in stepGroup.Steps)
                            {
                                if (step != null)
                                {
                                    var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.SagaStepUseCaseCommand.Name.SourceType()}Handler.cs");
                                    var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.SagaStepUseCaseCommand.Name.SourceType()}Handler.cs");
                                    var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(saga, step);
                                    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);
                                }

                                //if (step.OutBoxPollingWorker != null)
                                //{
                                //    var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.OutBoxPollingWorker.Name.SourceType()}Handler.cs");
                                //    var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.OutBoxPollingWorker.Name.SourceType()}Handler.cs");
                                //    var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(step.OutBoxPollingWorker,CommandType.WorkerPollingHandler);
                                //    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston, step.OutBoxPollingWorker);
                                //}
                                //
                                //if (step.QueueListenerWorker != null)
                                //{
                                //    var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.QueueListenerWorker.Name.SourceType()}Handler.cs");
                                //    var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.QueueListenerWorker.Name.SourceType()}Handler.cs");
                                //    var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(step.QueueListenerWorker, CommandType.WorkerListenerHandler);
                                //    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston, step.QueueListenerWorker);
                                //}
                                //
                                //if (step.InBoxPollingWorker != null)
                                //{
                                //    var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Migration"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.InBoxPollingWorker.Name.SourceType()}Handler.cs");
                                //    var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCasesSaga("Custon"), $"{saga.Name}\\{stepGroup.Name}\\{step.Name}\\{step.InBoxPollingWorker.Name.SourceType()}Handler.cs");
                                //    var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(step.InBoxPollingWorker, CommandType.WorkerPollingHandler);
                                //    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston, step.InBoxPollingWorker);
                                //}
                            }
                        }
                    }

                    foreach (var useCase in subGroup.UseCaseCommand)
                    {
                        // use cases 
                        var filePath = Path.Combine(GetPathAppAplicationCommandReceiversUseCases("Migration"), $"{group.Name}\\{subGroup.Name}\\{useCase.Name.SourceType()}Handler.cs");
                        var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversUseCases("Custon"), $"{group.Name}\\{subGroup.Name}\\{useCase.Name.SourceType()}Handler.cs");
                        var sourceCodeMigrationAgent = new SourceCodeAplicationHandlesAndResolvers(useCase, CommandType.UseCaseCommandHandler);
                        sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston, useCase);

                        //strategy 
                        foreach (var strategy in useCase.Estrategys)
                        {
                            var paths = new ExportPathsSourceCodeAplicationCommandReceiversUseCase
                            {
                                EnumPath = GetPathAppDominioStrategyEnum($"Migration\\{strategy.Type.Name}"),
                                InterfacePath = GetPathAppDominioStrategyInterfaces($"Migration\\{strategy.Type.Name}"),
                                ClassPath = GetPathAppInfraestructureSheredStrategy($"Migration\\{strategy.Type.Name}"),
                                CustomClassPath = GetPathAppInfraestructureSheredStrategy($"Custon\\{strategy.Type.Name}"),
                                FactoryInterfacePath = GetPathAppDominioStrategyInterfaces($"Migration\\{strategy.Type.Name}"), // candidato a aplication
                                FactoryClassPath = GetPathAppInfraestructureSheredStrategy($"Migration\\{strategy.Type.Name}"),
                                DependencyInjectionPath = GetPathAppInfraestructureSheredStrategy($"Migration\\{strategy.Type.Name}"),
                            };
                            List<CodigoGerado> CodigoGerado = new List<CodigoGerado>();
                            SourceCodeAplicationHandlesAndResolvers strategys = new SourceCodeAplicationHandlesAndResolvers(useCase, strategy, paths, ref CodigoGerado, CommandType.UseCaseCommandHandler);
                            bool contexto = false;
                            if (strategy.Type.Name == "INotification")
                                contexto = true;
                            foreach (var code in CodigoGerado.Where(x => x.CommandType != CommandType.DependencyIngection))
                                strategys.WriteCode(code.Conteudo, code.CaminhoArquivo, code.Custom, contexto);
                        }
                    }
                }
                
                foreach (var agent in group.Agents)
                {
                    var filePath = Path.Combine(GetPathAppAplicationCommandReceiversHubAgents("Migration"), $"{group.Name}\\{agent.Name}\\{agent.Name.SourceType()}{CommandType.Agent}Receivers.cs");
                    var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversHubAgents("Custon"), $"{group.Name}\\{agent.Name}\\{agent.Name.SourceType()}{CommandType.Agent}Receivers.cs");
                    var sourceCodeMigrationAgent = new SourceCodeAplicationCommandReceiversHubAgents(agent);
                    sourceCodeMigrationAgent.WriteCode(null, filePath, filePathCuston);
                }
            }
        }


        private string GetPathAppAplicationCommandCommandsHubAgents(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandCommands(), diretorioAnterior), "HubAgents");
        }
        private string GetPathAppAplicationCommandCommandsUseCases(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandCommands(), diretorioAnterior), "UseCases");
        }

        private string GetPathAppAplicationCommandCommandsSaga(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandCommands(), diretorioAnterior), "Saga");
        }

        private string GetPathAppAplicationCommandCommands()
        {
            return Path.Combine(GetPathAppAplicationCommand(), "Commands");
        }
        private string GetPathAppAplicationCommandCommandsCrud(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandCommands(), diretorioAnterior), "Crud");
        }
        private string GetPathAppAplicationCommandCommandsRead(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandCommands(), diretorioAnterior), "Read");
        }

        private string GetPathAppAplicationCommand()
        {
            return Path.Combine(GetPathAppAplication(), "Command");
        }

        private string GetPathAppAplication()
        {
            return Path.Combine(GetPathAppSolution(), "AppAplication");
        }

        public void AppAplicationGenerateCommandPartterns(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        private string GetPathAppAplicationCommandReceivers()
        {
            return Path.Combine(GetPathAppAplicationCommand(), "Receivers");
        }
        private string GetPathAppAplicationCommandReceiversCrud(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandReceivers(), diretorioAnterior), "Crud");
        }
        private string GetPathAppAplicationCommandReceiversRead(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandReceivers(), diretorioAnterior), "Read");
        }

        private string GetPathAppAplicationCommandReceiversHubAgents(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandReceivers(), diretorioAnterior), "HubAgents");
        }
        private string GetPathAppAplicationCommandReceiversUseCases(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandReceivers(), diretorioAnterior), "UseCases");
        }
        private string GetPathAppAplicationCommandReceiversUseCasesSaga(string diretorioAnterior)
        {
            return Path.Combine(Path.Combine(GetPathAppAplicationCommandReceivers(), diretorioAnterior), "Saga");
        }

        public void AppAplicationGenerateRepositoryInterfaces(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppAplicationGenerateRepositoryInterfacesRead(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"Repository\\Migration\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesRead.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"Repository\\Custon\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesRead.cs");
                var sourceCodeMigration = new SourceCodeAplicationRepositoryInterfacesReadMigration(entity);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Migration\\{entity.EntityName}\\{entity.EntityName}{CommandType.Read}DTO.cs");
                filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Custon\\{entity.EntityName}\\{entity.EntityName}{CommandType.Read}DTO.cs");
                var sourceCodeDTOMigration = new SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(entity, CommandType.Read, string.Empty);
                sourceCodeDTOMigration.WriteCode(entity, filePath, filePathCuston);

                foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Migration\\{entity.EntityName}\\{entity.EntityName}{column.Name}DTO.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Custon\\{entity.EntityName}\\{entity.EntityName}{column.Name}DTO.cs");
                    sourceCodeDTOMigration = new SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(entity, CommandType.ReadFK, column.Name);
                    sourceCodeDTOMigration.WriteCode(entity, filePath, filePathCuston);
                }


                foreach (var query in entity.Queries.OfType<IQueryWithMeta>())
                {
                    filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Migration\\{entity.EntityName}\\{entity.EntityName}{query.Meta.QueryName}DTO.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Custon\\{entity.EntityName}\\{entity.EntityName}{query.Meta.QueryName}DTO.cs");
                    sourceCodeDTOMigration = new SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(entity, CommandType.ReadQuery, query);
                    sourceCodeDTOMigration.WriteCode(entity, filePath, filePathCuston);
                }

            }
        }

        private string GetPathAppAplicationRepositoryInterfacesRead()
        {
            return Path.Combine(GetPathAppAplicationRepositoryInterfaces(), "Read");
        }

        private string GetPathAppAplicationRepositoryInterfaces()
        {
            return Path.Combine(GetPathAppAplication(), "RepositoryInterfaces");
        }

        public void AppAplicationGenerateRepositoryInterfacesWrite(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"Repository\\Migration\\{entity.EntityName}\\I{entity.EntityName}WriteRepository.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"Repository\\Custon\\{entity.EntityName}\\I{entity.EntityName}WriteRepository.cs");
                var sourceCodeMigration = new SourceCodeAplicationRepositoryInterfacesWriteMigration(entity);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }
        }

        private string GetPathAppAplicationRepositoryInterfacesWrite()
        {
            return Path.Combine(GetPathAppAplicationRepositoryInterfaces(), "Write");
        }

        public void AppDominioGenerateDominio(Migration.MigrationBase migration)
        {

        }

        private string GetPathAppDominioEntitys()
        {
            return Path.Combine(GetPathAppDominio(), "Entitys");
        }
        private string GetPathAppDominioSaga(string diretorioPosterior)
        {
            return Path.Combine(Path.Combine(GetPathAppDominio(), "Saga"), diretorioPosterior);
        }

        private string GetPathAppDominioStrategyEnum(string diretorio)
        {
            return Path.Combine(Path.Combine(GetPathAppDominio(), "Enum\\Strategy"), diretorio);
        }
        private string GetPathAppDominioStrategyInterfaces(string diretorio)
        {
            return Path.Combine(Path.Combine(GetPathAppDominio(), "Interfaces\\Strategy"), diretorio);
        }

        private string GetPathAppDominio()
        {
            return Path.Combine(GetPathAppSolution(), Path.Combine("AppDominio", "Dominio"));
        }

        private string GetPathAppSolution()
        {
            return _solutionDirectory;
        }

        public void AppDominioGenerateDominioEntitys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\I{entity.EntityName}Entity.cs");
                var filePathCuston = Path.Combine(GetPathAppDominioEntitys(), $"Custon\\{entity.EntityName}\\I{entity.EntityName}Entity.cs");
                var sourceCodeMigration = new SourceCodeEntityMigration(entity, CommandType.IEntity);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Entity.cs");
                filePathCuston = Path.Combine(GetPathAppDominioEntitys(), $"Custon\\{entity.EntityName}\\{entity.EntityName}Entity.cs");
                sourceCodeMigration = new SourceCodeEntityMigration(entity, CommandType.Entity);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}EntityDecorator.cs");
                filePathCuston = Path.Combine(GetPathAppDominioEntitys(), $"Custon\\{entity.EntityName}\\{entity.EntityName}EntityDecorator.cs");
                sourceCodeMigration = new SourceCodeEntityMigration(entity, CommandType.EntityDecorator);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Factory.cs");
                filePathCuston = Path.Combine(GetPathAppDominioEntitys(), $"Custon\\{entity.EntityName}\\{entity.EntityName}Factory.cs");
                sourceCodeMigration = new SourceCodeEntityMigration(entity, CommandType.Factory);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

            }
        }

        private void AppInternalEntitys(MigrationBase migration)
        {
            var filePath = Path.Combine(GetPathAppInfraestructure(), $"Migration\\Dominio\\ORM\\entities.cs");
            var filePathCuston = Path.Combine(GetPathAppInfraestructure(), $"Migration\\Dominio\\ORM\\Custonentities.cs");
            var sourceCodeMigration = new SourceCodeEntityInternalMigration(migration.Entitys);
            sourceCodeMigration.WriteCode(null, filePath, filePathCuston);
        }


        public void AppDominioGenerateDominioEnum(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppDominioGenerateDominioPrimitiveTypes(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppDominioGenerateDominioSpecifications(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppDominioGenerateDominioValidation(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateAPI(Migration.MigrationBase migration)
        {
            var filePath = Path.Combine(GetPathAppInfraestructureGenerateAPI(), $"Migration\\EndPoints{migration.MigrationName}.cs");
            var filePathCuston = Path.Combine(GetPathAppInfraestructureGenerateAPI(), $"Custon\\EndPoints{migration.MigrationName}.cs");
            var sourceCodeMigration = new SourceCodeInfraestructureAPIEndpointsMigration(migration);
            sourceCodeMigration.WriteCode(null, filePath, filePathCuston);

            filePath = Path.Combine(GetPathAppInfraestructureGenerateAPI(), $"Migration\\DependencInjection{migration.MigrationName}.cs");
            filePathCuston = Path.Combine(GetPathAppInfraestructureGenerateAPI(), $"Custon\\DependencInjection{migration.MigrationName}.cs");
            var sourceCodeMigrationIndependenceInjection = new SourceCodeInfraestructureDependencInjectionInjectionMigration(migration,InfraEstrutctureType.API);
            sourceCodeMigrationIndependenceInjection.WriteCode(null, filePath, filePathCuston);
        }
        public void AppInfraestructureGenerateWorker(Migration.MigrationBase migration)
        {
            var filePath = Path.Combine(GetPathAppInfraestructureGenerateWorker(), $"Migration\\DependencInjection{migration.MigrationName}.cs");
            var filePathCuston = Path.Combine(GetPathAppInfraestructureGenerateWorker(), $"Custon\\DependencInjection{migration.MigrationName}.cs");
            var sourceCodeMigrationIndependenceInjection = new SourceCodeInfraestructureDependencInjectionInjectionMigration(migration, InfraEstrutctureType.Worker);
            sourceCodeMigrationIndependenceInjection.WriteCode(null, filePath, filePathCuston);



            filePath = Path.Combine(GetPathAppInfraestructureGenerateWorker(), $"Migration\\WorkersBuilder{migration.MigrationName}.cs");
            filePathCuston = Path.Combine(GetPathAppInfraestructureGenerateWorker(), $"Custon\\WorkersBuilder{migration.MigrationName}.cs");
            var SourceCodeInfraestructureWorker = new SourceCodeInfraestructureWorker(migration);
            SourceCodeInfraestructureWorker.WriteCode(null, filePath, filePathCuston);
            
        }



        public void ModulesGenerate(Migration.MigrationBase migration)
        {
            var filePath = Path.Combine(GetPathAppInfraestructureGenerateModules(), $"Migration\\Modules{migration.MigrationName}.cs");
            var filePathCuston = Path.Combine(GetPathAppInfraestructureGenerateModules(), $"Custon\\Modules{migration.MigrationName}.cs");
            var sourceCodeMigration = new SourceCodeInfraestructureModulesMigration(migration);
            sourceCodeMigration.WriteCode(null, filePath, filePathCuston);
        }


        private string GetPathAppInfraestructureGenerateAPI()
        {
            return Path.Combine(GetPathAppInfraestructure(), "API");
        }
        private string GetPathAppInfraestructureGenerateWorker()
        {
            return Path.Combine(GetPathAppInfraestructure(), "Worker");
        }
        private string GetPathAppInfraestructureGenerateModules()
        {
            return Path.Combine(GetPathAppInfraestructure(), "API");
        }

        public void AppInfraestructureGenerateAutomacaoTest(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateMigration(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateRead(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateReadConcreteRepository(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(AppInfraestructureReadConcreteRepository(), $"Migration\\{entity.EntityName}\\{entity.EntityName}ReadRepository.cs");
                var filePathCuston = Path.Combine(AppInfraestructureReadConcreteRepository(), $"Custon\\{entity.EntityName}\\{entity.EntityName}ReadRepository.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureReadConcreteRepositoryMigration(entity, false);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                if (entity.CachedTable)
                {
                    filePath = Path.Combine(AppInfraestructureReadConcreteRepository(), $"Migration\\{entity.EntityName}\\{entity.EntityName}ReadRepositoryCacheDecorator.cs");
                    filePathCuston = Path.Combine(AppInfraestructureReadConcreteRepository(), $"Custon\\{entity.EntityName}\\{entity.EntityName}ReadRepositoryCacheDecorator.cs");
                    sourceCodeMigration = new SourceCodeInfraestructureReadConcreteRepositoryMigration(entity, true);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                }

                //filePath = Path.Combine(AppInfraestructureReadConcreteRepository(), $"{entity.EntityName}\\{entity.EntityName}ReadRepositoryCuston.cs");
                //var sourceCodeCuston = new SourceCodeInfraestructureReadConcreteRepositoryCuston(filePath, entity, true);
                //sourceCodeCuston.WriteCode();
            }
        }

        private string AppInfraestructureReadConcreteRepository()
        {
            return Path.Combine(GetPathAppInfraestructureRead(), "ConcreteRepository");
        }



        private string GetPathAppInfraestructureRead()
        {
            return Path.Combine(GetPathAppInfraestructure(), "RepositoryRead");
        }
        private string GetPathAppInfraestructureShered()
        {
            return Path.Combine(GetPathAppInfraestructure(), "Shered");
        }
        private string GetPathAppInfraestructureSheredStrategy(string directory)
        {
            return Path.Combine(Path.Combine(GetPathAppInfraestructureShered(), "Patterns\\Strategy"), directory);
        }

        private string GetPathAppInfraestructure()
        {
            return Path.Combine(GetPathAppSolution(), "APPInfraEstructure");
        }

        public void AppInfraestructureGenerateReadConcreteQuerys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}ReadQuerys.cs");
                var filePathCuston = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"Custon\\{entity.EntityName}\\{entity.EntityName}ReadQuerys.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureQueryReadMigration(entity, false);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);


                filePath = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"Migration\\{entity.EntityName}\\I{entity.EntityName}ReadQuerys.cs");
                filePathCuston = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"Custon\\{entity.EntityName}\\I{entity.EntityName}ReadQuerys.cs");
                sourceCodeMigration = new SourceCodeInfraestructureQueryReadMigration(entity, true);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }
        }

        private string GetPathAppInfraestructureReadConcreteQuerys()
        {
            return Path.Combine(GetPathAppInfraestructureRead(), "ConcreteQuerys");
        }

        public void AppInfraestructureGenerateShered(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateWrite(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppInfraestructureGenerateWriteConcreteRepository(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(AppInfraestructureWriteConcreteRepository(), $"Migration\\{entity.EntityName}\\{entity.EntityName}WriteRepository.cs");
                var filePathCuston = Path.Combine(AppInfraestructureWriteConcreteRepository(), $"Custon\\{entity.EntityName}\\{entity.EntityName}WriteRepository.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureWriteConcreteRepositoryMigration(entity);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }
        }

        private string AppInfraestructureWriteConcreteRepository()
        {
            return Path.Combine(GetPathAppInfraestructureWrite(), "ConcreteRepository");
        }

        private string GetPathAppInfraestructureWrite()
        {
            return Path.Combine(GetPathAppInfraestructure(), "RepositoryWrite");
        }

        public void AppInfraestructureGenerateWriteConcreteQuerys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppInfraestructureWriteConcreteQuerys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}WriteQuerys.cs");
                var filePathCuston = Path.Combine(GetPathAppInfraestructureWriteConcreteQuerys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}WriteQuerys.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureQueryWriteMigration(entity, false);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);


                filePath = Path.Combine(GetPathAppInfraestructureWriteConcreteQuerys(), $"Migration\\{entity.EntityName}\\I{entity.EntityName}WriteQuerys.cs");
                filePathCuston = Path.Combine(GetPathAppInfraestructureWriteConcreteQuerys(), $"Migration\\{entity.EntityName}\\I{entity.EntityName}WriteQuerys.cs");
                sourceCodeMigration = new SourceCodeInfraestructureQueryWriteMigration(entity, true);
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);



                //filePath = Path.Combine(GetPathAppDominioDominio(), $"{entity.EntityName}\\{entity.EntityName}WriteQuerysCuston.cs");
                //var sourceCodeCuston = new SourceCodeInfraestructureWriteQuerysCuston(filePath, entity, true);
                //sourceCodeCuston.WriteCode();
            }
        }

        private string GetPathAppInfraestructureWriteConcreteQuerys()
        {
            return Path.Combine(GetPathAppInfraestructureWrite(), "ConcreteQuerys");
        }

        public void AppSolutionGenerate(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void CodeGenaration(Migration.MigrationBase migration)
        {
            ///////////AppSolutionGenerate(migration);

            AppInfraestructureGenerateAPI(migration);
            AppInfraestructureGenerateWorker(migration);
            
            ModulesGenerate(migration);

            ///////////AppInfraestructureGenerateMigration(migration);

            ///////////AppInfraestructureGenerateRead(migration);
            AppInfraestructureGenerateReadConcreteRepository(migration);
            AppInfraestructureGenerateReadConcreteQuerys(migration);

            ///////////AppInfraestructureGenerateShered(migration);

            ///////////AppInfraestructureGenerateWrite(migration);
            AppInfraestructureGenerateWriteConcreteRepository(migration);
            AppInfraestructureGenerateWriteConcreteQuerys(migration);

            ///////////AppInfraestructureGenerateAutomacaoTest(migration);

            AppAplicationGenerateCommandReceivers(migration);
            ///////////AppAplicationGenerateCommandPartterns(migration);
            AppAplicationGenerateCommandCommands(migration);
            ///////////AppAplicationGenerateCommand(migration);

            ///////////AppAplicationGenerateRepositoryInterfaces(migration);
            AppAplicationGenerateRepositoryInterfacesRead(migration);
            AppAplicationGenerateRepositoryInterfacesWrite(migration);

            //AppDominioGenerateDominio(migration);
            AppDominioGenerateDominioEntitys(migration);
            //AppDominioGenerateDominioEnum(migration);
            //AppDominioGenerateDominioPrimitiveTypes(migration);
            //AppDominioGenerateDominioSpecifications(migration);
            //AppDominioGenerateDominioValidation(migration);

            AppInternalEntitys(migration);

        }
    }
}
