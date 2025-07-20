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
    public class YperfilReadRepository : IYperfilReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYperfilQueryRead _query;

        public YperfilReadRepository(SqlFactory factory, ICurrentUser correntUser,IYperfilQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YperfilDTO> getYperfil(ICommandRead command)
         {
            if (command is Command.Read.YperfilReadCommand c)
                return getYperfil(c);
            throw new NotImplementedException();
        }
        private DataPagination<YperfilDTO> getYperfil(Command.Read.YperfilReadCommand command)
        {
            var query = _query.YperfilQuery(command);

                var itens = _connection.Query<YperfilDTO>(query.Query,query.Parameters);
                return new DataPagination<YperfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
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

        public YperfilDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilDTO FirstByDescription(string value)
        {
            var query = _query.FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration