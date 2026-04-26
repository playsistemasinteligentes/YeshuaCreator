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
    public partial class yInboxReadRepository : IyInboxReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyInboxQueryRead _query;

        public yInboxReadRepository(IUnitOfWork unitOfWork, ICurrentUser currentUser,IyInboxQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yInboxDTO> getyInbox(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.yInboxReadCommand c)
                return getyInbox(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<yInboxDTO> getyInbox(Command.Read.yInboxReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yInboxQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters);
                return new DataPagination<yInboxDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yInboxSagaIdDTO> getyInboxReadFKSagaId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yInboxSagaIdDTO> lista;
            var query = _query.yInboxSagaIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yInboxSagaIdDTO>(query.Query,query.Parameters) as List<yInboxSagaIdDTO>;
            return lista;
        }

        public IEnumerable<yInboxSagaIdDTO> getyInboxReadFKSagaId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKSagaId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yInboxSagaStepIdDTO> getyInboxReadFKSagaStepId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yInboxSagaStepIdDTO> lista;
            var query = _query.yInboxSagaStepIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yInboxSagaStepIdDTO>(query.Query,query.Parameters) as List<yInboxSagaStepIdDTO>;
            return lista;
        }

        public IEnumerable<yInboxSagaStepIdDTO> getyInboxReadFKSagaStepId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKSagaStepId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yInboxTenantIDDTO> lista;
            var query = _query.yInboxTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yInboxTenantIDDTO>(query.Query,query.Parameters) as List<yInboxTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yInboxUserIdDTO> lista;
            var query = _query.yInboxUserIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yInboxUserIdDTO>(query.Query,query.Parameters) as List<yInboxUserIdDTO>;
            return lista;
        }

        public IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMessageId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByMessageIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTypeQuery(value , TakeOffTenantID);

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

        public bool ExistsByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProcessedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByProcessedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLastError(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLastErrorQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySagaStepId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySagaStepIdQuery(value , TakeOffTenantID);

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

        public yInboxDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByMessageId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByMessageIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByProcessedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByProcessedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByLastError(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastErrorQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstBySagaStepId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaStepIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByMessageId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByMessageIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByProcessedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByProcessedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByLastError(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastErrorQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllBySagaStepId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaStepIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration