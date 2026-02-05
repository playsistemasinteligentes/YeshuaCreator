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
            this.Query = $@" INSERT INTO MovimentoFinanceiro (IdOrigem, ContaDebitoId, ContaCreditoId, Valor, DataMovimento, DataVencimento, Status, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@IdOrigem, @ContaDebitoId, @ContaCreditoId, @Valor, @DataMovimento, @DataVencimento, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IdOrigem = MovimentoFinanceiro.IdOrigem,
                ContaDebitoId = MovimentoFinanceiro.ContaDebitoId,
                ContaCreditoId = MovimentoFinanceiro.ContaCreditoId,
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
            this.Query = $@" UPDATE MovimentoFinanceiro SET IdOrigem = @IdOrigem, ContaDebitoId = @ContaDebitoId, ContaCreditoId = @ContaCreditoId, Valor = @Valor, DataMovimento = @DataMovimento, DataVencimento = @DataVencimento, Status = @Status, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                IdOrigem = MovimentoFinanceiro.IdOrigem,
                ContaDebitoId = MovimentoFinanceiro.ContaDebitoId,
                ContaCreditoId = MovimentoFinanceiro.ContaCreditoId,
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
        public QueryModel UpdateIdOrigem(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET IdOrigem = @IdOrigem WHERE Id = @Id ";
            this.Parameters = new
            {
                IdOrigem = entity.IdOrigem,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateContaDebitoId(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET ContaDebitoId = @ContaDebitoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ContaDebitoId = entity.ContaDebitoId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateContaCreditoId(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET ContaCreditoId = @ContaCreditoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ContaCreditoId = entity.ContaCreditoId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValor(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Valor = @Valor WHERE Id = @Id ";
            this.Parameters = new
            {
                Valor = entity.Valor,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataMovimento(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET DataMovimento = @DataMovimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataMovimento = entity.DataMovimento,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataVencimento(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET DataVencimento = @DataVencimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataVencimento = entity.DataVencimento,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IMovimentoFinanceiroEntity entity)
        {
            this.Query = $@" UPDATE MovimentoFinanceiro SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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