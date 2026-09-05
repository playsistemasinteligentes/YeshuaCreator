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
    public class EstruturaCustoQueryWrite : QueryBase, IEstruturaCustoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EstruturaCustoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto)
        {
            this.Query = $@" INSERT INTO [EstruturaCusto] ([ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[EST_ID] VALUES(@ITO_ID, @ORD_ID, @PRO_ID, @PRO_ID_PRODUTO, @PRO_ID_COMPONENTE, @PRO_TIPO_CUSTO, @PRO_GRUPO_CONTABIL, @EST_ORDEM, @EST_GRUPO, @EST_QUANT, @EST_VALOR_TOTAL, @EST_DATA_BASE, @EST_BASE_PRODUCAO, @EST_NIVEL, @FPR_SEQ_REPETICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ITO_ID = EstruturaCusto.ITO_ID,
                ORD_ID = EstruturaCusto.ORD_ID,
                PRO_ID = EstruturaCusto.PRO_ID,
                PRO_ID_PRODUTO = EstruturaCusto.PRO_ID_PRODUTO,
                PRO_ID_COMPONENTE = EstruturaCusto.PRO_ID_COMPONENTE,
                PRO_TIPO_CUSTO = EstruturaCusto.PRO_TIPO_CUSTO,
                PRO_GRUPO_CONTABIL = EstruturaCusto.PRO_GRUPO_CONTABIL,
                EST_ORDEM = EstruturaCusto.EST_ORDEM,
                EST_GRUPO = EstruturaCusto.EST_GRUPO,
                EST_QUANT = EstruturaCusto.EST_QUANT,
                EST_VALOR_TOTAL = EstruturaCusto.EST_VALOR_TOTAL,
                EST_DATA_BASE = EstruturaCusto.EST_DATA_BASE,
                EST_BASE_PRODUCAO = EstruturaCusto.EST_BASE_PRODUCAO,
                EST_NIVEL = EstruturaCusto.EST_NIVEL,
                FPR_SEQ_REPETICAO = EstruturaCusto.FPR_SEQ_REPETICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [ITO_ID] = @ITO_ID, [ORD_ID] = @ORD_ID, [PRO_ID] = @PRO_ID, [PRO_ID_PRODUTO] = @PRO_ID_PRODUTO, [PRO_ID_COMPONENTE] = @PRO_ID_COMPONENTE, [PRO_TIPO_CUSTO] = @PRO_TIPO_CUSTO, [PRO_GRUPO_CONTABIL] = @PRO_GRUPO_CONTABIL, [EST_ORDEM] = @EST_ORDEM, [EST_GRUPO] = @EST_GRUPO, [EST_QUANT] = @EST_QUANT, [EST_VALOR_TOTAL] = @EST_VALOR_TOTAL, [EST_DATA_BASE] = @EST_DATA_BASE, [EST_BASE_PRODUCAO] = @EST_BASE_PRODUCAO, [EST_NIVEL] = @EST_NIVEL, [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                ITO_ID = EstruturaCusto.ITO_ID,
                ORD_ID = EstruturaCusto.ORD_ID,
                PRO_ID = EstruturaCusto.PRO_ID,
                PRO_ID_PRODUTO = EstruturaCusto.PRO_ID_PRODUTO,
                PRO_ID_COMPONENTE = EstruturaCusto.PRO_ID_COMPONENTE,
                PRO_TIPO_CUSTO = EstruturaCusto.PRO_TIPO_CUSTO,
                PRO_GRUPO_CONTABIL = EstruturaCusto.PRO_GRUPO_CONTABIL,
                EST_ORDEM = EstruturaCusto.EST_ORDEM,
                EST_GRUPO = EstruturaCusto.EST_GRUPO,
                EST_QUANT = EstruturaCusto.EST_QUANT,
                EST_VALOR_TOTAL = EstruturaCusto.EST_VALOR_TOTAL,
                EST_DATA_BASE = EstruturaCusto.EST_DATA_BASE,
                EST_BASE_PRODUCAO = EstruturaCusto.EST_BASE_PRODUCAO,
                EST_NIVEL = EstruturaCusto.EST_NIVEL,
                FPR_SEQ_REPETICAO = EstruturaCusto.FPR_SEQ_REPETICAO,
                Changed = EstruturaCusto.Changed,
                UserId = _executionContext.UserId,
                EST_ID = EstruturaCusto.EST_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITO_ID(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [ITO_ID] = @ITO_ID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                ITO_ID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [ORD_ID] = @ORD_ID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                ORD_ID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [PRO_ID] = @PRO_ID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PRODUTO(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [PRO_ID_PRODUTO] = @PRO_ID_PRODUTO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                PRO_ID_PRODUTO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_COMPONENTE(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [PRO_ID_COMPONENTE] = @PRO_ID_COMPONENTE WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                PRO_ID_COMPONENTE = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TIPO_CUSTO(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [PRO_TIPO_CUSTO] = @PRO_TIPO_CUSTO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                PRO_TIPO_CUSTO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_GRUPO_CONTABIL(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [PRO_GRUPO_CONTABIL] = @PRO_GRUPO_CONTABIL WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                PRO_GRUPO_CONTABIL = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_ORDEM(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_ORDEM] = @EST_ORDEM WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_ORDEM = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_GRUPO(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_GRUPO] = @EST_GRUPO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_GRUPO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_QUANT(int est_id, Decimal value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_QUANT] = @EST_QUANT WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_QUANT = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_VALOR_TOTAL(int est_id, Decimal value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_VALOR_TOTAL] = @EST_VALOR_TOTAL WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_VALOR_TOTAL = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_DATA_BASE(int est_id, string value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_DATA_BASE] = @EST_DATA_BASE WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_DATA_BASE = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_BASE_PRODUCAO(int est_id, Decimal value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_BASE_PRODUCAO] = @EST_BASE_PRODUCAO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_BASE_PRODUCAO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_NIVEL(int est_id, Decimal value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [EST_NIVEL] = @EST_NIVEL WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_NIVEL = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [TenantID] = @TenantID WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                TenantID = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int est_id, bool value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [Deleted] = @Deleted WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                Deleted = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int est_id, DateTime value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [Changed] = @Changed WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                Changed = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int est_id, int value)
        {
            this.Query = $@" UPDATE [EstruturaCusto] SET [UserId] = @UserId WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                UserId = value,
                EST_ID = est_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto)
        {
            this.Query = $@" DELETE FROM [EstruturaCusto] WHERE [EST_ID] = @EST_ID ";
            this.Parameters = new
            {
                EST_ID = EstruturaCusto.EST_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration