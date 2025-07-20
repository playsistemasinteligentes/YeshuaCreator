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
    public class YconfigNotificationReadRepository : IYconfigNotificationReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYconfigNotificationQueryRead _query;

        public YconfigNotificationReadRepository(SqlFactory factory, ICurrentUser correntUser,IYconfigNotificationQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YconfigNotificationDTO> getYconfigNotification(ICommandRead command)
         {
            if (command is Command.Read.YconfigNotificationReadCommand c)
                return getYconfigNotification(c);
            throw new NotImplementedException();
        }
        private DataPagination<YconfigNotificationDTO> getYconfigNotification(Command.Read.YconfigNotificationReadCommand command)
        {
            var query = _query.YconfigNotificationQuery(command);

                var itens = _connection.Query<YconfigNotificationDTO>(query.Query,query.Parameters);
                return new DataPagination<YconfigNotificationDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YconfigNotificationTenantIDDTO> getYconfigNotificationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YconfigNotificationTenantIDDTO> lista;
            var query = _query.YconfigNotificationTenantIDQuery(command);

                lista = _connection.Query<YconfigNotificationTenantIDDTO>(query.Query,query.Parameters) as List<YconfigNotificationTenantIDDTO>;
            return lista;
        }

        public IEnumerable<YconfigNotificationTenantIDDTO> getYconfigNotificationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYconfigNotificationReadFKTenantID(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailAdress(string value)
        {
            var query = _query.ExistsByEmailAdressQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailPassword(string value)
        {
            var query = _query.ExistsByEmailPasswordQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value)
        {
            var query = _query.ExistsByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YconfigNotificationDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigNotificationDTO FirstByEmailAdress(string value)
        {
            var query = _query.FirstByEmailAdressQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigNotificationDTO FirstByEmailPassword(string value)
        {
            var query = _query.FirstByEmailPasswordQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigNotificationDTO FirstByTenantID(int value)
        {
            var query = _query.FirstByTenantIDQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigNotificationDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration