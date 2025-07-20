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
    public class YStandardFieldsReadRepository : IYStandardFieldsReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IYStandardFieldsQueryRead _query;

        public YStandardFieldsReadRepository(SqlFactory factory, ICurrentUser correntUser,IYStandardFieldsQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<YStandardFieldsDTO> getYStandardFields(ICommandRead command)
         {
            if (command is Command.Read.YStandardFieldsReadCommand c)
                return getYStandardFields(c);
            throw new NotImplementedException();
        }
        private DataPagination<YStandardFieldsDTO> getYStandardFields(Command.Read.YStandardFieldsReadCommand command)
        {
            var query = _query.YStandardFieldsQuery(command);

                var itens = _connection.Query<YStandardFieldsDTO>(query.Query,query.Parameters);
                return new DataPagination<YStandardFieldsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsByDeleted(bool value)
        {
            var query = _query.ExistsByDeletedQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YStandardFieldsDTO FirstByDeleted(bool value)
        {
            var query = _query.FirstByDeletedQuery(value);

                var result = _connection.QueryFirstOrDefault<YStandardFieldsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YStandardFieldsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration