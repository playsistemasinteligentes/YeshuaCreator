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
using System.Collections.Generic;

namespace IRepository.Read
{
    public partial interface IySagaReadRepository
    {
        IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt);
        void ReleaseLock(int sagaId, string workerId);
        ySagaDTO GetByCorrelationId(string correlationId);
        ySagaDTO? GetLatestByTypeEntity(string type, string entityType, string? entityId, string? correlationId);
        ySagaDTO? GetLatestByTypeEntityAndStatus(string type, string entityType, string? entityId, int status);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
