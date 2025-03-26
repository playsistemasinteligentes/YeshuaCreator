using Dapper;
using Output.Querys.Y_Perfil;
using Repositorio.Outputs.DTOs.Y_Perfil;
using RepositoryInterfaces.Read.Repository.Y_Perfil;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Perfil
{
    public class Y_PerfilReadRepository : IY_PerfilReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PerfilReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<Y_PerfilDTO> getY_Perfil(object command)
         {
            if (command is Command.Commands.Read.Y_PerfilReadCommand c)
            {
                return getY_Perfil(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<Y_PerfilDTO> getY_Perfil(Command.Commands.Read.Y_PerfilReadCommand command)
        {
            List<Y_PerfilDTO> lista;
            var query = new Y_PerfilReadQuery().Y_PerfilQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_PerfilDTO>(query.Query,query.Parameters) as List<Y_PerfilDTO>;
            }
            return lista;
        }

        public Y_PerfilDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_PerfilDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration