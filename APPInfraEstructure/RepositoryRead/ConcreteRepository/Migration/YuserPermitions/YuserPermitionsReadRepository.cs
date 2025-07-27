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
    public class YuserPermitionsReadRepository : IYuserPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYuserPermitionsQueryRead _query;

        public YuserPermitionsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYuserPermitionsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YuserPermitionsDTO> getYuserPermitions(ICommandRead command)
         {
            if (command is Command.Read.YuserPermitionsReadCommand c)
                return getYuserPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YuserPermitionsDTO> getYuserPermitions(Command.Read.YuserPermitionsReadCommand command)
        {
            var query = _query.YuserPermitionsQuery(command);

                var itens = _connection.Query<YuserPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YuserPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YuserPermitionsPermitionsIdDTO> getYuserPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YuserPermitionsPermitionsIdDTO> lista;
            var query = _query.YuserPermitionsPermitionsIdQuery(command);

                lista = _connection.Query<YuserPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<YuserPermitionsPermitionsIdDTO>;
            return lista;
        }

        public IEnumerable<YuserPermitionsPermitionsIdDTO> getYuserPermitionsReadFKPermitionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYuserPermitionsReadFKPermitionsId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YuserPermitionsUserIdDTO> getYuserPermitionsReadFKUserId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YuserPermitionsUserIdDTO> lista;
            var query = _query.YuserPermitionsUserIdQuery(command);

                lista = _connection.Query<YuserPermitionsUserIdDTO>(query.Query,query.Parameters) as List<YuserPermitionsUserIdDTO>;
            return lista;
        }

        public IEnumerable<YuserPermitionsUserIdDTO> getYuserPermitionsReadFKUserId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYuserPermitionsReadFKUserId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPermitionsId(string value)
        {
            var query = _query.ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value)
        {
            var query = _query.ExistsByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YuserPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = _query.FirstByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermitionsDTO FirstByUserId(int value)
        {
            var query = _query.FirstByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration