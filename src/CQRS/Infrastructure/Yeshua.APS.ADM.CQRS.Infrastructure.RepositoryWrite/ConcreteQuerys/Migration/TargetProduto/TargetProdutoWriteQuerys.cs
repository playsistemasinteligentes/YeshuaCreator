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
    public class TargetProdutoQueryWrite : QueryBase, ITargetProdutoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TargetProdutoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTargetProdutoQuery(ITargetProdutoEntity TargetProduto)
        {
            this.Query = $@" INSERT INTO TargetProduto (MOV_ID, ORD_ID, PRO_ID, MAQ_ID, UNI_ID, TURM_ID, TURN_ID, USE_ID, TAR_DIA_TURMA, TAR_META_PERFORMANCE, TAR_REALIZADO_PERFORMANCE, TAR_PERCENTUAL_REALIZADO_PERFORMANCE, TAR_PROXIMA_META_PERFORMANCE, TAR_META_TEMPO_SETUP, TAR_REALIZADO_TEMPO_SETUP, TAR_PROXIMA_META_TEMPO_SETUP, TAR_META_TEMPO_SETUP_AJUSTE, TAR_REALIZADO_TEMPO_SETUP_AJUSTE, TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE, OCO_ID_PERFORMANCE, TAR_OBS_PERFORMANCE, OCO_ID_SETUP, TAR_OBS_SETUP, OCO_ID_SETUPA, TAR_OBS_SETUPA, TAR_TIPO_FEEDBACK_PERFORMANCE, TAR_TIPO_FEEDBACK_SETUP, TAR_TIPO_FEEDBACK_SETUP_AJUSTE, TAR_QTD_SETUP_AJUSTE, TAR_QTD, TAR_PARAMETRO_TIME_WORK_STOP_MACHINE, TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, TAR_PERFORMANCE_MAX_VERDE, TAR_PERFORMANCE_MIN_VERDE, TAR_SETUP_MAX_VERDE, TAR_SETUP_MIN_VERDE, TAR_SETUPA_MAX_VERDE, TAR_SETUPA_MIN_VERDE, TAR_PERFORMANCE_MIN_AMARELO, TAR_SETUP_MAX_AMARELO, TAR_SETUPA_MAX_AMARELO, TAR_OBS_OP_PARCIAL, TAR_OCO_ID_OP_PARCIAL, TAR_COR_PERFORMANCE, TAR_COR_SETUP_GERAL, TAR_COR_SETUP, TAR_COR_SETUPA, TAR_DIA_TURMA_D, FEE_QTD_PECAS_POR_PULSO, TAR_QTD_PERDAS, TAR_DATA_INICIAL, TAR_DATA_FINAL, TAR_APROVADO, TAR_TEMPO_PRODUZINDO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.TAR_ID VALUES(@MOV_ID, @ORD_ID, @PRO_ID, @MAQ_ID, @UNI_ID, @TURM_ID, @TURN_ID, @USE_ID, @TAR_DIA_TURMA, @TAR_META_PERFORMANCE, @TAR_REALIZADO_PERFORMANCE, @TAR_PERCENTUAL_REALIZADO_PERFORMANCE, @TAR_PROXIMA_META_PERFORMANCE, @TAR_META_TEMPO_SETUP, @TAR_REALIZADO_TEMPO_SETUP, @TAR_PROXIMA_META_TEMPO_SETUP, @TAR_META_TEMPO_SETUP_AJUSTE, @TAR_REALIZADO_TEMPO_SETUP_AJUSTE, @TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE, @OCO_ID_PERFORMANCE, @TAR_OBS_PERFORMANCE, @OCO_ID_SETUP, @TAR_OBS_SETUP, @OCO_ID_SETUPA, @TAR_OBS_SETUPA, @TAR_TIPO_FEEDBACK_PERFORMANCE, @TAR_TIPO_FEEDBACK_SETUP, @TAR_TIPO_FEEDBACK_SETUP_AJUSTE, @TAR_QTD_SETUP_AJUSTE, @TAR_QTD, @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE, @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE, @ROT_SEQ_TRANFORMACAO, @FPR_SEQ_REPETICAO, @TAR_PERFORMANCE_MAX_VERDE, @TAR_PERFORMANCE_MIN_VERDE, @TAR_SETUP_MAX_VERDE, @TAR_SETUP_MIN_VERDE, @TAR_SETUPA_MAX_VERDE, @TAR_SETUPA_MIN_VERDE, @TAR_PERFORMANCE_MIN_AMARELO, @TAR_SETUP_MAX_AMARELO, @TAR_SETUPA_MAX_AMARELO, @TAR_OBS_OP_PARCIAL, @TAR_OCO_ID_OP_PARCIAL, @TAR_COR_PERFORMANCE, @TAR_COR_SETUP_GERAL, @TAR_COR_SETUP, @TAR_COR_SETUPA, @TAR_DIA_TURMA_D, @FEE_QTD_PECAS_POR_PULSO, @TAR_QTD_PERDAS, @TAR_DATA_INICIAL, @TAR_DATA_FINAL, @TAR_APROVADO, @TAR_TEMPO_PRODUZINDO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MOV_ID = TargetProduto.MOV_ID,
                ORD_ID = TargetProduto.ORD_ID,
                PRO_ID = TargetProduto.PRO_ID,
                MAQ_ID = TargetProduto.MAQ_ID,
                UNI_ID = TargetProduto.UNI_ID,
                TURM_ID = TargetProduto.TURM_ID,
                TURN_ID = TargetProduto.TURN_ID,
                USE_ID = TargetProduto.USE_ID,
                TAR_DIA_TURMA = TargetProduto.TAR_DIA_TURMA,
                TAR_META_PERFORMANCE = TargetProduto.TAR_META_PERFORMANCE,
                TAR_REALIZADO_PERFORMANCE = TargetProduto.TAR_REALIZADO_PERFORMANCE,
                TAR_PERCENTUAL_REALIZADO_PERFORMANCE = TargetProduto.TAR_PERCENTUAL_REALIZADO_PERFORMANCE,
                TAR_PROXIMA_META_PERFORMANCE = TargetProduto.TAR_PROXIMA_META_PERFORMANCE,
                TAR_META_TEMPO_SETUP = TargetProduto.TAR_META_TEMPO_SETUP,
                TAR_REALIZADO_TEMPO_SETUP = TargetProduto.TAR_REALIZADO_TEMPO_SETUP,
                TAR_PROXIMA_META_TEMPO_SETUP = TargetProduto.TAR_PROXIMA_META_TEMPO_SETUP,
                TAR_META_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_META_TEMPO_SETUP_AJUSTE,
                TAR_REALIZADO_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_REALIZADO_TEMPO_SETUP_AJUSTE,
                TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE,
                OCO_ID_PERFORMANCE = TargetProduto.OCO_ID_PERFORMANCE,
                TAR_OBS_PERFORMANCE = TargetProduto.TAR_OBS_PERFORMANCE,
                OCO_ID_SETUP = TargetProduto.OCO_ID_SETUP,
                TAR_OBS_SETUP = TargetProduto.TAR_OBS_SETUP,
                OCO_ID_SETUPA = TargetProduto.OCO_ID_SETUPA,
                TAR_OBS_SETUPA = TargetProduto.TAR_OBS_SETUPA,
                TAR_TIPO_FEEDBACK_PERFORMANCE = TargetProduto.TAR_TIPO_FEEDBACK_PERFORMANCE,
                TAR_TIPO_FEEDBACK_SETUP = TargetProduto.TAR_TIPO_FEEDBACK_SETUP,
                TAR_TIPO_FEEDBACK_SETUP_AJUSTE = TargetProduto.TAR_TIPO_FEEDBACK_SETUP_AJUSTE,
                TAR_QTD_SETUP_AJUSTE = TargetProduto.TAR_QTD_SETUP_AJUSTE,
                TAR_QTD = TargetProduto.TAR_QTD,
                TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = TargetProduto.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE,
                TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = TargetProduto.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE,
                ROT_SEQ_TRANFORMACAO = TargetProduto.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = TargetProduto.FPR_SEQ_REPETICAO,
                TAR_PERFORMANCE_MAX_VERDE = TargetProduto.TAR_PERFORMANCE_MAX_VERDE,
                TAR_PERFORMANCE_MIN_VERDE = TargetProduto.TAR_PERFORMANCE_MIN_VERDE,
                TAR_SETUP_MAX_VERDE = TargetProduto.TAR_SETUP_MAX_VERDE,
                TAR_SETUP_MIN_VERDE = TargetProduto.TAR_SETUP_MIN_VERDE,
                TAR_SETUPA_MAX_VERDE = TargetProduto.TAR_SETUPA_MAX_VERDE,
                TAR_SETUPA_MIN_VERDE = TargetProduto.TAR_SETUPA_MIN_VERDE,
                TAR_PERFORMANCE_MIN_AMARELO = TargetProduto.TAR_PERFORMANCE_MIN_AMARELO,
                TAR_SETUP_MAX_AMARELO = TargetProduto.TAR_SETUP_MAX_AMARELO,
                TAR_SETUPA_MAX_AMARELO = TargetProduto.TAR_SETUPA_MAX_AMARELO,
                TAR_OBS_OP_PARCIAL = TargetProduto.TAR_OBS_OP_PARCIAL,
                TAR_OCO_ID_OP_PARCIAL = TargetProduto.TAR_OCO_ID_OP_PARCIAL,
                TAR_COR_PERFORMANCE = TargetProduto.TAR_COR_PERFORMANCE,
                TAR_COR_SETUP_GERAL = TargetProduto.TAR_COR_SETUP_GERAL,
                TAR_COR_SETUP = TargetProduto.TAR_COR_SETUP,
                TAR_COR_SETUPA = TargetProduto.TAR_COR_SETUPA,
                TAR_DIA_TURMA_D = TargetProduto.TAR_DIA_TURMA_D,
                FEE_QTD_PECAS_POR_PULSO = TargetProduto.FEE_QTD_PECAS_POR_PULSO,
                TAR_QTD_PERDAS = TargetProduto.TAR_QTD_PERDAS,
                TAR_DATA_INICIAL = TargetProduto.TAR_DATA_INICIAL,
                TAR_DATA_FINAL = TargetProduto.TAR_DATA_FINAL,
                TAR_APROVADO = TargetProduto.TAR_APROVADO,
                TAR_TEMPO_PRODUZINDO = TargetProduto.TAR_TEMPO_PRODUZINDO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTargetProdutoQuery(ITargetProdutoEntity TargetProduto)
        {
            this.Query = $@" UPDATE TargetProduto SET MOV_ID = @MOV_ID, ORD_ID = @ORD_ID, PRO_ID = @PRO_ID, MAQ_ID = @MAQ_ID, UNI_ID = @UNI_ID, TURM_ID = @TURM_ID, TURN_ID = @TURN_ID, USE_ID = @USE_ID, TAR_DIA_TURMA = @TAR_DIA_TURMA, TAR_META_PERFORMANCE = @TAR_META_PERFORMANCE, TAR_REALIZADO_PERFORMANCE = @TAR_REALIZADO_PERFORMANCE, TAR_PERCENTUAL_REALIZADO_PERFORMANCE = @TAR_PERCENTUAL_REALIZADO_PERFORMANCE, TAR_PROXIMA_META_PERFORMANCE = @TAR_PROXIMA_META_PERFORMANCE, TAR_META_TEMPO_SETUP = @TAR_META_TEMPO_SETUP, TAR_REALIZADO_TEMPO_SETUP = @TAR_REALIZADO_TEMPO_SETUP, TAR_PROXIMA_META_TEMPO_SETUP = @TAR_PROXIMA_META_TEMPO_SETUP, TAR_META_TEMPO_SETUP_AJUSTE = @TAR_META_TEMPO_SETUP_AJUSTE, TAR_REALIZADO_TEMPO_SETUP_AJUSTE = @TAR_REALIZADO_TEMPO_SETUP_AJUSTE, TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = @TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE, OCO_ID_PERFORMANCE = @OCO_ID_PERFORMANCE, TAR_OBS_PERFORMANCE = @TAR_OBS_PERFORMANCE, OCO_ID_SETUP = @OCO_ID_SETUP, TAR_OBS_SETUP = @TAR_OBS_SETUP, OCO_ID_SETUPA = @OCO_ID_SETUPA, TAR_OBS_SETUPA = @TAR_OBS_SETUPA, TAR_TIPO_FEEDBACK_PERFORMANCE = @TAR_TIPO_FEEDBACK_PERFORMANCE, TAR_TIPO_FEEDBACK_SETUP = @TAR_TIPO_FEEDBACK_SETUP, TAR_TIPO_FEEDBACK_SETUP_AJUSTE = @TAR_TIPO_FEEDBACK_SETUP_AJUSTE, TAR_QTD_SETUP_AJUSTE = @TAR_QTD_SETUP_AJUSTE, TAR_QTD = @TAR_QTD, TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE, TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE, ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO, TAR_PERFORMANCE_MAX_VERDE = @TAR_PERFORMANCE_MAX_VERDE, TAR_PERFORMANCE_MIN_VERDE = @TAR_PERFORMANCE_MIN_VERDE, TAR_SETUP_MAX_VERDE = @TAR_SETUP_MAX_VERDE, TAR_SETUP_MIN_VERDE = @TAR_SETUP_MIN_VERDE, TAR_SETUPA_MAX_VERDE = @TAR_SETUPA_MAX_VERDE, TAR_SETUPA_MIN_VERDE = @TAR_SETUPA_MIN_VERDE, TAR_PERFORMANCE_MIN_AMARELO = @TAR_PERFORMANCE_MIN_AMARELO, TAR_SETUP_MAX_AMARELO = @TAR_SETUP_MAX_AMARELO, TAR_SETUPA_MAX_AMARELO = @TAR_SETUPA_MAX_AMARELO, TAR_OBS_OP_PARCIAL = @TAR_OBS_OP_PARCIAL, TAR_OCO_ID_OP_PARCIAL = @TAR_OCO_ID_OP_PARCIAL, TAR_COR_PERFORMANCE = @TAR_COR_PERFORMANCE, TAR_COR_SETUP_GERAL = @TAR_COR_SETUP_GERAL, TAR_COR_SETUP = @TAR_COR_SETUP, TAR_COR_SETUPA = @TAR_COR_SETUPA, TAR_DIA_TURMA_D = @TAR_DIA_TURMA_D, FEE_QTD_PECAS_POR_PULSO = @FEE_QTD_PECAS_POR_PULSO, TAR_QTD_PERDAS = @TAR_QTD_PERDAS, TAR_DATA_INICIAL = @TAR_DATA_INICIAL, TAR_DATA_FINAL = @TAR_DATA_FINAL, TAR_APROVADO = @TAR_APROVADO, TAR_TEMPO_PRODUZINDO = @TAR_TEMPO_PRODUZINDO, Changed = @Changed, UserId = @UserId WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                MOV_ID = TargetProduto.MOV_ID,
                ORD_ID = TargetProduto.ORD_ID,
                PRO_ID = TargetProduto.PRO_ID,
                MAQ_ID = TargetProduto.MAQ_ID,
                UNI_ID = TargetProduto.UNI_ID,
                TURM_ID = TargetProduto.TURM_ID,
                TURN_ID = TargetProduto.TURN_ID,
                USE_ID = TargetProduto.USE_ID,
                TAR_DIA_TURMA = TargetProduto.TAR_DIA_TURMA,
                TAR_META_PERFORMANCE = TargetProduto.TAR_META_PERFORMANCE,
                TAR_REALIZADO_PERFORMANCE = TargetProduto.TAR_REALIZADO_PERFORMANCE,
                TAR_PERCENTUAL_REALIZADO_PERFORMANCE = TargetProduto.TAR_PERCENTUAL_REALIZADO_PERFORMANCE,
                TAR_PROXIMA_META_PERFORMANCE = TargetProduto.TAR_PROXIMA_META_PERFORMANCE,
                TAR_META_TEMPO_SETUP = TargetProduto.TAR_META_TEMPO_SETUP,
                TAR_REALIZADO_TEMPO_SETUP = TargetProduto.TAR_REALIZADO_TEMPO_SETUP,
                TAR_PROXIMA_META_TEMPO_SETUP = TargetProduto.TAR_PROXIMA_META_TEMPO_SETUP,
                TAR_META_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_META_TEMPO_SETUP_AJUSTE,
                TAR_REALIZADO_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_REALIZADO_TEMPO_SETUP_AJUSTE,
                TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = TargetProduto.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE,
                OCO_ID_PERFORMANCE = TargetProduto.OCO_ID_PERFORMANCE,
                TAR_OBS_PERFORMANCE = TargetProduto.TAR_OBS_PERFORMANCE,
                OCO_ID_SETUP = TargetProduto.OCO_ID_SETUP,
                TAR_OBS_SETUP = TargetProduto.TAR_OBS_SETUP,
                OCO_ID_SETUPA = TargetProduto.OCO_ID_SETUPA,
                TAR_OBS_SETUPA = TargetProduto.TAR_OBS_SETUPA,
                TAR_TIPO_FEEDBACK_PERFORMANCE = TargetProduto.TAR_TIPO_FEEDBACK_PERFORMANCE,
                TAR_TIPO_FEEDBACK_SETUP = TargetProduto.TAR_TIPO_FEEDBACK_SETUP,
                TAR_TIPO_FEEDBACK_SETUP_AJUSTE = TargetProduto.TAR_TIPO_FEEDBACK_SETUP_AJUSTE,
                TAR_QTD_SETUP_AJUSTE = TargetProduto.TAR_QTD_SETUP_AJUSTE,
                TAR_QTD = TargetProduto.TAR_QTD,
                TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = TargetProduto.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE,
                TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = TargetProduto.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE,
                ROT_SEQ_TRANFORMACAO = TargetProduto.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = TargetProduto.FPR_SEQ_REPETICAO,
                TAR_PERFORMANCE_MAX_VERDE = TargetProduto.TAR_PERFORMANCE_MAX_VERDE,
                TAR_PERFORMANCE_MIN_VERDE = TargetProduto.TAR_PERFORMANCE_MIN_VERDE,
                TAR_SETUP_MAX_VERDE = TargetProduto.TAR_SETUP_MAX_VERDE,
                TAR_SETUP_MIN_VERDE = TargetProduto.TAR_SETUP_MIN_VERDE,
                TAR_SETUPA_MAX_VERDE = TargetProduto.TAR_SETUPA_MAX_VERDE,
                TAR_SETUPA_MIN_VERDE = TargetProduto.TAR_SETUPA_MIN_VERDE,
                TAR_PERFORMANCE_MIN_AMARELO = TargetProduto.TAR_PERFORMANCE_MIN_AMARELO,
                TAR_SETUP_MAX_AMARELO = TargetProduto.TAR_SETUP_MAX_AMARELO,
                TAR_SETUPA_MAX_AMARELO = TargetProduto.TAR_SETUPA_MAX_AMARELO,
                TAR_OBS_OP_PARCIAL = TargetProduto.TAR_OBS_OP_PARCIAL,
                TAR_OCO_ID_OP_PARCIAL = TargetProduto.TAR_OCO_ID_OP_PARCIAL,
                TAR_COR_PERFORMANCE = TargetProduto.TAR_COR_PERFORMANCE,
                TAR_COR_SETUP_GERAL = TargetProduto.TAR_COR_SETUP_GERAL,
                TAR_COR_SETUP = TargetProduto.TAR_COR_SETUP,
                TAR_COR_SETUPA = TargetProduto.TAR_COR_SETUPA,
                TAR_DIA_TURMA_D = TargetProduto.TAR_DIA_TURMA_D,
                FEE_QTD_PECAS_POR_PULSO = TargetProduto.FEE_QTD_PECAS_POR_PULSO,
                TAR_QTD_PERDAS = TargetProduto.TAR_QTD_PERDAS,
                TAR_DATA_INICIAL = TargetProduto.TAR_DATA_INICIAL,
                TAR_DATA_FINAL = TargetProduto.TAR_DATA_FINAL,
                TAR_APROVADO = TargetProduto.TAR_APROVADO,
                TAR_TEMPO_PRODUZINDO = TargetProduto.TAR_TEMPO_PRODUZINDO,
                Changed = TargetProduto.Changed,
                UserId = _executionContext.UserId,
                TAR_ID = TargetProduto.TAR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_ID(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET MOV_ID = @MOV_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                MOV_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET ORD_ID = @ORD_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                ORD_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET PRO_ID = @PRO_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET MAQ_ID = @MAQ_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET UNI_ID = @UNI_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                UNI_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TURM_ID = @TURM_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TURM_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_ID(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TURN_ID = @TURN_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TURN_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET USE_ID = @USE_ID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_DIA_TURMA(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_DIA_TURMA = @TAR_DIA_TURMA WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_DIA_TURMA = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_META_PERFORMANCE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_META_PERFORMANCE = @TAR_META_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_META_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_REALIZADO_PERFORMANCE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_REALIZADO_PERFORMANCE = @TAR_REALIZADO_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_REALIZADO_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PERCENTUAL_REALIZADO_PERFORMANCE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PERCENTUAL_REALIZADO_PERFORMANCE = @TAR_PERCENTUAL_REALIZADO_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PERCENTUAL_REALIZADO_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PROXIMA_META_PERFORMANCE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PROXIMA_META_PERFORMANCE = @TAR_PROXIMA_META_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PROXIMA_META_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_META_TEMPO_SETUP(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_META_TEMPO_SETUP = @TAR_META_TEMPO_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_META_TEMPO_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_REALIZADO_TEMPO_SETUP(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_REALIZADO_TEMPO_SETUP = @TAR_REALIZADO_TEMPO_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_REALIZADO_TEMPO_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PROXIMA_META_TEMPO_SETUP(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PROXIMA_META_TEMPO_SETUP = @TAR_PROXIMA_META_TEMPO_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PROXIMA_META_TEMPO_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_META_TEMPO_SETUP_AJUSTE = @TAR_META_TEMPO_SETUP_AJUSTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_META_TEMPO_SETUP_AJUSTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_REALIZADO_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_REALIZADO_TEMPO_SETUP_AJUSTE = @TAR_REALIZADO_TEMPO_SETUP_AJUSTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_REALIZADO_TEMPO_SETUP_AJUSTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = @TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_PERFORMANCE(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET OCO_ID_PERFORMANCE = @OCO_ID_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                OCO_ID_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_OBS_PERFORMANCE(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_OBS_PERFORMANCE = @TAR_OBS_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_OBS_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_SETUP(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET OCO_ID_SETUP = @OCO_ID_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                OCO_ID_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_OBS_SETUP(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_OBS_SETUP = @TAR_OBS_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_OBS_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_SETUPA(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET OCO_ID_SETUPA = @OCO_ID_SETUPA WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                OCO_ID_SETUPA = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_OBS_SETUPA(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_OBS_SETUPA = @TAR_OBS_SETUPA WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_OBS_SETUPA = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_TIPO_FEEDBACK_PERFORMANCE(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_TIPO_FEEDBACK_PERFORMANCE = @TAR_TIPO_FEEDBACK_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_TIPO_FEEDBACK_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_TIPO_FEEDBACK_SETUP(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_TIPO_FEEDBACK_SETUP = @TAR_TIPO_FEEDBACK_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_TIPO_FEEDBACK_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_TIPO_FEEDBACK_SETUP_AJUSTE(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_TIPO_FEEDBACK_SETUP_AJUSTE = @TAR_TIPO_FEEDBACK_SETUP_AJUSTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_TIPO_FEEDBACK_SETUP_AJUSTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_QTD_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_QTD_SETUP_AJUSTE = @TAR_QTD_SETUP_AJUSTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_QTD_SETUP_AJUSTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_QTD(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_QTD = @TAR_QTD WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_QTD = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PERFORMANCE_MAX_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PERFORMANCE_MAX_VERDE = @TAR_PERFORMANCE_MAX_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PERFORMANCE_MAX_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PERFORMANCE_MIN_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PERFORMANCE_MIN_VERDE = @TAR_PERFORMANCE_MIN_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PERFORMANCE_MIN_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUP_MAX_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUP_MAX_VERDE = @TAR_SETUP_MAX_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUP_MAX_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUP_MIN_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUP_MIN_VERDE = @TAR_SETUP_MIN_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUP_MIN_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUPA_MAX_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUPA_MAX_VERDE = @TAR_SETUPA_MAX_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUPA_MAX_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUPA_MIN_VERDE(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUPA_MIN_VERDE = @TAR_SETUPA_MIN_VERDE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUPA_MIN_VERDE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_PERFORMANCE_MIN_AMARELO(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_PERFORMANCE_MIN_AMARELO = @TAR_PERFORMANCE_MIN_AMARELO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_PERFORMANCE_MIN_AMARELO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUP_MAX_AMARELO(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUP_MAX_AMARELO = @TAR_SETUP_MAX_AMARELO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUP_MAX_AMARELO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_SETUPA_MAX_AMARELO(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_SETUPA_MAX_AMARELO = @TAR_SETUPA_MAX_AMARELO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_SETUPA_MAX_AMARELO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_OBS_OP_PARCIAL(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_OBS_OP_PARCIAL = @TAR_OBS_OP_PARCIAL WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_OBS_OP_PARCIAL = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_OCO_ID_OP_PARCIAL(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_OCO_ID_OP_PARCIAL = @TAR_OCO_ID_OP_PARCIAL WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_OCO_ID_OP_PARCIAL = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_COR_PERFORMANCE(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_COR_PERFORMANCE = @TAR_COR_PERFORMANCE WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_COR_PERFORMANCE = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_COR_SETUP_GERAL(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_COR_SETUP_GERAL = @TAR_COR_SETUP_GERAL WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_COR_SETUP_GERAL = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_COR_SETUP(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_COR_SETUP = @TAR_COR_SETUP WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_COR_SETUP = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_COR_SETUPA(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_COR_SETUPA = @TAR_COR_SETUPA WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_COR_SETUPA = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_DIA_TURMA_D(int tar_id, DateTime value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_DIA_TURMA_D = @TAR_DIA_TURMA_D WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_DIA_TURMA_D = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFEE_QTD_PECAS_POR_PULSO(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET FEE_QTD_PECAS_POR_PULSO = @FEE_QTD_PECAS_POR_PULSO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                FEE_QTD_PECAS_POR_PULSO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_QTD_PERDAS(int tar_id, Decimal value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_QTD_PERDAS = @TAR_QTD_PERDAS WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_QTD_PERDAS = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_DATA_INICIAL(int tar_id, DateTime value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_DATA_INICIAL = @TAR_DATA_INICIAL WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_DATA_INICIAL = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_DATA_FINAL(int tar_id, DateTime value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_DATA_FINAL = @TAR_DATA_FINAL WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_DATA_FINAL = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_APROVADO(int tar_id, string value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_APROVADO = @TAR_APROVADO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_APROVADO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTAR_TEMPO_PRODUZINDO(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET TAR_TEMPO_PRODUZINDO = @TAR_TEMPO_PRODUZINDO WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_TEMPO_PRODUZINDO = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET TenantID = @TenantID WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int tar_id, bool value)
        {
            this.Query = $@" UPDATE TargetProduto SET Deleted = @Deleted WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int tar_id, DateTime value)
        {
            this.Query = $@" UPDATE TargetProduto SET Changed = @Changed WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                Changed = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int tar_id, int value)
        {
            this.Query = $@" UPDATE TargetProduto SET UserId = @UserId WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                UserId = value,
                TAR_ID = tar_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTargetProdutoQuery(ITargetProdutoEntity TargetProduto)
        {
            this.Query = $@" DELETE FROM TargetProduto WHERE TAR_ID = @TAR_ID ";
            this.Parameters = new
            {
                TAR_ID = TargetProduto.TAR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration