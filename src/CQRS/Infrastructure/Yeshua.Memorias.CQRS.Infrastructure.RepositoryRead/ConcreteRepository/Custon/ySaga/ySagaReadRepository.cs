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
using RepositoryInterfaces.Patterns.Worker;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.Repository
{
    public partial class ySagaReadRepository
    {
        private static string RunnableSagaPredicate(string saga) => @"
                    " + saga + @".[Status] = 1
                    AND " + saga + @".[ProcessingScope] = @ProcessingScope
                    AND (" + saga + @".[LockedBy] IS NULL OR " + saga + @".[LockedAt] < @StaleLockLimit)
                    AND EXISTS (
                        SELECT 1
                          FROM [ySagaStep] runnableStep
                         WHERE runnableStep.[SagaId] = " + saga + @".[Id]
                           AND runnableStep.[Status] IN (1, 4)
                    )
                    AND (
                        " + saga + @".[NextExecutionAt] IS NULL
                        OR " + saga + @".[NextExecutionAt] <= @Now
                        OR EXISTS (
                            SELECT 1
                              FROM [ySagaStep] pendingApplyStep
                             WHERE pendingApplyStep.[SagaId] = " + saga + @".[Id]
                               AND pendingApplyStep.[Status] = 4
                        )
                    )";

        private static string ItemHealthProjection => @"
                WITH ItemState AS (
                    SELECT s.[Id],
                           s.[CorrelationId] AS ItemReference,
                           s.[Type] AS ItemType,
                           s.[Status] AS SagaStatus,
                           s.[CreatedAt],
                           s.[NextExecutionAt],
                           s.[LockedAt],
                           s.[LockedBy],
                           s.[OperationalEntityId],
                           s.[RootOperationId],
                           s.[ExecutionId],
                           currentStep.[Status] AS StepStatus,
                           COALESCE(currentStep.[ExecutionCount], 0) AS ExecutionCount,
                           COALESCE(currentStep.[RetryCount], 0) AS RetryCount,
                           currentStep.[LastExecutionAt],
                           currentStep.[ErrorMessage],
                           CASE
                               WHEN currentStep.[Status] = 4
                                   THEN COALESCE(currentStep.[LastExecutionAt], s.[CreatedAt])
                               ELSE COALESCE(s.[NextExecutionAt], s.[CreatedAt])
                           END AS EligibleSince,
                           CASE WHEN " + RunnableSagaPredicate("s") + @"
                                THEN 1 ELSE 0 END AS IsRunnable
                      FROM [ySaga] s
                      OUTER APPLY (
                          SELECT TOP (1)
                                 st.[Status],
                                 st.[ExecutionCount],
                                 st.[RetryCount],
                                 st.[LastExecutionAt],
                                 st.[ErrorMessage]
                            FROM [ySagaStep] st
                           WHERE st.[SagaId] = s.[Id]
                             AND st.[Deleted] = 0
                             AND st.[StepKey] = s.[KeyCurrentStep]
                           ORDER BY st.[IndexOrder]
                      ) currentStep
                     WHERE s.[ProcessingScope] = @ProcessingScope
                       AND s.[Deleted] = 0
                       AND s.[Status] IN (1, 3)
                ),
                ClassifiedItem AS (
                    SELECT *,
                           CASE
                               WHEN [SagaStatus] = 3 OR [StepStatus] = 6 THEN 5
                               WHEN [SagaStatus] = 1
                                AND [LockedBy] IS NOT NULL
                                AND [LockedAt] < @ProcessingStuckLimit THEN 2
                               WHEN [RetryCount] >= @RepeatedFailureCount THEN 4
                               WHEN [ExecutionCount] >= @RecurrentExecutionCount THEN 3
                               WHEN [IsRunnable] = 1
                                AND [EligibleSince] < @ExcessiveWaitLimit THEN 1
                               ELSE 0
                           END AS Disease,
                           CASE WHEN [IsRunnable] = 1
                                THEN DATEDIFF_BIG(SECOND, [EligibleSince], @Now)
                                ELSE 0 END AS EligibleAgeSeconds,
                           CASE WHEN [LockedBy] IS NOT NULL AND [LockedAt] IS NOT NULL
                                THEN DATEDIFF_BIG(SECOND, [LockedAt], @Now)
                                ELSE 0 END AS ProcessingAgeSeconds
                      FROM ItemState
                )";

        public IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt)
        {
            var sql = @"
                WITH cte AS (
                    SELECT TOP (@Limit) *
                    FROM [ySaga] WITH (UPDLOCK, READPAST, ROWLOCK)
                    WHERE " + RunnableSagaPredicate("[ySaga]") + @"
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
                ProcessingScope = _executionContext.ProcessingScope,
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

        public WorkerQueueHealthSnapshot GetRunnableSagaHealth(
            WorkerQueueItemHealthThresholds thresholds)
        {
            var now = DateTime.UtcNow;
            var snapshot = _unitOfWork.Query<RunnableSagaHealthRow>(
                ItemHealthProjection + @"
                SELECT COALESCE(SUM(CASE WHEN [IsRunnable] = 1 THEN 1 ELSE 0 END), 0) AS EligibleCount,
                       MIN(CASE WHEN [IsRunnable] = 1 THEN [EligibleSince] END) AS OldestEligibleAtUtc,
                       COALESCE(SUM(CASE WHEN [Disease] <> 0 THEN 1 ELSE 0 END), 0) AS SickItemCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 1 THEN 1 ELSE 0 END), 0) AS ExcessiveWaitCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 2 THEN 1 ELSE 0 END), 0) AS StaleProcessingCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 3 THEN 1 ELSE 0 END), 0) AS RecurrentExecutionCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 4 THEN 1 ELSE 0 END), 0) AS RepeatedFailureCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 5 THEN 1 ELSE 0 END), 0) AS TerminalFailureCount
                  FROM ClassifiedItem;", HealthParameters(now, thresholds))
                .Single();

            var oldestAgeSeconds = snapshot.OldestEligibleAtUtc.HasValue
                ? Math.Max(0, (long)(now - snapshot.OldestEligibleAtUtc.Value).TotalSeconds)
                : 0;

            return new WorkerQueueHealthSnapshot(
                snapshot.EligibleCount,
                oldestAgeSeconds,
                snapshot.SickItemCount,
                snapshot.ExcessiveWaitCount,
                snapshot.StaleProcessingCount,
                snapshot.RecurrentExecutionCount,
                snapshot.RepeatedFailureCount,
                snapshot.TerminalFailureCount);
        }

        public IReadOnlyList<WorkerQueueSickItem> GetSickSagaItems(
            WorkerQueueItemHealthThresholds thresholds,
            int limit)
        {
            var now = DateTime.UtcNow;
            var safeLimit = Math.Clamp(limit, 1, 100);
            var rows = _unitOfWork.Query<SickSagaItemRow>(
                ItemHealthProjection + @"
                SELECT TOP (@Limit)
                       [ItemReference],
                       [ItemType],
                       [Disease],
                       [EligibleAgeSeconds],
                       [ProcessingAgeSeconds],
                       [ExecutionCount],
                       [RetryCount],
                       CASE
                           WHEN [Disease] = 5 THEN 'terminal_failed'
                           WHEN [Disease] = 4 THEN 'retry_scheduled'
                           WHEN [LockedBy] IS NOT NULL THEN 'processing'
                           WHEN [StepStatus] = 3 THEN 'waiting_response'
                           ELSE 'waiting'
                       END AS LastOutcome,
                       [OperationalEntityId],
                       [RootOperationId],
                       [ExecutionId],
                       CASE WHEN NULLIF([ErrorMessage], '') IS NULL THEN NULL
                            ELSE LOWER(CONVERT(varchar(64), HASHBYTES('SHA2_256', [ErrorMessage]), 2))
                       END AS ErrorSignature
                  FROM ClassifiedItem
                 WHERE [Disease] <> 0
                 ORDER BY CASE [Disease]
                              WHEN 5 THEN 1
                              WHEN 2 THEN 2
                              WHEN 4 THEN 3
                              WHEN 3 THEN 4
                              ELSE 5
                          END,
                          [EligibleAgeSeconds] DESC,
                          [ProcessingAgeSeconds] DESC;",
                new
                {
                    Limit = safeLimit,
                    ProcessingScope = _executionContext.ProcessingScope,
                    Now = now,
                    StaleLockLimit = now.AddMinutes(-1),
                    ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                    ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                    thresholds.RecurrentExecutionCount,
                    thresholds.RepeatedFailureCount
                });

            return rows
                .Select(row => new WorkerQueueSickItem(
                    row.ItemReference,
                    row.ItemType,
                    (WorkerQueueItemDisease)row.Disease,
                    row.Disease is 2 or 5 ? "critical" : "warning",
                    Math.Max(0, row.EligibleAgeSeconds),
                    Math.Max(0, row.ProcessingAgeSeconds),
                    row.ExecutionCount,
                    row.RetryCount,
                    row.LastOutcome,
                    row.OperationalEntityId,
                    row.RootOperationId,
                    row.ExecutionId,
                    row.ErrorSignature))
                .ToList();
        }

        private object HealthParameters(
            DateTime now,
            WorkerQueueItemHealthThresholds thresholds) => new
            {
                ProcessingScope = _executionContext.ProcessingScope,
                Now = now,
                StaleLockLimit = now.AddMinutes(-1),
                ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                thresholds.RecurrentExecutionCount,
                thresholds.RepeatedFailureCount
            };

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

        private sealed class RunnableSagaHealthRow
        {
            public long EligibleCount { get; init; }
            public DateTime? OldestEligibleAtUtc { get; init; }
            public long SickItemCount { get; init; }
            public long ExcessiveWaitCount { get; init; }
            public long StaleProcessingCount { get; init; }
            public long RecurrentExecutionCount { get; init; }
            public long RepeatedFailureCount { get; init; }
            public long TerminalFailureCount { get; init; }
        }

        private sealed class SickSagaItemRow
        {
            public string ItemReference { get; init; } = string.Empty;
            public string ItemType { get; init; } = string.Empty;
            public int Disease { get; init; }
            public long EligibleAgeSeconds { get; init; }
            public long ProcessingAgeSeconds { get; init; }
            public int ExecutionCount { get; init; }
            public int RetryCount { get; init; }
            public string LastOutcome { get; init; } = string.Empty;
            public string? OperationalEntityId { get; init; }
            public string? RootOperationId { get; init; }
            public string? ExecutionId { get; init; }
            public string? ErrorSignature { get; init; }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
