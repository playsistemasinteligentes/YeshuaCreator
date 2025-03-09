using Dominio.Entitys.MovimentacaoFinanceira;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraWriteQuery : QueryBase
    {
        public QueryModel InserirMovimentacaoFinanceiraQuery(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            this.Query = $@" INSERT INTO MovimentacaoFinanceira (PacienteId, ServicoId, Valor, TipoMovimentacao, DataMovimentacao, SaldoAtual) VALUES(@PacienteId, @ServicoId, @Valor, @TipoMovimentacao, @DataMovimentacao, @SaldoAtual) ";
            this.Parameters = new
            {
                PacienteId = MovimentacaoFinanceira.PacienteId,
                ServicoId = MovimentacaoFinanceira.ServicoId,
                Valor = MovimentacaoFinanceira.Valor,
                TipoMovimentacao = MovimentacaoFinanceira.TipoMovimentacao,
                DataMovimentacao = MovimentacaoFinanceira.DataMovimentacao,
                SaldoAtual = MovimentacaoFinanceira.SaldoAtual,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentacaoFinanceiraQuery(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET PacienteId = @PacienteId, ServicoId = @ServicoId, Valor = @Valor, TipoMovimentacao = @TipoMovimentacao, DataMovimentacao = @DataMovimentacao, SaldoAtual = @SaldoAtual WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = MovimentacaoFinanceira.PacienteId,
                ServicoId = MovimentacaoFinanceira.ServicoId,
                Valor = MovimentacaoFinanceira.Valor,
                TipoMovimentacao = MovimentacaoFinanceira.TipoMovimentacao,
                DataMovimentacao = MovimentacaoFinanceira.DataMovimentacao,
                SaldoAtual = MovimentacaoFinanceira.SaldoAtual,
                Id = MovimentacaoFinanceira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMovimentacaoFinanceiraQuery(MovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            this.Query = $@" DELETE FROM MovimentacaoFinanceira WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MovimentacaoFinanceira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration