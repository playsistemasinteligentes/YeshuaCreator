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
    public interface IMaquinaQueryRead 
    {
        public QueryModel MaquinaQuery(Command.Read.MaquinaReadCommand Command );
        public QueryModel MaquinaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MaquinaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MaquinaCAL_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(string value );
        public QueryModel ExistsByDescricaoQuery(string value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByCAL_IDQuery(int value );
        public QueryModel ExistsByMAQ_CONTROL_IPQuery(string value );
        public QueryModel ExistsByGMA_IDQuery(string value );
        public QueryModel ExistsByMAQ_ULTIMA_ATUALIZACAOQuery(DateTime value );
        public QueryModel ExistsByMAQ_SIRENE_SEMAFOROQuery(int value );
        public QueryModel ExistsByMAQ_COR_SEMAFOROQuery(string value );
        public QueryModel ExistsByMAQ_ID_MAQ_PAIQuery(string value );
        public QueryModel ExistsByMAQ_TIPO_CONTADORQuery(int value );
        public QueryModel ExistsByMAQ_TIPO_PLANEJAMENTOQuery(string value );
        public QueryModel ExistsByMAQ_AVALIA_CUSTOQuery(int value );
        public QueryModel ExistsByFPR_ID_OP_PRODUZINDOQuery(int value );
        public QueryModel ExistsByMAQ_CONGELA_FILAQuery(int value );
        public QueryModel ExistsByMAQ_TEMPO_MIN_PARADAQuery(int value );
        public QueryModel ExistsByMAQ_QTD_CORESQuery(int value );
        public QueryModel ExistsByMAQ_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByMAQ_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value );
        public QueryModel ExistsByEQU_IDQuery(string value );
        public QueryModel ExistsByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value );
        public QueryModel ExistsByMAQ_ACOMPANHA_LOTE_PILOTOQuery(string value );
        public QueryModel ExistsByMAQ_ID_SENSORQuery(int value );
        public QueryModel ExistsByMAQ_DEBOUNCING_LOWQuery(int value );
        public QueryModel ExistsByMAQ_DEBOUNCING_HIGHTQuery(int value );
        public QueryModel ExistsByMAQ_TIPO_SINALQuery(int value );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LARGURA_CHAPA_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LARGURA_CHAPA_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LARGURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ALTURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ABA_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ABA_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LAP_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_LAP_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ONDASQuery(string value );
        public QueryModel ExistsByMAQ_PROLONGA_LAPQuery(string value );
        public QueryModel ExistsByMAQ_LARGURA_IMPRESSAOQuery(Decimal value );
        public QueryModel ExistsByMAQ_COMPRIMENTO_IMPRESSAOQuery(Decimal value );
        public QueryModel ExistsByMAQ_ROLO_DISPOSITIVO_DEQuery(Decimal value );
        public QueryModel ExistsByMAQ_ROLO_DISPOSITIVO_ATEQuery(Decimal value );
        public QueryModel ExistsByMAQ_FAMILIASQuery(string value );
        public QueryModel ExistsByMAQ_REFILE_MINIMOQuery(Decimal value );
        public QueryModel ExistsByMAQ_LARGURA_UTILQuery(Decimal value );
        public QueryModel ExistsByMAQ_TOTAL_ACOQuery(Decimal value );
        public QueryModel ExistsByMAQ_FECHAMENTOQuery(string value );
        public QueryModel ExistsByMAQ_OPERACAO_VINCARQuery(Decimal value );
        public QueryModel ExistsByMAQ_OPERACAO_MONTA_DIVISAOQuery(Decimal value );
        public QueryModel ExistsByMAQ_OPERACAO_SERRARQuery(Decimal value );
        public QueryModel ExistsByMAQ_TIPO_LAPQuery(string value );
        public QueryModel ExistsByMAQ_INDICE_PARADAS_POR_OPQuery(Decimal value );
        public QueryModel ExistsByMAQ_PERDA_MAXIMAQuery(int value );
        public QueryModel ExistsByMAQ_TOTAL_PECAS_REFILANDOQuery(int value );
        public QueryModel ExistsByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(int value );
        public QueryModel ExistsByMAQ_TOTAL_VINCOSQuery(int value );
        public QueryModel FirstByIdQuery(string value );
        public QueryModel FirstByDescricaoQuery(string value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByCAL_IDQuery(int value );
        public QueryModel FirstByMAQ_CONTROL_IPQuery(string value );
        public QueryModel FirstByGMA_IDQuery(string value );
        public QueryModel FirstByMAQ_ULTIMA_ATUALIZACAOQuery(DateTime value );
        public QueryModel FirstByMAQ_SIRENE_SEMAFOROQuery(int value );
        public QueryModel FirstByMAQ_COR_SEMAFOROQuery(string value );
        public QueryModel FirstByMAQ_ID_MAQ_PAIQuery(string value );
        public QueryModel FirstByMAQ_TIPO_CONTADORQuery(int value );
        public QueryModel FirstByMAQ_TIPO_PLANEJAMENTOQuery(string value );
        public QueryModel FirstByMAQ_AVALIA_CUSTOQuery(int value );
        public QueryModel FirstByFPR_ID_OP_PRODUZINDOQuery(int value );
        public QueryModel FirstByMAQ_CONGELA_FILAQuery(int value );
        public QueryModel FirstByMAQ_TEMPO_MIN_PARADAQuery(int value );
        public QueryModel FirstByMAQ_QTD_CORESQuery(int value );
        public QueryModel FirstByMAQ_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByMAQ_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value );
        public QueryModel FirstByEQU_IDQuery(string value );
        public QueryModel FirstByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value );
        public QueryModel FirstByMAQ_ACOMPANHA_LOTE_PILOTOQuery(string value );
        public QueryModel FirstByMAQ_ID_SENSORQuery(int value );
        public QueryModel FirstByMAQ_DEBOUNCING_LOWQuery(int value );
        public QueryModel FirstByMAQ_DEBOUNCING_HIGHTQuery(int value );
        public QueryModel FirstByMAQ_TIPO_SINALQuery(int value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_LARGURA_CHAPA_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_LARGURA_CHAPA_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_LARGURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_ALTURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_ABA_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_ABA_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_LAP_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_LAP_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_ONDASQuery(string value );
        public QueryModel FirstByMAQ_PROLONGA_LAPQuery(string value );
        public QueryModel FirstByMAQ_LARGURA_IMPRESSAOQuery(Decimal value );
        public QueryModel FirstByMAQ_COMPRIMENTO_IMPRESSAOQuery(Decimal value );
        public QueryModel FirstByMAQ_ROLO_DISPOSITIVO_DEQuery(Decimal value );
        public QueryModel FirstByMAQ_ROLO_DISPOSITIVO_ATEQuery(Decimal value );
        public QueryModel FirstByMAQ_FAMILIASQuery(string value );
        public QueryModel FirstByMAQ_REFILE_MINIMOQuery(Decimal value );
        public QueryModel FirstByMAQ_LARGURA_UTILQuery(Decimal value );
        public QueryModel FirstByMAQ_TOTAL_ACOQuery(Decimal value );
        public QueryModel FirstByMAQ_FECHAMENTOQuery(string value );
        public QueryModel FirstByMAQ_OPERACAO_VINCARQuery(Decimal value );
        public QueryModel FirstByMAQ_OPERACAO_MONTA_DIVISAOQuery(Decimal value );
        public QueryModel FirstByMAQ_OPERACAO_SERRARQuery(Decimal value );
        public QueryModel FirstByMAQ_TIPO_LAPQuery(string value );
        public QueryModel FirstByMAQ_INDICE_PARADAS_POR_OPQuery(Decimal value );
        public QueryModel FirstByMAQ_PERDA_MAXIMAQuery(int value );
        public QueryModel FirstByMAQ_TOTAL_PECAS_REFILANDOQuery(int value );
        public QueryModel FirstByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(int value );
        public QueryModel FirstByMAQ_TOTAL_VINCOSQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration