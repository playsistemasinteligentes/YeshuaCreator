using Dapper;
using Output.Querys.Profissional;
using Repositorio.Outputs.DTOs.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Profissional
{
    public class ProfissionalReadRepository : IProfissionalReadRepository
    {
        protected readonly IDbConnection _connection;

        public ProfissionalReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ProfissionalDTO> getAllProfissional()
        {
            List<ProfissionalDTO> lista;
            var query = new ProfissionalReadQuery().SelectAllProfissionalQuery();

            using (_connection)
            {
                lista = _connection.Query<ProfissionalDTO>(query.Query) as List<ProfissionalDTO>;
            }
            return lista;
        }

        public ProfissionalDTO getById()
        {
            throw new NotImplementedException();
        }
        public ProfissionalDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
