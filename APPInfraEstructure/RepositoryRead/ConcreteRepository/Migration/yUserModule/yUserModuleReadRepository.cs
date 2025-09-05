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
    public class yUserModuleReadRepository : IyUserModuleReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyUserModuleQueryRead _query;

        public yUserModuleReadRepository(SqlFactory factory, ICurrentUser currentUser,IyUserModuleQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yUserModuleDTO> getyUserModule(ICommandRead command )
         {
            if (command is Command.Read.yUserModuleReadCommand c)
                return getyUserModule(c );
            throw new NotImplementedException();
        }
        private DataPagination<yUserModuleDTO> getyUserModule(Command.Read.yUserModuleReadCommand command )
        {
            var query = _query.yUserModuleQuery(command );

                var itens = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters);
                return new DataPagination<yUserModuleDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yUserModuleModuleIdDTO> getyUserModuleReadFKModuleId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserModuleModuleIdDTO> lista;
            var query = _query.yUserModuleModuleIdQuery(command );

                lista = _connection.Query<yUserModuleModuleIdDTO>(query.Query,query.Parameters) as List<yUserModuleModuleIdDTO>;
            return lista;
        }

        public IEnumerable<yUserModuleModuleIdDTO> getyUserModuleReadFKModuleId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserModuleReadFKModuleId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserModuleUserIdDTO> getyUserModuleReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserModuleUserIdDTO> lista;
            var query = _query.yUserModuleUserIdQuery(command );

                lista = _connection.Query<yUserModuleUserIdDTO>(query.Query,query.Parameters) as List<yUserModuleUserIdDTO>;
            return lista;
        }

        public IEnumerable<yUserModuleUserIdDTO> getyUserModuleReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserModuleReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserModuleTenantIDDTO> getyUserModuleReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserModuleTenantIDDTO> lista;
            var query = _query.yUserModuleTenantIDQuery(command );

                lista = _connection.Query<yUserModuleTenantIDDTO>(query.Query,query.Parameters) as List<yUserModuleTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yUserModuleTenantIDDTO> getyUserModuleReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserModuleReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByModuleId(string value )
        {
            var query = _query.ExistsByModuleIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

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

        public yUserModuleDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByModuleId(string value )
        {
            var query = _query.FirstByModuleIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserModuleDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yUserModuleDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByModuleId(string value )
        {
            var query = _query.FirstByModuleIdQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

        public IEnumerable<yUserModuleDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yUserModuleDTO>(query.Query,query.Parameters) as List<yUserModuleDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration