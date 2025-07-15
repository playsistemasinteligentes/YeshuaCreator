using Dapper;
using Output.Querys.Y_Permtions;
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
    public class Y_PermtionsReadRepository : IY_PermtionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PermtionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_PermtionsDTO> getY_Permtions(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_PermtionsReadCommand c)
                return getY_Permtions(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_PermtionsDTO> getY_Permtions(Command.Commands.Read.Y_PermtionsReadCommand command)
        {
            var query = new Y_PermtionsReadQuery().Y_PermtionsQuery(command);

                var itens = _connection.Query<Y_PermtionsDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_PermtionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(string value)
        {
            var query = new Y_PermtionsReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value)
        {
            var query = new Y_PermtionsReadQuery().ExistsByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_PermtionsDTO FirstById(string value)
        {
            var query = new Y_PermtionsReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PermtionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PermtionsDTO FirstByDescription(string value)
        {
            var query = new Y_PermtionsReadQuery().FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PermtionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PermtionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration