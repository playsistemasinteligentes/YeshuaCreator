using Dapper;
using Output.Querys.Yuser;
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
    public class YuserReadRepository : IYuserReadRepository
    {
        protected readonly IDbConnection _connection;

        public YuserReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<YuserDTO> getYuser(ICommandRead command)
         {
            if (command is Command.Commands.Read.YuserReadCommand c)
                return getYuser(c);
            throw new NotImplementedException();
        }
        private DataPagination<YuserDTO> getYuser(Command.Commands.Read.YuserReadCommand command)
        {
            var query = new YuserReadQuery().YuserQuery(command);

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
            var query = new YuserReadQuery().YuserTenantIDQuery(command);

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
            var query = new YuserReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new YuserReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmail(string value)
        {
            var query = new YuserReadQuery().ExistsByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySenha(string value)
        {
            var query = new YuserReadQuery().ExistsBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = new YuserReadQuery().ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YuserDTO FirstById(int value)
        {
            var query = new YuserReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByNome(string value)
        {
            var query = new YuserReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByEmail(string value)
        {
            var query = new YuserReadQuery().FirstByEmailQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstBySenha(string value)
        {
            var query = new YuserReadQuery().FirstBySenhaQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserDTO FirstByTenantID(int value)
        {
            var query = new YuserReadQuery().FirstByTenantIDQuery(value);

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