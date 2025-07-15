using Dapper;
using Output.Querys.Y_Tenant;
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
    public class Y_TenantReadRepository : IY_TenantReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_TenantReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_TenantDTO> getY_Tenant(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_TenantReadCommand c)
                return getY_Tenant(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_TenantDTO> getY_Tenant(Command.Commands.Read.Y_TenantReadCommand command)
        {
            var query = new Y_TenantReadQuery().Y_TenantQuery(command);

                var itens = _connection.Query<Y_TenantDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_TenantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Y_TenantUserIDAdminDTO> getY_TenantReadFKUserIDAdmin(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_TenantUserIDAdminDTO> lista;
            var query = new Y_TenantReadQuery().Y_TenantUserIDAdminQuery(command);

                lista = _connection.Query<Y_TenantUserIDAdminDTO>(query.Query,query.Parameters) as List<Y_TenantUserIDAdminDTO>;
            return lista;
        }

        public IEnumerable<Y_TenantUserIDAdminDTO> getY_TenantReadFKUserIDAdmin(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_TenantReadFKUserIDAdmin(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = new Y_TenantReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCnpjCpf(int value)
        {
            var query = new Y_TenantReadQuery().ExistsByCnpjCpfQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new Y_TenantReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserIDAdmin(int value)
        {
            var query = new Y_TenantReadQuery().ExistsByUserIDAdminQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_TenantDTO FirstById(int value)
        {
            var query = new Y_TenantReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_TenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_TenantDTO FirstByCnpjCpf(int value)
        {
            var query = new Y_TenantReadQuery().FirstByCnpjCpfQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_TenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_TenantDTO FirstByNome(string value)
        {
            var query = new Y_TenantReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_TenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_TenantDTO FirstByUserIDAdmin(int value)
        {
            var query = new Y_TenantReadQuery().FirstByUserIDAdminQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_TenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_TenantDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration