using Dapper;
using Dominio.Patterns.Saga;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.Repository
{
    public partial class ySagaReadRepository
    {
        /// <summary>
        /// ClaimRunnableSagas = pegar e travar sagas executáveis
        /// </summary>
        public IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt)
        {
            var sql = @"
                        WITH cte AS (
                            SELECT TOP (@Limit) *
                            FROM ySaga WITH (UPDLOCK, READPAST, ROWLOCK)
                            WHERE 
                                Status = 1 -- InProgress
                                AND (LockedBy IS NULL OR LockedAt < @DtNowlockedAt)
                                AND (NextExecutionAt IS NULL OR NextExecutionAt <= @DtNow)
                            ORDER BY 
                                ISNULL(NextExecutionAt, '1900-01-01') ASC
                        )
                        UPDATE cte
                        SET 
                            LockedBy = @LockedBy, 
                            LockedAt = @LockedAt,
                            NextExecutionAt = @NextExecutionAt
                        OUTPUT inserted.*;
                        ";

            var sagas = _unitOfWork.Query<ySagaDTO>(sql, new
            {   
                Limit = limit,
                LockedBy = lockedBy,
                LockedAt = lockedAt,
                NextExecutionAt = nextExecutionAt,
                DtNow = DateTime.UtcNow,
                DtNowlockedAt = lockedAt.AddMinutes(-1)

            }).ToList();

            if (!sagas.Any())
                return sagas;

            // 🔥 busca os steps
            var ids = sagas.Select(s => s.id);

            var sqlSteps = @" SELECT * FROM ySagaStep WHERE SagaId IN @Ids ";

            var steps = _unitOfWork.Query<ySagaStepDTO>(sqlSteps, new { Ids = ids });

            // 🔥 agrupa por saga
            var stepsBySaga = steps
                .GroupBy(s => s.sagaid)
                .ToDictionary(g => g.Key, g => g.ToList());

            // 🔥 injeta no DTO
            foreach (var saga in sagas)
            {
                if (stepsBySaga.TryGetValue(saga.id, out var sagaSteps))
                {
                    saga.Steps = sagaSteps;
                }
            }

            return sagas;
        }

        /// <summary>
        /// Libera lock manual (caso necessário)
        /// </summary>
        public void ReleaseLock(int sagaId, string workerId)
        {
            var sql = @"
                        UPDATE ySaga
                        SET 
                            LockedBy = NULL,
                            LockedAt = NULL
                        WHERE Id = @CorrelationId
                          AND LockedBy = @WorkerId ";

            _unitOfWork.Execute(sql, new
            {
                SagaId = sagaId,
                WorkerId = workerId
            });
        }

        public ySagaDTO GetByCorrelationId(string correlationId)
        {
            var sql = @"
                        SELECT s.*
                        FROM ySaga s
                        INNER JOIN ySagaStep st ON st.CorrelationId = s.id
                        WHERE st.CorrelationId = @CorrelationId
                    ";

            var saga = _unitOfWork.Query<ySagaDTO>(sql, new { CorrelationId = correlationId }).FirstOrDefault();

            if (saga == null)
                return null;

            // 🔥 carrega steps (igual você já faz)
            var steps = _unitOfWork.Query<ySagaStepDTO>( "SELECT * FROM ySagaStep WHERE CorrelationId = @Id", new { Id = saga.id });

            saga.Steps = steps.ToList();

            return saga;
        }


    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
