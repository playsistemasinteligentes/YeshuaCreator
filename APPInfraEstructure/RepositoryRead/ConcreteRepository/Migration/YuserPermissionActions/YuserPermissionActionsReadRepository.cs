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
    public class YuserPermissionActionsReadRepository : IYuserPermissionActionsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYuserPermissionActionsQueryRead _query;

        public YuserPermissionActionsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYuserPermissionActionsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YuserPermissionActionsDTO> getYuserPermissionActions(ICommandRead command)
         {
            if (command is Command.Read.YuserPermissionActionsReadCommand c)
                return getYuserPermissionActions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YuserPermissionActionsDTO> getYuserPermissionActions(Command.Read.YuserPermissionActionsReadCommand command)
        {
            var query = _query.YuserPermissionActionsQuery(command);

                var itens = _connection.Query<YuserPermissionActionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YuserPermissionActionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YuserPermissionActionsPerfilIdDTO> getYuserPermissionActionsReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YuserPermissionActionsPerfilIdDTO> lista;
            var query = _query.YuserPermissionActionsPerfilIdQuery(command);

                lista = _connection.Query<YuserPermissionActionsPerfilIdDTO>(query.Query,query.Parameters) as List<YuserPermissionActionsPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<YuserPermissionActionsPerfilIdDTO> getYuserPermissionActionsReadFKPerfilId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYuserPermissionActionsReadFKPerfilId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YuserPermissionActionspermissionActionsIdDTO> getYuserPermissionActionsReadFKpermissionActionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YuserPermissionActionspermissionActionsIdDTO> lista;
            var query = _query.YuserPermissionActionspermissionActionsIdQuery(command);

                lista = _connection.Query<YuserPermissionActionspermissionActionsIdDTO>(query.Query,query.Parameters) as List<YuserPermissionActionspermissionActionsIdDTO>;
            return lista;
        }

        public IEnumerable<YuserPermissionActionspermissionActionsIdDTO> getYuserPermissionActionsReadFKpermissionActionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYuserPermissionActionsReadFKpermissionActionsId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPerfilId(int value)
        {
            var query = _query.ExistsByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBypermissionActionsId(string value)
        {
            var query = _query.ExistsBypermissionActionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrant(bool value)
        {
            var query = _query.ExistsByGrantQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreate(bool value)
        {
            var query = _query.ExistsByCreateQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRead(bool value)
        {
            var query = _query.ExistsByReadQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUpdate(bool value)
        {
            var query = _query.ExistsByUpdateQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDelete(bool value)
        {
            var query = _query.ExistsByDeleteQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value)
        {
            var query = _query.ExistsByValidUntilQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YuserPermissionActionsDTO FirstByPerfilId(int value)
        {
            var query = _query.FirstByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstBypermissionActionsId(string value)
        {
            var query = _query.FirstBypermissionActionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByGrant(bool value)
        {
            var query = _query.FirstByGrantQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByCreate(bool value)
        {
            var query = _query.FirstByCreateQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByRead(bool value)
        {
            var query = _query.FirstByReadQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByUpdate(bool value)
        {
            var query = _query.FirstByUpdateQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByDelete(bool value)
        {
            var query = _query.FirstByDeleteQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO FirstByValidUntil(DateTime value)
        {
            var query = _query.FirstByValidUntilQuery(value);

                var result = _connection.QueryFirstOrDefault<YuserPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YuserPermissionActionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration