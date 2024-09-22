using Dapper;
using Output.Querys.Agendamentos;
using Repositorio.Outputs.DTOs.Agendamentos;
using RepositoryInterfaces.Read.Repository.Agendamentos;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Agendamentos
{
    public class AgendamentosReadRepository : IAgendamentosReadRepository
    {
        protected readonly IDbConnection _connection;

        public AgendamentosReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<AgendamentosDTO> getAllAgendamentos()
        {
            List<AgendamentosDTO> lista;
            var query = new AgendamentosReadQuery().SelectAllAgendamentosQuery();

            using (_connection)
            {
                lista = _connection.Query<AgendamentosDTO>(query.Query) as List<AgendamentosDTO>;
            }
            return lista;
        }

        public AgendamentosDTO getById()
        {
            throw new NotImplementedException();
        }
        public AgendamentosDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
