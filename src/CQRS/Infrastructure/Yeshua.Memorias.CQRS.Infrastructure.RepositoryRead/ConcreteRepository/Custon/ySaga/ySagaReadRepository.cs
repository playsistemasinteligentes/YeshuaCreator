// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Repositorio.Outputs;
using System;
using System.Linq;

namespace Read.Repository
{
    public partial class ySagaReadRepository
    {
        public bool TryClaimSagaForExecution(int sagaId, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt)
        {
            var sql = @"
                UPDATE [ySaga]
                   SET [LockedBy] = @LockedBy,
                       [LockedAt] = @LockedAt,
                       [NextExecutionAt] = @NextExecutionAt
                 WHERE [Id] = @SagaId
                   AND [Status] = 1
                   AND [ProcessingScope] = @ProcessingScope
                   AND ([LockedBy] IS NULL OR [LockedBy] = @LockedBy OR [LockedAt] IS NULL OR [LockedAt] < @StaleLockLimit);

                SELECT @@ROWCOUNT;";

            var affected = _unitOfWork.ExecuteScalar<int>(sql, new
            {
                SagaId = sagaId,
                LockedBy = lockedBy,
                LockedAt = lockedAt,
                NextExecutionAt = nextExecutionAt,
                ProcessingScope = _executionContext.ProcessingScope,
                StaleLockLimit = lockedAt.AddMinutes(-1)
            });

            return affected == 1;
        }

        public void ReleaseLock(int sagaId, string workerId)
        {
            var sql = @"
                UPDATE [ySaga]
                   SET [LockedBy] = NULL,
                       [LockedAt] = NULL
                 WHERE [Id] = @SagaId
                   AND [LockedBy] = @WorkerId";

            _unitOfWork.Execute(sql, new { SagaId = sagaId, WorkerId = workerId });
        }

        public ySagaDTO? GetByIdWithSteps(int sagaId)
        {
            var saga = _unitOfWork.Query<ySagaDTO>(
                @"SELECT *
                    FROM [ySaga]
                   WHERE [Id] = @SagaId
                     AND [Deleted] = 0;",
                new { SagaId = sagaId })
                .FirstOrDefault();

            if (saga == null)
                return null;

            var steps = _unitOfWork.Query<ySagaStepDTO>(
                @"SELECT *
                    FROM [ySagaStep]
                   WHERE [SagaId] = @SagaId
                     AND [Deleted] = 0
                   ORDER BY [IndexOrder];",
                new { SagaId = saga.id });

            saga.Steps = steps.ToList();
            return saga;
        }

        public ySagaDTO GetByCorrelationId(string correlationId)
        {
            var sql = @"
                SELECT s.*
                  FROM [ySaga] s
                 INNER JOIN [ySagaStep] st ON st.[SagaId] = s.[Id]
                 WHERE st.[CorrelationId] = @CorrelationId";

            var saga = _unitOfWork.Query<ySagaDTO>(sql, new { CorrelationId = correlationId }).FirstOrDefault();
            if (saga == null)
                return null;

            var steps = _unitOfWork.Query<ySagaStepDTO>(
                "SELECT * FROM [ySagaStep] WHERE [SagaId] = @SagaId",
                new { SagaId = saga.id });

            saga.Steps = steps.ToList();
            return saga;
        }

        public ySagaDTO? GetLatestByTypeEntity(string type, string entityType, string? entityId, string? correlationId)
        {
            var sql = @"
                SELECT TOP 1 *
                  FROM [ySaga]
                 WHERE [Type] = @Type
                   AND [EntityType] = @EntityType
                   AND [TenantID] = @TenantID
                   AND [Deleted] = 0
                   AND (
                        (@EntityId <> '' AND [EntityId] = @EntityId)
                     OR (@CorrelationId <> '' AND [CorrelationId] = @CorrelationId)
                   )
                 ORDER BY [Id] DESC;";

            var saga = _unitOfWork.Query<ySagaDTO>(sql, new
            {
                Type = type,
                EntityType = entityType,
                EntityId = entityId ?? string.Empty,
                CorrelationId = correlationId ?? string.Empty,
                TenantID = _executionContext.TenantID
            }).FirstOrDefault();

            if (saga == null)
                return null;

            var steps = _unitOfWork.Query<ySagaStepDTO>(
                @"SELECT *
                    FROM [ySagaStep]
                   WHERE [SagaId] = @SagaId
                     AND [TenantID] = @TenantID
                     AND [Deleted] = 0
                   ORDER BY [IndexOrder]",
                new
                {
                    SagaId = saga.id,
                    TenantID = _executionContext.TenantID
                });

            saga.Steps = steps.ToList();
            return saga;
        }

        public ySagaDTO? GetLatestByTypeEntityAndStatus(string type, string entityType, string? entityId, int status)
        {
            var sql = @"
                SELECT TOP 1 *
                  FROM [ySaga]
                 WHERE [Type] = @Type
                   AND [EntityType] = @EntityType
                   AND [EntityId] = @EntityId
                   AND [Status] = @Status
                 ORDER BY [Id] DESC;";

            return _unitOfWork.Query<ySagaDTO>(sql, new
            {
                Type = type,
                EntityType = entityType,
                EntityId = entityId,
                Status = status
            }).FirstOrDefault();
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
