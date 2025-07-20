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
    public class YuserReadRepository : IYuserReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYuserQueryRead _query;

        public YuserReadRepository(SqlFactory factory, ICurrentUser correntUser,IYuserQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YuserDTO> getYuser(ICommandRead command)
         {
            if (command is Command.Read.YuserReadCommand c)
                return getYuser(c);
            throw new NotImplementedException();
        }
        private DataPagination<YuserDTO> getYuser(Command.Read.YuserReadCommand command)
        {
            var query = _query.YuserQuery(command);

                var itens = _connection.Query<YuserDTO>(query.Query,query.Parameters);
                return new DataPagination<YuserDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YuserTenantIDDTO> getYuserReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YuserTenantIDDTO> lista;
            var query = _query.YuserTenantIDQuery(command);

                lista = _connection.Query<YuserTenantIDDTO>(query.Query,query.Parameters) as List<YuserTenantIDDTO>;
            return lista;
        }

        public IEnumerable<YuserTenantIDDTO> getYuserReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYuserReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = _query.ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmail(string value)
        {
            var query = _query.ExistsByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySenha(string value)
        {
            var query = _query.ExistsBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = _query.ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YuserDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByEmail(string value)
        {
            var query = _query.FirstByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstBySenha(string value)
        {
            var query = _query.FirstBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByTenantID(int value)
        {
            var query = _query.FirstByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration