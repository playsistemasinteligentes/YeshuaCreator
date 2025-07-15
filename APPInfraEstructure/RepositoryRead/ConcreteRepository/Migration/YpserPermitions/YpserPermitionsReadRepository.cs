using Dapper;
using Output.Querys.YpserPermitions;
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
    public class YpserPermitionsReadRepository : IYpserPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public YpserPermitionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<YpserPermitionsDTO> getYpserPermitions(ICommandRead command)
         {
            if (command is Command.Commands.Read.YpserPermitionsReadCommand c)
                return getYpserPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YpserPermitionsDTO> getYpserPermitions(Command.Commands.Read.YpserPermitionsReadCommand command)
        {
            var query = new YpserPermitionsReadQuery().YpserPermitionsQuery(command);

                var itens = _connection.Query<YpserPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YpserPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YpserPermitionsUserIdDTO> getYpserPermitionsReadFKUserId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YpserPermitionsUserIdDTO> lista;
            var query = new YpserPermitionsReadQuery().YpserPermitionsUserIdQuery(command);

                lista = _connection.Query<YpserPermitionsUserIdDTO>(query.Query,query.Parameters) as List<YpserPermitionsUserIdDTO>;
            return lista;
        }

        public IEnumerable<YpserPermitionsUserIdDTO> getYpserPermitionsReadFKUserId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYpserPermitionsReadFKUserId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YpserPermitionsPermitionsIdDTO> getYpserPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YpserPermitionsPermitionsIdDTO> lista;
            var query = new YpserPermitionsReadQuery().YpserPermitionsPermitionsIdQuery(command);

                lista = _connection.Query<YpserPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<YpserPermitionsPermitionsIdDTO>;
            return lista;
        }

        public IEnumerable<YpserPermitionsPermitionsIdDTO> getYpserPermitionsReadFKPermitionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYpserPermitionsReadFKPermitionsId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUserId(int value)
        {
            var query = new YpserPermitionsReadQuery().ExistsByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPermitionsId(string value)
        {
            var query = new YpserPermitionsReadQuery().ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YpserPermitionsDTO FirstByUserId(int value)
        {
            var query = new YpserPermitionsReadQuery().FirstByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YpserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpserPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = new YpserPermitionsReadQuery().FirstByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YpserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YpserPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration