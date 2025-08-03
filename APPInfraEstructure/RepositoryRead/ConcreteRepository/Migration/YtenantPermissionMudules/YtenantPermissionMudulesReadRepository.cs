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
    public class YtenantPermissionMudulesReadRepository : IYtenantPermissionMudulesReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYtenantPermissionMudulesQueryRead _query;

        public YtenantPermissionMudulesReadRepository(SqlFactory factory, ICurrentUser correntUser,IYtenantPermissionMudulesQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YtenantPermissionMudulesDTO> getYtenantPermissionMudules(ICommandRead command)
         {
            if (command is Command.Read.YtenantPermissionMudulesReadCommand c)
                return getYtenantPermissionMudules(c);
            throw new NotImplementedException();
        }
        private DataPagination<YtenantPermissionMudulesDTO> getYtenantPermissionMudules(Command.Read.YtenantPermissionMudulesReadCommand command)
        {
            var query = _query.YtenantPermissionMudulesQuery(command);

                var itens = _connection.Query<YtenantPermissionMudulesDTO>(query.Query,query.Parameters);
                return new DataPagination<YtenantPermissionMudulesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YtenantPermissionMudulespermissionModulesIdDTO> getYtenantPermissionMudulesReadFKpermissionModulesId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YtenantPermissionMudulespermissionModulesIdDTO> lista;
            var query = _query.YtenantPermissionMudulespermissionModulesIdQuery(command);

                lista = _connection.Query<YtenantPermissionMudulespermissionModulesIdDTO>(query.Query,query.Parameters) as List<YtenantPermissionMudulespermissionModulesIdDTO>;
            return lista;
        }

        public IEnumerable<YtenantPermissionMudulespermissionModulesIdDTO> getYtenantPermissionMudulesReadFKpermissionModulesId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYtenantPermissionMudulesReadFKpermissionModulesId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YtenantPermissionMudulesTenantIDDTO> getYtenantPermissionMudulesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YtenantPermissionMudulesTenantIDDTO> lista;
            var query = _query.YtenantPermissionMudulesTenantIDQuery(command);

                lista = _connection.Query<YtenantPermissionMudulesTenantIDDTO>(query.Query,query.Parameters) as List<YtenantPermissionMudulesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<YtenantPermissionMudulesTenantIDDTO> getYtenantPermissionMudulesReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYtenantPermissionMudulesReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBypermissionModulesId(string value)
        {
            var query = _query.ExistsBypermissionModulesIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = _query.ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value)
        {
            var query = _query.ExistsByValidUntilQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YtenantPermissionMudulesDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantPermissionMudulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantPermissionMudulesDTO FirstBypermissionModulesId(string value)
        {
            var query = _query.FirstBypermissionModulesIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantPermissionMudulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantPermissionMudulesDTO FirstByTenantID(int value)
        {
            var query = _query.FirstByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantPermissionMudulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantPermissionMudulesDTO FirstByValidUntil(DateTime value)
        {
            var query = _query.FirstByValidUntilQuery(value);

                var result = _connection.QueryFirstOrDefault<YtenantPermissionMudulesDTO>(query.Query, query.Parameters);
                return result;
        }

        public YtenantPermissionMudulesDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration