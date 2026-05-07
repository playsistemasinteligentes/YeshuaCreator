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
    public partial class ySagaStepReadRepository : IySagaStepReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IySagaStepQueryRead _query;

        public ySagaStepReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IySagaStepQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ySagaStepDTO> getySagaStep(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.ySagaStepReadCommand c)
                return getySagaStep(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<ySagaStepDTO> getySagaStep(Command.Read.ySagaStepReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.ySagaStepQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters);
                return new DataPagination<ySagaStepDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ySagaStepSagaIdDTO> getySagaStepReadFKSagaId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<ySagaStepSagaIdDTO> lista;
            var query = _query.ySagaStepSagaIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<ySagaStepSagaIdDTO>(query.Query,query.Parameters) as List<ySagaStepSagaIdDTO>;
            return lista;
        }

        public IEnumerable<ySagaStepSagaIdDTO> getySagaStepReadFKSagaId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaStepReadFKSagaId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ySagaStepTenantIDDTO> getySagaStepReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<ySagaStepTenantIDDTO> lista;
            var query = _query.ySagaStepTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<ySagaStepTenantIDDTO>(query.Query,query.Parameters) as List<ySagaStepTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ySagaStepTenantIDDTO> getySagaStepReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaStepReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ySagaStepUserIdDTO> getySagaStepReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<ySagaStepUserIdDTO> lista;
            var query = _query.ySagaStepUserIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<ySagaStepUserIdDTO>(query.Query,query.Parameters) as List<ySagaStepUserIdDTO>;
            return lista;
        }

        public IEnumerable<ySagaStepUserIdDTO> getySagaStepReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaStepReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStepKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByStepKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIndexOrder(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIndexOrderQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByExecutionCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByExecutionCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLastExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLastExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByErrorMessage(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByErrorMessageQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByRetryCountQuery(value , TakeOffTenantID);

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

        public ySagaStepDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByStepKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStepKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByIndexOrder(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIndexOrderQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByExecutionCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByExecutionCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByLastExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByErrorMessage(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByErrorMessageQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaStepDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaStepDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByStepKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStepKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByIndexOrder(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIndexOrderQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByCorrelationId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCorrelationIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByExecutionCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByExecutionCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByLastExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByErrorMessage(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByErrorMessageQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

        public IEnumerable<ySagaStepDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaStepDTO>(query.Query,query.Parameters) as List<ySagaStepDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration