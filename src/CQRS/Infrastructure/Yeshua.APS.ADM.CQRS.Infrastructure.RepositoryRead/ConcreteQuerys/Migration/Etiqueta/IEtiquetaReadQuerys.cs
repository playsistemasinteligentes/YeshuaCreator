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
    public interface IEtiquetaQueryRead 
    {
        public QueryModel EtiquetaQuery(Command.Read.EtiquetaReadCommand Command );
        public QueryModel EtiquetaUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EtiquetaORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EtiquetaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EtiquetaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByETI_IDQuery(int value );
        public QueryModel ExistsByETI_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByETI_CODIGO_BARRASQuery(string value );
        public QueryModel ExistsByETI_SEQUENCIAQuery(int value );
        public QueryModel ExistsByETI_NUMERO_COPIASQuery(int value );
        public QueryModel ExistsByETI_STATUSQuery(string value );
        public QueryModel ExistsByETI_DATA_FABRICACAOQuery(DateTime value );
        public QueryModel ExistsByETI_COD_BARRAS_ORIGINALQuery(string value );
        public QueryModel ExistsByETI_OP_ORIGINALQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByIMP_IDQuery(int value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByROT_PRO_IDQuery(string value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByETI_QUANTIDADE_PALETEQuery(Decimal value );
        public QueryModel ExistsByETI_LOTEQuery(string value );
        public QueryModel ExistsByETI_SUB_LOTEQuery(string value );
        public QueryModel ExistsByETI_IMPRIMIR_DEQuery(int value );
        public QueryModel ExistsByETI_IMPRIMIR_ATEQuery(int value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByETI_IDQuery(int value );
        public QueryModel FirstByETI_EMISSAOQuery(DateTime value );
        public QueryModel FirstByETI_CODIGO_BARRASQuery(string value );
        public QueryModel FirstByETI_SEQUENCIAQuery(int value );
        public QueryModel FirstByETI_NUMERO_COPIASQuery(int value );
        public QueryModel FirstByETI_STATUSQuery(string value );
        public QueryModel FirstByETI_DATA_FABRICACAOQuery(DateTime value );
        public QueryModel FirstByETI_COD_BARRAS_ORIGINALQuery(string value );
        public QueryModel FirstByETI_OP_ORIGINALQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByIMP_IDQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByROT_PRO_IDQuery(string value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByETI_QUANTIDADE_PALETEQuery(Decimal value );
        public QueryModel FirstByETI_LOTEQuery(string value );
        public QueryModel FirstByETI_SUB_LOTEQuery(string value );
        public QueryModel FirstByETI_IMPRIMIR_DEQuery(int value );
        public QueryModel FirstByETI_IMPRIMIR_ATEQuery(int value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration