// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IFilaProducaoPrevistaQueryRead 
    {
        public QueryModel FilaProducaoPrevistaQuery(Command.Read.FilaProducaoPrevistaReadCommand Command );
        public QueryModel FilaProducaoPrevistaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FilaProducaoPrevistaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByROT_PRO_IDQuery(string value );
        public QueryModel ExistsByFPR_QUANTIDADE_PREVISTAQuery(Decimal value );
        public QueryModel ExistsByROT_MAQ_IDQuery(string value );
        public QueryModel ExistsByFPR_DATA_INICIO_PREVISTAQuery(DateTime value );
        public QueryModel ExistsByFPR_DATA_FIM_PREVISTAQuery(DateTime value );
        public QueryModel ExistsByFPR_DATA_FIM_MAXIMAQuery(DateTime value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByFPR_OBS_PRODUCAOQuery(string value );
        public QueryModel ExistsByFPR_STATUSQuery(string value );
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_SETUPQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_SETUPAQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(Decimal value );
        public QueryModel ExistsByFPR_QTD_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByFPR_QTD_SETUPQuery(Decimal value );
        public QueryModel ExistsByFPR_QTD_PRODUZIDAQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_TEORICO_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_RESTANTE_PERFORMANCQuery(Decimal value );
        public QueryModel ExistsByFPR_VELOCIDADE_P_ATINGIR_METAQuery(Decimal value );
        public QueryModel ExistsByFPR_QTD_RESTANTEQuery(Decimal value );
        public QueryModel ExistsByFPR_VELO_ATU_PC_SEGUNDOQuery(Decimal value );
        public QueryModel ExistsByFPR_PERFORMANCE_PROJETADAQuery(Decimal value );
        public QueryModel ExistsByFPR_TEMPO_RESTANTE_TOTALQuery(Decimal value );
        public QueryModel ExistsByFPR_FIM_PREVISTO_ATUALQuery(DateTime value );
        public QueryModel ExistsByFPR_PRODUZINDOQuery(int value );
        public QueryModel ExistsByFPR_ORDEM_NA_FILAQuery(Decimal value );
        public QueryModel ExistsByFPR_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByFPR_TRUNCADOQuery(string value );
        public QueryModel ExistsByFPR_DATA_TRUNC_INIQuery(DateTime value );
        public QueryModel ExistsByFPR_DATA_TRUNC_FIMQuery(DateTime value );
        public QueryModel ExistsByFPR_IDQuery(int value );
        public QueryModel ExistsByFPR_COR_FILAQuery(string value );
        public QueryModel ExistsByMAQ_ID_MANUALQuery(string value );
        public QueryModel ExistsByMAQ_ID_RESTRINGIDAQuery(string value );
        public QueryModel ExistsByFPR_PREVISAO_MATERIA_PRIMAQuery(DateTime value );
        public QueryModel ExistsByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(DateTime value );
        public QueryModel ExistsByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(DateTime value );
        public QueryModel ExistsByFPR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel ExistsByFPR_INICIO_GRUPO_PRODUTIVOQuery(DateTime value );
        public QueryModel ExistsByFPR_FIM_GRUPO_PRODUTIVOQuery(DateTime value );
        public QueryModel ExistsByFPR_COR_BICO1Query(string value );
        public QueryModel ExistsByFPR_COR_BICO2Query(string value );
        public QueryModel ExistsByFPR_COR_BICO3Query(string value );
        public QueryModel ExistsByFPR_COR_BICO4Query(string value );
        public QueryModel ExistsByFPR_COR_BICO5Query(string value );
        public QueryModel ExistsByFPR_META_SETUPQuery(Decimal value );
        public QueryModel ExistsByFPR_ORD_ID_REPROGRAMADOQuery(string value );
        public QueryModel ExistsByFPR_PRIORIDADEQuery(int value );
        public QueryModel ExistsByFPR_SEQ_INCLUSAO_FILAQuery(int value );
        public QueryModel ExistsByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel ExistsByFPR_ID_ORIGEMQuery(int value );
        public QueryModel ExistsByFPR_DATA_ENTREGAQuery(DateTime value );
        public QueryModel ExistsByEQU_IDQuery(string value );
        public QueryModel ExistsByFPR_GRUPO_PRODUTIVO_MANUALQuery(Decimal value );
        public QueryModel ExistsByFPR_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByFPR_MOTIVO_PULA_FILAQuery(string value );
        public QueryModel ExistsByOCO_IDQuery(string value );
        public QueryModel ExistsByFPR_PESO_UNITARIOQuery(string value );
        public QueryModel ExistsByFPR_M2_UNITARIOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByROT_PRO_IDQuery(string value );
        public QueryModel FirstByFPR_QUANTIDADE_PREVISTAQuery(Decimal value );
        public QueryModel FirstByROT_MAQ_IDQuery(string value );
        public QueryModel FirstByFPR_DATA_INICIO_PREVISTAQuery(DateTime value );
        public QueryModel FirstByFPR_DATA_FIM_PREVISTAQuery(DateTime value );
        public QueryModel FirstByFPR_DATA_FIM_MAXIMAQuery(DateTime value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByFPR_OBS_PRODUCAOQuery(string value );
        public QueryModel FirstByFPR_STATUSQuery(string value );
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_SETUPQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_SETUPAQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(Decimal value );
        public QueryModel FirstByFPR_QTD_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByFPR_QTD_SETUPQuery(Decimal value );
        public QueryModel FirstByFPR_QTD_PRODUZIDAQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_TEORICO_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_RESTANTE_PERFORMANCQuery(Decimal value );
        public QueryModel FirstByFPR_VELOCIDADE_P_ATINGIR_METAQuery(Decimal value );
        public QueryModel FirstByFPR_QTD_RESTANTEQuery(Decimal value );
        public QueryModel FirstByFPR_VELO_ATU_PC_SEGUNDOQuery(Decimal value );
        public QueryModel FirstByFPR_PERFORMANCE_PROJETADAQuery(Decimal value );
        public QueryModel FirstByFPR_TEMPO_RESTANTE_TOTALQuery(Decimal value );
        public QueryModel FirstByFPR_FIM_PREVISTO_ATUALQuery(DateTime value );
        public QueryModel FirstByFPR_PRODUZINDOQuery(int value );
        public QueryModel FirstByFPR_ORDEM_NA_FILAQuery(Decimal value );
        public QueryModel FirstByFPR_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByFPR_TRUNCADOQuery(string value );
        public QueryModel FirstByFPR_DATA_TRUNC_INIQuery(DateTime value );
        public QueryModel FirstByFPR_DATA_TRUNC_FIMQuery(DateTime value );
        public QueryModel FirstByFPR_IDQuery(int value );
        public QueryModel FirstByFPR_COR_FILAQuery(string value );
        public QueryModel FirstByMAQ_ID_MANUALQuery(string value );
        public QueryModel FirstByMAQ_ID_RESTRINGIDAQuery(string value );
        public QueryModel FirstByFPR_PREVISAO_MATERIA_PRIMAQuery(DateTime value );
        public QueryModel FirstByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(DateTime value );
        public QueryModel FirstByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(DateTime value );
        public QueryModel FirstByFPR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel FirstByFPR_INICIO_GRUPO_PRODUTIVOQuery(DateTime value );
        public QueryModel FirstByFPR_FIM_GRUPO_PRODUTIVOQuery(DateTime value );
        public QueryModel FirstByFPR_COR_BICO1Query(string value );
        public QueryModel FirstByFPR_COR_BICO2Query(string value );
        public QueryModel FirstByFPR_COR_BICO3Query(string value );
        public QueryModel FirstByFPR_COR_BICO4Query(string value );
        public QueryModel FirstByFPR_COR_BICO5Query(string value );
        public QueryModel FirstByFPR_META_SETUPQuery(Decimal value );
        public QueryModel FirstByFPR_ORD_ID_REPROGRAMADOQuery(string value );
        public QueryModel FirstByFPR_PRIORIDADEQuery(int value );
        public QueryModel FirstByFPR_SEQ_INCLUSAO_FILAQuery(int value );
        public QueryModel FirstByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel FirstByFPR_ID_ORIGEMQuery(int value );
        public QueryModel FirstByFPR_DATA_ENTREGAQuery(DateTime value );
        public QueryModel FirstByEQU_IDQuery(string value );
        public QueryModel FirstByFPR_GRUPO_PRODUTIVO_MANUALQuery(Decimal value );
        public QueryModel FirstByFPR_EMISSAOQuery(DateTime value );
        public QueryModel FirstByFPR_MOTIVO_PULA_FILAQuery(string value );
        public QueryModel FirstByOCO_IDQuery(string value );
        public QueryModel FirstByFPR_PESO_UNITARIOQuery(string value );
        public QueryModel FirstByFPR_M2_UNITARIOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration