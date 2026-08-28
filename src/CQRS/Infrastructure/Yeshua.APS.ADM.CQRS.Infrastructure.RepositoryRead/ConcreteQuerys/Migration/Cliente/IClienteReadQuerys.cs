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
    public interface IClienteQueryRead 
    {
        public QueryModel ClienteQuery(Command.Read.ClienteReadCommand Command );
        public QueryModel ClienteMUN_ID_ENTREGAQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ClienteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ClienteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByCLI_NOMEQuery(string value );
        public QueryModel ExistsByCLI_FONEQuery(string value );
        public QueryModel ExistsByCLI_OBSQuery(string value );
        public QueryModel ExistsByCLI_ENDERECO_ENTREGAQuery(string value );
        public QueryModel ExistsByCLI_CPF_CNPJQuery(string value );
        public QueryModel ExistsByCLI_BAIRRO_ENTREGAQuery(string value );
        public QueryModel ExistsByCLI_CEP_ENTREGAQuery(string value );
        public QueryModel ExistsByCLI_EMAILQuery(string value );
        public QueryModel ExistsByCLI_INTEGRACAOQuery(string value );
        public QueryModel ExistsByMUN_ID_ENTREGAQuery(string value );
        public QueryModel ExistsByCLI_TRANSLADOQuery(Decimal value );
        public QueryModel ExistsByCLI_REGIAO_ENTREGAQuery(string value );
        public QueryModel ExistsByCLI_EXIGENTE_NA_IMPRESSAOQuery(int value );
        public QueryModel ExistsByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(Decimal value );
        public QueryModel ExistsByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value );
        public QueryModel ExistsByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value );
        public QueryModel ExistsByREP_IDQuery(string value );
        public QueryModel ExistsByCLI_RAZAO_SOCIALQuery(string value );
        public QueryModel ExistsByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(string value );
        public QueryModel ExistsByCLI_CONTATOQuery(string value );
        public QueryModel ExistsByCLI_SETORQuery(string value );
        public QueryModel ExistsBySEG_IDQuery(string value );
        public QueryModel ExistsByCLI_TIPOQuery(string value );
        public QueryModel ExistsByCLI_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByCLI_LATITUDE_ENTREGAQuery(Decimal value );
        public QueryModel ExistsByCLI_LONGITUDE_ENTREGAQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByCLI_NOMEQuery(string value );
        public QueryModel FirstByCLI_FONEQuery(string value );
        public QueryModel FirstByCLI_OBSQuery(string value );
        public QueryModel FirstByCLI_ENDERECO_ENTREGAQuery(string value );
        public QueryModel FirstByCLI_CPF_CNPJQuery(string value );
        public QueryModel FirstByCLI_BAIRRO_ENTREGAQuery(string value );
        public QueryModel FirstByCLI_CEP_ENTREGAQuery(string value );
        public QueryModel FirstByCLI_EMAILQuery(string value );
        public QueryModel FirstByCLI_INTEGRACAOQuery(string value );
        public QueryModel FirstByMUN_ID_ENTREGAQuery(string value );
        public QueryModel FirstByCLI_TRANSLADOQuery(Decimal value );
        public QueryModel FirstByCLI_REGIAO_ENTREGAQuery(string value );
        public QueryModel FirstByCLI_EXIGENTE_NA_IMPRESSAOQuery(int value );
        public QueryModel FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(Decimal value );
        public QueryModel FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value );
        public QueryModel FirstByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value );
        public QueryModel FirstByREP_IDQuery(string value );
        public QueryModel FirstByCLI_RAZAO_SOCIALQuery(string value );
        public QueryModel FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(string value );
        public QueryModel FirstByCLI_CONTATOQuery(string value );
        public QueryModel FirstByCLI_SETORQuery(string value );
        public QueryModel FirstBySEG_IDQuery(string value );
        public QueryModel FirstByCLI_TIPOQuery(string value );
        public QueryModel FirstByCLI_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByCLI_LATITUDE_ENTREGAQuery(Decimal value );
        public QueryModel FirstByCLI_LONGITUDE_ENTREGAQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration