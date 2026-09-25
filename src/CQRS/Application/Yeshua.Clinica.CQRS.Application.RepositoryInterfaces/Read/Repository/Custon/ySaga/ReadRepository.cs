// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using System;

namespace IRepository.Read
{
    public partial interface IySagaReadRepository
    {
        bool TryClaimSagaForExecution(int sagaId, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt);
        ySagaDTO? GetByIdWithSteps(int sagaId);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
