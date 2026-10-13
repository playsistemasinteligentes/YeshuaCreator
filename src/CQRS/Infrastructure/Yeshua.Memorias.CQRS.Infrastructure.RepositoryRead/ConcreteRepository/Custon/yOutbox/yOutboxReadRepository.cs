// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

namespace Read.Repository;

public partial class yOutboxReadRepository
{
    public IEnumerable<Repositorio.Outputs.yOutboxDTO> GetPendingMediaRenderMessages(int batchSize)
    {
        const string sql = """
            SELECT TOP (@BatchSize) * FROM yOutbox
            WHERE ProcessingScope = @ProcessingScope AND Deleted = 0
              AND Status = 0 AND Type = 'media.album.render.requested'
            ORDER BY Id;
            """;
        return _unitOfWork.Query<Repositorio.Outputs.yOutboxDTO>(sql, new
        {
            BatchSize = Math.Clamp(batchSize, 1, 5),
            ProcessingScope = _executionContext.ProcessingScope
        }).ToArray();
    }
}
