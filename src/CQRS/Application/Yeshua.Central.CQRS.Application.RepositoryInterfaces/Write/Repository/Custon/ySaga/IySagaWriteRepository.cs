using Dominio.Entitys;
using Dominio.Patterns.Saga;

namespace IRepository.Write
{
    public partial interface IySagaWriteRepository
    {
        void Save(SagaBase sagastep);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
