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
    public class YpermissionModulesReadRepository : IYpermissionModulesReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYpermissionModulesQueryRead _query;

        public YpermissionModulesReadRepository(SqlFactory factory, ICurrentUser correntUser,IYpermissionModulesQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YpermissionModulesDTO> getYpermissionModules(ICommandRead command)
         {
            if (command is Command.Read.YpermissionModulesReadCommand c)
                return getYpermissionModules(c);
            throw new NotImplementedException();
        }
        private DataPagination<YpermissionModulesDTO> getYpermissionModules(Command.Read.YpermissionModulesReadCommand command)
        {
            var query = _query.YpermissionModulesQuery(command);

                var itens = _connection.Query<YpermissionModulesDTO>(query.Query,query.Parameters);
                return new DataPagination<YpermissionModulesDTO>(
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

        public YpermissionModulesDTO FirstById(string value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermissionModulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermissionModulesDTO FirstByDescription(string value)
        {
            var query = _query.FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<YpermissionModulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpermissionModulesDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration