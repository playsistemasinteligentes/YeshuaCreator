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
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Dapper.SqlMapper;
using static Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class CSharpCQRS : ICSharpCQRS
    {
        public CSharpCQRS(
            string name,
            string solutionDirectory,
            string? studioProjectName = null)
        {
            _name = name;
            _solutionDirectory = solutionDirectory;
            _studioProjectName = studioProjectName;
        }

        public string _name { get; set; }
        public string _solutionDirectory { get; set; }
        private readonly string? _studioProjectName;

        public void AppAplicationGenerateCommand(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppAplicationGenerateCommandCommands(Migration.MigrationBase migration)
        {

            #region Migrations 
            // crud 
            foreach (var entity in migration.Entitys.Where(x => !x.IsFromView))
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
                SourceCodeAplicationCommandReceiversMigration sourceCodeMigration;
                string filePath;
                string filePathCuston;

                if (!entity.IsFromView)
                {
                    filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Insert}Receivers.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Insert}Receivers.cs");
                    sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Insert, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                    filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Update}Receivers.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Update}Receivers.cs");
                    sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Update, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);

                    filePath = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Migration"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Delete}Receivers.cs");
                    filePathCuston = Path.Combine(GetPathAppAplicationCommandReceiversCrud("Custon"), $"{entity.EntityName}\\{entity.EntityName}{CommandType.Delete}Receivers.cs");
                    sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity, CommandType.Delete, CQRSParam.I.NameSpaceCommandReceiversWrite, string.Empty);
                    sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
                }

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

                var sagaWorkerPath = Path.Combine(GetPathAppAplicationCommandSagaPatterns("Migration"), "SagaWorkerCommandHandler.cs");
                var sagaWorkerCustonPath = Path.Combine(GetPathAppAplicationCommandSagaPatterns("Custon"), "SagaWorkerCommandHandler.cs");
                new SourceCodeApplicationSagaWorker(false).WriteCode(null, sagaWorkerPath, sagaWorkerCustonPath);

                var sagaInboxWorkerPath = Path.Combine(GetPathAppAplicationCommandSagaPatterns("Migration"), "SagaInboxWorkerCommandHandler.cs");
                var sagaInboxWorkerCustonPath = Path.Combine(GetPathAppAplicationCommandSagaPatterns("Custon"), "SagaInboxWorkerCommandHandler.cs");
                new SourceCodeApplicationSagaWorker(true).WriteCode(null, sagaInboxWorkerPath, sagaInboxWorkerCustonPath);
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
            return Path.Combine(GetPathAppAplication(), GetApplicationCommandProjectName());
        }

        private string GetPathAppAplicationCommandSagaPatterns(string directory)
        {
            return Path.Combine(GetPathAppAplicationCommand(), "Patterns", directory, "Saga");
        }

        private string GetPathAppAplication()
        {
            return Path.Combine(GetPathAppSolution(), "src", "CQRS", "Application");
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
            return Path.Combine(GetPathAppAplication(), GetApplicationRepositoryInterfacesProjectName());
        }

        public void AppAplicationGenerateRepositoryInterfacesWrite(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys.Where(x => !x.IsFromView))
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
        private string GetPathAppDominioBehaviors()
        {
            return Path.Combine(GetPathAppDominio(), "Behaviors");
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
            return Path.Combine(
                GetPathAppSolution(),
                "src",
                "CQRS",
                "Domain",
                GetApplicationDomainProjectName());
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

                filePath = Path.Combine(GetPathAppDominioBehaviors(), $"Migration\\{entity.EntityName}\\{entity.EntityName}DomainBehavior.cs");
                filePathCuston = Path.Combine(GetPathAppDominioBehaviors(), $"Custon\\{entity.EntityName}\\{entity.EntityName}DomainBehavior.cs");
                var sourceCodeDomainBehavior = new SourceCodeDomainBehaviorMigration(entity);
                sourceCodeDomainBehavior.WriteCode(entity, filePath, filePathCuston);

            }
        }

        private void AppInternalEntitys(MigrationBase migration)
        {
            // pendencia: separar o dicionario das migrations internas da Engine do dicionario do aplicativo.
            // observacao: durante o bootstrap a Engine ainda mantem esta copia; cada Studio recebe sua copia propria abaixo.
            var filePath = Path.Combine(GetPathEngineDominioOrm(), "entities.cs");
            var filePathCuston = Path.Combine(GetPathEngineDominioOrm(), "Custonentities.cs");
            var sourceCodeMigration = new SourceCodeEntityInternalMigration(migration.Entitys);
            sourceCodeMigration.WriteCode(null, filePath, filePathCuston);
        }

        public void AppStudioGenerateEntityDictionary(MigrationBase migration)
        {
            if (string.IsNullOrWhiteSpace(_studioProjectName))
                return;

            var studioProjectName = _studioProjectName.Trim();
            var studioProjectDirectory = Path.Combine(
                GetPathAppSolution(),
                "src",
                "Studio",
                studioProjectName);
            var studioProjectPath = Path.Combine(
                studioProjectDirectory,
                $"{studioProjectName}.csproj");

            if (!File.Exists(studioProjectPath))
            {
                throw new InvalidOperationException(
                    $"O projeto Studio '{studioProjectPath}' nao foi encontrado. " +
                    "Informe o nome exato do projeto para gerar o dicionario local.");
            }

            var filePath = Path.Combine(
                studioProjectDirectory,
                "Dominio",
                "ORM",
                "entities.cs");
            var namespaceName = $"{studioProjectName}.Domain.Entities";
            var sourceCodeMigration = new SourceCodeEntityInternalMigration(
                migration.Entitys,
                namespaceName);
            sourceCodeMigration.WriteMigrationCode(filePath);
        }

        private string GetPathEngineDominioOrm()
        {
            return Path.Combine(GetPathAppSolution(), "src", "Engine", "Yeshua.Engine", "Dominio", "ORM");
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
            return Path.Combine(GetPathAppInfraestructure(), GetApplicationInfrastructureApiProjectName());
        }
        private string GetPathAppInfraestructureGenerateWorker()
        {
            return Path.Combine(GetPathAppInfraestructure(), GetApplicationInfrastructureWorkerProjectName());
        }
        private string GetPathAppInfraestructureGenerateModules()
        {
            return GetPathAppInfraestructureGenerateAPI();
        }

        public void AppInfraestructureGenerateAutomacaoTest(Migration.MigrationBase migration)
        {
            EnsureIntegrationTestProjectFiles();

            var smokeEntities = migration.Entitys
                .Where(ShouldGenerateApiSmokeCrud)
                .ToList();
            var orderedEntities = OrderEntitiesForApiSmoke(smokeEntities).ToList();
            for (var index = 0; index < orderedEntities.Count; index++)
            {
                var entity = orderedEntities[index];
                var filePath = Path.Combine(GetPathTestsIntegrationApiSmoke(), $"Migration\\{entity.EntityName}\\{entity.EntityName}CrudApiSmokeTests.cs");
                var filePathCuston = Path.Combine(GetPathTestsIntegrationApiSmoke(), $"Custon\\{entity.EntityName}\\{entity.EntityName}CrudApiSmokeTests.cs");
                var sourceCodeMigration = new SourceCodeIntegrationApiSmokeCrudTestMigration(
                    entity,
                    index + 1,
                    GetApplicationIntegrationApiSmokeProjectName());
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }

            for (var index = 0; index < orderedEntities.Count; index++)
            {
                var entity = orderedEntities[index];
                var filePath = Path.Combine(GetPathTestsIntegrationApiSeed(), $"Migration\\{entity.EntityName}\\{entity.EntityName}CrudApiSeedTests.cs");
                var filePathCuston = Path.Combine(GetPathTestsIntegrationApiSeed(), $"Custon\\{entity.EntityName}\\{entity.EntityName}CrudApiSeedTests.cs");
                var sourceCodeMigration = new SourceCodeIntegrationApiSeedCrudTestMigration(
                    entity,
                    index + 1,
                    GetApplicationIntegrationApiSeedProjectName());
                sourceCodeMigration.WriteCode(entity, filePath, filePathCuston);
            }

            WriteIntegrationApiSmokeSuiteFile(orderedEntities);
            WriteIntegrationApiSeedSuiteFile(orderedEntities);
            WritePostBuildManifest();
        }

        private void WritePostBuildManifest()
        {
            // <operational-spec>
            // standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD
            // gates: G2,G7
            // depths: D0
            // severities: notApplicable
            // modes: Live
            // dataClassification: SafeMetadata
            // identities: Application,Environment,Version
            // technicalOutcomes: Success,Failure
            // businessOutcomes: notApplicable
            // evidence: PostBuildManifest
            // </operational-spec>
            var smokeProjectName = GetApplicationIntegrationApiSmokeProjectName();
            var relativeProjectDirectory = Path.Combine("tests", "CQRS", smokeProjectName)
                .Replace('\\', '/');
            var content = $$"""
            {
              "application": "{{GetApplicationName()}}",
              "environment": "Production",
              "baseUrlSettingsFile": "{{relativeProjectDirectory}}/appsettings.json",
              "smokeProject": "{{relativeProjectDirectory}}/{{smokeProjectName}}.csproj",
              "apiIdentityPath": "yapi/operational/identity",
              "apiLivenessPath": "yapi/health/live",
              "apiReadinessPath": "yapi/health/ready",
              "workerLivenessPath": "yworker/health/live",
              "workerReadinessPath": "yworker/health/ready",
              "_yeshua": {
                "artifact": "GENERATED_REGENERABLE",
                "ownership": "ENGINE",
                "sourceOfTruth": "DSL_OR_ENGINE_TEMPLATE"
              },
              "_operationalSpecification": {
                "standard": "OPERATIONAL_SUPPORT_ADOPTION_STANDARD",
                "gates": ["G2", "G7"],
                "depths": ["D0"],
                "severities": ["notApplicable"],
                "modes": ["Live"],
                "dataClassification": ["SafeMetadata"],
                "identities": ["Application", "Environment", "Version"],
                "technicalOutcomes": ["Success", "Failure"],
                "businessOutcomes": ["notApplicable"],
                "evidence": "PostBuildManifest"
              }
            }
            """;

            WriteText(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "Migration", "PostBuildManifest.json"),
                content);
        }

        private static bool ShouldGenerateApiSmokeCrud(Entity entity)
        {
            return !entity.IsFromView &&
                !string.Equals(entity.EntityName, "yTenant", StringComparison.OrdinalIgnoreCase);
        }

        private static IEnumerable<Entity> OrderEntitiesForApiSmoke(IEnumerable<Entity> entities)
        {
            var ordered = new List<Entity>();
            var remaining = entities
                .GroupBy(entity => entity.EntityName, StringComparer.OrdinalIgnoreCase)
                .Select(group => group.First())
                .ToList();
            var entityNames = remaining.Select(entity => entity.EntityName).ToHashSet(StringComparer.OrdinalIgnoreCase);

            while (remaining.Count > 0)
            {
                var progressed = false;

                foreach (var entity in remaining.ToList())
                {
                    var hasPendingDependency = GetApiSmokeDependencies(entity, entityNames)
                        .Any(dependency => remaining.Any(candidate =>
                            string.Equals(candidate.EntityName, dependency, StringComparison.OrdinalIgnoreCase)));

                    if (hasPendingDependency)
                        continue;

                    ordered.Add(entity);
                    remaining.Remove(entity);
                    progressed = true;
                }

                if (!progressed)
                {
                    ordered.AddRange(remaining);
                    break;
                }
            }

            return ordered;
        }

        private static IEnumerable<string> GetApiSmokeDependencies(Entity entity, ISet<string> entityNames)
        {
            return entity.AddColumns
                .Where(column =>
                    column.IsFK &&
                    !column.IsBackEndField &&
                    !column.IsValueDefault &&
                    !string.IsNullOrWhiteSpace(column.FkEntityName) &&
                    !string.Equals(column.FkEntityName, entity.EntityName, StringComparison.OrdinalIgnoreCase) &&
                    entityNames.Contains(column.FkEntityName))
                .Select(column => column.FkEntityName)
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        private void WriteIntegrationApiSmokeSuiteFile(IReadOnlyList<Entity> orderedEntities)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// <yeshua>");
            sb.AppendLine("// artifact: GENERATED_REGENERABLE");
            sb.AppendLine("// createdBy: DSL");
            sb.AppendLine("// ownership: ENGINE");
            sb.AppendLine("// editable: false");
            sb.AppendLine("// regeneration: REPLACE");
            sb.AppendLine("// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE");
            sb.AppendLine("// generator: Dominio.Schemas.CQRS.CSharpCQRS.WriteIntegrationApiSmokeSuiteFile");
            sb.AppendLine("// </yeshua>");
            sb.AppendLine();
            sb.AppendLine("// <operational-spec>");
            sb.AppendLine("// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD");
            sb.AppendLine("// gates: G7");
            sb.AppendLine("// depths: D0");
            sb.AppendLine("// severities: notApplicable");
            sb.AppendLine("// modes: Live");
            sb.AppendLine("// dataClassification: OperationalData");
            sb.AppendLine("// identities: Application,Environment,Version");
            sb.AppendLine("// technicalOutcomes: Success,Failure");
            sb.AppendLine("// businessOutcomes: notApplicable");
            sb.AppendLine("// evidence: TechnicalSmoke");
            sb.AppendLine("// </operational-spec>");
            sb.AppendLine();
            sb.AppendLine($"namespace {GetApplicationIntegrationApiSmokeProjectName()}.Migration;");
            sb.AppendLine();
            sb.AppendLine("[Trait(\"TestPurpose\", \"TechnicalSmoke\")]");
            sb.AppendLine("[Trait(\"SpecificationGate\", \"G7\")]");
            sb.AppendLine("[Trait(\"DiagnosticDepth\", \"D0\")]");
            sb.AppendLine("[Trait(\"ExecutionMode\", \"Live\")]");
            sb.AppendLine("public sealed class ApiSmokeCrudSuiteTests");
            sb.AppendLine("{");
            sb.AppendLine("    [IntegrationFact]");
            sb.AppendLine("    public async Task Crud_smoke_suite_should_run_entities_in_dependency_order()");
            sb.AppendLine("    {");
            sb.AppendLine("        ApiSmokeTestContext.Clear();");
            sb.AppendLine();
            sb.AppendLine("        var deleteSteps = new Stack<Func<Task>>();");
            sb.AppendLine("        var deleteErrors = new List<Exception>();");
            sb.AppendLine("        Exception? testError = null;");
            sb.AppendLine();
            sb.AppendLine("        try");
            sb.AppendLine("        {");

            for (var index = 0; index < orderedEntities.Count; index++)
            {
                var entity = orderedEntities[index];
                var variableName = $"step{(index + 1).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                sb.AppendLine($"            var {variableName} = new {entity.EntityName}.{entity.EntityName}CrudApiSmokeTests();");
                sb.AppendLine($"            deleteSteps.Push({variableName}.DeleteAsync);");
                sb.AppendLine($"            await {variableName}.ExecuteAsync();");
                sb.AppendLine();
            }

            sb.AppendLine("        }");
            sb.AppendLine("        catch (Exception ex)");
            sb.AppendLine("        {");
            sb.AppendLine("            testError = ex;");
            sb.AppendLine("        }");
            sb.AppendLine("        finally");
            sb.AppendLine("        {");
            sb.AppendLine("            while (deleteSteps.Count > 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                try");
            sb.AppendLine("                {");
            sb.AppendLine("                    await deleteSteps.Pop()();");
            sb.AppendLine("                }");
            sb.AppendLine("                catch (Exception ex)");
            sb.AppendLine("                {");
            sb.AppendLine("                    deleteErrors.Add(ex);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        if (testError is not null)");
            sb.AppendLine("            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(testError).Throw();");
            sb.AppendLine();
            sb.AppendLine("        if (deleteErrors.Count > 0)");
            sb.AppendLine("            throw new AggregateException(\"One or more API smoke cleanup steps failed.\", deleteErrors);");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            WriteText(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "Migration", "ApiSmokeCrudSuiteTests.cs"),
                sb.ToString());
        }

        private void WriteIntegrationApiSeedSuiteFile(IReadOnlyList<Entity> orderedEntities)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// <yeshua>");
            sb.AppendLine("// artifact: GENERATED_REGENERABLE");
            sb.AppendLine("// createdBy: DSL");
            sb.AppendLine("// ownership: ENGINE");
            sb.AppendLine("// editable: false");
            sb.AppendLine("// regeneration: REPLACE");
            sb.AppendLine("// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE");
            sb.AppendLine("// generator: Dominio.Schemas.CQRS.CSharpCQRS.WriteIntegrationApiSeedSuiteFile");
            sb.AppendLine("// </yeshua>");
            sb.AppendLine();
            sb.AppendLine("// <operational-spec>");
            sb.AppendLine("// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD");
            sb.AppendLine("// gates: G7");
            sb.AppendLine("// depths: D0");
            sb.AppendLine("// severities: notApplicable");
            sb.AppendLine("// modes: Live");
            sb.AppendLine("// dataClassification: OperationalData");
            sb.AppendLine("// identities: Application,Environment,Version");
            sb.AppendLine("// technicalOutcomes: Success,Failure");
            sb.AppendLine("// businessOutcomes: notApplicable");
            sb.AppendLine("// evidence: TestDataSeed");
            sb.AppendLine("// </operational-spec>");
            sb.AppendLine();
            sb.AppendLine($"namespace {GetApplicationIntegrationApiSeedProjectName()}.Migration;");
            sb.AppendLine();
            sb.AppendLine("[Trait(\"TestPurpose\", \"TestDataSeed\")]");
            sb.AppendLine("[Trait(\"SpecificationGate\", \"G7\")]");
            sb.AppendLine("[Trait(\"DiagnosticDepth\", \"D0\")]");
            sb.AppendLine("[Trait(\"ExecutionMode\", \"Live\")]");
            sb.AppendLine("public sealed class ApiSeedCrudSuiteTests");
            sb.AppendLine("{");
            sb.AppendLine("    [IntegrationFact]");
            sb.AppendLine("    public async Task Crud_seed_suite_should_create_entities_in_dependency_order_without_cleanup()");
            sb.AppendLine("    {");
            sb.AppendLine("        ApiSeedTestContext.Clear();");
            sb.AppendLine();

            for (var index = 0; index < orderedEntities.Count; index++)
            {
                var entity = orderedEntities[index];
                var variableName = $"step{(index + 1).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                sb.AppendLine($"        var {variableName} = new {entity.EntityName}.{entity.EntityName}CrudApiSeedTests();");
                sb.AppendLine($"        await {variableName}.ExecuteAsync();");
                sb.AppendLine();
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            WriteText(
                Path.Combine(GetPathTestsIntegrationApiSeed(), "Migration", "ApiSeedCrudSuiteTests.cs"),
                sb.ToString());
        }

        private void EnsureIntegrationTestProjectFiles()
        {
            var testKitProjectPath = Path.Combine(
                GetPathTestsIntegrationApiTestKit(),
                "Yeshua.CQRS.Tests.Integration.Api.TestKit.csproj");
            var smokeProjectName = GetApplicationIntegrationApiSmokeProjectName();
            var smokeProjectPath = Path.Combine(
                GetPathTestsIntegrationApiSmoke(),
                $"{smokeProjectName}.csproj");
            var seedProjectName = GetApplicationIntegrationApiSeedProjectName();
            var seedProjectPath = Path.Combine(
                GetPathTestsIntegrationApiSeed(),
                $"{seedProjectName}.csproj");

            WriteTextIfMissing(
                testKitProjectPath,
                @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""xunit"" Version=""2.5.3"" />
  </ItemGroup>

</Project>");

            WriteTextIfMissing(
                smokeProjectPath,
                @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""coverlet.collector"" Version=""6.0.0"" />
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.8.0"" />
    <PackageReference Include=""xunit"" Version=""2.5.3"" />
    <PackageReference Include=""xunit.runner.visualstudio"" Version=""2.5.3"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\Yeshua.CQRS.Tests.Integration.Api.TestKit\Yeshua.CQRS.Tests.Integration.Api.TestKit.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <Using Include=""Xunit"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""appsettings*.json"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update=""xunit.runner.json"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>");

            WriteTextIfMissing(
                seedProjectPath,
                @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""coverlet.collector"" Version=""6.0.0"" />
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.8.0"" />
    <PackageReference Include=""xunit"" Version=""2.5.3"" />
    <PackageReference Include=""xunit.runner.visualstudio"" Version=""2.5.3"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\Yeshua.CQRS.Tests.Integration.Api.TestKit\Yeshua.CQRS.Tests.Integration.Api.TestKit.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <Using Include=""Xunit"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""appsettings*.json"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update=""xunit.runner.json"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "GlobalUsings.cs"),
                "global using Yeshua.CQRS.Tests.Integration.Api.TestKit;");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSeed(), "GlobalUsings.cs"),
                "global using Yeshua.CQRS.Tests.Integration.Api.TestKit;");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "AssemblyInfo.cs"),
                @"using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true, MaxParallelThreads = 1)]");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSeed(), "AssemblyInfo.cs"),
                @"using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true, MaxParallelThreads = 1)]");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "xunit.runner.json"),
                @"{
  ""parallelizeAssembly"": false,
  ""parallelizeTestCollections"": false,
  ""maxParallelThreads"": 1
}");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSeed(), "xunit.runner.json"),
                @"{
  ""parallelizeAssembly"": false,
  ""parallelizeTestCollections"": false,
  ""maxParallelThreads"": 1
}");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSmoke(), "appsettings.json"),
                @"{
  ""TestSettings"": {
    ""BaseUrl"": ""https://localhost:7214/"",
    ""LoginPath"": ""yapi/login"",
    ""Login"": """",
    ""Password"": """",
    ""TimeoutSeconds"": 100
  }
}");

            WriteTextIfMissing(
                Path.Combine(GetPathTestsIntegrationApiSeed(), "appsettings.json"),
                @"{
  ""TestSettings"": {
    ""BaseUrl"": ""https://localhost:7214/"",
    ""LoginPath"": ""yapi/login"",
    ""Login"": """",
    ""Password"": """",
    ""TimeoutSeconds"": 100
  }
}");

            AddProjectToSolution(testKitProjectPath, "Yeshua.Tests");
            AddProjectToSolution(smokeProjectPath, "Yeshua.Tests");
            AddProjectToSolution(seedProjectPath, "Yeshua.Tests");
        }

        private void WriteTextIfMissing(string filePath, string content)
        {
            if (File.Exists(filePath))
                return;

            WriteText(filePath, content);
        }

        private void WriteText(string filePath, string content)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private void EnsureApplicationHostMyConfig(string projectDirectory)
        {
            var myConfig = TryReadStudioHostMyConfig();
            if (myConfig is null)
                return;

            var appSettingsPath = Path.Combine(projectDirectory, "appsettings.json");
            JsonObject root;

            if (File.Exists(appSettingsPath))
            {
                root = JsonNode.Parse(File.ReadAllText(appSettingsPath)) as JsonObject
                    ?? throw new InvalidOperationException(
                        $"O arquivo '{appSettingsPath}' nao possui um objeto JSON valido.");
            }
            else
            {
                root = new JsonObject();
            }

            root["MyConfig"] = myConfig;
            WriteText(
                appSettingsPath,
                root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
        }

        private JsonObject? TryReadStudioHostMyConfig()
        {
            if (string.IsNullOrWhiteSpace(_studioProjectName))
                return null;

            var appSettingsPath = Path.Combine(
                _solutionDirectory,
                "src",
                "Studio",
                _studioProjectName,
                "appsettings.json");

            if (!File.Exists(appSettingsPath))
                return null;

            var root = JsonNode.Parse(File.ReadAllText(appSettingsPath)) as JsonObject
                ?? throw new InvalidOperationException(
                    $"O arquivo '{appSettingsPath}' nao possui um objeto JSON valido.");

            if (root["MyConfig"] is not JsonObject myConfig)
                return null;

            var hostMyConfig = new JsonObject();
            CopyJsonProperty(myConfig, hostMyConfig, "ReadConectionString");
            CopyJsonProperty(myConfig, hostMyConfig, "WriteConectionString");

            return hostMyConfig.Count == 0 ? null : hostMyConfig;
        }

        private static void CopyJsonProperty(JsonObject source, JsonObject destination, string propertyName)
        {
            if (source[propertyName] is null)
                return;

            destination[propertyName] = JsonNode.Parse(source[propertyName]!.ToJsonString());
        }

        private string GetPathTestsIntegrationApiTestKit()
        {
            return Path.Combine(GetPathTestsCQRS(), "Yeshua.CQRS.Tests.Integration.Api.TestKit");
        }

        private string GetPathTestsIntegrationApiSmoke()
        {
            return Path.Combine(GetPathTestsCQRS(), GetApplicationIntegrationApiSmokeProjectName());
        }

        private string GetPathTestsIntegrationApiSeed()
        {
            return Path.Combine(GetPathTestsCQRS(), GetApplicationIntegrationApiSeedProjectName());
        }

        private string GetApplicationIntegrationApiSmokeProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Tests.Integration.Api.Smoke";
        }

        private string GetApplicationIntegrationApiSeedProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Tests.Integration.Api.Seed";
        }

        private string GetPathTestsCQRS()
        {
            return Path.Combine(GetPathAppSolution(), "tests", "CQRS");
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
            return Path.Combine(GetPathAppInfraestructure(), GetApplicationInfrastructureRepositoryReadProjectName());
        }
        private string GetPathAppInfraestructureShered()
        {
            return Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureSharedProjectName());
        }
        private string GetPathAppInfraestructureSheredStrategy(string directory)
        {
            return Path.Combine(Path.Combine(GetPathAppInfraestructureShered(), "Patterns\\Strategy"), directory);
        }

        private string GetPathAppInfraestructure()
        {
            return Path.Combine(GetPathAppSolution(), "src", "CQRS", "Infrastructure");
        }

        public void AppInfrastructureGenerateRuntimeIdentity()
        {
            var applicationInfrastructureSharedProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureSharedProjectName());
            var runtimeIdentityPath = Path.Combine(
                applicationInfrastructureSharedProjectDirectory,
                "Operational",
                "Migration",
                "RuntimeIdentityProvider.cs");
            new SourceCodeInfrastructureRuntimeIdentityMigration()
                .WriteGeneratedCode(runtimeIdentityPath);

            var applicationInfrastructureWorkerProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureWorkerProjectName());
            var workerReporterPath = Path.Combine(
                applicationInfrastructureWorkerProjectDirectory,
                "Migration",
                "Operational",
                "RuntimeIdentityReporter.cs");
            new SourceCodeInfrastructureWorkerRuntimeIdentityReporterMigration()
                .WriteGeneratedCode(workerReporterPath);

            EnsureRuntimeIdentityMetadata(Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureApiProjectName(),
                $"{GetApplicationInfrastructureApiProjectName()}.csproj"));
            EnsureRuntimeIdentityMetadata(Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureWorkerProjectName(),
                $"{GetApplicationInfrastructureWorkerProjectName()}.csproj"));
        }

        public void AppInfrastructureGenerateOperationalHealth()
        {
            var applicationInfrastructureWorkerProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureWorkerProjectName());
            var workerHealthPath = Path.Combine(
                applicationInfrastructureWorkerProjectDirectory,
                "Migration",
                "Operational",
                "WorkerOperationalHealth.cs");

            new SourceCodeInfrastructureWorkerOperationalHealthMigration()
                .WriteGeneratedCode(workerHealthPath);
        }

        public void AppInfrastructureGenerateOperationalControl(Migration.MigrationBase migration)
        {
            var applicationInfrastructureSharedProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                GetApplicationInfrastructureSharedProjectName());
            var statePath = Path.Combine(
                applicationInfrastructureSharedProjectDirectory,
                "Operational",
                "Migration",
                "OperationalLoggingPolicy.cs");
            new SourceCodeInfrastructureOperationalControlStateMigration(migration)
                .WriteGeneratedCode(statePath);

            foreach (var hostProjectName in new[]
                     {
                         GetApplicationInfrastructureApiProjectName(),
                         GetApplicationInfrastructureWorkerProjectName()
                     })
            {
                var synchronizerPath = Path.Combine(
                    GetPathAppInfraestructure(),
                    hostProjectName,
                    "Migration",
                    "Operational",
                    "OperationalPolicySynchronizer.cs");
                new SourceCodeInfrastructureOperationalControlSynchronizerMigration()
                    .WriteGeneratedCode(synchronizerPath);
            }
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
            foreach (var entity in migration.Entitys.Where(x => !x.IsFromView))
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
            return Path.Combine(GetPathAppInfraestructure(), GetApplicationInfrastructureRepositoryWriteProjectName());
        }

        public void AppInfraestructureGenerateWriteConcreteQuerys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys.Where(x => !x.IsFromView))
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
            var sharedDomainProjectPath = Path.Combine(
                GetPathAppSolution(),
                "src",
                "CQRS",
                "Domain",
                "Yeshua.CQRS.Domain",
                "Yeshua.CQRS.Domain.csproj");

            if (!File.Exists(sharedDomainProjectPath))
                throw new FileNotFoundException("O projeto de dominio compartilhado nao foi encontrado.", sharedDomainProjectPath);

            var applicationDomainProjectName = GetApplicationDomainProjectName();
            var applicationDomainProjectDirectory = Path.Combine(
                GetPathAppSolution(),
                "src",
                "CQRS",
                "Domain",
                applicationDomainProjectName);
            var applicationDomainProjectPath = Path.Combine(
                applicationDomainProjectDirectory,
                $"{applicationDomainProjectName}.csproj");

            if (!File.Exists(applicationDomainProjectPath))
            {
                var sharedProjectReference = Path.GetRelativePath(applicationDomainProjectDirectory, sharedDomainProjectPath);
                WriteText(
                    applicationDomainProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{sharedProjectReference}"" />
  </ItemGroup>

</Project>");
            }

            AddProjectToSolution(applicationDomainProjectPath, "Yeshua.CQRS.Domain");

            var sharedRepositoryInterfacesProjectPath = Path.Combine(
                GetPathAppAplication(),
                "Yeshua.CQRS.Application.RepositoryInterfaces",
                "Yeshua.CQRS.Application.RepositoryInterfaces.csproj");

            if (!File.Exists(sharedRepositoryInterfacesProjectPath))
            {
                throw new FileNotFoundException(
                    "O projeto RepositoryInterfaces compartilhado nao foi encontrado.",
                    sharedRepositoryInterfacesProjectPath);
            }

            var applicationRepositoryInterfacesProjectName = GetApplicationRepositoryInterfacesProjectName();
            var applicationRepositoryInterfacesProjectDirectory = Path.Combine(
                GetPathAppAplication(),
                applicationRepositoryInterfacesProjectName);
            var applicationRepositoryInterfacesProjectPath = Path.Combine(
                applicationRepositoryInterfacesProjectDirectory,
                $"{applicationRepositoryInterfacesProjectName}.csproj");

            if (!File.Exists(applicationRepositoryInterfacesProjectPath))
            {
                var sharedRepositoryInterfacesProjectReference = Path.GetRelativePath(
                    applicationRepositoryInterfacesProjectDirectory,
                    sharedRepositoryInterfacesProjectPath);
                var applicationDomainProjectReference = Path.GetRelativePath(
                    applicationRepositoryInterfacesProjectDirectory,
                    applicationDomainProjectPath);

                WriteText(
                    applicationRepositoryInterfacesProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{sharedRepositoryInterfacesProjectReference}"" />
    <ProjectReference Include=""{applicationDomainProjectReference}"" />
  </ItemGroup>

</Project>");
            }

            AddProjectToSolution(applicationRepositoryInterfacesProjectPath, "Yeshua.CQRS.Application");

            var sharedCommandProjectPath = Path.Combine(
                GetPathAppSolution(),
                "src",
                "CQRS",
                "Application",
                "Yeshua.CQRS.Application.Command",
                "Yeshua.CQRS.Application.Command.csproj");

            if (!File.Exists(sharedCommandProjectPath))
                throw new FileNotFoundException("O projeto Command compartilhado nao foi encontrado.", sharedCommandProjectPath);

            var applicationCommandProjectName = GetApplicationCommandProjectName();
            var applicationCommandProjectDirectory = Path.Combine(
                GetPathAppAplication(),
                applicationCommandProjectName);
            var applicationCommandProjectPath = Path.Combine(
                applicationCommandProjectDirectory,
                $"{applicationCommandProjectName}.csproj");

            if (!File.Exists(applicationCommandProjectPath))
            {
                var sharedCommandProjectReference = Path.GetRelativePath(
                    applicationCommandProjectDirectory,
                    sharedCommandProjectPath);
                var applicationDomainProjectReference = Path.GetRelativePath(
                    applicationCommandProjectDirectory,
                    applicationDomainProjectPath);
                var applicationRepositoryInterfacesProjectReference = Path.GetRelativePath(
                    applicationCommandProjectDirectory,
                    applicationRepositoryInterfacesProjectPath);

                WriteText(
                    applicationCommandProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
                    <ProjectReference Include=""{sharedCommandProjectReference}"" />
                    <ProjectReference Include=""{applicationDomainProjectReference}"" />
                    <ProjectReference Include=""{applicationRepositoryInterfacesProjectReference}"" />
                  </ItemGroup>

</Project>");
            }

            EnsureProjectReference(applicationCommandProjectPath, applicationRepositoryInterfacesProjectPath);
            AddProjectToSolution(applicationCommandProjectPath, "Yeshua.CQRS.Application");

            var sharedInfrastructureProjectPath = Path.Combine(
                GetPathAppInfraestructure(),
                "Yeshua.CQRS.Infrastructure.Shared",
                "Yeshua.CQRS.Infrastructure.Shared.csproj");

            if (!File.Exists(sharedInfrastructureProjectPath))
            {
                throw new FileNotFoundException(
                    "O projeto de infraestrutura compartilhada nao foi encontrado.",
                    sharedInfrastructureProjectPath);
            }

            var applicationInfrastructureSharedProjectName =
                GetApplicationInfrastructureSharedProjectName();
            var applicationInfrastructureSharedProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureSharedProjectName);
            var applicationInfrastructureSharedProjectPath = Path.Combine(
                applicationInfrastructureSharedProjectDirectory,
                $"{applicationInfrastructureSharedProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureSharedProjectPath))
            {
                var sharedInfrastructureProjectReference = Path.GetRelativePath(
                    applicationInfrastructureSharedProjectDirectory,
                    sharedInfrastructureProjectPath);
                var applicationDomainProjectReference = Path.GetRelativePath(
                    applicationInfrastructureSharedProjectDirectory,
                    applicationDomainProjectPath);
                var applicationRepositoryInterfacesProjectReference = Path.GetRelativePath(
                    applicationInfrastructureSharedProjectDirectory,
                    applicationRepositoryInterfacesProjectPath);

                WriteText(
                    applicationInfrastructureSharedProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{sharedInfrastructureProjectReference}"" />
    <ProjectReference Include=""{applicationDomainProjectReference}"" />
    <ProjectReference Include=""{applicationRepositoryInterfacesProjectReference}"" />
  </ItemGroup>

</Project>");
            }

            EnsureProjectReference(
                applicationInfrastructureSharedProjectPath,
                sharedInfrastructureProjectPath);
            EnsureProjectReference(
                applicationInfrastructureSharedProjectPath,
                applicationDomainProjectPath);
            EnsureProjectReference(
                applicationInfrastructureSharedProjectPath,
                applicationRepositoryInterfacesProjectPath);
            AddProjectToSolution(
                applicationInfrastructureSharedProjectPath,
                "Yeshua.CQRS.Infrastructure");

            var applicationInfrastructureRepositoryReadProjectName =
                GetApplicationInfrastructureRepositoryReadProjectName();
            var applicationInfrastructureRepositoryReadProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureRepositoryReadProjectName);
            var applicationInfrastructureRepositoryReadProjectPath = Path.Combine(
                applicationInfrastructureRepositoryReadProjectDirectory,
                $"{applicationInfrastructureRepositoryReadProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureRepositoryReadProjectPath))
            {
                var sharedInfrastructureProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryReadProjectDirectory,
                    sharedInfrastructureProjectPath);
                var applicationCommandProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryReadProjectDirectory,
                    applicationCommandProjectPath);
                var applicationRepositoryInterfacesProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryReadProjectDirectory,
                    applicationRepositoryInterfacesProjectPath);

                WriteText(
                    applicationInfrastructureRepositoryReadProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{sharedInfrastructureProjectReference}"" />
    <ProjectReference Include=""{applicationCommandProjectReference}"" />
    <ProjectReference Include=""{applicationRepositoryInterfacesProjectReference}"" />
  </ItemGroup>

</Project>");
            }

            EnsureProjectReference(
                applicationInfrastructureRepositoryReadProjectPath,
                sharedInfrastructureProjectPath);
            EnsureProjectReference(
                applicationInfrastructureRepositoryReadProjectPath,
                applicationCommandProjectPath);
            EnsureProjectReference(
                applicationInfrastructureRepositoryReadProjectPath,
                applicationRepositoryInterfacesProjectPath);
            AddProjectToSolution(
                applicationInfrastructureRepositoryReadProjectPath,
                "Yeshua.CQRS.Infrastructure");

            var applicationInfrastructureRepositoryWriteProjectName =
                GetApplicationInfrastructureRepositoryWriteProjectName();
            var applicationInfrastructureRepositoryWriteProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureRepositoryWriteProjectName);
            var applicationInfrastructureRepositoryWriteProjectPath = Path.Combine(
                applicationInfrastructureRepositoryWriteProjectDirectory,
                $"{applicationInfrastructureRepositoryWriteProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureRepositoryWriteProjectPath))
            {
                var sharedInfrastructureProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryWriteProjectDirectory,
                    sharedInfrastructureProjectPath);
                var applicationCommandProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryWriteProjectDirectory,
                    applicationCommandProjectPath);
                var applicationRepositoryInterfacesProjectReference = Path.GetRelativePath(
                    applicationInfrastructureRepositoryWriteProjectDirectory,
                    applicationRepositoryInterfacesProjectPath);

                WriteText(
                    applicationInfrastructureRepositoryWriteProjectPath,
                    $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""{sharedInfrastructureProjectReference}"" />
    <ProjectReference Include=""{applicationCommandProjectReference}"" />
    <ProjectReference Include=""{applicationRepositoryInterfacesProjectReference}"" />
  </ItemGroup>

</Project>");
            }

            EnsureProjectReference(
                applicationInfrastructureRepositoryWriteProjectPath,
                sharedInfrastructureProjectPath);
            EnsureProjectReference(
                applicationInfrastructureRepositoryWriteProjectPath,
                applicationCommandProjectPath);
            EnsureProjectReference(
                applicationInfrastructureRepositoryWriteProjectPath,
                applicationRepositoryInterfacesProjectPath);
            AddProjectToSolution(
                applicationInfrastructureRepositoryWriteProjectPath,
                "Yeshua.CQRS.Infrastructure");

            var applicationInfrastructureApiProjectName =
                GetApplicationInfrastructureApiProjectName();
            var applicationInfrastructureApiProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureApiProjectName);
            var applicationInfrastructureApiProjectPath = Path.Combine(
                applicationInfrastructureApiProjectDirectory,
                $"{applicationInfrastructureApiProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureApiProjectPath))
            {
                WriteText(
                    applicationInfrastructureApiProjectPath,
                    @"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.AspNetCore.Authentication.JwtBearer"" Version=""8.0.14"" />
    <PackageReference Include=""Swashbuckle.AspNetCore"" Version=""6.5.0"" />
  </ItemGroup>

</Project>");
            }

            EnsureProjectReference(
                applicationInfrastructureApiProjectPath,
                applicationInfrastructureSharedProjectPath);
            RemoveProjectReference(
                applicationInfrastructureApiProjectPath,
                sharedInfrastructureProjectPath);
            EnsureProjectReference(applicationInfrastructureApiProjectPath, applicationDomainProjectPath);
            EnsureProjectReference(applicationInfrastructureApiProjectPath, applicationCommandProjectPath);
            EnsureProjectReference(
                applicationInfrastructureApiProjectPath,
                applicationRepositoryInterfacesProjectPath);
            EnsureProjectReference(
                applicationInfrastructureApiProjectPath,
                applicationInfrastructureRepositoryReadProjectPath);
            EnsureProjectReference(
                applicationInfrastructureApiProjectPath,
                applicationInfrastructureRepositoryWriteProjectPath);
            EnsureExternalConnectorContentMetadata(applicationInfrastructureApiProjectPath);
            EnsureApplicationInfrastructureApiFiles(applicationInfrastructureApiProjectDirectory);
            AddProjectToSolution(applicationInfrastructureApiProjectPath, "Yeshua.CQRS.Infrastructure");

            // pendencia: criar o Worker apenas quando a DSL do aplicativo declarar fila, polling ou outro processamento em segundo plano.
            var applicationInfrastructureWorkerProjectName =
                GetApplicationInfrastructureWorkerProjectName();
            var applicationInfrastructureWorkerProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureWorkerProjectName);
            var applicationInfrastructureWorkerProjectPath = Path.Combine(
                applicationInfrastructureWorkerProjectDirectory,
                $"{applicationInfrastructureWorkerProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureWorkerProjectPath))
            {
                WriteText(
                    applicationInfrastructureWorkerProjectPath,
                    @"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>

</Project>");
            }

            EnsureProjectReference(
                applicationInfrastructureWorkerProjectPath,
                applicationInfrastructureSharedProjectPath);
            RemoveProjectReference(
                applicationInfrastructureWorkerProjectPath,
                sharedInfrastructureProjectPath);
            EnsureProjectReference(applicationInfrastructureWorkerProjectPath, applicationDomainProjectPath);
            EnsureProjectReference(applicationInfrastructureWorkerProjectPath, applicationCommandProjectPath);
            EnsureProjectReference(
                applicationInfrastructureWorkerProjectPath,
                applicationRepositoryInterfacesProjectPath);
            EnsureProjectReference(
                applicationInfrastructureWorkerProjectPath,
                applicationInfrastructureRepositoryReadProjectPath);
            EnsureProjectReference(
                applicationInfrastructureWorkerProjectPath,
                applicationInfrastructureRepositoryWriteProjectPath);
            EnsureApplicationInfrastructureWorkerFiles(applicationInfrastructureWorkerProjectDirectory);
            AddProjectToSolution(applicationInfrastructureWorkerProjectPath, "Yeshua.CQRS.Infrastructure");

            var applicationInfrastructureFrontProjectName =
                GetApplicationInfrastructureFrontProjectName();
            var applicationInfrastructureFrontProjectDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                applicationInfrastructureFrontProjectName);
            var applicationInfrastructureFrontProjectPath = Path.Combine(
                applicationInfrastructureFrontProjectDirectory,
                $"{applicationInfrastructureFrontProjectName}.csproj");

            if (!File.Exists(applicationInfrastructureFrontProjectPath))
            {
                WriteText(
                    applicationInfrastructureFrontProjectPath,
                    @"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>");
            }

            EnsureApplicationInfrastructureFrontFiles(applicationInfrastructureFrontProjectDirectory);
            AddProjectToSolution(applicationInfrastructureFrontProjectPath, "Yeshua.CQRS.Infrastructure");
        }

        private string GetApplicationDomainProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Domain";
        }

        private string GetApplicationCommandProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Application.Command";
        }

        private string GetApplicationRepositoryInterfacesProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Application.RepositoryInterfaces";
        }

        private string GetApplicationInfrastructureRepositoryReadProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.RepositoryRead";
        }

        private string GetApplicationInfrastructureSharedProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.Shared";
        }

        private string GetApplicationInfrastructureRepositoryWriteProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.RepositoryWrite";
        }

        private string GetApplicationInfrastructureApiProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.Api";
        }

        private string GetApplicationInfrastructureWorkerProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.Worker";
        }

        private string GetApplicationInfrastructureFrontProjectName()
        {
            return $"Yeshua.{GetApplicationName()}.CQRS.Infrastructure.Front";
        }

        private void EnsureApplicationInfrastructureApiFiles(string projectDirectory)
        {
            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Program.cs"),
                @"using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var origins = builder.Configuration.GetSection(""Cors:Origins"").Get<string[]>() ?? [];
        if (origins.Length > 0)
            policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(""v1"", new OpenApiInfo { Title = builder.Environment.ApplicationName, Version = ""v1"" });
    options.AddSecurityDefinition(""Bearer"", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = ""Authorization"",
        Type = SecuritySchemeType.Http,
        Scheme = ""bearer"",
        BearerFormat = ""JWT""
    });
});

Migrations.DependencInjection.MapDependencInjection(builder);
Migrations.DependenceInjectionCuston.MapDependenceInjection(builder);

var jwtSettings = new JwtSettings();
builder.Configuration.Bind(""JwtSettings"", jwtSettings);
builder.Services.AddSingleton(jwtSettings);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseResponseCompression();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

API.Migrations.Endpoints.MapEndpoints(app);
API.Migrations.EndpointsCuston.MapEndpoints(app);

app.Run();");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "StateResults.cs"),
                @"using Microsoft.AspNetCore.Http;
using RepositoryInterfaces.Patterns.Command;

namespace API;

public static class StateResults
{
    public static IResult From<T>(State<T> state)
    {
        return state.StatusCode switch
        {
            202 => TypedResults.Accepted((string?)null, state),
            >= 200 and < 300 => TypedResults.Ok(state),
            >= 400 and < 500 => TypedResults.BadRequest(state),
            _ => TypedResults.Problem(state.Message)
        };
    }

    public static async Task<IResult> TryAsync<T>(Func<Task<State<T>>> action)
    {
        try
        {
            return From(await action());
        }
        catch (ReceiverException<T> exception)
        {
            return TypedResults.BadRequest(exception.State);
        }
        catch
        {
            return TypedResults.Problem(""Nao foi possivel concluir a operacao."");
        }
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Services", "CurrentUserHttp.cs"),
                @"using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Shered.Services;

public sealed class executionContextHttp : IExecutionContext
{
    private readonly IHttpContextAccessor _http;
    private readonly string _fallbackTraceId = Guid.NewGuid().ToString(""N"");
    private int? _manualTenantId;
    private int? _manualUserId;
    private string? _manualTraceId;
    private ExecutionOrigin? _manualOrigin;

    public executionContextHttp(IHttpContextAccessor http) => _http = http;

    public int TenantID => _manualTenantId ?? GetTenantId();
    public int UserId => _manualUserId ?? GetUserId();
    public IEnumerable<Claim> Claims => _http.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
    public string TraceId => _manualTraceId ?? _http.HttpContext?.TraceIdentifier ?? _fallbackTraceId;
    public ExecutionOrigin Origem =>
        _manualOrigin ?? (_http.HttpContext is null ? ExecutionOrigin.Worker : ExecutionOrigin.Http);

    public void SetTenantId(int id) => _manualTenantId = id;
    public void SetUserId(int id) => _manualUserId = id;
    public void SetTraceId(string traceId) => _manualTraceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _manualOrigin = origem;

    private int GetTenantId() => GetIntClaim(""tenantId"");
    private int GetUserId() => GetIntClaim(ClaimTypes.NameIdentifier);

    private int GetIntClaim(string claimType)
    {
        var value = _http.HttpContext?.User?.FindFirst(claimType)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Custon", "IndependenceInjection.cs"),
                @"using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Patterns.FileStore;
using Shered.Services;

namespace Migrations;

public static class DependenceInjectionCuston
{
    public static void MapDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IExecutionContext, executionContextHttp>();

        builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection(""RabbitMq""));
        builder.Services.AddSingleton<RabbitMqConnectionManager>();
        builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
        builder.Services.AddSingleton<IQueuePublisher, RabbitMQQueuePublisher>();
        builder.Services.AddSingleton<IQueueListener, RabbitMQQueueListener>();

        builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection(""Storage""));
        builder.Services.AddScoped<IFileStorage, StorageService>();
        builder.Services.AddScoped<IStorageProvider, DiskStorageProvider>();
        builder.Services.AddScoped<StorageResolver>();

        builder.Services.AddScoped<ISqlFactory>(_ =>
            new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Custon", "EndPoints.cs"),
                @"namespace API.Migrations;

public static class EndpointsCuston
{
    public static void MapEndpoints(this WebApplication app)
    {
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "appsettings.json"),
                @"{
  ""Cors"": {
    ""Origins"": []
  },
  ""JwtSettings"": {
    ""SecretKey"": ""configure-using-user-secrets-or-environment-variables"",
    ""ExpirationMinutes"": 60
  },
  ""RabbitMq"": {},
  ""Storage"": {}
}");

            EnsureApplicationHostMyConfig(projectDirectory);
            EnsureApplicationInfrastructureApiLaunchSettings(projectDirectory);
        }

        private void EnsureApplicationInfrastructureApiLaunchSettings(string projectDirectory)
        {
            var launchSettingsPath = Path.Combine(
                projectDirectory,
                "Properties",
                "launchSettings.json");
            JsonObject root;

            if (File.Exists(launchSettingsPath))
            {
                root = JsonNode.Parse(File.ReadAllText(launchSettingsPath)) as JsonObject
                    ?? throw new InvalidOperationException(
                        $"O arquivo '{launchSettingsPath}' nao possui um objeto JSON valido.");
            }
            else
            {
                root = new JsonObject();
            }

            var profiles = root["profiles"] as JsonObject;
            if (profiles is null)
            {
                profiles = new JsonObject();
                root["profiles"] = profiles;
            }

            var projectProfiles = profiles
                .Where(profile => profile.Value is JsonObject profileObject
                    && string.Equals(
                        profileObject["commandName"]?.GetValue<string>(),
                        "Project",
                        StringComparison.OrdinalIgnoreCase))
                .Select(profile => (JsonObject)profile.Value!)
                .ToList();

            if (projectProfiles.Count == 0)
            {
                var projectProfile = new JsonObject
                {
                    ["commandName"] = "Project",
                    ["environmentVariables"] = new JsonObject
                    {
                        ["ASPNETCORE_ENVIRONMENT"] = "Development"
                    }
                };
                profiles[GetApplicationInfrastructureApiProjectName()] = projectProfile;
                projectProfiles.Add(projectProfile);
            }

            foreach (var profile in projectProfiles)
            {
                profile["launchBrowser"] = true;
                profile["launchUrl"] = "swagger";
            }

            WriteText(
                launchSettingsPath,
                root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
        }

        private void EnsureApplicationInfrastructureFrontFiles(string projectDirectory)
        {
            WriteText(
                Path.Combine(projectDirectory, "Program.cs"),
                @"var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();");

            WriteText(
                Path.Combine(projectDirectory, "appsettings.json"),
                @"{
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft.AspNetCore"": ""Warning""
    }
  },
  ""AllowedHosts"": ""*""
}");

            var frontPort = GetApplicationInfrastructureFrontPort();
            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Properties", "launchSettings.json"),
                $@"{{
  ""profiles"": {{
    ""{GetApplicationInfrastructureFrontProjectName()}"": {{
      ""commandName"": ""Project"",
      ""launchBrowser"": true,
      ""environmentVariables"": {{
        ""ASPNETCORE_ENVIRONMENT"": ""Development""
      }},
      ""applicationUrl"": ""http://localhost:{frontPort}""
    }}
  }}
}}");

            SyncApplicationInfrastructureFrontStandardFiles(projectDirectory);
            WriteTextIfMissing(
                Path.Combine(projectDirectory, "wwwroot", "Custon", "extensions.js"),
                @"window.yeshuaExtensions = window.yeshuaExtensions || {};");
        }

        private int GetApplicationInfrastructureFrontPort()
        {
            uint hash = 2166136261;
            foreach (var character in GetApplicationName())
            {
                hash ^= character;
                hash *= 16777619;
            }

            return 57000 + (int)(hash % 1000);
        }

        private void SyncApplicationInfrastructureFrontStandardFiles(string projectDirectory)
        {
            var templateDirectory = Path.Combine(
                GetPathAppInfraestructure(),
                "Yeshua.CQRS.Infrastructure.Front",
                "wwwroot");
            if (!Directory.Exists(templateDirectory))
            {
                throw new DirectoryNotFoundException(
                    $"A matriz do Front nao foi encontrada em '{templateDirectory}'.");
            }

            var destinationDirectory = Path.Combine(projectDirectory, "wwwroot");
            foreach (var sourceFile in Directory.GetFiles(
                templateDirectory,
                "*",
                System.IO.SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(templateDirectory, sourceFile);
                var firstDirectory = relativePath.Split(
                    Path.DirectorySeparatorChar,
                    Path.AltDirectorySeparatorChar)[0];
                if (string.Equals(firstDirectory, "Custon", StringComparison.OrdinalIgnoreCase))
                    continue;

                var destinationFile = Path.Combine(destinationDirectory, relativePath);
                var destinationFileDirectory = Path.GetDirectoryName(destinationFile);
                if (!string.IsNullOrWhiteSpace(destinationFileDirectory))
                    Directory.CreateDirectory(destinationFileDirectory);

                File.Copy(sourceFile, destinationFile, overwrite: true);
            }
        }

        private void EnsureApplicationInfrastructureWorkerFiles(string projectDirectory)
        {
            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Program.cs"),
                @"using Command.Interfaces.Patterns.Queue;
using Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
DependencInjection.MapDependencInjection(builder);
WorkerInfrastructure.MapWorkerInfrastructure(builder);
Worker.Custon.CustonDependenceInjection.MapCustonDependenceInjection(builder);
WorkersBuilder.MapWorkersBuilder(builder);

var app = builder.Build();
var topology = DependencInjection.GetQueueTopology();

if (topology.Exchanges.Count > 0)
{
    var initializer = app.Services.GetRequiredService<IQueueTopologyInitializer>();
    await initializer.InitializeAsync(topology);
}

await app.RunAsync();");

            WriteText(
                Path.Combine(projectDirectory, "Migration", "WorkerInfrastructure.cs"),
                @"using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Patterns.FileStore;
using Worker.Custon;

namespace Migrations;

public static class WorkerInfrastructure
{
    public static void MapWorkerInfrastructure(WebApplicationBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddScoped<IExecutionContext, WorkerExecutionContext>();

        builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection(""RabbitMq""));
        builder.Services.AddSingleton<RabbitMqConnectionManager>();
        builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
        builder.Services.AddSingleton<IQueuePublisher, RabbitMQQueuePublisher>();
        builder.Services.AddSingleton<IQueueListener, RabbitMQQueueListener>();

        builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection(""Storage""));
        builder.Services.AddScoped<IFileStorage, StorageService>();
        builder.Services.AddScoped<IStorageProvider, DiskStorageProvider>();
        builder.Services.AddScoped<StorageResolver>();

        builder.Services.AddScoped<ISqlFactory>(_ =>
            new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));

        // pendencia: registrar workers de polling, fila, saga, inbox ou outbox
        // somente quando a DSL do aplicativo declarar essas politicas.
        // observacao: handlers que implementam IWorkerCycleResult alimentam
        // a telemetria do Command pelo ReciverBase.
    }
}");

            WriteText(
                Path.Combine(projectDirectory, "Migration", "PollingWorker.cs"),
                @"using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;

namespace Worker.Custon;

public sealed class PollingWorker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PollingWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;

    public PollingWorker(
        IServiceProvider serviceProvider,
        ILogger<PollingWorker<TReceiver, TCommand, TResponse>> logger,
        TimeSpan interval)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _interval = interval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var workerName = typeof(TReceiver).Name;
        _logger.LogInformation(""Worker {Worker} iniciado."", workerName);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                await receiver.ExecuteAsync(new TCommand(), stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception)
            {
                // A excecao do Command ja foi registrada pelo ReciverBase.
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

}");

            WriteText(
                Path.Combine(projectDirectory, "Migration", "QueueListenerWorker.cs"),
                @"using Command.Interfaces.Patterns.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;

namespace Worker.Custon;

public sealed class QueueListenerWorker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IQueueListener _listener;
    private readonly ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly string[] _queues;

    public QueueListenerWorker(
        IServiceProvider serviceProvider,
        IQueueListener listener,
        ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> logger,
        params string[] queues)
    {
        _serviceProvider = serviceProvider;
        _listener = listener;
        _logger = logger;
        _queues = queues;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var queue in _queues)
        {
            _ = Task.Run(() => _listener.ListenAsync<TCommand>(queue, async message =>
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                await receiver.ExecuteAsync(message, stoppingToken);
            }, stoppingToken), stoppingToken);
        }

        return Task.CompletedTask;
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Migration", "WorkerExecutionContext.cs"),
                @"using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Worker.Custon;

public sealed class WorkerExecutionContext : IExecutionContext
{
    private int _tenantId;
    private int _userId;
    private string _traceId = Guid.NewGuid().ToString(""N"");
    private ExecutionOrigin _origin = ExecutionOrigin.Worker;

    public int UserId => _userId;
    public int TenantID => _tenantId;
    public string TraceId => _traceId;
    public ExecutionOrigin Origem => _origin;
    public IEnumerable<Claim> Claims => Enumerable.Empty<Claim>();

    public void SetTenantId(int id) => _tenantId = id;
    public void SetUserId(int id) => _userId = id;
    public void SetTraceId(string traceId) => _traceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _origin = origem;
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "Custon", "DependencInjection.cs"),
                @"namespace Worker.Custon;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
    }
}");

            WriteTextIfMissing(
                Path.Combine(projectDirectory, "appsettings.json"),
                @"{
  ""RabbitMq"": {},
  ""Storage"": {}
        }");

            EnsureApplicationHostMyConfig(projectDirectory);
        }

        private string GetApplicationName()
        {
            var applicationName = _name?.Trim();
            if (string.IsNullOrWhiteSpace(applicationName))
                throw new InvalidOperationException("O nome do aplicativo deve ser informado para criar os projetos.");

            if (applicationName is "." or ".." || applicationName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                throw new InvalidOperationException($"O nome do aplicativo '{applicationName}' nao pode ser usado em um projeto.");

            return applicationName;
        }

        private void EnsureRuntimeIdentityMetadata(string projectPath)
        {
            if (!File.Exists(projectPath))
                throw new FileNotFoundException(
                    "O projeto do host nao foi encontrado para receber a identidade de build.",
                    projectPath);

            var projectDocument = XDocument.Load(projectPath);
            var project = projectDocument.Root
                ?? throw new InvalidOperationException($"O projeto '{projectPath}' nao possui raiz XML.");

            var propertyGroup = project.Elements("PropertyGroup").FirstOrDefault();
            if (propertyGroup == null)
            {
                propertyGroup = new XElement("PropertyGroup");
                project.AddFirst(propertyGroup);
            }

            EnsureProjectProperty(
                propertyGroup,
                "YeshuaCommitSha",
                "$(SourceRevisionId)",
                "'$(YeshuaCommitSha)' == ''");
            EnsureProjectProperty(
                propertyGroup,
                "YeshuaBuildTimestampUtc",
                "UNSET",
                "'$(YeshuaBuildTimestampUtc)' == ''");

            var runtimeOptionsGroup = project.Elements("ItemGroup")
                .FirstOrDefault(group => group.Elements("RuntimeHostConfigurationOption").Any());
            if (runtimeOptionsGroup == null)
            {
                runtimeOptionsGroup = new XElement("ItemGroup");
                project.Add(runtimeOptionsGroup);
            }

            EnsureRuntimeHostConfigurationOption(
                runtimeOptionsGroup,
                "Yeshua.Application",
                GetApplicationName());
            EnsureRuntimeHostConfigurationOption(
                runtimeOptionsGroup,
                "Yeshua.Version",
                "$(Version)");
            EnsureRuntimeHostConfigurationOption(
                runtimeOptionsGroup,
                "Yeshua.CommitSha",
                "$(YeshuaCommitSha)");
            EnsureRuntimeHostConfigurationOption(
                runtimeOptionsGroup,
                "Yeshua.BuildTimestampUtc",
                "$(YeshuaBuildTimestampUtc)");

            var legacyKeys = new HashSet<string>(StringComparer.Ordinal)
            {
                "YeshuaApplication",
                "YeshuaVersion",
                "YeshuaCommitSha",
                "YeshuaBuildTimestampUtc"
            };
            foreach (var legacyMetadata in project
                         .Descendants("AssemblyMetadata")
                         .Where(element => legacyKeys.Contains(
                             element.Attribute("Include")?.Value ?? string.Empty))
                         .ToList())
            {
                legacyMetadata.Remove();
            }

            WriteText(projectPath, projectDocument.ToString());
        }

        private static void EnsureProjectProperty(
            XElement propertyGroup,
            string name,
            string value,
            string condition)
        {
            var property = propertyGroup.Element(name);
            if (property == null)
            {
                property = new XElement(name);
                propertyGroup.Add(property);
            }

            property.Value = value;
            property.SetAttributeValue("Condition", condition);
        }

        private static void EnsureRuntimeHostConfigurationOption(
            XElement itemGroup,
            string key,
            string value)
        {
            var matchingOptions = itemGroup.Elements("RuntimeHostConfigurationOption")
                .Where(option => string.Equals(
                    option.Attribute("Include")?.Value,
                    key,
                    StringComparison.Ordinal))
                .ToList();
            var option = matchingOptions.FirstOrDefault();
            if (option == null)
            {
                option = new XElement("RuntimeHostConfigurationOption");
                itemGroup.Add(option);
            }

            foreach (var duplicate in matchingOptions.Skip(1))
                duplicate.Remove();

            option.SetAttributeValue("Include", key);
            option.SetAttributeValue("Value", value);
        }

        private void EnsureExternalConnectorContentMetadata(string projectPath)
        {
            if (!File.Exists(projectPath))
                throw new FileNotFoundException(
                    "O projeto da API nao foi encontrado para receber os artefatos dos conectores.",
                    projectPath);

            var projectDocument = XDocument.Load(projectPath);
            var projectRoot = projectDocument.Root
                ?? throw new InvalidOperationException($"O projeto '{projectPath}' nao possui elemento raiz.");

            var itemGroup = projectRoot.Elements("ItemGroup")
                .FirstOrDefault(group => group.Elements("None")
                    .Any(item => string.Equals(
                        item.Attribute("Update")?.Value,
                        @"Custon\ExternalConnectors\**\*.*",
                        StringComparison.OrdinalIgnoreCase)));

            if (itemGroup == null)
            {
                itemGroup = new XElement("ItemGroup");
                projectRoot.Add(itemGroup);
            }

            var matchingItems = itemGroup.Elements("None")
                .Where(item => string.Equals(
                    item.Attribute("Update")?.Value,
                    @"Custon\ExternalConnectors\**\*.*",
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
            var item = matchingItems.FirstOrDefault();
            if (item == null)
            {
                item = new XElement("None");
                itemGroup.Add(item);
            }

            foreach (var duplicate in matchingItems.Skip(1))
                duplicate.Remove();

            item.SetAttributeValue("Update", @"Custon\ExternalConnectors\**\*.*");
            SetChildElementValue(item, "CopyToOutputDirectory", "PreserveNewest");
            SetChildElementValue(item, "CopyToPublishDirectory", "PreserveNewest");

            WriteText(projectPath, projectDocument.ToString());
        }

        private static void SetChildElementValue(
            XElement element,
            string name,
            string value)
        {
            var child = element.Element(name);
            if (child == null)
            {
                child = new XElement(name);
                element.Add(child);
            }

            child.Value = value;
        }

        private void EnsureProjectReference(string projectPath, string referencedProjectPath)
        {
            var projectDirectory = Path.GetDirectoryName(projectPath)
                ?? throw new InvalidOperationException("O diretorio do projeto nao foi encontrado.");
            var relativeReference = Path.GetRelativePath(projectDirectory, referencedProjectPath)
                .Replace('/', '\\');
            var projectDocument = XDocument.Load(projectPath);
            var projectRoot = projectDocument.Root
                ?? throw new InvalidOperationException($"O projeto '{projectPath}' nao possui elemento raiz.");

            var referenceExists = projectRoot
                .Descendants("ProjectReference")
                .Any(reference => string.Equals(
                    reference.Attribute("Include")?.Value,
                    relativeReference,
                    StringComparison.OrdinalIgnoreCase));

            if (referenceExists)
                return;

            var referenceGroup = projectRoot
                .Elements("ItemGroup")
                .FirstOrDefault(group => group.Elements("ProjectReference").Any());

            if (referenceGroup is null)
            {
                referenceGroup = new XElement("ItemGroup");
                projectRoot.Add(referenceGroup);
            }

            referenceGroup.Add(new XElement(
                "ProjectReference",
                new XAttribute("Include", relativeReference)));
            WriteText(projectPath, projectDocument.ToString());
        }

        private void RemoveProjectReference(string projectPath, string referencedProjectPath)
        {
            var projectDirectory = Path.GetDirectoryName(projectPath)
                ?? throw new InvalidOperationException("O diretorio do projeto nao foi encontrado.");
            var relativeReference = Path.GetRelativePath(projectDirectory, referencedProjectPath)
                .Replace('/', '\\');
            var projectDocument = XDocument.Load(projectPath);
            var references = projectDocument
                .Descendants("ProjectReference")
                .Where(reference => string.Equals(
                    reference.Attribute("Include")?.Value,
                    relativeReference,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (references.Count == 0)
                return;

            foreach (var reference in references)
                reference.Remove();

            WriteText(projectPath, projectDocument.ToString());
        }

        private void AddProjectToSolution(string projectPath, string solutionFolder)
        {
            var solutionFiles = Directory.GetFiles(GetPathAppSolution(), "*.sln", System.IO.SearchOption.TopDirectoryOnly);
            if (solutionFiles.Length != 1)
                throw new InvalidOperationException("A raiz da solucao deve conter exatamente um arquivo .sln.");

            var solutionPath = solutionFiles[0];
            var relativeProjectPath = Path.GetRelativePath(GetPathAppSolution(), projectPath)
                .Replace('/', '\\');
            var solutionContent = File.ReadAllText(solutionPath);

            if (solutionContent.Contains(relativeProjectPath, StringComparison.OrdinalIgnoreCase))
                return;

            var processStartInfo = new ProcessStartInfo("dotnet")
            {
                WorkingDirectory = GetPathAppSolution(),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            processStartInfo.ArgumentList.Add("sln");
            processStartInfo.ArgumentList.Add(solutionPath);
            processStartInfo.ArgumentList.Add("add");
            processStartInfo.ArgumentList.Add(projectPath);
            processStartInfo.ArgumentList.Add("--solution-folder");
            processStartInfo.ArgumentList.Add(solutionFolder);

            using var process = Process.Start(processStartInfo)
                ?? throw new InvalidOperationException("Nao foi possivel iniciar o dotnet para atualizar a solucao.");
            var standardOutput = process.StandardOutput.ReadToEndAsync();
            var standardError = process.StandardError.ReadToEndAsync();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException(
                    $"Nao foi possivel adicionar o projeto a solucao.{Environment.NewLine}" +
                    standardOutput.GetAwaiter().GetResult() +
                    standardError.GetAwaiter().GetResult());
            }
        }

        public void CodeGenaration(Migration.MigrationBase migration)
        {
            AppSolutionGenerate(migration);
            AppInfrastructureGenerateRuntimeIdentity();
            AppInfrastructureGenerateOperationalHealth();
            AppInfrastructureGenerateOperationalControl(migration);

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

            AppInfraestructureGenerateAutomacaoTest(migration);

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
            AppStudioGenerateEntityDictionary(migration);

        }
    }
}
