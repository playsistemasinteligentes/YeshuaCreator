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
    public class T_IndicadoresQueryWrite : QueryBase, IT_IndicadoresQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_IndicadoresQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores)
        {
            this.Query = $@" INSERT INTO [T_Indicadores] ([IND_DESCRICAO], [NEG_ID], [DESC_CALCULO], [IND_TIPOCOMPARADOR], [IND_GRAFICO], [IND_CONEXAO], [IND_DTCRIACAO], [RESPOSAVELIND], [RESPOSAVELCARGA], [PROCEXTRACAO], [PER_ID], [DIM_ID], [DOM_EMPRESA], [DOM_FILIAL], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[IND_ID] VALUES(@IND_DESCRICAO, @NEG_ID, @DESC_CALCULO, @IND_TIPOCOMPARADOR, @IND_GRAFICO, @IND_CONEXAO, @IND_DTCRIACAO, @RESPOSAVELIND, @RESPOSAVELCARGA, @PROCEXTRACAO, @PER_ID, @DIM_ID, @DOM_EMPRESA, @DOM_FILIAL, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IND_DESCRICAO = T_Indicadores.IND_DESCRICAO,
                NEG_ID = T_Indicadores.NEG_ID,
                DESC_CALCULO = T_Indicadores.DESC_CALCULO,
                IND_TIPOCOMPARADOR = T_Indicadores.IND_TIPOCOMPARADOR,
                IND_GRAFICO = T_Indicadores.IND_GRAFICO,
                IND_CONEXAO = T_Indicadores.IND_CONEXAO,
                IND_DTCRIACAO = T_Indicadores.IND_DTCRIACAO,
                RESPOSAVELIND = T_Indicadores.RESPOSAVELIND,
                RESPOSAVELCARGA = T_Indicadores.RESPOSAVELCARGA,
                PROCEXTRACAO = T_Indicadores.PROCEXTRACAO,
                PER_ID = T_Indicadores.PER_ID,
                DIM_ID = T_Indicadores.DIM_ID,
                DOM_EMPRESA = T_Indicadores.DOM_EMPRESA,
                DOM_FILIAL = T_Indicadores.DOM_FILIAL,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_DESCRICAO] = @IND_DESCRICAO, [NEG_ID] = @NEG_ID, [DESC_CALCULO] = @DESC_CALCULO, [IND_TIPOCOMPARADOR] = @IND_TIPOCOMPARADOR, [IND_GRAFICO] = @IND_GRAFICO, [IND_CONEXAO] = @IND_CONEXAO, [IND_DTCRIACAO] = @IND_DTCRIACAO, [RESPOSAVELIND] = @RESPOSAVELIND, [RESPOSAVELCARGA] = @RESPOSAVELCARGA, [PROCEXTRACAO] = @PROCEXTRACAO, [PER_ID] = @PER_ID, [DIM_ID] = @DIM_ID, [DOM_EMPRESA] = @DOM_EMPRESA, [DOM_FILIAL] = @DOM_FILIAL, [Changed] = @Changed, [UserId] = @UserId WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_DESCRICAO = T_Indicadores.IND_DESCRICAO,
                NEG_ID = T_Indicadores.NEG_ID,
                DESC_CALCULO = T_Indicadores.DESC_CALCULO,
                IND_TIPOCOMPARADOR = T_Indicadores.IND_TIPOCOMPARADOR,
                IND_GRAFICO = T_Indicadores.IND_GRAFICO,
                IND_CONEXAO = T_Indicadores.IND_CONEXAO,
                IND_DTCRIACAO = T_Indicadores.IND_DTCRIACAO,
                RESPOSAVELIND = T_Indicadores.RESPOSAVELIND,
                RESPOSAVELCARGA = T_Indicadores.RESPOSAVELCARGA,
                PROCEXTRACAO = T_Indicadores.PROCEXTRACAO,
                PER_ID = T_Indicadores.PER_ID,
                DIM_ID = T_Indicadores.DIM_ID,
                DOM_EMPRESA = T_Indicadores.DOM_EMPRESA,
                DOM_FILIAL = T_Indicadores.DOM_FILIAL,
                Changed = T_Indicadores.Changed,
                UserId = _executionContext.UserId,
                IND_ID = T_Indicadores.IND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_DESCRICAO(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_DESCRICAO] = @IND_DESCRICAO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_DESCRICAO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNEG_ID(int ind_id, int value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [NEG_ID] = @NEG_ID WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                NEG_ID = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDESC_CALCULO(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [DESC_CALCULO] = @DESC_CALCULO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                DESC_CALCULO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_TIPOCOMPARADOR(int ind_id, int value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_TIPOCOMPARADOR] = @IND_TIPOCOMPARADOR WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_TIPOCOMPARADOR = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_GRAFICO(int ind_id, int value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_GRAFICO] = @IND_GRAFICO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_GRAFICO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_CONEXAO(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_CONEXAO] = @IND_CONEXAO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_CONEXAO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_DTCRIACAO(int ind_id, DateTime value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [IND_DTCRIACAO] = @IND_DTCRIACAO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_DTCRIACAO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRESPOSAVELIND(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [RESPOSAVELIND] = @RESPOSAVELIND WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                RESPOSAVELIND = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRESPOSAVELCARGA(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [RESPOSAVELCARGA] = @RESPOSAVELCARGA WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                RESPOSAVELCARGA = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePROCEXTRACAO(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [PROCEXTRACAO] = @PROCEXTRACAO WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                PROCEXTRACAO = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [PER_ID] = @PER_ID WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                PER_ID = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [DIM_ID] = @DIM_ID WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                DIM_ID = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_EMPRESA(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [DOM_EMPRESA] = @DOM_EMPRESA WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                DOM_EMPRESA = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_FILIAL(int ind_id, string value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [DOM_FILIAL] = @DOM_FILIAL WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                DOM_FILIAL = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int ind_id, int value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [TenantID] = @TenantID WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                TenantID = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int ind_id, bool value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [Deleted] = @Deleted WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                Deleted = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int ind_id, DateTime value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [Changed] = @Changed WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                Changed = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int ind_id, int value)
        {
            this.Query = $@" UPDATE [T_Indicadores] SET [UserId] = @UserId WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                UserId = value,
                IND_ID = ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores)
        {
            this.Query = $@" DELETE FROM [T_Indicadores] WHERE [IND_ID] = @IND_ID ";
            this.Parameters = new
            {
                IND_ID = T_Indicadores.IND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration