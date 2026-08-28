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
    public interface IItensOrcamentoQueryRead 
    {
        public QueryModel ItensOrcamentoQuery(Command.Read.ItensOrcamentoReadCommand Command );
        public QueryModel ItensOrcamentoGRP_ID_COMPOSICAOQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensOrcamentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensOrcamentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByITO_IDQuery(int value );
        public QueryModel ExistsByORC_IDQuery(int value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByITO_OBSQuery(string value );
        public QueryModel ExistsByITO_QUANTIDADEQuery(Decimal value );
        public QueryModel ExistsByITO_CUSTOQuery(Decimal value );
        public QueryModel ExistsByITO_MARGEMQuery(Decimal value );
        public QueryModel ExistsByITO_VALOR_UNITARIOQuery(Decimal value );
        public QueryModel ExistsByITO_VERSSAO_CUSTOQuery(DateTime value );
        public QueryModel ExistsByITO_STATUSQuery(string value );
        public QueryModel ExistsByITO_ERP_CUSTOS_FIXOSQuery(Decimal value );
        public QueryModel ExistsByITO_ERP_CUSTOS_VARIAVEISQuery(Decimal value );
        public QueryModel ExistsByITO_ERP_DESPESAS_VAR_VENDAQuery(Decimal value );
        public QueryModel ExistsByITO_ERP_IMPOSTOSQuery(Decimal value );
        public QueryModel ExistsByGRP_ID_COMPOSICAOQuery(string value );
        public QueryModel ExistsByITO_LARGURAQuery(Decimal value );
        public QueryModel ExistsByITO_COMPRIMENTOQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByITO_IDQuery(int value );
        public QueryModel FirstByORC_IDQuery(int value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByITO_OBSQuery(string value );
        public QueryModel FirstByITO_QUANTIDADEQuery(Decimal value );
        public QueryModel FirstByITO_CUSTOQuery(Decimal value );
        public QueryModel FirstByITO_MARGEMQuery(Decimal value );
        public QueryModel FirstByITO_VALOR_UNITARIOQuery(Decimal value );
        public QueryModel FirstByITO_VERSSAO_CUSTOQuery(DateTime value );
        public QueryModel FirstByITO_STATUSQuery(string value );
        public QueryModel FirstByITO_ERP_CUSTOS_FIXOSQuery(Decimal value );
        public QueryModel FirstByITO_ERP_CUSTOS_VARIAVEISQuery(Decimal value );
        public QueryModel FirstByITO_ERP_DESPESAS_VAR_VENDAQuery(Decimal value );
        public QueryModel FirstByITO_ERP_IMPOSTOSQuery(Decimal value );
        public QueryModel FirstByGRP_ID_COMPOSICAOQuery(string value );
        public QueryModel FirstByITO_LARGURAQuery(Decimal value );
        public QueryModel FirstByITO_COMPRIMENTOQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration