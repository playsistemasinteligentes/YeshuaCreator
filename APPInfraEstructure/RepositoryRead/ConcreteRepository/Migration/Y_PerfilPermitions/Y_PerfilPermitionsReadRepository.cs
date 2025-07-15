using Dapper;
using Output.Querys.Y_PerfilPermitions;
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
    public class Y_PerfilPermitionsReadRepository : IY_PerfilPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PerfilPermitionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_PerfilPermitionsDTO> getY_PerfilPermitions(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_PerfilPermitionsReadCommand c)
                return getY_PerfilPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_PerfilPermitionsDTO> getY_PerfilPermitions(Command.Commands.Read.Y_PerfilPermitionsReadCommand command)
        {
            var query = new Y_PerfilPermitionsReadQuery().Y_PerfilPermitionsQuery(command);

                var itens = _connection.Query<Y_PerfilPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_PerfilPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<Y_PerfilPermitionsPerfilIdDTO> getY_PerfilPermitionsReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_PerfilPermitionsPerfilIdDTO> lista;
            var query = new Y_PerfilPermitionsReadQuery().Y_PerfilPermitionsPerfilIdQuery(command);

                lista = _connection.Query<Y_PerfilPermitionsPerfilIdDTO>(query.Query,query.Parameters) as List<Y_PerfilPermitionsPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<Y_PerfilPermitionsPerfilIdDTO> getY_PerfilPermitionsReadFKPerfilId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_PerfilPermitionsReadFKPerfilId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<Y_PerfilPermitionsPermitionsIdDTO> getY_PerfilPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_PerfilPermitionsPermitionsIdDTO> lista;
            var query = new Y_PerfilPermitionsReadQuery().Y_PerfilPermitionsPermitionsIdQuery(command);

                lista = _connection.Query<Y_PerfilPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<Y_PerfilPermitionsPermitionsIdDTO>;
            return lista;
        }

        public IEnumerable<Y_PerfilPermitionsPermitionsIdDTO> getY_PerfilPermitionsReadFKPermitionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_PerfilPermitionsReadFKPermitionsId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPerfilId(int value)
        {
            var query = new Y_PerfilPermitionsReadQuery().ExistsByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPermitionsId(string value)
        {
            var query = new Y_PerfilPermitionsReadQuery().ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_PerfilPermitionsDTO FirstByPerfilId(int value)
        {
            var query = new Y_PerfilPermitionsReadQuery().FirstByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PerfilPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PerfilPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = new Y_PerfilPermitionsReadQuery().FirstByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PerfilPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PerfilPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration