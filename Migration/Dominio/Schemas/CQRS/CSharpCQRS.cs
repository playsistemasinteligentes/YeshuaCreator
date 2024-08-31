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

        public string _name { get ; set ; }
        public string _solutionDirectory { get ; set ; }

        public void AppAplicationGenerateCommand(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppAplicationGenerateCommandCommands(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandCommands(), $"{entity.EntityName}\\{entity.EntityName}CommandsMigration.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandCommandsMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

                filePath = Path.Combine(GetPathAppAplicationCommandCommands(), $"{entity.EntityName}\\{entity.EntityName}CommandsCuston.cs");
                var sourceCodeCuston = new SourceCodeAplicationCommandCommandsCuston(filePath, entity, true);
                sourceCodeCuston.WriteCode();
            }
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
            return Path.Combine(GetPathAppSolution(), "Aplication");
        }

        public void AppAplicationGenerateCommandPartterns(Migration.MigrationBase migration)
        {
            throw new NotImplementedException();
        }

        public void AppAplicationGenerateCommandReceivers(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppAplicationCommandReceivers(), $"{entity.EntityName}\\{entity.EntityName}ReceiversMigration.cs");
                var sourceCodeMigration = new SourceCodeAplicationCommandReceiversMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

                filePath = Path.Combine(GetPathAppAplicationCommandReceivers(), $"{entity.EntityName}\\{entity.EntityName}ReceiversCuston.cs");
                var sourceCodeCuston = new SourceCodeAplicationCommandReceiversCuston(filePath, entity, true);
                sourceCodeCuston.WriteCode();
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
                var filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"{entity.EntityName}\\{entity.EntityName}RepositoryInterfacesReadMigration.cs");
                var sourceCodeMigration = new SourceCodeAplicationRepositoryInterfacesReadMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

                filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesRead(), $"{entity.EntityName}\\{entity.EntityName}RepositoryInterfacesReadCuston.cs");
                var sourceCodeCuston = new SourceCodeAplicationRepositoryInterfacesReadCuston(filePath, entity, true);
                sourceCodeCuston.WriteCode();
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
                var filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"{entity.EntityName}\\{entity.EntityName}RepositoryInterfacesWriteMigration.cs");
                var sourceCodeMigration = new SourceCodeAplicationRepositoryInterfacesWriteMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

                filePath = Path.Combine(GetPathAppAplicationRepositoryInterfacesWrite(), $"{entity.EntityName}\\{entity.EntityName}RepositoryInterfacesWriteCuston.cs");
                var sourceCodeCuston = new SourceCodeAplicationRepositoryInterfacesWriteCuston(filePath, entity, true);
                sourceCodeCuston.WriteCode();
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
            return Path.Combine(GetPathAppDominio(), "Dominio"); 
        }

        private string GetPathAppDominio()
        {
            return Path.Combine(GetPathAppSolution(), "Dominio");
        }

        private string GetPathAppSolution()
        {
            return Path.Combine(_solutionDirectory,_name);
        }

        public void AppDominioGenerateDominioEntitys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppDominioDominio(), $"{entity.EntityName}\\{entity.EntityName}Migration.cs");
                var sourceCodeMigration = new SourceCodeClassMigration(filePath, entity);
                    sourceCodeMigration.WriteCode();
                
                filePath = Path.Combine(GetPathAppDominioDominio(), $"{entity.EntityName}\\{entity.EntityName}Custon.cs");
                var sourceCodeCuston = new SourceCodeClassCuston(filePath, entity, true);
                sourceCodeCuston.WriteCode();
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
                var filePath = Path.Combine(AppInfraestructureReadConcreteRepository(), $"{entity.EntityName}\\{entity.EntityName}ReadRepositoryMigration.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureReadConcreteRepositoryMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

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
            return Path.Combine(GetPathAppInfraestructure(), "Read");
        }

        private string GetPathAppInfraestructure()
        {
            return Path.Combine(GetPathAppSolution(), "InfraEstructure");
        }

        public void AppInfraestructureGenerateReadConcreteQuerys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"{entity.EntityName}\\{entity.EntityName}ReadQuerysMigration.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureReadQuerysMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

                //filePath = Path.Combine(GetPathAppInfraestructureReadConcreteQuerys(), $"{entity.EntityName}\\{entity.EntityName}ReadQuerysCuston.cs");
                //var sourceCodeCuston = new SourceCodeInfraestructureReadQuerysCuston(filePath, entity, true);
                //sourceCodeCuston.WriteCode();
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
                var filePath = Path.Combine(AppInfraestructureWriteConcreteRepository(), $"{entity.EntityName}\\{entity.EntityName}WriteRepositoryMigration.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureWriteConcreteRepositoryMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

//                filePath = Path.Combine(AppInfraestructureWriteConcreteRepository(), $"{entity.EntityName}\\{entity.EntityName}WriteRepositoryCuston.cs");
//                var sourceCodeCuston = new SourceCodeInfraestructureWriteConcreteRepositoryCuston(filePath, entity, true);
//                sourceCodeCuston.WriteCode();
            }
        }

        private string AppInfraestructureWriteConcreteRepository()
        {
            return Path.Combine(GetPathAppInfraestructureWrite(), "ConcreteRepository");
        }

        private string GetPathAppInfraestructureWrite()
        {
            return Path.Combine(GetPathAppInfraestructure(),"Write");
        }

        public void AppInfraestructureGenerateWriteConcreteQuerys(Migration.MigrationBase migration)
        {
            foreach (var entity in migration.Entitys)
            {
                var filePath = Path.Combine(GetPathAppInfraestructureWriteConcreteQuerys(), $"{entity.EntityName}\\{entity.EntityName}WriteQuerysMigration.cs");
                var sourceCodeMigration = new SourceCodeInfraestructureWriteQuerysMigration(filePath, entity);
                sourceCodeMigration.WriteCode();

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
            /////////AppSolutionGenerate(migration);
         
            /////////AppInfraestructureGenerateAPI(migration);
            
            /////////AppInfraestructureGenerateMigration(migration);
            
            /////////AppInfraestructureGenerateRead(migration);
            AppInfraestructureGenerateReadConcreteRepository(migration);
            AppInfraestructureGenerateReadConcreteQuerys(migration);
            
            /////////AppInfraestructureGenerateShered(migration);
            
            /////////AppInfraestructureGenerateWrite(migration);
            AppInfraestructureGenerateWriteConcreteRepository(migration);
            AppInfraestructureGenerateWriteConcreteQuerys(migration);
            
            /////////AppInfraestructureGenerateAutomacaoTest(migration);
            
            /////////AppAplicationGenerateCommand(migration);
            ///////AppAplicationGenerateCommandCommands(migration);
            /////////AppAplicationGenerateCommandPartterns(migration);
            ///////AppAplicationGenerateCommandReceivers(migration);
            
            /////////AppAplicationGenerateRepositoryInterfaces(migration);
            ///////AppAplicationGenerateRepositoryInterfacesRead(migration);
            ///////AppAplicationGenerateRepositoryInterfacesWrite(migration);
            
            //AppDominioGenerateDominio(migration);
            AppDominioGenerateDominioEntitys(migration);
            //AppDominioGenerateDominioEnum(migration);
            //AppDominioGenerateDominioPrimitiveTypes(migration);
            //AppDominioGenerateDominioSpecifications(migration);
            //AppDominioGenerateDominioValidation(migration);
        }
    }
}
