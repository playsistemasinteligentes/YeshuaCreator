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
    public partial class yGrantReadRepository : IyGrantReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyGrantQueryRead _query;

        public yGrantReadRepository(ISqlFactory factory, ICurrentUser currentUser,IyGrantQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yGrantDTO> getyGrant(ICommandRead command )
         {
            if (command is Command.Read.yGrantReadCommand c)
                return getyGrant(c );
            throw new NotImplementedException();
        }
        private DataPagination<yGrantDTO> getyGrant(Command.Read.yGrantReadCommand command )
        {
            var query = _query.yGrantQuery(command );

                var itens = _connection.Query<yGrantDTO>(query.Query,query.Parameters);
                return new DataPagination<yGrantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yGrantTenantIDDTO> getyGrantReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yGrantTenantIDDTO> lista;
            var query = _query.yGrantTenantIDQuery(command );

                lista = _connection.Query<yGrantTenantIDDTO>(query.Query,query.Parameters) as List<yGrantTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yGrantTenantIDDTO> getyGrantReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyGrantReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yGrantUserIdDTO> getyGrantReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yGrantUserIdDTO> lista;
            var query = _query.yGrantUserIdQuery(command );

                lista = _connection.Query<yGrantUserIdDTO>(query.Query,query.Parameters) as List<yGrantUserIdDTO>;
            return lista;
        }

        public IEnumerable<yGrantUserIdDTO> getyGrantReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyGrantReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(string value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value )
        {
            var query = _query.ExistsByDescriptionQuery(value );

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

        public yGrantDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yGrantDTO FirstByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yGrantDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yGrantDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yGrantDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yGrantDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

        public IEnumerable<yGrantDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yGrantDTO>(query.Query,query.Parameters) as List<yGrantDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration