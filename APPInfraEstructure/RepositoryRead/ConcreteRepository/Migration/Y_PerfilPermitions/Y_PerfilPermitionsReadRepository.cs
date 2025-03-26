using Dapper;
using Output.Querys.Y_PerfilPermitions;
using Repositorio.Outputs.DTOs.Y_PerfilPermitions;
using RepositoryInterfaces.Read.Repository.Y_PerfilPermitions;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_PerfilPermitions
{
    public class Y_PerfilPermitionsReadRepository : IY_PerfilPermitionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PerfilPermitionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<Y_PerfilPermitionsDTO> getY_PerfilPermitions(object command)
         {
            if (command is Command.Commands.Read.Y_PerfilPermitionsReadCommand c)
            {
                return getY_PerfilPermitions(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<Y_PerfilPermitionsDTO> getY_PerfilPermitions(Command.Commands.Read.Y_PerfilPermitionsReadCommand command)
        {
            List<Y_PerfilPermitionsDTO> lista;
            var query = new Y_PerfilPermitionsReadQuery().Y_PerfilPermitionsQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_PerfilPermitionsDTO>(query.Query,query.Parameters) as List<Y_PerfilPermitionsDTO>;
            }
            return lista;
        }

        private IEnumerable<Y_PerfilPermitionsPerfilIdDTO> getY_PerfilPermitionsReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_PerfilPermitionsPerfilIdDTO> lista;
            var query = new Y_PerfilPermitionsReadQuery().Y_PerfilPermitionsPerfilIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_PerfilPermitionsPerfilIdDTO>(query.Query,query.Parameters) as List<Y_PerfilPermitionsPerfilIdDTO>;
            }
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

            using (_connection)
            {
                lista = _connection.Query<Y_PerfilPermitionsPermitionsIdDTO>(query.Query,query.Parameters) as List<Y_PerfilPermitionsPermitionsIdDTO>;
            }
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

        public Y_PerfilPermitionsDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_PerfilPermitionsDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration