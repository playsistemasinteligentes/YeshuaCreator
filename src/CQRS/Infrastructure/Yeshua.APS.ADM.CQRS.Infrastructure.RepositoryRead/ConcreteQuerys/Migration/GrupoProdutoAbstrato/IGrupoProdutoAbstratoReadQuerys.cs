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
    public interface IGrupoProdutoAbstratoQueryRead 
    {
        public QueryModel GrupoProdutoAbstratoQuery(Command.Read.GrupoProdutoAbstratoReadCommand Command );
        public QueryModel GrupoProdutoAbstratoGRP_PAP_ONDAQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoProdutoAbstratoVIN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoProdutoAbstratoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoProdutoAbstratoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGRP_IDQuery(string value );
        public QueryModel ExistsByGRP_DESCRICAOQuery(string value );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByGRP_TIPOQuery(Decimal value );
        public QueryModel ExistsByGRP_PAP_ONDAQuery(string value );
        public QueryModel ExistsByGRP_PAP_GRAMATURAQuery(Decimal value );
        public QueryModel ExistsByGRP_PAP_ALTURAQuery(Decimal value );
        public QueryModel ExistsByGRP_PAP_NOME_COMERCIALQuery(string value );
        public QueryModel ExistsByGRP_ATIVOQuery(string value );
        public QueryModel ExistsByGRP_DT_CRIACAOQuery(DateTime value );
        public QueryModel ExistsByGRP_PAPEL1Query(string value );
        public QueryModel ExistsByGRP_PAPEL2Query(string value );
        public QueryModel ExistsByGRP_PAPEL3Query(string value );
        public QueryModel ExistsByGRP_PAPEL4Query(string value );
        public QueryModel ExistsByGRP_PAPEL5Query(string value );
        public QueryModel ExistsByGRP_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByGRP_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByGRP_TYPEQuery(int value );
        public QueryModel ExistsByGRP_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(Decimal value );
        public QueryModel ExistsByGRP_RESINAQuery(string value );
        public QueryModel ExistsByGRP_ENDURECEDOR_MIOLOQuery(string value );
        public QueryModel ExistsByVIN_IDQuery(int value );
        public QueryModel ExistsByGRP_COLUNA_DEQuery(Decimal value );
        public QueryModel ExistsByGRP_COLUNA_ATEQuery(Decimal value );
        public QueryModel ExistsByGRP_CRUSHQuery(Decimal value );
        public QueryModel ExistsByGRP_ID_FAMILIAQuery(string value );
        public QueryModel ExistsByGRP_REFILE_LARGURAQuery(Decimal value );
        public QueryModel ExistsByGRP_REFILE_COMPRIMENTOQuery(Decimal value );
        public QueryModel ExistsByGRP_TIPO_LAPQuery(string value );
        public QueryModel ExistsByGRP_LAP_PROLONGADOQuery(string value );
        public QueryModel ExistsByGRP_TAMANHO_LAP_OND_SIMPLESQuery(Decimal value );
        public QueryModel ExistsByGRP_TAMANHO_LAP_OND_DUPLAQuery(Decimal value );
        public QueryModel ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(Decimal value );
        public QueryModel ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(Decimal value );
        public QueryModel ExistsByGRP_FEFCOQuery(string value );
        public QueryModel ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(int value );
        public QueryModel ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(int value );
        public QueryModel ExistsByGRP_PREFIXO_ID_PRODUTOQuery(string value );
        public QueryModel ExistsByGRP_COLUNA_CAIXAQuery(Decimal value );
        public QueryModel ExistsByGRP_COLUNA_CHAPAQuery(Decimal value );
        public QueryModel ExistsByGRP_MULLENQuery(Decimal value );
        public QueryModel ExistsByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(int value );
        public QueryModel ExistsByGRP_PERCENTUAL_PERDA_MEDIAQuery(Decimal value );
        public QueryModel ExistsByGRP_FILTRA_SEQ_TRANSQuery(int value );
        public QueryModel ExistsByGRP_IMG_CAIXAQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByGRP_IDQuery(string value );
        public QueryModel FirstByGRP_DESCRICAOQuery(string value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByGRP_TIPOQuery(Decimal value );
        public QueryModel FirstByGRP_PAP_ONDAQuery(string value );
        public QueryModel FirstByGRP_PAP_GRAMATURAQuery(Decimal value );
        public QueryModel FirstByGRP_PAP_ALTURAQuery(Decimal value );
        public QueryModel FirstByGRP_PAP_NOME_COMERCIALQuery(string value );
        public QueryModel FirstByGRP_ATIVOQuery(string value );
        public QueryModel FirstByGRP_DT_CRIACAOQuery(DateTime value );
        public QueryModel FirstByGRP_PAPEL1Query(string value );
        public QueryModel FirstByGRP_PAPEL2Query(string value );
        public QueryModel FirstByGRP_PAPEL3Query(string value );
        public QueryModel FirstByGRP_PAPEL4Query(string value );
        public QueryModel FirstByGRP_PAPEL5Query(string value );
        public QueryModel FirstByGRP_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByGRP_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByGRP_TYPEQuery(int value );
        public QueryModel FirstByGRP_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(Decimal value );
        public QueryModel FirstByGRP_RESINAQuery(string value );
        public QueryModel FirstByGRP_ENDURECEDOR_MIOLOQuery(string value );
        public QueryModel FirstByVIN_IDQuery(int value );
        public QueryModel FirstByGRP_COLUNA_DEQuery(Decimal value );
        public QueryModel FirstByGRP_COLUNA_ATEQuery(Decimal value );
        public QueryModel FirstByGRP_CRUSHQuery(Decimal value );
        public QueryModel FirstByGRP_ID_FAMILIAQuery(string value );
        public QueryModel FirstByGRP_REFILE_LARGURAQuery(Decimal value );
        public QueryModel FirstByGRP_REFILE_COMPRIMENTOQuery(Decimal value );
        public QueryModel FirstByGRP_TIPO_LAPQuery(string value );
        public QueryModel FirstByGRP_LAP_PROLONGADOQuery(string value );
        public QueryModel FirstByGRP_TAMANHO_LAP_OND_SIMPLESQuery(Decimal value );
        public QueryModel FirstByGRP_TAMANHO_LAP_OND_DUPLAQuery(Decimal value );
        public QueryModel FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(Decimal value );
        public QueryModel FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(Decimal value );
        public QueryModel FirstByGRP_FEFCOQuery(string value );
        public QueryModel FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(int value );
        public QueryModel FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(int value );
        public QueryModel FirstByGRP_PREFIXO_ID_PRODUTOQuery(string value );
        public QueryModel FirstByGRP_COLUNA_CAIXAQuery(Decimal value );
        public QueryModel FirstByGRP_COLUNA_CHAPAQuery(Decimal value );
        public QueryModel FirstByGRP_MULLENQuery(Decimal value );
        public QueryModel FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(int value );
        public QueryModel FirstByGRP_PERCENTUAL_PERDA_MEDIAQuery(Decimal value );
        public QueryModel FirstByGRP_FILTRA_SEQ_TRANSQuery(int value );
        public QueryModel FirstByGRP_IMG_CAIXAQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration