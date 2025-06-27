using Dapper;
using Output.Querys.Y_Tenant_Configuration;
using Repositorio.Outputs.DTOs.Y_Tenant_Configuration;
using RepositoryInterfaces.Read.Repository.Y_Tenant_Configuration;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Tenant_Configuration
{
    public class Y_Tenant_ConfigurationReadRepository : IY_Tenant_ConfigurationReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_Tenant_ConfigurationReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_Tenant_ConfigurationDTO> getY_Tenant_Configuration(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_Tenant_ConfigurationReadCommand c)
                return getY_Tenant_Configuration(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_Tenant_ConfigurationDTO> getY_Tenant_Configuration(Command.Commands.Read.Y_Tenant_ConfigurationReadCommand command)
        {
            var query = new Y_Tenant_ConfigurationReadQuery().Y_Tenant_ConfigurationQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<Y_Tenant_ConfigurationDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_Tenant_ConfigurationDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        private IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_Tenant_ConfigurationTenantIDDTO> lista;
            var query = new Y_Tenant_ConfigurationReadQuery().Y_Tenant_ConfigurationTenantIDQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_Tenant_ConfigurationTenantIDDTO>(query.Query,query.Parameters) as List<Y_Tenant_ConfigurationTenantIDDTO>;
            }
            return lista;
        }

        public IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_Tenant_ConfigurationReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public Y_Tenant_ConfigurationDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration