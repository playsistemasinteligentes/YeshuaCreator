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
        protected readonly ICurrentUser _currentUser;
        public MovimentacaoFinanceiraQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
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
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET PacienteId = @PacienteId, ServicoId = @ServicoId, Valor = @Valor, TipoMovimentacao = @TipoMovimentacao, DataMovimentacao = @DataMovimentacao, SaldoAtual = @SaldoAtual, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = MovimentacaoFinanceira.PacienteId,
                ServicoId = MovimentacaoFinanceira.ServicoId,
                Valor = MovimentacaoFinanceira.Valor,
                TipoMovimentacao = MovimentacaoFinanceira.TipoMovimentacao,
                DataMovimentacao = MovimentacaoFinanceira.DataMovimentacao,
                SaldoAtual = MovimentacaoFinanceira.SaldoAtual,
                Changed = MovimentacaoFinanceira.Changed,
                UserId = _currentUser.UserId,
                Id = MovimentacaoFinanceira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET PacienteId = @PacienteId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET ServicoId = @ServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ServicoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(int id, Decimal value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoMovimentacao(int id, int value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET TipoMovimentacao = @TipoMovimentacao WHERE Id = @Id ";
            this.Parameters = new
            {
                TipoMovimentacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataMovimentacao(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET DataMovimentacao = @DataMovimentacao WHERE Id = @Id ";
            this.Parameters = new
            {
                DataMovimentacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSaldoAtual(int id, Decimal value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET SaldoAtual = @SaldoAtual WHERE Id = @Id ";
            this.Parameters = new
            {
                SaldoAtual = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentacaoFinanceira SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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