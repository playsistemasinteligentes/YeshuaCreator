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
    public class yUserGrantReadRepository : IyUserGrantReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IyUserGrantQueryRead _query;

        public yUserGrantReadRepository(SqlFactory factory, ICurrentUser correntUser,IyUserGrantQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<yUserGrantDTO> getyUserGrant(ICommandRead command )
         {
            if (command is Command.Read.yUserGrantReadCommand c)
                return getyUserGrant(c );
            throw new NotImplementedException();
        }
        private DataPagination<yUserGrantDTO> getyUserGrant(Command.Read.yUserGrantReadCommand command )
        {
            var query = _query.yUserGrantQuery(command );

                var itens = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters);
                return new DataPagination<yUserGrantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yUserGrantPerfilIdDTO> getyUserGrantReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantPerfilIdDTO> lista;
            var query = _query.yUserGrantPerfilIdQuery(command );

                lista = _connection.Query<yUserGrantPerfilIdDTO>(query.Query,query.Parameters) as List<yUserGrantPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantPerfilIdDTO> getyUserGrantReadFKPerfilId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKPerfilId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantGrantIdDTO> getyUserGrantReadFKGrantId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantGrantIdDTO> lista;
            var query = _query.yUserGrantGrantIdQuery(command );

                lista = _connection.Query<yUserGrantGrantIdDTO>(query.Query,query.Parameters) as List<yUserGrantGrantIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantGrantIdDTO> getyUserGrantReadFKGrantId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKGrantId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantTenantIDDTO> getyUserGrantReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantTenantIDDTO> lista;
            var query = _query.yUserGrantTenantIDQuery(command );

                lista = _connection.Query<yUserGrantTenantIDDTO>(query.Query,query.Parameters) as List<yUserGrantTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantTenantIDDTO> getyUserGrantReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantUserIdDTO> getyUserGrantReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantUserIdDTO> lista;
            var query = _query.yUserGrantUserIdQuery(command );

                lista = _connection.Query<yUserGrantUserIdDTO>(query.Query,query.Parameters) as List<yUserGrantUserIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantUserIdDTO> getyUserGrantReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPerfilId(int value )
        {
            var query = _query.ExistsByPerfilIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrantId(string value )
        {
            var query = _query.ExistsByGrantIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrant(bool value )
        {
            var query = _query.ExistsByGrantQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreate(bool value )
        {
            var query = _query.ExistsByCreateQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRead(bool value )
        {
            var query = _query.ExistsByReadQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUpdate(bool value )
        {
            var query = _query.ExistsByUpdateQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDelete(bool value )
        {
            var query = _query.ExistsByDeleteQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value )
        {
            var query = _query.ExistsByValidUntilQuery(value );

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

        public yUserGrantDTO FirstByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByGrant(bool value )
        {
            var query = _query.FirstByGrantQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCreate(bool value )
        {
            var query = _query.FirstByCreateQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByRead(bool value )
        {
            var query = _query.FirstByReadQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByUpdate(bool value )
        {
            var query = _query.FirstByUpdateQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByDelete(bool value )
        {
            var query = _query.FirstByDeleteQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByGrant(bool value )
        {
            var query = _query.FirstByGrantQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCreate(bool value )
        {
            var query = _query.FirstByCreateQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByRead(bool value )
        {
            var query = _query.FirstByReadQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByUpdate(bool value )
        {
            var query = _query.FirstByUpdateQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByDelete(bool value )
        {
            var query = _query.FirstByDeleteQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration