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
    public class YperfilPermissionActionsReadRepository : IYperfilPermissionActionsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYperfilPermissionActionsQueryRead _query;

        public YperfilPermissionActionsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYperfilPermissionActionsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YperfilPermissionActionsDTO> getYperfilPermissionActions(ICommandRead command)
         {
            if (command is Command.Read.YperfilPermissionActionsReadCommand c)
                return getYperfilPermissionActions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YperfilPermissionActionsDTO> getYperfilPermissionActions(Command.Read.YperfilPermissionActionsReadCommand command)
        {
            var query = _query.YperfilPermissionActionsQuery(command);

                var itens = _connection.Query<YperfilPermissionActionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YperfilPermissionActionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YperfilPermissionActionsPerfilIdDTO> getYperfilPermissionActionsReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YperfilPermissionActionsPerfilIdDTO> lista;
            var query = _query.YperfilPermissionActionsPerfilIdQuery(command);

                lista = _connection.Query<YperfilPermissionActionsPerfilIdDTO>(query.Query,query.Parameters) as List<YperfilPermissionActionsPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<YperfilPermissionActionsPerfilIdDTO> getYperfilPermissionActionsReadFKPerfilId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYperfilPermissionActionsReadFKPerfilId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YperfilPermissionActionspermissionActionsIdDTO> getYperfilPermissionActionsReadFKpermissionActionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YperfilPermissionActionspermissionActionsIdDTO> lista;
            var query = _query.YperfilPermissionActionspermissionActionsIdQuery(command);

                lista = _connection.Query<YperfilPermissionActionspermissionActionsIdDTO>(query.Query,query.Parameters) as List<YperfilPermissionActionspermissionActionsIdDTO>;
            return lista;
        }

        public IEnumerable<YperfilPermissionActionspermissionActionsIdDTO> getYperfilPermissionActionsReadFKpermissionActionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYperfilPermissionActionsReadFKpermissionActionsId(c);
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

        public YperfilPermissionActionsDTO FirstByPerfilId(int value)
        {
            var query = _query.FirstByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstBypermissionActionsId(string value)
        {
            var query = _query.FirstBypermissionActionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByGrant(bool value)
        {
            var query = _query.FirstByGrantQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByCreate(bool value)
        {
            var query = _query.FirstByCreateQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByRead(bool value)
        {
            var query = _query.FirstByReadQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByUpdate(bool value)
        {
            var query = _query.FirstByUpdateQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByDelete(bool value)
        {
            var query = _query.FirstByDeleteQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO FirstByValidUntil(DateTime value)
        {
            var query = _query.FirstByValidUntilQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermissionActionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermissionActionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration