using Dapper;
using Output.Querys.Servico;
using Repositorio.Outputs.DTOs.Servico;
using RepositoryInterfaces.Read.Repository.Servico;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Servico
{
    public class ServicoReadRepository : IServicoReadRepository
    {
        protected readonly IDbConnection _connection;

        public ServicoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ServicoDTO> getAllServico()
        {
            List<ServicoDTO> lista;
            var query = new ServicoReadQuery().SelectAllServicoQuery();

            using (_connection)
            {
                lista = _connection.Query<ServicoDTO>(query.Query) as List<ServicoDTO>;
            }
            return lista;
        }

        public ServicoDTO getById()
        {
            throw new NotImplementedException();
        }
        public ServicoDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
