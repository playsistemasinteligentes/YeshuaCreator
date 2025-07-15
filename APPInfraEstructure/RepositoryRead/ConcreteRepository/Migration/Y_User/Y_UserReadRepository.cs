using Dapper;
using Output.Querys.Y_User;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using Read.RepositoryInterfaces;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public class Y_UserReadRepository : IY_UserReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_UserReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_UserDTO> getY_User(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_UserReadCommand c)
                return getY_User(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_UserDTO> getY_User(Command.Commands.Read.Y_UserReadCommand command)
        {
            var query = new Y_UserReadQuery().Y_UserQuery(command);

                var itens = _connection.Query<Y_UserDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_UserDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Y_UserTenantIDDTO> getY_UserReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_UserTenantIDDTO> lista;
            var query = new Y_UserReadQuery().Y_UserTenantIDQuery(command);

                lista = _connection.Query<Y_UserTenantIDDTO>(query.Query,query.Parameters) as List<Y_UserTenantIDDTO>;
            return lista;
        }

        public IEnumerable<Y_UserTenantIDDTO> getY_UserReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_UserReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = new Y_UserReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new Y_UserReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmail(string value)
        {
            var query = new Y_UserReadQuery().ExistsByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySenha(string value)
        {
            var query = new Y_UserReadQuery().ExistsBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = new Y_UserReadQuery().ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_UserDTO FirstById(int value)
        {
            var query = new Y_UserReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserDTO FirstByNome(string value)
        {
            var query = new Y_UserReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserDTO FirstByEmail(string value)
        {
            var query = new Y_UserReadQuery().FirstByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserDTO FirstBySenha(string value)
        {
            var query = new Y_UserReadQuery().FirstBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserDTO FirstByTenantID(int value)
        {
            var query = new Y_UserReadQuery().FirstByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration