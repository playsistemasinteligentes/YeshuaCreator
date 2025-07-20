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
    public class YtenantReadRepository : IYtenantReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYtenantQueryRead _query;

        public YtenantReadRepository(SqlFactory factory, ICurrentUser correntUser,IYtenantQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YtenantDTO> getYtenant(ICommandRead command)
         {
            if (command is Command.Read.YtenantReadCommand c)
                return getYtenant(c);
            throw new NotImplementedException();
        }
        private DataPagination<YtenantDTO> getYtenant(Command.Read.YtenantReadCommand command)
        {
            var query = _query.YtenantQuery(command);

                var itens = _connection.Query<YtenantDTO>(query.Query,query.Parameters);
                return new DataPagination<YtenantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YtenantUserIDAdminDTO> getYtenantReadFKUserIDAdmin(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YtenantUserIDAdminDTO> lista;
            var query = _query.YtenantUserIDAdminQuery(command);

                lista = _connection.Query<YtenantUserIDAdminDTO>(query.Query,query.Parameters) as List<YtenantUserIDAdminDTO>;
            return lista;
        }

        public IEnumerable<YtenantUserIDAdminDTO> getYtenantReadFKUserIDAdmin(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYtenantReadFKUserIDAdmin(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCnpjCpf(int value)
        {
            var query = _query.ExistsByCnpjCpfQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = _query.ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserIDAdmin(int value)
        {
            var query = _query.ExistsByUserIDAdminQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YtenantDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantDTO FirstByCnpjCpf(int value)
        {
            var query = _query.FirstByCnpjCpfQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantDTO FirstByUserIDAdmin(int value)
        {
            var query = _query.FirstByUserIDAdminQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration