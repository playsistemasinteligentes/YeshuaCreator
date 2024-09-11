using Dapper;
using Output.Querys.Paciente;
using Repositorio.Outputs.DTOs.Paciente;
using RepositoryInterfaces.Read.Repository.Paciente;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Paciente
{
    public class PacienteReadRepository : IPacienteReadRepository
    {
        protected readonly IDbConnection _connection;

        public PacienteReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<PacienteDTO> getAllPaciente()
        {
            List<PacienteDTO> lista;
            var query = new PacienteReadQuery().SelectAllPacienteQuery();

            using (_connection)
            {
                lista = _connection.Query<PacienteDTO>(query.Query) as List<PacienteDTO>;
            }
            return lista;
        }

       public IEnumerable<PacienteDTO> GetAllPacientes()
        {
            throw new NotImplementedException();
         }
        public PacienteDTO getById()
        {
            throw new NotImplementedException();
        }
        public PacienteDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
