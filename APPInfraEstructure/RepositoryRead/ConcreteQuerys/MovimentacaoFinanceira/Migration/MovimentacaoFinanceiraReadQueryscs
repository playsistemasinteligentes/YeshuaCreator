using Dominio.Entitys.MovimentacaoFinanceira;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraReadQuery : QueryBase
    {
        public QueryModel SelectAllMovimentacaoFinanceiraQuery()
        {
            this.Query = $@" select Id, PacienteId, ServicoId, Valor, TipoMovimentacao, DataMovimentacao, SaldoAtual from MovimentacaoFinanceira ";
            return new QueryModel(this.Query, null);
        }
    }
}
