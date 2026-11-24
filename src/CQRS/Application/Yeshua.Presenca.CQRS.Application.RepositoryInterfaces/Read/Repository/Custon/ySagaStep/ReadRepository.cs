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
using System.Collections.Generic;

namespace IRepository.Read
{
    public partial interface IySagaStepReadRepository
    {
        int SetPendingApply();
        int SetPendingApplyByInboxId(int inboxId);
        ySagaStepDTO? GetFirstBySagaStepKeyAndStatuses(int sagaId, string stepKey, IEnumerable<int> statuses);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
