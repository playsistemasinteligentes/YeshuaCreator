using Dapper;
using Dominio.Entitys.MovimentacaoFinanceira;
using Input.Querys.MovimentacaoFinanceira;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraWriteRepository : IMovimentacaoFinanceiraWriteRepository
    {
        private readonly IDbConnection _Connection;

        public MovimentacaoFinanceiraWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            var query = new MovimentacaoFinanceiraWriteQuery().InserirMovimentacaoFinanceiraQuery(MovimentacaoFinanceira);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            throw new NotImplementedException();
        }
    }
}
