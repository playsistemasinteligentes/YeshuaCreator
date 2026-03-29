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
    public partial class yConfigArctetureReadRepository : IyConfigArctetureReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IyConfigArctetureQueryRead _query;

        public yConfigArctetureReadRepository(ISqlFactory factory, ICurrentUser currentUser,IyConfigArctetureQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<yConfigArctetureDTO> getyConfigArcteture(ICommandRead command )
         {
            if (command is Command.Read.yConfigArctetureReadCommand c)
                return getyConfigArcteture(c );
            throw new NotImplementedException();
        }
        private DataPagination<yConfigArctetureDTO> getyConfigArcteture(Command.Read.yConfigArctetureReadCommand command )
        {
            var query = _query.yConfigArctetureQuery(command );

                var itens = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters);
                return new DataPagination<yConfigArctetureDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yConfigArctetureTenantIDDTO> getyConfigArctetureReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yConfigArctetureTenantIDDTO> lista;
            var query = _query.yConfigArctetureTenantIDQuery(command );

                lista = _connection.Query<yConfigArctetureTenantIDDTO>(query.Query,query.Parameters) as List<yConfigArctetureTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yConfigArctetureTenantIDDTO> getyConfigArctetureReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyConfigArctetureReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yConfigArctetureUserIdDTO> getyConfigArctetureReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yConfigArctetureUserIdDTO> lista;
            var query = _query.yConfigArctetureUserIdQuery(command );

                lista = _connection.Query<yConfigArctetureUserIdDTO>(query.Query,query.Parameters) as List<yConfigArctetureUserIdDTO>;
            return lista;
        }

        public IEnumerable<yConfigArctetureUserIdDTO> getyConfigArctetureReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyConfigArctetureReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditTrackerActived(int value )
        {
            var query = _query.ExistsByAuditTrackerActivedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditCRUDActived(int value )
        {
            var query = _query.ExistsByAuditCRUDActivedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

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

        public yConfigArctetureDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByAuditTrackerActived(int value )
        {
            var query = _query.FirstByAuditTrackerActivedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByAuditCRUDActived(int value )
        {
            var query = _query.FirstByAuditCRUDActivedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public yConfigArctetureDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<yConfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByAuditTrackerActived(int value )
        {
            var query = _query.FirstByAuditTrackerActivedQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByAuditCRUDActived(int value )
        {
            var query = _query.FirstByAuditCRUDActivedQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<yConfigArctetureDTO>(query.Query,query.Parameters) as List<yConfigArctetureDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration