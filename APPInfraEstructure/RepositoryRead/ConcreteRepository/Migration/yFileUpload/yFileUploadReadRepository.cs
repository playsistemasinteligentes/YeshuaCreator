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
    public class yFileUploadReadRepository : IyFileUploadReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyFileUploadQueryRead _query;

        public yFileUploadReadRepository(SqlFactory factory, ICurrentUser currentUser,IyFileUploadQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yFileUploadDTO> getyFileUpload(ICommandRead command )
         {
            if (command is Command.Read.yFileUploadReadCommand c)
                return getyFileUpload(c );
            throw new NotImplementedException();
        }
        private DataPagination<yFileUploadDTO> getyFileUpload(Command.Read.yFileUploadReadCommand command )
        {
            var query = _query.yFileUploadQuery(command );

                var itens = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters);
                return new DataPagination<yFileUploadDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yFileUploadTenantIDDTO> lista;
            var query = _query.yFileUploadTenantIDQuery(command );

                lista = _connection.Query<yFileUploadTenantIDDTO>(query.Query,query.Parameters) as List<yFileUploadTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyFileUploadReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yFileUploadUserIdDTO> lista;
            var query = _query.yFileUploadUserIdQuery(command );

                lista = _connection.Query<yFileUploadUserIdDTO>(query.Query,query.Parameters) as List<yFileUploadUserIdDTO>;
            return lista;
        }

        public IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyFileUploadReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIdempotencyKey(string value )
        {
            var query = _query.ExistsByIdempotencyKeyQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByType(string value )
        {
            var query = _query.ExistsByTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFilePath(string value )
        {
            var query = _query.ExistsByFilePathQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFileSize(long value )
        {
            var query = _query.ExistsByFileSizeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByContentType(string value )
        {
            var query = _query.ExistsByContentTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value )
        {
            var query = _query.ExistsByCreatedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCompletedAt(DateTime value )
        {
            var query = _query.ExistsByCompletedAtQuery(value );

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

        public yFileUploadDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByIdempotencyKey(string value )
        {
            var query = _query.FirstByIdempotencyKeyQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByFilePath(string value )
        {
            var query = _query.FirstByFilePathQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByFileSize(long value )
        {
            var query = _query.FirstByFileSizeQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByContentType(string value )
        {
            var query = _query.FirstByContentTypeQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByCompletedAt(DateTime value )
        {
            var query = _query.FirstByCompletedAtQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByIdempotencyKey(string value )
        {
            var query = _query.FirstByIdempotencyKeyQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByType(string value )
        {
            var query = _query.FirstByTypeQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByFilePath(string value )
        {
            var query = _query.FirstByFilePathQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByFileSize(long value )
        {
            var query = _query.FirstByFileSizeQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByContentType(string value )
        {
            var query = _query.FirstByContentTypeQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByCreatedAt(DateTime value )
        {
            var query = _query.FirstByCreatedAtQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByCompletedAt(DateTime value )
        {
            var query = _query.FirstByCompletedAtQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration