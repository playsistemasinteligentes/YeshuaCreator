// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
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

            return _unitOfWork.ExecuteScalar<int>(sql, new
            {
                SagaId = sagaId,
                LockedBy = lockedBy,
                LockedAt = lockedAt,
                NextExecutionAt = nextExecutionAt,
                ProcessingScope = _executionContext.ProcessingScope,
                StaleLockLimit = lockedAt.AddMinutes(-1)
            }) == 1;
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

            saga.Steps = _unitOfWork.Query<ySagaStepDTO>(
                @"SELECT *
                    FROM [ySagaStep]
                   WHERE [SagaId] = @SagaId
                     AND [Deleted] = 0
                   ORDER BY [IndexOrder];",
                new { SagaId = saga.id })
                .ToList();

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
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
