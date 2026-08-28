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
    public interface ITargetProdutoQueryRead 
    {
        public QueryModel TargetProdutoQuery(Command.Read.TargetProdutoReadCommand Command );
        public QueryModel TargetProdutoMOV_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoUNI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoTURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoTURN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoOCO_ID_PERFORMANCEQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TargetProdutoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTAR_IDQuery(int value );
        public QueryModel ExistsByMOV_IDQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByUNI_IDQuery(string value );
        public QueryModel ExistsByTURM_IDQuery(string value );
        public QueryModel ExistsByTURN_IDQuery(string value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByTAR_DIA_TURMAQuery(string value );
        public QueryModel ExistsByTAR_META_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByTAR_REALIZADO_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByTAR_PROXIMA_META_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByTAR_META_TEMPO_SETUPQuery(Decimal value );
        public QueryModel ExistsByTAR_REALIZADO_TEMPO_SETUPQuery(Decimal value );
        public QueryModel ExistsByTAR_PROXIMA_META_TEMPO_SETUPQuery(Decimal value );
        public QueryModel ExistsByTAR_META_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel ExistsByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel ExistsByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel ExistsByOCO_ID_PERFORMANCEQuery(string value );
        public QueryModel ExistsByTAR_OBS_PERFORMANCEQuery(string value );
        public QueryModel ExistsByOCO_ID_SETUPQuery(string value );
        public QueryModel ExistsByTAR_OBS_SETUPQuery(string value );
        public QueryModel ExistsByOCO_ID_SETUPAQuery(string value );
        public QueryModel ExistsByTAR_OBS_SETUPAQuery(string value );
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(string value );
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_SETUPQuery(string value );
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(string value );
        public QueryModel ExistsByTAR_QTD_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel ExistsByTAR_QTDQuery(Decimal value );
        public QueryModel ExistsByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(int value );
        public QueryModel ExistsByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(int value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByTAR_PERFORMANCE_MAX_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_PERFORMANCE_MIN_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUP_MAX_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUP_MIN_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUPA_MAX_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUPA_MIN_VERDEQuery(Decimal value );
        public QueryModel ExistsByTAR_PERFORMANCE_MIN_AMARELOQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUP_MAX_AMARELOQuery(Decimal value );
        public QueryModel ExistsByTAR_SETUPA_MAX_AMARELOQuery(Decimal value );
        public QueryModel ExistsByTAR_OBS_OP_PARCIALQuery(string value );
        public QueryModel ExistsByTAR_OCO_ID_OP_PARCIALQuery(string value );
        public QueryModel ExistsByTAR_COR_PERFORMANCEQuery(string value );
        public QueryModel ExistsByTAR_COR_SETUP_GERALQuery(string value );
        public QueryModel ExistsByTAR_COR_SETUPQuery(string value );
        public QueryModel ExistsByTAR_COR_SETUPAQuery(string value );
        public QueryModel ExistsByTAR_DIA_TURMA_DQuery(DateTime value );
        public QueryModel ExistsByFEE_QTD_PECAS_POR_PULSOQuery(Decimal value );
        public QueryModel ExistsByTAR_QTD_PERDASQuery(Decimal value );
        public QueryModel ExistsByTAR_DATA_INICIALQuery(DateTime value );
        public QueryModel ExistsByTAR_DATA_FINALQuery(DateTime value );
        public QueryModel ExistsByTAR_APROVADOQuery(string value );
        public QueryModel ExistsByTAR_TEMPO_PRODUZINDOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByTAR_IDQuery(int value );
        public QueryModel FirstByMOV_IDQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByUNI_IDQuery(string value );
        public QueryModel FirstByTURM_IDQuery(string value );
        public QueryModel FirstByTURN_IDQuery(string value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByTAR_DIA_TURMAQuery(string value );
        public QueryModel FirstByTAR_META_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByTAR_REALIZADO_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByTAR_PROXIMA_META_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByTAR_META_TEMPO_SETUPQuery(Decimal value );
        public QueryModel FirstByTAR_REALIZADO_TEMPO_SETUPQuery(Decimal value );
        public QueryModel FirstByTAR_PROXIMA_META_TEMPO_SETUPQuery(Decimal value );
        public QueryModel FirstByTAR_META_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel FirstByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel FirstByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel FirstByOCO_ID_PERFORMANCEQuery(string value );
        public QueryModel FirstByTAR_OBS_PERFORMANCEQuery(string value );
        public QueryModel FirstByOCO_ID_SETUPQuery(string value );
        public QueryModel FirstByTAR_OBS_SETUPQuery(string value );
        public QueryModel FirstByOCO_ID_SETUPAQuery(string value );
        public QueryModel FirstByTAR_OBS_SETUPAQuery(string value );
        public QueryModel FirstByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(string value );
        public QueryModel FirstByTAR_TIPO_FEEDBACK_SETUPQuery(string value );
        public QueryModel FirstByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(string value );
        public QueryModel FirstByTAR_QTD_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel FirstByTAR_QTDQuery(Decimal value );
        public QueryModel FirstByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(int value );
        public QueryModel FirstByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(int value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByTAR_PERFORMANCE_MAX_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_PERFORMANCE_MIN_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_SETUP_MAX_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_SETUP_MIN_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_SETUPA_MAX_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_SETUPA_MIN_VERDEQuery(Decimal value );
        public QueryModel FirstByTAR_PERFORMANCE_MIN_AMARELOQuery(Decimal value );
        public QueryModel FirstByTAR_SETUP_MAX_AMARELOQuery(Decimal value );
        public QueryModel FirstByTAR_SETUPA_MAX_AMARELOQuery(Decimal value );
        public QueryModel FirstByTAR_OBS_OP_PARCIALQuery(string value );
        public QueryModel FirstByTAR_OCO_ID_OP_PARCIALQuery(string value );
        public QueryModel FirstByTAR_COR_PERFORMANCEQuery(string value );
        public QueryModel FirstByTAR_COR_SETUP_GERALQuery(string value );
        public QueryModel FirstByTAR_COR_SETUPQuery(string value );
        public QueryModel FirstByTAR_COR_SETUPAQuery(string value );
        public QueryModel FirstByTAR_DIA_TURMA_DQuery(DateTime value );
        public QueryModel FirstByFEE_QTD_PECAS_POR_PULSOQuery(Decimal value );
        public QueryModel FirstByTAR_QTD_PERDASQuery(Decimal value );
        public QueryModel FirstByTAR_DATA_INICIALQuery(DateTime value );
        public QueryModel FirstByTAR_DATA_FINALQuery(DateTime value );
        public QueryModel FirstByTAR_APROVADOQuery(string value );
        public QueryModel FirstByTAR_TEMPO_PRODUZINDOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration