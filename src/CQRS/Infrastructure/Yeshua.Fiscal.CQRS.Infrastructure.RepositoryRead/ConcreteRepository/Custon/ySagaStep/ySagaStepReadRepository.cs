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
using Dapper;
using Repositorio.Outputs;
using System.Collections.Generic;
using System.Linq;

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

                UPDATE sg
                   SET sg.[NextExecutionAt] = SYSUTCDATETIME()
                  FROM [ySaga] sg
                 INNER JOIN [ySagaStep] s ON s.[SagaId] = sg.[Id]
                 INNER JOIN [yInbox] i ON i.[CorrelationId] = s.[CorrelationId]
                 WHERE s.[Status] = 4
                   AND i.[Status] = 0;

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

        public ySagaStepDTO? GetFirstBySagaStepKeyAndStatuses(int sagaId, string stepKey, IEnumerable<int> statuses)
        {
            var sql = @"
                SELECT TOP 1 *
                  FROM [ySagaStep]
                 WHERE [SagaId] = @SagaId
                   AND [StepKey] = @StepKey
                   AND [Status] IN @Statuses
                 ORDER BY [IndexOrder];";

            return _unitOfWork.Query<ySagaStepDTO>(sql, new
            {
                SagaId = sagaId,
                StepKey = stepKey,
                Statuses = statuses.ToArray()
            }).FirstOrDefault();
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
