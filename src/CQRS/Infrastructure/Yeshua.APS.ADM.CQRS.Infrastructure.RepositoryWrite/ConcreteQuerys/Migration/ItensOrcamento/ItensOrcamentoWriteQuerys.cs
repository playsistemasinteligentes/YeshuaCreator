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
    public class ItensOrcamentoQueryWrite : QueryBase, IItensOrcamentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItensOrcamentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento)
        {
            this.Query = $@" INSERT INTO [ItensOrcamento] ([ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@ITO_ID, @ORC_ID, @TIP_ID, @PRO_ID, @ITO_OBS, @ITO_QUANTIDADE, @ITO_CUSTO, @ITO_MARGEM, @ITO_VALOR_UNITARIO, @ITO_VERSSAO_CUSTO, @ITO_STATUS, @ITO_ERP_CUSTOS_FIXOS, @ITO_ERP_CUSTOS_VARIAVEIS, @ITO_ERP_DESPESAS_VAR_VENDA, @ITO_ERP_IMPOSTOS, @GRP_ID_COMPOSICAO, @ITO_LARGURA, @ITO_COMPRIMENTO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ITO_ID = ItensOrcamento.ITO_ID,
                ORC_ID = ItensOrcamento.ORC_ID,
                TIP_ID = ItensOrcamento.TIP_ID,
                PRO_ID = ItensOrcamento.PRO_ID,
                ITO_OBS = ItensOrcamento.ITO_OBS,
                ITO_QUANTIDADE = ItensOrcamento.ITO_QUANTIDADE,
                ITO_CUSTO = ItensOrcamento.ITO_CUSTO,
                ITO_MARGEM = ItensOrcamento.ITO_MARGEM,
                ITO_VALOR_UNITARIO = ItensOrcamento.ITO_VALOR_UNITARIO,
                ITO_VERSSAO_CUSTO = ItensOrcamento.ITO_VERSSAO_CUSTO,
                ITO_STATUS = ItensOrcamento.ITO_STATUS,
                ITO_ERP_CUSTOS_FIXOS = ItensOrcamento.ITO_ERP_CUSTOS_FIXOS,
                ITO_ERP_CUSTOS_VARIAVEIS = ItensOrcamento.ITO_ERP_CUSTOS_VARIAVEIS,
                ITO_ERP_DESPESAS_VAR_VENDA = ItensOrcamento.ITO_ERP_DESPESAS_VAR_VENDA,
                ITO_ERP_IMPOSTOS = ItensOrcamento.ITO_ERP_IMPOSTOS,
                GRP_ID_COMPOSICAO = ItensOrcamento.GRP_ID_COMPOSICAO,
                ITO_LARGURA = ItensOrcamento.ITO_LARGURA,
                ITO_COMPRIMENTO = ItensOrcamento.ITO_COMPRIMENTO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ID] = @ITO_ID, [ORC_ID] = @ORC_ID, [TIP_ID] = @TIP_ID, [PRO_ID] = @PRO_ID, [ITO_OBS] = @ITO_OBS, [ITO_QUANTIDADE] = @ITO_QUANTIDADE, [ITO_CUSTO] = @ITO_CUSTO, [ITO_MARGEM] = @ITO_MARGEM, [ITO_VALOR_UNITARIO] = @ITO_VALOR_UNITARIO, [ITO_VERSSAO_CUSTO] = @ITO_VERSSAO_CUSTO, [ITO_STATUS] = @ITO_STATUS, [ITO_ERP_CUSTOS_FIXOS] = @ITO_ERP_CUSTOS_FIXOS, [ITO_ERP_CUSTOS_VARIAVEIS] = @ITO_ERP_CUSTOS_VARIAVEIS, [ITO_ERP_DESPESAS_VAR_VENDA] = @ITO_ERP_DESPESAS_VAR_VENDA, [ITO_ERP_IMPOSTOS] = @ITO_ERP_IMPOSTOS, [GRP_ID_COMPOSICAO] = @GRP_ID_COMPOSICAO, [ITO_LARGURA] = @ITO_LARGURA, [ITO_COMPRIMENTO] = @ITO_COMPRIMENTO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ID = ItensOrcamento.ITO_ID,
                ORC_ID = ItensOrcamento.ORC_ID,
                TIP_ID = ItensOrcamento.TIP_ID,
                PRO_ID = ItensOrcamento.PRO_ID,
                ITO_OBS = ItensOrcamento.ITO_OBS,
                ITO_QUANTIDADE = ItensOrcamento.ITO_QUANTIDADE,
                ITO_CUSTO = ItensOrcamento.ITO_CUSTO,
                ITO_MARGEM = ItensOrcamento.ITO_MARGEM,
                ITO_VALOR_UNITARIO = ItensOrcamento.ITO_VALOR_UNITARIO,
                ITO_VERSSAO_CUSTO = ItensOrcamento.ITO_VERSSAO_CUSTO,
                ITO_STATUS = ItensOrcamento.ITO_STATUS,
                ITO_ERP_CUSTOS_FIXOS = ItensOrcamento.ITO_ERP_CUSTOS_FIXOS,
                ITO_ERP_CUSTOS_VARIAVEIS = ItensOrcamento.ITO_ERP_CUSTOS_VARIAVEIS,
                ITO_ERP_DESPESAS_VAR_VENDA = ItensOrcamento.ITO_ERP_DESPESAS_VAR_VENDA,
                ITO_ERP_IMPOSTOS = ItensOrcamento.ITO_ERP_IMPOSTOS,
                GRP_ID_COMPOSICAO = ItensOrcamento.GRP_ID_COMPOSICAO,
                ITO_LARGURA = ItensOrcamento.ITO_LARGURA,
                ITO_COMPRIMENTO = ItensOrcamento.ITO_COMPRIMENTO,
                Changed = ItensOrcamento.Changed,
                UserId = _executionContext.UserId,
                Id = ItensOrcamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ID] = @ITO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORC_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ORC_ID] = @ORC_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ORC_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [TIP_ID] = @TIP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [PRO_ID] = @PRO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_OBS(int id, string value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_OBS] = @ITO_OBS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_QUANTIDADE(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_QUANTIDADE] = @ITO_QUANTIDADE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_QUANTIDADE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_CUSTO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_CUSTO] = @ITO_CUSTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_MARGEM(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_MARGEM] = @ITO_MARGEM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_MARGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_VALOR_UNITARIO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_VALOR_UNITARIO] = @ITO_VALOR_UNITARIO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_VALOR_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_VERSSAO_CUSTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_VERSSAO_CUSTO] = @ITO_VERSSAO_CUSTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_VERSSAO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_STATUS] = @ITO_STATUS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ERP_CUSTOS_FIXOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ERP_CUSTOS_FIXOS] = @ITO_ERP_CUSTOS_FIXOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ERP_CUSTOS_FIXOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ERP_CUSTOS_VARIAVEIS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ERP_CUSTOS_VARIAVEIS] = @ITO_ERP_CUSTOS_VARIAVEIS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ERP_CUSTOS_VARIAVEIS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ERP_DESPESAS_VAR_VENDA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ERP_DESPESAS_VAR_VENDA] = @ITO_ERP_DESPESAS_VAR_VENDA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ERP_DESPESAS_VAR_VENDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ERP_IMPOSTOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_ERP_IMPOSTOS] = @ITO_ERP_IMPOSTOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_ERP_IMPOSTOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_COMPOSICAO(int id, string value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [GRP_ID_COMPOSICAO] = @GRP_ID_COMPOSICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_ID_COMPOSICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_LARGURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_LARGURA] = @ITO_LARGURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_COMPRIMENTO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [ITO_COMPRIMENTO] = @ITO_COMPRIMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITO_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ItensOrcamento] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento)
        {
            this.Query = $@" DELETE FROM [ItensOrcamento] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ItensOrcamento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration