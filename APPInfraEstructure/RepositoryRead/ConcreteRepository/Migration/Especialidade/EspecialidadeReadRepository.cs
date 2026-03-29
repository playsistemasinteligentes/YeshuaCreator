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
    public partial class EspecialidadeReadRepository : IEspecialidadeReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IEspecialidadeQueryRead _query;

        public EspecialidadeReadRepository(ISqlFactory factory, ICurrentUser currentUser,IEspecialidadeQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command )
         {
            if (command is Command.Read.EspecialidadeReadCommand c)
                return getEspecialidade(c );
            throw new NotImplementedException();
        }
        private DataPagination<EspecialidadeDTO> getEspecialidade(Command.Read.EspecialidadeReadCommand command )
        {
            var query = _query.EspecialidadeQuery(command );

                var itens = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters);
                return new DataPagination<EspecialidadeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EspecialidadeTenantIDDTO> getEspecialidadeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EspecialidadeTenantIDDTO> lista;
            var query = _query.EspecialidadeTenantIDQuery(command );

                lista = _connection.Query<EspecialidadeTenantIDDTO>(query.Query,query.Parameters) as List<EspecialidadeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EspecialidadeTenantIDDTO> getEspecialidadeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEspecialidadeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EspecialidadeUserIdDTO> getEspecialidadeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EspecialidadeUserIdDTO> lista;
            var query = _query.EspecialidadeUserIdQuery(command );

                lista = _connection.Query<EspecialidadeUserIdDTO>(query.Query,query.Parameters) as List<EspecialidadeUserIdDTO>;
            return lista;
        }

        public IEnumerable<EspecialidadeUserIdDTO> getEspecialidadeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEspecialidadeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

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

        public EspecialidadeDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

        public IEnumerable<EspecialidadeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters) as List<EspecialidadeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration