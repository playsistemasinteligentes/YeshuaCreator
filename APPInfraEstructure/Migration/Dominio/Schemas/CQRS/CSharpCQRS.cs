using Dominio.TiposPrimitivos;
using Interfaces.Schemas;
using Interfaces.Schemas.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandCommands(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommands(), $"Custon\\{entity.EntityName}\\{entity.EntityName}Commands.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
            }

            /*
             AddHub("ClinicaPaciente")
                .AddAgents("Agente de Agendamento de Paciente")
                    .AddAgentMetod("Interagir com paciente para agendamentos via WhatsApp", "")
                    .AddInteractionMenu("Menu de Agendamento:")
                    .AddOption(1, "Agendar novo atendimento")
             */
            foreach (var hub in migration.Hubs)
            {
                foreach (var agent in hub.Agents)
                {
                    foreach (var InteractionMenu in agent.InteractionMenu)
                    {
                        foreach (var option in InteractionMenu.Options)
                        {
                            var filePath = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents(), $"Migration\\{hub.Name}\\{agent.Name.SourceType()}\\{option.Value.SourceType()}Commands.cs");
                            var filePathCuston = Path.Combine(GetPathAppAplicationCommandCommandsHubAgents(), $"Custon\\{hub.Name}\\{agent.Name.SourceType()}\\{option.Value.SourceType()}Commands.cs");
                            var sourceCodeMigration = new SourceCodeAplicationCommandCommandsHubAgentsInteractionMenuMigration(option.Key, option.Value);
                            sourceCodeMigration.WriteCode(filePath, filePathCuston);
                        }
                    }
                }
            }
        }

        private string GetPathAppAplicationCommandCommandsHubAgents()
        {
            return Path.Combine(GetPathAppAplicationCommandCommands(), "HubAgents");
        }

        private string GetPathAppAplicationCommandCommands()
        {
            return Path.Combine(GetPathAppAplicationCommand(), "Commands");
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

        public void AppAplicationGenerateCommandReceivers(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandReceivers(), $"Migration\\{entity.EntityName}\\{entity.EntityName}InsertReceivers.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationCommandReceivers(), $"Custon\\{entity.EntityName}\\{entity.EntityName}InsertReceivers.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
            }
        }

        private string GetPathAppAplicationCommandReceivers()
        {
            return Path.Combine(GetPathAppAplicationCommand(), "Receivers");
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
                sourceCodeMigration.WriteCode(filePath, filePathCuston);

                filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Migration\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesReadDTO.cs");
                filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"DTOs\\Custon\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesReadDTO.cs");
                var sourceCodeDTOMigration = new SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(entity);
                sourceCodeDTOMigration.WriteCode(filePath, filePathCuston);
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
                var filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"Repository\\Migration\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesWrite.cs");
                var filePathCuston = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"Repository\\Custon\\{entity.EntityName}\\I{entity.EntityName}RepositoryInterfacesWrite.cs");
                var sourceCodeMigration = new SourceCodeAplicationRepositoryInterfacesWriteMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
            }
        }

        private string GetPathAppAplicationRepositoryInterfacesWrite()
        {
            return Path.Combine(GetPathAppAplicationRepositoryInterfaces(), "Write");
        }

        public void AppDominioGenerateDominio(Migration.MigrationBase migration)
        {

        }

        private string GetPathAppDominioDominio()
        {
            return Path.Combine(GetPathAppDominio(), "Entitys");
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
                var filePath = Path.Combine(GetPathAppDominioDominio(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Entity.cs");
                var filePathCuston = Path.Combine(GetPathAppDominioDominio(), $"Custon\\{entity.EntityName}\\{entity.EntityName}Entity.cs");
                var sourceCodeMigration = new SourceCodeEntityMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
            }
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
            throw new NotImplementedException();
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
                var sourceCodeMigration = new SourceCodeInfraestructureReadConcreteRepositoryMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);

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
                var sourceCodeMigration = new SourceCodeInfraestructureReadQuerysMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
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
                sourceCodeMigration.WriteCode(filePath, filePathCuston);
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
                var sourceCodeMigration = new SourceCodeInfraestructureWriteQuerysMigration(entity);
                sourceCodeMigration.WriteCode(filePath, filePathCuston);

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

            ///////////AppInfraestructureGenerateAPI(migration);

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
        }
    }
}
