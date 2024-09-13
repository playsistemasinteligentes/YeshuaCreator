using Dapper;
using Output.Querys.Atendimento;
using Repositorio.Outputs.DTOs.Atendimento;
using RepositoryInterfaces.Read.Repository.Atendimento;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Atendimento
{
    public class AtendimentoReadRepository : IAtendimentoReadRepository
    {
        protected readonly IDbConnection _connection;

        public AtendimentoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<AtendimentoDTO> getAllAtendimento()
        {
            List<AtendimentoDTO> lista;
            var query = new AtendimentoReadQuery().SelectAllAtendimentoQuery();

            using (_connection)
            {
                lista = _connection.Query<AtendimentoDTO>(query.Query) as List<AtendimentoDTO>;
            }
            return lista;
        }

        public AtendimentoDTO getById()
        {
            throw new NotImplementedException();
        }
        public AtendimentoDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
