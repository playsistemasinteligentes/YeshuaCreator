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
    public partial class yOutboxReadRepository : IyOutboxReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyOutboxQueryRead _query;

        public yOutboxReadRepository(IUnitOfWork unitOfWork, ICurrentUser currentUser,IyOutboxQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yOutboxDTO> getyOutbox(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.yOutboxReadCommand c)
                return getyOutbox(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<yOutboxDTO> getyOutbox(Command.Read.yOutboxReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yOutboxQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters);
                return new DataPagination<yOutboxDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yOutboxSagaIdDTO> getyOutboxReadFKSagaId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yOutboxSagaIdDTO> lista;
            var query = _query.yOutboxSagaIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yOutboxSagaIdDTO>(query.Query,query.Parameters) as List<yOutboxSagaIdDTO>;
            return lista;
        }

        public IEnumerable<yOutboxSagaIdDTO> getyOutboxReadFKSagaId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKSagaId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yOutboxSagaStepIdDTO> getyOutboxReadFKSagaStepId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yOutboxSagaStepIdDTO> lista;
            var query = _query.yOutboxSagaStepIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yOutboxSagaStepIdDTO>(query.Query,query.Parameters) as List<yOutboxSagaStepIdDTO>;
            return lista;
        }

        public IEnumerable<yOutboxSagaStepIdDTO> getyOutboxReadFKSagaStepId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKSagaStepId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yOutboxTenantIDDTO> lista;
            var query = _query.yOutboxTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yOutboxTenantIDDTO>(query.Query,query.Parameters) as List<yOutboxTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yOutboxUserIdDTO> lista;
            var query = _query.yOutboxUserIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yOutboxUserIdDTO>(query.Query,query.Parameters) as List<yOutboxUserIdDTO>;
            return lista;
        }

        public IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKUserId(c , TakeOffTenantID);
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

        public bool ExistsBySentAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySentAtQuery(value , TakeOffTenantID);

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

        public yOutboxDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByMessageId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByMessageIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstBySentAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySentAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByLastError(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastErrorQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstBySagaStepId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaStepIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByMessageId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByMessageIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByPayload(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByPayloadQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllBySentAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySentAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByRetryCountQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByLastError(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastErrorQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllBySagaStepId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaStepIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public DataPagination<yOutboxStandardDTO> GetyOutboxProximaPendente(ICommandRead command , bool TakeOffTenantID = false)
        {
            if (command is Command.Read.yOutboxProximaPendenteCommand c)
             {
            var query = _query.yOutboxProximaPendenteQuery(c , TakeOffTenantID);

                var itens = _unitOfWork.Query<yOutboxStandardDTO>(query.Query,query.Parameters);
                return new DataPagination<yOutboxStandardDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
             }
            throw new NotImplementedException();
        }


    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration