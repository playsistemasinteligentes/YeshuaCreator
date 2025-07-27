using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class MovimentacaoFinanceiraQueryWrite : QueryBase, IMovimentacaoFinanceiraQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public MovimentacaoFinanceiraQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            this.Query = $@" INSERT INTO MovimentacaoFinanceira (PacienteId, ServicoId, Valor, TipoMovimentacao, DataMovimentacao, SaldoAtual, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PacienteId, @ServicoId, @Valor, @TipoMovimentacao, @DataMovimentacao, @SaldoAtual, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PacienteId = MovimentacaoFinanceira.PacienteId,
                ServicoId = MovimentacaoFinanceira.ServicoId,
                Valor = MovimentacaoFinanceira.Valor,
                TipoMovimentacao = MovimentacaoFinanceira.TipoMovimentacao,
                DataMovimentacao = MovimentacaoFinanceira.DataMovimentacao,
                SaldoAtual = MovimentacaoFinanceira.SaldoAtual,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
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
        public QueryModel UpdatePacienteId(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET PacienteId = @PacienteId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = entity.PacienteId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoId(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET ServicoId = @ServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ServicoId = entity.ServicoId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = entity.Valor,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET TipoMovimentacao = @TipoMovimentacao WHERE Id = @Id ";
            this.Parameters = new
            {
                TipoMovimentacao = entity.TipoMovimentacao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataMovimentacao(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET DataMovimentacao = @DataMovimentacao WHERE Id = @Id ";
            this.Parameters = new
            {
                DataMovimentacao = entity.DataMovimentacao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSaldoAtual(IMovimentacaoFinanceiraEntity entity)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET SaldoAtual = @SaldoAtual WHERE Id = @Id ";
            this.Parameters = new
            {
                SaldoAtual = entity.SaldoAtual,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration