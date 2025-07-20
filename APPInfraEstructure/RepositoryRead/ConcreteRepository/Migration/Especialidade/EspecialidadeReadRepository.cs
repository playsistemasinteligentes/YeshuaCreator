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
    public class EspecialidadeReadRepository : IEspecialidadeReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IEspecialidadeQueryRead _query;

        public EspecialidadeReadRepository(SqlFactory factory, ICurrentUser correntUser,IEspecialidadeQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command)
         {
            if (command is Command.Read.EspecialidadeReadCommand c)
                return getEspecialidade(c);
            throw new NotImplementedException();
        }
        private DataPagination<EspecialidadeDTO> getEspecialidade(Command.Read.EspecialidadeReadCommand command)
        {
            var query = _query.EspecialidadeQuery(command);

                var itens = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters);
                return new DataPagination<EspecialidadeDTO>(
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

        public bool ExistsByDescricao(string value)
        {
            var query = _query.ExistsByDescricaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public EspecialidadeDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO FirstByDescricao(string value)
        {
            var query = _query.FirstByDescricaoQuery(value);

                var result = _connection.QueryFirstOrDefault<EspecialidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public EspecialidadeDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration