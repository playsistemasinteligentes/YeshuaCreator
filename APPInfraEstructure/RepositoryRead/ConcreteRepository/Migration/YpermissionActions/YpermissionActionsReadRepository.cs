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
    public class YpermissionActionsReadRepository : IYpermissionActionsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYpermissionActionsQueryRead _query;

        public YpermissionActionsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYpermissionActionsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YpermissionActionsDTO> getYpermissionActions(ICommandRead command)
         {
            if (command is Command.Read.YpermissionActionsReadCommand c)
                return getYpermissionActions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YpermissionActionsDTO> getYpermissionActions(Command.Read.YpermissionActionsReadCommand command)
        {
            var query = _query.YpermissionActionsQuery(command);

                var itens = _connection.Query<YpermissionActionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YpermissionActionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(string value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value)
        {
            var query = _query.ExistsByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YpermissionActionsDTO FirstById(string value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermissionActionsDTO FirstByDescription(string value)
        {
            var query = _query.FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermissionActionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration