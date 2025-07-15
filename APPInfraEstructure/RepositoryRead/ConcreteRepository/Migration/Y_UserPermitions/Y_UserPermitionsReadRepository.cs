using Dapper;
using Output.Querys.Y_UserPermitions;
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
    public class Y_UserPermitionsReadRepository : IY_UserPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_UserPermitionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_UserPermitionsDTO> getY_UserPermitions(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_UserPermitionsReadCommand c)
                return getY_UserPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_UserPermitionsDTO> getY_UserPermitions(Command.Commands.Read.Y_UserPermitionsReadCommand command)
        {
            var query = new Y_UserPermitionsReadQuery().Y_UserPermitionsQuery(command);

                var itens = _connection.Query<Y_UserPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_UserPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Y_UserPermitionsUserIdDTO> getY_UserPermitionsReadFKUserId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_UserPermitionsUserIdDTO> lista;
            var query = new Y_UserPermitionsReadQuery().Y_UserPermitionsUserIdQuery(command);

                lista = _connection.Query<Y_UserPermitionsUserIdDTO>(query.Query,query.Parameters) as List<Y_UserPermitionsUserIdDTO>;
            return lista;
        }

        public IEnumerable<Y_UserPermitionsUserIdDTO> getY_UserPermitionsReadFKUserId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_UserPermitionsReadFKUserId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<Y_UserPermitionsPermitionsIdDTO> getY_UserPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_UserPermitionsPermitionsIdDTO> lista;
            var query = new Y_UserPermitionsReadQuery().Y_UserPermitionsPermitionsIdQuery(command);

                lista = _connection.Query<Y_UserPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<Y_UserPermitionsPermitionsIdDTO>;
            return lista;
        }

        public IEnumerable<Y_UserPermitionsPermitionsIdDTO> getY_UserPermitionsReadFKPermitionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_UserPermitionsReadFKPermitionsId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUserId(int value)
        {
            var query = new Y_UserPermitionsReadQuery().ExistsByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPermitionsId(string value)
        {
            var query = new Y_UserPermitionsReadQuery().ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_UserPermitionsDTO FirstByUserId(int value)
        {
            var query = new Y_UserPermitionsReadQuery().FirstByUserIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = new Y_UserPermitionsReadQuery().FirstByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_UserPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_UserPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration