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
    public class YpserPermitionsReadRepository : IYpserPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYpserPermitionsQueryRead _query;

        public YpserPermitionsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYpserPermitionsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YpserPermitionsDTO> getYpserPermitions(ICommandRead command)
         {
            if (command is Command.Read.YpserPermitionsReadCommand c)
                return getYpserPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YpserPermitionsDTO> getYpserPermitions(Command.Read.YpserPermitionsReadCommand command)
        {
            var query = _query.YpserPermitionsQuery(command);

                var itens = _connection.Query<YpserPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YpserPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YpserPermitionsPermitionsIdDTO> getYpserPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YpserPermitionsPermitionsIdDTO> lista;
            var query = _query.YpserPermitionsPermitionsIdQuery(command);

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

        public bool ExistsByPermitionsId(string value)
        {
            var query = _query.ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YpserPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = _query.FirstByPermitionsIdQuery(value);

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