using Dapper;
using Output.Querys.Clinica;
using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Read.Repository;
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
    public class ClinicaReadRepository : IClinicaReadRepositorys
    {
        protected readonly IDbConnection _connection;

        public ClinicaReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ClincaDTO> getAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClincaDTO> getAllClinicas()
        {
            List<ClincaDTO> lista;
            var query = new ClinicaReadQuery().SelectAllClinicaQuery();

            using (_connection)
            {
                lista = _connection.Query<ClincaDTO>(query.Query) as List<ClincaDTO>;
            }
            return lista;

        }

        public ClincaDTO getById()
        {
            throw new NotImplementedException();
        }

        public ClincaDTO getByIds()
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> IReadRepositoryBase.getAll()
        {
            throw new NotImplementedException();
        }
    }
}
