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
    public class yOutboxReadRepository : IyOutboxReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyOutboxQueryRead _query;

        public yOutboxReadRepository(SqlFactory factory, ICurrentUser currentUser,IyOutboxQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yOutboxDTO> getyOutbox(ICommandRead command )
         {
            if (command is Command.Read.yOutboxReadCommand c)
                return getyOutbox(c );
            throw new NotImplementedException();
        }
        private DataPagination<yOutboxDTO> getyOutbox(Command.Read.yOutboxReadCommand command )
        {
            var query = _query.yOutboxQuery(command );

                var itens = _connection.Query<yOutboxDTO>(query.Query,query.Parameters);
                return new DataPagination<yOutboxDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yOutboxTenantIDDTO> lista;
            var query = _query.yOutboxTenantIDQuery(command );

                lista = _connection.Query<yOutboxTenantIDDTO>(query.Query,query.Parameters) as List<yOutboxTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yOutboxUserIdDTO> lista;
            var query = _query.yOutboxUserIdQuery(command );

                lista = _connection.Query<yOutboxUserIdDTO>(query.Query,query.Parameters) as List<yOutboxUserIdDTO>;
            return lista;
        }

        public IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyOutboxReadFKUserId(c );
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

        public yOutboxDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByMessageId(string value )
        {
            var query = _query.FirstByMessageIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByJobId(string value )
        {
            var query = _query.FirstByJobIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByPayload(string value )
        {
            var query = _query.FirstByPayloadQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstBySentAt(DateTime value )
        {
            var query = _query.FirstBySentAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByRetryCount(int value )
        {
            var query = _query.FirstByRetryCountQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByLastError(string value )
        {
            var query = _query.FirstByLastErrorQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public yOutboxDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yOutboxDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByMessageId(string value )
        {
            var query = _query.FirstByMessageIdQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByJobId(string value )
        {
            var query = _query.FirstByJobIdQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByPayload(string value )
        {
            var query = _query.FirstByPayloadQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllBySentAt(DateTime value )
        {
            var query = _query.FirstBySentAtQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByRetryCount(int value )
        {
            var query = _query.FirstByRetryCountQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByLastError(string value )
        {
            var query = _query.FirstByLastErrorQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

        public IEnumerable<yOutboxDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yOutboxDTO>(query.Query,query.Parameters) as List<yOutboxDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration