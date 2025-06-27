using Dapper;
using Output.Querys.Y_UserPermitions;
using Repositorio.Outputs.DTOs.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_UserPermitions
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

            using (_connection)
            {
                var itens = _connection.Query<Y_UserPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_UserPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        private IEnumerable<Y_UserPermitionsUserIdDTO> getY_UserPermitionsReadFKUserId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_UserPermitionsUserIdDTO> lista;
            var query = new Y_UserPermitionsReadQuery().Y_UserPermitionsUserIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_UserPermitionsUserIdDTO>(query.Query,query.Parameters) as List<Y_UserPermitionsUserIdDTO>;
            }
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

            using (_connection)
            {
                lista = _connection.Query<Y_UserPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<Y_UserPermitionsPermitionsIdDTO>;
            }
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

        public Y_UserPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration