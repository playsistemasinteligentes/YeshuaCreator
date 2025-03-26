using Dapper;
using Output.Querys.Y_User;
using Repositorio.Outputs.DTOs.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_User
{
    public class Y_UserReadRepository : IY_UserReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_UserReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<Y_UserDTO> getY_User(object command)
         {
            if (command is Command.Commands.Read.Y_UserReadCommand c)
            {
                return getY_User(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<Y_UserDTO> getY_User(Command.Commands.Read.Y_UserReadCommand command)
        {
            List<Y_UserDTO> lista;
            var query = new Y_UserReadQuery().Y_UserQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_UserDTO>(query.Query,query.Parameters) as List<Y_UserDTO>;
            }
            return lista;
        }

        public Y_UserDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_UserDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration