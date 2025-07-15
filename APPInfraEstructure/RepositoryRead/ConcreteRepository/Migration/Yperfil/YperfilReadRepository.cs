using Dapper;
using Output.Querys.Yperfil;
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
    public class YperfilReadRepository : IYperfilReadRepository
    {
        protected readonly IDbConnection _connection;

        public YperfilReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<YperfilDTO> getYperfil(ICommandRead command)
         {
            if (command is Command.Commands.Read.YperfilReadCommand c)
                return getYperfil(c);
            throw new NotImplementedException();
        }
        private DataPagination<YperfilDTO> getYperfil(Command.Commands.Read.YperfilReadCommand command)
        {
            var query = new YperfilReadQuery().YperfilQuery(command);

                var itens = _connection.Query<YperfilDTO>(query.Query,query.Parameters);
                return new DataPagination<YperfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = new YperfilReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value)
        {
            var query = new YperfilReadQuery().ExistsByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YperfilDTO FirstById(int value)
        {
            var query = new YperfilReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilDTO FirstByDescription(string value)
        {
            var query = new YperfilReadQuery().FirstByDescriptionQuery(value);

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