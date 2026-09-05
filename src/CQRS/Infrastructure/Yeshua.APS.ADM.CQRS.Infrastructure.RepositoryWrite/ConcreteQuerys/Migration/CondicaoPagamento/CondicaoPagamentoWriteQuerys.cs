// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

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
    public class CondicaoPagamentoQueryWrite : QueryBase, ICondicaoPagamentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CondicaoPagamentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento)
        {
            this.Query = $@" INSERT INTO [CondicaoPagamento] ([CON_ID], [CON_DESCRICAO], [CON_PARCELAS], [CON_VALOR_ACRECIMO], [CON_INTEGRACAO_ERP], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CON_ID, @CON_DESCRICAO, @CON_PARCELAS, @CON_VALOR_ACRECIMO, @CON_INTEGRACAO_ERP, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CON_ID = CondicaoPagamento.CON_ID,
                CON_DESCRICAO = CondicaoPagamento.CON_DESCRICAO,
                CON_PARCELAS = CondicaoPagamento.CON_PARCELAS,
                CON_VALOR_ACRECIMO = CondicaoPagamento.CON_VALOR_ACRECIMO,
                CON_INTEGRACAO_ERP = CondicaoPagamento.CON_INTEGRACAO_ERP,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_ID] = @CON_ID, [CON_DESCRICAO] = @CON_DESCRICAO, [CON_PARCELAS] = @CON_PARCELAS, [CON_VALOR_ACRECIMO] = @CON_VALOR_ACRECIMO, [CON_INTEGRACAO_ERP] = @CON_INTEGRACAO_ERP, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = CondicaoPagamento.CON_ID,
                CON_DESCRICAO = CondicaoPagamento.CON_DESCRICAO,
                CON_PARCELAS = CondicaoPagamento.CON_PARCELAS,
                CON_VALOR_ACRECIMO = CondicaoPagamento.CON_VALOR_ACRECIMO,
                CON_INTEGRACAO_ERP = CondicaoPagamento.CON_INTEGRACAO_ERP,
                Changed = CondicaoPagamento.Changed,
                UserId = _executionContext.UserId,
                Id = CondicaoPagamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_ID] = @CON_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_DESCRICAO] = @CON_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_PARCELAS(int id, int value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_PARCELAS] = @CON_PARCELAS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_PARCELAS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_VALOR_ACRECIMO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_VALOR_ACRECIMO] = @CON_VALOR_ACRECIMO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_VALOR_ACRECIMO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_INTEGRACAO_ERP(int id, string value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [CON_INTEGRACAO_ERP] = @CON_INTEGRACAO_ERP WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CON_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CondicaoPagamento] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento)
        {
            this.Query = $@" DELETE FROM [CondicaoPagamento] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CondicaoPagamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration