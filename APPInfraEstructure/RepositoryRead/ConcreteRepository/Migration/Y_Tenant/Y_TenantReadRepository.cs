using Dapper;
using Output.Querys.Y_Tenant;
using Repositorio.Outputs.DTOs.Y_Tenant;
using RepositoryInterfaces.Read.Repository.Y_Tenant;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Tenant
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

            using (_connection)
            {
                var itens = _connection.Query<Y_TenantDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_TenantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        private IEnumerable<Y_TenantUserIDAdminDTO> getY_TenantReadFKUserIDAdmin(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_TenantUserIDAdminDTO> lista;
            var query = new Y_TenantReadQuery().Y_TenantUserIDAdminQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_TenantUserIDAdminDTO>(query.Query,query.Parameters) as List<Y_TenantUserIDAdminDTO>;
            }
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

        public Y_TenantDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration