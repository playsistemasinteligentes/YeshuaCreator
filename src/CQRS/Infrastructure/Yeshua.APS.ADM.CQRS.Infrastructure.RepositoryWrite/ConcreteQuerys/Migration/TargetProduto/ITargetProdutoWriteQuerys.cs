// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface ITargetProdutoQueryWrite 
     {
        public QueryModel InserirTargetProdutoQuery(ITargetProdutoEntity TargetProduto);
        public QueryModel UpdateTargetProdutoQuery(ITargetProdutoEntity TargetProduto);
        QueryModel UpdateMOV_ID(int tar_id, int value);
        QueryModel UpdateORD_ID(int tar_id, string value);
        QueryModel UpdatePRO_ID(int tar_id, string value);
        QueryModel UpdateMAQ_ID(int tar_id, string value);
        QueryModel UpdateUNI_ID(int tar_id, string value);
        QueryModel UpdateTURM_ID(int tar_id, string value);
        QueryModel UpdateTURN_ID(int tar_id, string value);
        QueryModel UpdateUSE_ID(int tar_id, int value);
        QueryModel UpdateTAR_DIA_TURMA(int tar_id, string value);
        QueryModel UpdateTAR_META_PERFORMANCE(int tar_id, Decimal value);
        QueryModel UpdateTAR_REALIZADO_PERFORMANCE(int tar_id, Decimal value);
        QueryModel UpdateTAR_PERCENTUAL_REALIZADO_PERFORMANCE(int tar_id, Decimal value);
        QueryModel UpdateTAR_PROXIMA_META_PERFORMANCE(int tar_id, Decimal value);
        QueryModel UpdateTAR_META_TEMPO_SETUP(int tar_id, Decimal value);
        QueryModel UpdateTAR_REALIZADO_TEMPO_SETUP(int tar_id, Decimal value);
        QueryModel UpdateTAR_PROXIMA_META_TEMPO_SETUP(int tar_id, Decimal value);
        QueryModel UpdateTAR_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        QueryModel UpdateTAR_REALIZADO_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        QueryModel UpdateTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        QueryModel UpdateOCO_ID_PERFORMANCE(int tar_id, string value);
        QueryModel UpdateTAR_OBS_PERFORMANCE(int tar_id, string value);
        QueryModel UpdateOCO_ID_SETUP(int tar_id, string value);
        QueryModel UpdateTAR_OBS_SETUP(int tar_id, string value);
        QueryModel UpdateOCO_ID_SETUPA(int tar_id, string value);
        QueryModel UpdateTAR_OBS_SETUPA(int tar_id, string value);
        QueryModel UpdateTAR_TIPO_FEEDBACK_PERFORMANCE(int tar_id, string value);
        QueryModel UpdateTAR_TIPO_FEEDBACK_SETUP(int tar_id, string value);
        QueryModel UpdateTAR_TIPO_FEEDBACK_SETUP_AJUSTE(int tar_id, string value);
        QueryModel UpdateTAR_QTD_SETUP_AJUSTE(int tar_id, Decimal value);
        QueryModel UpdateTAR_QTD(int tar_id, Decimal value);
        QueryModel UpdateTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int tar_id, int value);
        QueryModel UpdateTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int tar_id, int value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int tar_id, int value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int tar_id, int value);
        QueryModel UpdateTAR_PERFORMANCE_MAX_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_PERFORMANCE_MIN_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUP_MAX_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUP_MIN_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUPA_MAX_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUPA_MIN_VERDE(int tar_id, Decimal value);
        QueryModel UpdateTAR_PERFORMANCE_MIN_AMARELO(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUP_MAX_AMARELO(int tar_id, Decimal value);
        QueryModel UpdateTAR_SETUPA_MAX_AMARELO(int tar_id, Decimal value);
        QueryModel UpdateTAR_OBS_OP_PARCIAL(int tar_id, string value);
        QueryModel UpdateTAR_OCO_ID_OP_PARCIAL(int tar_id, string value);
        QueryModel UpdateTAR_COR_PERFORMANCE(int tar_id, string value);
        QueryModel UpdateTAR_COR_SETUP_GERAL(int tar_id, string value);
        QueryModel UpdateTAR_COR_SETUP(int tar_id, string value);
        QueryModel UpdateTAR_COR_SETUPA(int tar_id, string value);
        QueryModel UpdateTAR_DIA_TURMA_D(int tar_id, DateTime value);
        QueryModel UpdateFEE_QTD_PECAS_POR_PULSO(int tar_id, Decimal value);
        QueryModel UpdateTAR_QTD_PERDAS(int tar_id, Decimal value);
        QueryModel UpdateTAR_DATA_INICIAL(int tar_id, DateTime value);
        QueryModel UpdateTAR_DATA_FINAL(int tar_id, DateTime value);
        QueryModel UpdateTAR_APROVADO(int tar_id, string value);
        QueryModel UpdateTAR_TEMPO_PRODUZINDO(int tar_id, int value);
        QueryModel UpdateTenantID(int tar_id, int value);
        QueryModel UpdateDeleted(int tar_id, bool value);
        QueryModel UpdateChanged(int tar_id, DateTime value);
        QueryModel UpdateUserId(int tar_id, int value);
        public QueryModel DeleteTargetProdutoQuery(ITargetProdutoEntity TargetProduto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration