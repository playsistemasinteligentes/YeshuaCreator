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
    public partial class PlanoContaReadRepository : IPlanoContaReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IPlanoContaQueryRead _query;

        public PlanoContaReadRepository(SqlFactory factory, ICurrentUser currentUser,IPlanoContaQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<PlanoContaDTO> getPlanoConta(ICommandRead command )
         {
            if (command is Command.Read.PlanoContaReadCommand c)
                return getPlanoConta(c );
            throw new NotImplementedException();
        }
        private DataPagination<PlanoContaDTO> getPlanoConta(Command.Read.PlanoContaReadCommand command )
        {
            var query = _query.PlanoContaQuery(command );

                var itens = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters);
                return new DataPagination<PlanoContaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PlanoContaTenantIDDTO> getPlanoContaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoContaTenantIDDTO> lista;
            var query = _query.PlanoContaTenantIDQuery(command );

                lista = _connection.Query<PlanoContaTenantIDDTO>(query.Query,query.Parameters) as List<PlanoContaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PlanoContaTenantIDDTO> getPlanoContaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoContaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanoContaUserIdDTO> getPlanoContaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoContaUserIdDTO> lista;
            var query = _query.PlanoContaUserIdQuery(command );

                lista = _connection.Query<PlanoContaUserIdDTO>(query.Query,query.Parameters) as List<PlanoContaUserIdDTO>;
            return lista;
        }

        public IEnumerable<PlanoContaUserIdDTO> getPlanoContaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoContaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCodigo(string value )
        {
            var query = _query.ExistsByCodigoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipo(int value )
        {
            var query = _query.ExistsByTipoQuery(value );

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

        public PlanoContaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByCodigo(string value )
        {
            var query = _query.FirstByCodigoQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByTipo(int value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoContaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<PlanoContaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByCodigo(string value )
        {
            var query = _query.FirstByCodigoQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByTipo(int value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

        public IEnumerable<PlanoContaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<PlanoContaDTO>(query.Query,query.Parameters) as List<PlanoContaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration