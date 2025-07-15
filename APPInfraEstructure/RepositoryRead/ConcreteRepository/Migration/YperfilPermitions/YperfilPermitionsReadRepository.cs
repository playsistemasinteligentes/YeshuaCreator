using Dapper;
using Output.Querys.YperfilPermitions;
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
    public class YperfilPermitionsReadRepository : IYperfilPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public YperfilPermitionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<YperfilPermitionsDTO> getYperfilPermitions(ICommandRead command)
         {
            if (command is Command.Commands.Read.YperfilPermitionsReadCommand c)
                return getYperfilPermitions(c);
            throw new NotImplementedException();
        }
        private DataPagination<YperfilPermitionsDTO> getYperfilPermitions(Command.Commands.Read.YperfilPermitionsReadCommand command)
        {
            var query = new YperfilPermitionsReadQuery().YperfilPermitionsQuery(command);

                var itens = _connection.Query<YperfilPermitionsDTO>(query.Query,query.Parameters);
                return new DataPagination<YperfilPermitionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<YperfilPermitionsPerfilIdDTO> getYperfilPermitionsReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YperfilPermitionsPerfilIdDTO> lista;
            var query = new YperfilPermitionsReadQuery().YperfilPermitionsPerfilIdQuery(command);

                lista = _connection.Query<YperfilPermitionsPerfilIdDTO>(query.Query,query.Parameters) as List<YperfilPermitionsPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<YperfilPermitionsPerfilIdDTO> getYperfilPermitionsReadFKPerfilId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYperfilPermitionsReadFKPerfilId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<YperfilPermitionsPermitionsIdDTO> getYperfilPermitionsReadFKPermitionsId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<YperfilPermitionsPermitionsIdDTO> lista;
            var query = new YperfilPermitionsReadQuery().YperfilPermitionsPermitionsIdQuery(command);

                lista = _connection.Query<YperfilPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<YperfilPermitionsPermitionsIdDTO>;
            return lista;
        }

        public IEnumerable<YperfilPermitionsPermitionsIdDTO> getYperfilPermitionsReadFKPermitionsId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getYperfilPermitionsReadFKPermitionsId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPerfilId(int value)
        {
            var query = new YperfilPermitionsReadQuery().ExistsByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPermitionsId(string value)
        {
            var query = new YperfilPermitionsReadQuery().ExistsByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public YperfilPermitionsDTO FirstByPerfilId(int value)
        {
            var query = new YperfilPermitionsReadQuery().FirstByPerfilIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermitionsDTO FirstByPermitionsId(string value)
        {
            var query = new YperfilPermitionsReadQuery().FirstByPermitionsIdQuery(value);

                var result = _connection.QueryFirstOrDefault<YperfilPermitionsDTO>(query.Query, query.Parameters);
                return result;
        }

        public YperfilPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration