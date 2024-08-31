using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Schemas.CQRS
{
    public interface ICSharpCQRS : ISchemaCodeGeneration
    {
        public string _name { get; set; }

        void AppSolutionGenerate(Dominio.Migration.MigrationBase migration);

        void AppInfraestructureGenerateAPI(Dominio.Migration.MigrationBase migration);

        void AppInfraestructureGenerateMigration(Dominio.Migration.MigrationBase migration);
        
        void AppInfraestructureGenerateRead(Dominio.Migration.MigrationBase migration);
        void AppInfraestructureGenerateReadConcreteRepository(Dominio.Migration.MigrationBase migration);
        void AppInfraestructureGenerateReadConcreteQuerys(Dominio.Migration.MigrationBase migration);

        void AppInfraestructureGenerateShered(Dominio.Migration.MigrationBase migration);

        void AppInfraestructureGenerateWrite(Dominio.Migration.MigrationBase migration);
        void AppInfraestructureGenerateWriteConcreteRepository(Dominio.Migration.MigrationBase migration);
        void AppInfraestructureGenerateWriteConcreteQuerys(Dominio.Migration.MigrationBase migration);

        void AppInfraestructureGenerateAutomacaoTest(Dominio.Migration.MigrationBase migration);

        void AppAplicationGenerateCommand(Dominio.Migration.MigrationBase migration);
        void AppAplicationGenerateCommandCommands(Dominio.Migration.MigrationBase migration);
        void AppAplicationGenerateCommandPartterns(Dominio.Migration.MigrationBase migration);
        void AppAplicationGenerateCommandReceivers(Dominio.Migration.MigrationBase migration);

        void AppAplicationGenerateRepositoryInterfaces(Dominio.Migration.MigrationBase migration);
        void AppAplicationGenerateRepositoryInterfacesRead(Dominio.Migration.MigrationBase migration);
        void AppAplicationGenerateRepositoryInterfacesWrite(Dominio.Migration.MigrationBase migration);

        void AppDominioGenerateDominio(Dominio.Migration.MigrationBase migration);
        void AppDominioGenerateDominioEntitys(Dominio.Migration.MigrationBase migration);
        void AppDominioGenerateDominioEnum(Dominio.Migration.MigrationBase migration);
        void AppDominioGenerateDominioSpecifications(Dominio.Migration.MigrationBase migration);
        void AppDominioGenerateDominioPrimitiveTypes(Dominio.Migration.MigrationBase migration);
        void AppDominioGenerateDominioValidation(Dominio.Migration.MigrationBase migration);

    }
}
