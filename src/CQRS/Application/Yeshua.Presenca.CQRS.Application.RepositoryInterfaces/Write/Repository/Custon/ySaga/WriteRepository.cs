// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Patterns.Saga;

namespace IRepository.Write
{
    public partial interface IySagaWriteRepository
    {
        void Save(SagaBase saga);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
