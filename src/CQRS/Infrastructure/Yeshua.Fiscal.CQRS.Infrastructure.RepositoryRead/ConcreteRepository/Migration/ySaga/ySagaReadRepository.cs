// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class ySagaReadRepository : IySagaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IySagaQueryRead _query;

        public ySagaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IySagaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetySagaCustom(Command.Read.ySagaReadCommand command, ref DataPagination<ySagaDTO> result, ref bool handled);

        public DataPagination<ySagaDTO> getySaga(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.ySagaReadCommand c)
                return getySaga(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<ySagaDTO> getySaga(Command.Read.ySagaReadCommand command , bool TakeOffTenantID = false)
        {
            var customResult = new DataPagination<ySagaDTO>();
            var customHandled = false;
            TryGetySagaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ySagaQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters);
                return new DataPagination<ySagaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ySagaTenantIDDTO> getySagaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.ySagaTenantIDQuery(command , TakeOffTenantID);

                var lista = _unitOfWork.Query<ySagaTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ySagaTenantIDDTO> getySagaReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ySagaUserIdDTO> getySagaReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.ySagaUserIdQuery(command , TakeOffTenantID);

                var lista = _unitOfWork.Query<ySagaUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ySagaUserIdDTO> getySagaReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRootOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByRootOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExecutionId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByExecutionIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCausationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCausationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ySagaDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByRootOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRootOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByExecutionId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByExecutionIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCausationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCausationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByOperationalEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByOperationalEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByRootOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRootOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByOperationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByOperationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByExecutionId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByExecutionIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCausationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCausationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByOperationalEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByOperationalEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

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
                           COALESCE(NULLIF(s.[CorrelationId], ''), CONVERT(varchar(20), s.[Id])) AS ItemReference,
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

        public IEnumerable<ySagaDTO> ClaimRunnableSagas(
            int limit,
            string lockedBy,
            DateTime lockedAt,
            DateTime nextExecutionAt)
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
                Limit = Math.Clamp(limit, 1, 100),
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
                .Query<ySagaStepDTO>(
                    "SELECT * FROM [ySagaStep] WHERE [SagaId] IN @Ids AND [Deleted] = 0",
                    new { Ids = ids })
                .ToList();
            var stepsBySaga = steps
                .GroupBy(step => step.sagaid)
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var saga in sagas)
                if (stepsBySaga.TryGetValue(saga.id, out var sagaSteps))
                    saga.Steps = sagaSteps;

            return sagas;
        }

        public RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot GetRunnableSagaHealth(
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds)
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
                  FROM ClassifiedItem;",
                HealthParameters(now, thresholds))
                .Single();

            var oldestAgeSeconds = snapshot.OldestEligibleAtUtc.HasValue
                ? Math.Max(0, (long)(now - snapshot.OldestEligibleAtUtc.Value).TotalSeconds)
                : 0;

            return new RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot(
                snapshot.EligibleCount,
                oldestAgeSeconds,
                snapshot.SickItemCount,
                snapshot.ExcessiveWaitCount,
                snapshot.StaleProcessingCount,
                snapshot.RecurrentExecutionCount,
                snapshot.RepeatedFailureCount,
                snapshot.TerminalFailureCount);
        }

        public IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> GetSickSagaItems(
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds,
            int limit)
        {
            var now = DateTime.UtcNow;
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
                    Limit = Math.Clamp(limit, 1, 100),
                    ProcessingScope = _executionContext.ProcessingScope,
                    Now = now,
                    StaleLockLimit = now.AddMinutes(-1),
                    ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                    ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                    thresholds.RecurrentExecutionCount,
                    thresholds.RepeatedFailureCount
                });

            return rows
                .Select(row => new RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem(
                    row.ItemReference,
                    row.ItemType,
                    (RepositoryInterfaces.Patterns.Worker.WorkerQueueItemDisease)row.Disease,
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
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds) => new
            {
                ProcessingScope = _executionContext.ProcessingScope,
                Now = now,
                StaleLockLimit = now.AddMinutes(-1),
                ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                thresholds.RecurrentExecutionCount,
                thresholds.RepeatedFailureCount
            };

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