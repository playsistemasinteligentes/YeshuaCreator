using Dapper;
using Output.Querys.Ypermtions;
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
    public class YpermtionsReadRepository : IYpermtionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public YpermtionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<YpermtionsDTO> getYpermtions(ICommandRead command)
         {
            if (command is Command.Commands.Read.YpermtionsReadCommand c)
                return getYpermtions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YpermtionsDTO> getYpermtions(Command.Commands.Read.YpermtionsReadCommand command)
        {
            var query = new YpermtionsReadQuery().YpermtionsQuery(command);

                var itens = _connection.Query<YpermtionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YpermtionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(string value)
        {
            var query = new YpermtionsReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value)
        {
            var query = new YpermtionsReadQuery().ExistsByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YpermtionsDTO FirstById(string value)
        {
            var query = new YpermtionsReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermtionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermtionsDTO FirstByDescription(string value)
        {
            var query = new YpermtionsReadQuery().FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermtionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermtionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration