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
    public class ClpMedicoesHQueryWrite : QueryBase, IClpMedicoesHQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ClpMedicoesHQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH)
        {
            this.Query = $@" INSERT INTO [ClpMedicoesH] ([ID], [MAQUINA_ID], [DATA_INI], [DATA_FIM], [CLP_EMISSAO], [QTD], [GRUPO], [STATUS], [URN_ID], [URM_ID], [ID_LOTE_CLP], [OCO_ID], [FASE], [CLP_ORIGEM], [CLP_LOTE], [COMPACTA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@ID, @MAQUINA_ID, @DATA_INI, @DATA_FIM, @CLP_EMISSAO, @QTD, @GRUPO, @STATUS, @URN_ID, @URM_ID, @ID_LOTE_CLP, @OCO_ID, @FASE, @CLP_ORIGEM, @CLP_LOTE, @COMPACTA, @BOL_ID, @COR_SEQUENCIA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ID = ClpMedicoesH.ID,
                MAQUINA_ID = ClpMedicoesH.MAQUINA_ID,
                DATA_INI = ClpMedicoesH.DATA_INI,
                DATA_FIM = ClpMedicoesH.DATA_FIM,
                CLP_EMISSAO = ClpMedicoesH.CLP_EMISSAO,
                QTD = ClpMedicoesH.QTD,
                GRUPO = ClpMedicoesH.GRUPO,
                STATUS = ClpMedicoesH.STATUS,
                URN_ID = ClpMedicoesH.URN_ID,
                URM_ID = ClpMedicoesH.URM_ID,
                ID_LOTE_CLP = ClpMedicoesH.ID_LOTE_CLP,
                OCO_ID = ClpMedicoesH.OCO_ID,
                FASE = ClpMedicoesH.FASE,
                CLP_ORIGEM = ClpMedicoesH.CLP_ORIGEM,
                CLP_LOTE = ClpMedicoesH.CLP_LOTE,
                COMPACTA = ClpMedicoesH.COMPACTA,
                BOL_ID = ClpMedicoesH.BOL_ID,
                COR_SEQUENCIA = ClpMedicoesH.COR_SEQUENCIA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [MAQUINA_ID] = @MAQUINA_ID, [DATA_INI] = @DATA_INI, [DATA_FIM] = @DATA_FIM, [CLP_EMISSAO] = @CLP_EMISSAO, [QTD] = @QTD, [GRUPO] = @GRUPO, [STATUS] = @STATUS, [URN_ID] = @URN_ID, [URM_ID] = @URM_ID, [ID_LOTE_CLP] = @ID_LOTE_CLP, [OCO_ID] = @OCO_ID, [FASE] = @FASE, [CLP_ORIGEM] = @CLP_ORIGEM, [CLP_LOTE] = @CLP_LOTE, [COMPACTA] = @COMPACTA, [BOL_ID] = @BOL_ID, [COR_SEQUENCIA] = @COR_SEQUENCIA, [Changed] = @Changed, [UserId] = @UserId WHERE [ID] = @ID ";
            this.Parameters = new
            {
                MAQUINA_ID = ClpMedicoesH.MAQUINA_ID,
                DATA_INI = ClpMedicoesH.DATA_INI,
                DATA_FIM = ClpMedicoesH.DATA_FIM,
                CLP_EMISSAO = ClpMedicoesH.CLP_EMISSAO,
                QTD = ClpMedicoesH.QTD,
                GRUPO = ClpMedicoesH.GRUPO,
                STATUS = ClpMedicoesH.STATUS,
                URN_ID = ClpMedicoesH.URN_ID,
                URM_ID = ClpMedicoesH.URM_ID,
                ID_LOTE_CLP = ClpMedicoesH.ID_LOTE_CLP,
                OCO_ID = ClpMedicoesH.OCO_ID,
                FASE = ClpMedicoesH.FASE,
                CLP_ORIGEM = ClpMedicoesH.CLP_ORIGEM,
                CLP_LOTE = ClpMedicoesH.CLP_LOTE,
                COMPACTA = ClpMedicoesH.COMPACTA,
                BOL_ID = ClpMedicoesH.BOL_ID,
                COR_SEQUENCIA = ClpMedicoesH.COR_SEQUENCIA,
                Changed = ClpMedicoesH.Changed,
                UserId = _executionContext.UserId,
                ID = ClpMedicoesH.ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQUINA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [MAQUINA_ID] = @MAQUINA_ID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                MAQUINA_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDATA_INI(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [DATA_INI] = @DATA_INI WHERE [ID] = @ID ";
            this.Parameters = new
            {
                DATA_INI = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDATA_FIM(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [DATA_FIM] = @DATA_FIM WHERE [ID] = @ID ";
            this.Parameters = new
            {
                DATA_FIM = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLP_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [CLP_EMISSAO] = @CLP_EMISSAO WHERE [ID] = @ID ";
            this.Parameters = new
            {
                CLP_EMISSAO = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQTD(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [QTD] = @QTD WHERE [ID] = @ID ";
            this.Parameters = new
            {
                QTD = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRUPO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [GRUPO] = @GRUPO WHERE [ID] = @ID ";
            this.Parameters = new
            {
                GRUPO = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSTATUS(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [STATUS] = @STATUS WHERE [ID] = @ID ";
            this.Parameters = new
            {
                STATUS = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateURN_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [URN_ID] = @URN_ID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                URN_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateURM_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [URM_ID] = @URM_ID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                URM_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateID_LOTE_CLP(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [ID_LOTE_CLP] = @ID_LOTE_CLP WHERE [ID] = @ID ";
            this.Parameters = new
            {
                ID_LOTE_CLP = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [OCO_ID] = @OCO_ID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                OCO_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFASE(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [FASE] = @FASE WHERE [ID] = @ID ";
            this.Parameters = new
            {
                FASE = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLP_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [CLP_ORIGEM] = @CLP_ORIGEM WHERE [ID] = @ID ";
            this.Parameters = new
            {
                CLP_ORIGEM = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLP_LOTE(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [CLP_LOTE] = @CLP_LOTE WHERE [ID] = @ID ";
            this.Parameters = new
            {
                CLP_LOTE = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOMPACTA(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [COMPACTA] = @COMPACTA WHERE [ID] = @ID ";
            this.Parameters = new
            {
                COMPACTA = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [BOL_ID] = @BOL_ID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                BOL_ID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [COR_SEQUENCIA] = @COR_SEQUENCIA WHERE [ID] = @ID ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [TenantID] = @TenantID WHERE [ID] = @ID ";
            this.Parameters = new
            {
                TenantID = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [Deleted] = @Deleted WHERE [ID] = @ID ";
            this.Parameters = new
            {
                Deleted = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [Changed] = @Changed WHERE [ID] = @ID ";
            this.Parameters = new
            {
                Changed = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ClpMedicoesH] SET [UserId] = @UserId WHERE [ID] = @ID ";
            this.Parameters = new
            {
                UserId = value,
                ID = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH)
        {
            this.Query = $@" DELETE FROM [ClpMedicoesH] WHERE [ID] = @ID ";
            this.Parameters = new
            {
                ID = ClpMedicoesH.ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration