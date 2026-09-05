// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

// pendencia: mover esta infraestrutura interna de saga para geracao padrao da Engine.
namespace Read.Repository
{
    public partial class ySagaStepReadRepository
    {
        public int SetPendingApply()
        {
            var sql = @"
                BEGIN TRAN;

                UPDATE s
                   SET s.[Status] = 4,
                       s.[Payload] = i.[Payload]
                  FROM [ySagaStep] s
                 INNER JOIN [yInbox] i ON i.[CorrelationId] = s.[CorrelationId]
                 WHERE i.[Status] = 0
                   AND s.[Status] = 3;

                DECLARE @Applied INT = @@ROWCOUNT;

                UPDATE i
                   SET i.[Status] = 1
                  FROM [yInbox] i
                 INNER JOIN [ySagaStep] s ON s.[CorrelationId] = i.[CorrelationId]
                 WHERE s.[Status] = 4
                   AND i.[Status] = 0;

                COMMIT;

                SELECT @Applied;";

            return _unitOfWork.ExecuteScalar<int>(sql);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
