using Dapper;
using Output.Querys.Clinica;
using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Clinica
{
    public class ClinicaReadRepository : IClinicaReadRepository
    {
        protected readonly IDbConnection _connection;

        public ClinicaReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ClinicaDTO> getAllClinica()
        {
            List<ClinicaDTO> lista;
            var query = new ClinicaReadQuery().SelectAllClinicaQuery();

            using (_connection)
            {
                lista = _connection.Query<ClinicaDTO>(query.Query) as List<ClinicaDTO>;
            }
            return lista;
        }

        public ClinicaDTO getById()
        {
            throw new NotImplementedException();
        }
        public ClinicaDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
