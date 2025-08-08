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
    public class yPerfilReadRepository : IyPerfilReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IyPerfilQueryRead _query;

        public yPerfilReadRepository(SqlFactory factory, ICurrentUser correntUser,IyPerfilQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<yPerfilDTO> getyPerfil(ICommandRead command )
         {
            if (command is Command.Read.yPerfilReadCommand c)
                return getyPerfil(c );
            throw new NotImplementedException();
        }
        private DataPagination<yPerfilDTO> getyPerfil(Command.Read.yPerfilReadCommand command )
        {
            var query = _query.yPerfilQuery(command );

                var itens = _connection.Query<yPerfilDTO>(query.Query,query.Parameters);
                return new DataPagination<yPerfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yPerfilTenantIDDTO> getyPerfilReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yPerfilTenantIDDTO> lista;
            var query = _query.yPerfilTenantIDQuery(command );

                lista = _connection.Query<yPerfilTenantIDDTO>(query.Query,query.Parameters) as List<yPerfilTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yPerfilTenantIDDTO> getyPerfilReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yPerfilUserIdDTO> getyPerfilReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yPerfilUserIdDTO> lista;
            var query = _query.yPerfilUserIdQuery(command );

                lista = _connection.Query<yPerfilUserIdDTO>(query.Query,query.Parameters) as List<yPerfilUserIdDTO>;
            return lista;
        }

        public IEnumerable<yPerfilUserIdDTO> getyPerfilReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
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

        public yPerfilDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilDTO FirstByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllByDescription(string value )
        {
            var query = _query.FirstByDescriptionQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

        public IEnumerable<yPerfilDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yPerfilDTO>(query.Query,query.Parameters) as List<yPerfilDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration