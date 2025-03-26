using Dapper;
using Output.Querys.Y_Permtions;
using Repositorio.Outputs.DTOs.Y_Permtions;
using RepositoryInterfaces.Read.Repository.Y_Permtions;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Permtions
{
    public class Y_PermtionsReadRepository : IY_PermtionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PermtionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<Y_PermtionsDTO> getY_Permtions(object command)
         {
            if (command is Command.Commands.Read.Y_PermtionsReadCommand c)
            {
                return getY_Permtions(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<Y_PermtionsDTO> getY_Permtions(Command.Commands.Read.Y_PermtionsReadCommand command)
        {
            List<Y_PermtionsDTO> lista;
            var query = new Y_PermtionsReadQuery().Y_PermtionsQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_PermtionsDTO>(query.Query,query.Parameters) as List<Y_PermtionsDTO>;
            }
            return lista;
        }

        public Y_PermtionsDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_PermtionsDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration