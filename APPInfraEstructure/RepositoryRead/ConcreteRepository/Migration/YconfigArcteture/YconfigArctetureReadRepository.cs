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
    public class YconfigArctetureReadRepository : IYconfigArctetureReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYconfigArctetureQueryRead _query;

        public YconfigArctetureReadRepository(SqlFactory factory, ICurrentUser correntUser,IYconfigArctetureQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YconfigArctetureDTO> getYconfigArcteture(ICommandRead command)
         {
            if (command is Command.Read.YconfigArctetureReadCommand c)
                return getYconfigArcteture(c);
            throw new NotImplementedException();
        }
        private DataPagination<YconfigArctetureDTO> getYconfigArcteture(Command.Read.YconfigArctetureReadCommand command)
        {
            var query = _query.YconfigArctetureQuery(command);

                var itens = _connection.Query<YconfigArctetureDTO>(query.Query,query.Parameters);
                return new DataPagination<YconfigArctetureDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditTrackerActived(int value)
        {
            var query = _query.ExistsByAuditTrackerActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAuditCRUDActived(int value)
        {
            var query = _query.ExistsByAuditCRUDActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YconfigArctetureDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigArctetureDTO FirstByAuditTrackerActived(int value)
        {
            var query = _query.FirstByAuditTrackerActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigArctetureDTO FirstByAuditCRUDActived(int value)
        {
            var query = _query.FirstByAuditCRUDActivedQuery(value);

                var result = _connection.QueryFirstOrDefault<YconfigArctetureDTO>(query.Query, query.Parameters);
                return result;
        }

        public YconfigArctetureDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration