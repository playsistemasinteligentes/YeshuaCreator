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

        public IEnumerable<GrupoServicoDTO> getAllGrupoServico()
        {
            List<GrupoServicoDTO> lista;
            var query = new GrupoServicoReadQuery().SelectAllGrupoServicoQuery();

            using (_connection)
            {
                lista = _connection.Query<GrupoServicoDTO>(query.Query) as List<GrupoServicoDTO>;
            }
            return lista;
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
