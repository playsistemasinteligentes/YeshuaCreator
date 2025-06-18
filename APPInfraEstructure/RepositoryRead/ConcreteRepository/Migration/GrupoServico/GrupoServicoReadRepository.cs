using Dapper;
using Output.Querys.GrupoServico;
using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.GrupoServico
{
    public class GrupoServicoReadRepository : IGrupoServicoReadRepository
    {
        protected readonly IDbConnection _connection;

        public GrupoServicoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<GrupoServicoDTO> getGrupoServico(object command)
        {
            if (command is Command.Commands.Read.GrupoServicoReadCommand c)
            {
                return getGrupoServico(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<GrupoServicoDTO> getGrupoServico(Command.Commands.Read.GrupoServicoReadCommand command)
        {
            var query = new GrupoServicoReadQuery().GrupoServicoQuery(command);
            using (_connection)
            {
                return _connection.Query<GrupoServicoDTO>(query.Query, query.Parameters);
            }
        }

        public GrupoServicoDTO getById()
        {
            throw new NotImplementedException();
        }
        public GrupoServicoDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration