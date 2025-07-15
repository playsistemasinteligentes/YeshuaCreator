using Dapper;
using Output.Querys.Ytenant_Configuration;
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
    public class Ytenant_ConfigurationReadRepository : IYtenant_ConfigurationReadRepository
    {
        protected readonly IDbConnection _connection;

        public Ytenant_ConfigurationReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Ytenant_ConfigurationDTO> getYtenant_Configuration(ICommandRead command)
         {
            if (command is Command.Commands.Read.Ytenant_ConfigurationReadCommand c)
                return getYtenant_Configuration(c);
            throw new NotImplementedException();
        }
        private DataPagination<Ytenant_ConfigurationDTO> getYtenant_Configuration(Command.Commands.Read.Ytenant_ConfigurationReadCommand command)
        {
            var query = new Ytenant_ConfigurationReadQuery().Ytenant_ConfigurationQuery(command);

                var itens = _connection.Query<Ytenant_ConfigurationDTO>(query.Query,query.Parameters);
                return new DataPagination<Ytenant_ConfigurationDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Ytenant_ConfigurationTenantIDDTO> getYtenant_ConfigurationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Ytenant_ConfigurationTenantIDDTO> lista;
            var query = new Ytenant_ConfigurationReadQuery().Ytenant_ConfigurationTenantIDQuery(command);

                lista = _connection.Query<Ytenant_ConfigurationTenantIDDTO>(query.Query,query.Parameters) as List<Ytenant_ConfigurationTenantIDDTO>;
            return lista;
        }

        public IEnumerable<Ytenant_ConfigurationTenantIDDTO> getYtenant_ConfigurationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYtenant_ConfigurationReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditTrackerActived(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().ExistsByAuditTrackerActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditCRUDActived(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().ExistsByAuditCRUDActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Ytenant_ConfigurationDTO FirstById(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Ytenant_ConfigurationDTO>(query.Query, query.Parameters);
                return result;
        }

        public Ytenant_ConfigurationDTO FirstByAuditTrackerActived(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().FirstByAuditTrackerActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<Ytenant_ConfigurationDTO>(query.Query, query.Parameters);
                return result;
        }

        public Ytenant_ConfigurationDTO FirstByAuditCRUDActived(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().FirstByAuditCRUDActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<Ytenant_ConfigurationDTO>(query.Query, query.Parameters);
                return result;
        }

        public Ytenant_ConfigurationDTO FirstByTenantID(int value)
        {
            var query = new Ytenant_ConfigurationReadQuery().FirstByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<Ytenant_ConfigurationDTO>(query.Query, query.Parameters);
                return result;
        }

        public Ytenant_ConfigurationDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration