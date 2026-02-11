using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public class yInboxReadRepository : IyInboxReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyInboxQueryRead _query;

        public yInboxReadRepository(SqlFactory factory, ICurrentUser currentUser,IyInboxQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yInboxDTO> getyInbox(ICommandRead command )
         {
            if (command is Command.Read.yInboxReadCommand c)
                return getyInbox(c );
            throw new NotImplementedException();
        }
        private DataPagination<yInboxDTO> getyInbox(Command.Read.yInboxReadCommand command )
        {
            var query = _query.yInboxQuery(command );

                var itens = _connection.Query<yInboxDTO>(query.Query,query.Parameters);
                return new DataPagination<yInboxDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yInboxTenantIDDTO> lista;
            var query = _query.yInboxTenantIDQuery(command );

                lista = _connection.Query<yInboxTenantIDDTO>(query.Query,query.Parameters) as List<yInboxTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yInboxUserIdDTO> lista;
            var query = _query.yInboxUserIdQuery(command );

                lista = _connection.Query<yInboxUserIdDTO>(query.Query,query.Parameters) as List<yInboxUserIdDTO>;
            return lista;
        }

        public IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyInboxReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMessageId(string value )
        {
            var query = _query.ExistsByMessageIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByJobId(string value )
        {
            var query = _query.ExistsByJobIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByType(string value )
        {
            var query = _query.ExistsByTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPayload(string value )
        {
            var query = _query.ExistsByPayloadQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value )
        {
            var query = _query.ExistsByCreatedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySentAt(DateTime value )
        {
            var query = _query.ExistsBySentAtQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRetryCount(int value )
        {
            var query = _query.ExistsByRetryCountQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLastError(string value )
        {
            var query = _query.ExistsByLastErrorQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public yInboxDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByMessageId(string value )
        {
            var query = _query.FirstByMessageIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByJobId(string value )
        {
            var query = _query.FirstByJobIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByPayload(string value )
        {
            var query = _query.FirstByPayloadQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstBySentAt(DateTime value )
        {
            var query = _query.FirstBySentAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByRetryCount(int value )
        {
            var query = _query.FirstByRetryCountQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByLastError(string value )
        {
            var query = _query.FirstByLastErrorQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yInboxDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yInboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByMessageId(string value )
        {
            var query = _query.FirstByMessageIdQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByJobId(string value )
        {
            var query = _query.FirstByJobIdQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByPayload(string value )
        {
            var query = _query.FirstByPayloadQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllBySentAt(DateTime value )
        {
            var query = _query.FirstBySentAtQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByRetryCount(int value )
        {
            var query = _query.FirstByRetryCountQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByLastError(string value )
        {
            var query = _query.FirstByLastErrorQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

        public IEnumerable<yInboxDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yInboxDTO>(query.Query,query.Parameters) as List<yInboxDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration