using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;

namespace IRepository.Read
{
    public partial interface IySagaStepReadRepository
    {
        public void SetPendingApply();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration