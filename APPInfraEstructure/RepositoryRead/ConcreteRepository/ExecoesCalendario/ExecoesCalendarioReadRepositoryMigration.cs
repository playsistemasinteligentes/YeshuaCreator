using Dapper;
using Output.Querys.ExecoesCalendario;
using Repositorio.Outputs.DTOs.ExecoesCalendario;
using RepositoryInterfaces.Read.Repository.ExecoesCalendario;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.ExecoesCalendario
{
    public class ExecoesCalendarioReadRepository : IExecoesCalendarioReadRepository
    {
        protected readonly IDbConnection _connection;

        public ExecoesCalendarioReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ExecoesCalendarioDTO> getAllExecoesCalendario()
        {
            List<ExecoesCalendarioDTO> lista;
            var query = new ExecoesCalendarioReadQuery().SelectAllExecoesCalendarioQuery();

            using (_connection)
            {
                lista = _connection.Query<ExecoesCalendarioDTO>(query.Query) as List<ExecoesCalendarioDTO>;
            }
            return lista;
        }

        public ExecoesCalendarioDTO getById()
        {
            throw new NotImplementedException();
        }
        public ExecoesCalendarioDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
