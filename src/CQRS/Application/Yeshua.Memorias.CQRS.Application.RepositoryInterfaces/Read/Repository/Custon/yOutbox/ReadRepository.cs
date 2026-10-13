// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

namespace IRepository.Read;

public partial interface IyOutboxReadRepository
{
    IEnumerable<Repositorio.Outputs.yOutboxDTO> GetPendingMediaRenderMessages(int batchSize);
}
