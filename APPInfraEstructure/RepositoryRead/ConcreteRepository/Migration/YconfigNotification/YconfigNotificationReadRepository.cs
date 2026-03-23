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
    public partial class yConfigNotificationReadRepository : IyConfigNotificationReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyConfigNotificationQueryRead _query;

        public yConfigNotificationReadRepository(SqlFactory factory, ICurrentUser currentUser,IyConfigNotificationQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yConfigNotificationDTO> getyConfigNotification(ICommandRead command )
         {
            if (command is Command.Read.yConfigNotificationReadCommand c)
                return getyConfigNotification(c );
            throw new NotImplementedException();
        }
        private DataPagination<yConfigNotificationDTO> getyConfigNotification(Command.Read.yConfigNotificationReadCommand command )
        {
            var query = _query.yConfigNotificationQuery(command );

                var itens = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters);
                return new DataPagination<yConfigNotificationDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yConfigNotificationTenantIDDTO> getyConfigNotificationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yConfigNotificationTenantIDDTO> lista;
            var query = _query.yConfigNotificationTenantIDQuery(command );

                lista = _connection.Query<yConfigNotificationTenantIDDTO>(query.Query,query.Parameters) as List<yConfigNotificationTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yConfigNotificationTenantIDDTO> getyConfigNotificationReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyConfigNotificationReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yConfigNotificationUserIdDTO> getyConfigNotificationReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yConfigNotificationUserIdDTO> lista;
            var query = _query.yConfigNotificationUserIdQuery(command );

                lista = _connection.Query<yConfigNotificationUserIdDTO>(query.Query,query.Parameters) as List<yConfigNotificationUserIdDTO>;
            return lista;
        }

        public IEnumerable<yConfigNotificationUserIdDTO> getyConfigNotificationReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyConfigNotificationReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailSmtpClient(string value )
        {
            var query = _query.ExistsByEmailSmtpClientQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailPort(int value )
        {
            var query = _query.ExistsByEmailPortQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailUserName(string value )
        {
            var query = _query.ExistsByEmailUserNameQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmailPassword(string value )
        {
            var query = _query.ExistsByEmailPasswordQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public yConfigNotificationDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByEmailSmtpClient(string value )
        {
            var query = _query.FirstByEmailSmtpClientQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByEmailPort(int value )
        {
            var query = _query.FirstByEmailPortQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByEmailUserName(string value )
        {
            var query = _query.FirstByEmailUserNameQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByEmailPassword(string value )
        {
            var query = _query.FirstByEmailPasswordQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigNotificationDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigNotificationDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailSmtpClient(string value )
        {
            var query = _query.FirstByEmailSmtpClientQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPort(int value )
        {
            var query = _query.FirstByEmailPortQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailUserName(string value )
        {
            var query = _query.FirstByEmailUserNameQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPassword(string value )
        {
            var query = _query.FirstByEmailPasswordQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yConfigNotificationDTO>(query.Query,query.Parameters) as List<yConfigNotificationDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration