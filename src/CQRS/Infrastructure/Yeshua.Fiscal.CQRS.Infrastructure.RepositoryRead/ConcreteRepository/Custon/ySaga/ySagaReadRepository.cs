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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.Repository
{
    public partial class ySagaReadRepository
    {
        public IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt)
        {
            var sql = @"
                WITH cte AS (
                    SELECT TOP (@Limit) *
                    FROM [ySaga] WITH (UPDLOCK, READPAST, ROWLOCK)
                    WHERE [Status] = 1
                      AND ([LockedBy] IS NULL OR [LockedAt] < @StaleLockLimit)
                      AND (
                          [NextExecutionAt] IS NULL
                          OR [NextExecutionAt] <= @Now
                          OR EXISTS (
                              SELECT 1
                                FROM [ySagaStep] st
                               WHERE st.[SagaId] = [ySaga].[Id]
                                 AND st.[Status] IN (1, 4)
                          )
                      )
                    ORDER BY ISNULL([NextExecutionAt], '1900-01-01') ASC
                )
                UPDATE cte
                   SET [LockedBy] = @LockedBy,
                       [LockedAt] = @LockedAt,
                       [NextExecutionAt] = @NextExecutionAt
                OUTPUT inserted.*;";

            var sagas = _unitOfWork.Query<ySagaDTO>(sql, new
            {
                Limit = limit,
                LockedBy = lockedBy,
                LockedAt = lockedAt,
                NextExecutionAt = nextExecutionAt,
                Now = DateTime.UtcNow,
                StaleLockLimit = lockedAt.AddMinutes(-1)
            }).ToList();

            if (sagas.Count == 0)
                return sagas;

            var ids = sagas.Select(saga => saga.id).ToArray();
            var steps = _unitOfWork
                .Query<ySagaStepDTO>("SELECT * FROM [ySagaStep] WHERE [SagaId] IN @Ids", new { Ids = ids })
                .ToList();

            var stepsBySaga = steps
                .GroupBy(step => step.sagaid)
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var saga in sagas)
            {
                if (stepsBySaga.TryGetValue(saga.id, out var sagaSteps))
                    saga.Steps = sagaSteps;
            }

            return sagas;
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
