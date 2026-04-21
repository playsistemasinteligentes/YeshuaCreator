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
        public IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string workerId)
        {
            var sql = @" UPDATE TOP (@Limit) ySaga
                            SET 
                                LockedBy = @WorkerId, 
                                LockedAt = GETUTCDATE()
                            OUTPUT inserted.*
                            WHERE 
                                Status = 1 -- InProgress
                                AND (LockedBy IS NULL OR LockedAt < DATEADD(MINUTE, -1, GETUTCDATE()))
                                AND (NextExecutionAt IS NULL OR NextExecutionAt <= GETUTCDATE())";


            var sagas = _unitOfWork.Query<ySagaDTO>(sql, new
            {
                Limit = limit,
                WorkerId = workerId
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
                        WHERE Id = @SagaId
                          AND LockedBy = @WorkerId
                        ";

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
                        INNER JOIN ySagaStep st ON st.SagaId = s.id
                        WHERE st.CorrelationId = @CorrelationId
                    ";

            var saga = _unitOfWork.Query<ySagaDTO>(sql, new { CorrelationId = correlationId }).FirstOrDefault();

            if (saga == null)
                return null;

            // 🔥 carrega steps (igual você já faz)
            var steps = _unitOfWork.Query<ySagaStepDTO>( "SELECT * FROM ySagaStep WHERE SagaId = @Id", new { Id = saga.id });

            saga.Steps = steps.ToList();

            return saga;
        }


    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
