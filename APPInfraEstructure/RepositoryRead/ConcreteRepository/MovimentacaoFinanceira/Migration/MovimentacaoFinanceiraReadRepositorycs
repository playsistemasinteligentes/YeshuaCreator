using Dapper;
using Output.Querys.MovimentacaoFinanceira;
using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraReadRepository : IMovimentacaoFinanceiraReadRepository
    {
        protected readonly IDbConnection _connection;

        public MovimentacaoFinanceiraReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> getAllMovimentacaoFinanceira()
        {
            List<MovimentacaoFinanceiraDTO> lista;
            var query = new MovimentacaoFinanceiraReadQuery().SelectAllMovimentacaoFinanceiraQuery();

            using (_connection)
            {
                lista = _connection.Query<MovimentacaoFinanceiraDTO>(query.Query) as List<MovimentacaoFinanceiraDTO>;
            }
            return lista;
        }

        public MovimentacaoFinanceiraDTO getById()
        {
            throw new NotImplementedException();
        }
        public MovimentacaoFinanceiraDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
