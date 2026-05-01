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
    public class MovimentoFinanceiroQueryWrite : QueryBase, IMovimentoFinanceiroQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public MovimentoFinanceiroQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            this.Query = $@" INSERT INTO MovimentoFinanceiro (IdOrigem, ContaDebitoId, Valor, DataMovimento, DataVencimento, Status, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@IdOrigem, @ContaDebitoId, @Valor, @DataMovimento, @DataVencimento, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IdOrigem = MovimentoFinanceiro.IdOrigem,
                ContaDebitoId = MovimentoFinanceiro.ContaDebitoId,
                Valor = MovimentoFinanceiro.Valor,
                DataMovimento = MovimentoFinanceiro.DataMovimento,
                DataVencimento = MovimentoFinanceiro.DataVencimento,
                Status = MovimentoFinanceiro.Status,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET IdOrigem = @IdOrigem, ContaDebitoId = @ContaDebitoId, Valor = @Valor, DataMovimento = @DataMovimento, DataVencimento = @DataVencimento, Status = @Status, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                IdOrigem = MovimentoFinanceiro.IdOrigem,
                ContaDebitoId = MovimentoFinanceiro.ContaDebitoId,
                Valor = MovimentoFinanceiro.Valor,
                DataMovimento = MovimentoFinanceiro.DataMovimento,
                DataVencimento = MovimentoFinanceiro.DataVencimento,
                Status = MovimentoFinanceiro.Status,
                Changed = MovimentoFinanceiro.Changed,
                UserId = _currentUser.UserId,
                Id = MovimentoFinanceiro.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIdOrigem(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET IdOrigem = @IdOrigem WHERE Id = @Id ";
            this.Parameters = new
            {
                IdOrigem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateContaDebitoId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET ContaDebitoId = @ContaDebitoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ContaDebitoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(int id, Decimal value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataMovimento(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET DataMovimento = @DataMovimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataMovimento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataVencimento(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET DataVencimento = @DataVencimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataVencimento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro)
        {
            this.Query = $@" DELETE FROM MovimentoFinanceiro WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MovimentoFinanceiro.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration