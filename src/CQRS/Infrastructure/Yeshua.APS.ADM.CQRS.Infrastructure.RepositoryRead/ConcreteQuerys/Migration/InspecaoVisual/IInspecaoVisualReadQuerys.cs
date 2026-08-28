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
    public interface IInspecaoVisualQueryRead 
    {
        public QueryModel InspecaoVisualQuery(Command.Read.InspecaoVisualReadCommand Command );
        public QueryModel InspecaoVisualTURN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel InspecaoVisualTURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel InspecaoVisualTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel InspecaoVisualUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIPV_IDQuery(int value );
        public QueryModel ExistsByIPV_VALORQuery(string value );
        public QueryModel ExistsByIPV_ID_OPERADORQuery(int value );
        public QueryModel ExistsByIPV_ID_LIBERACAOQuery(int value );
        public QueryModel ExistsByIPV_OBSQuery(string value );
        public QueryModel ExistsByIPV_DATA_COLETAQuery(DateTime value );
        public QueryModel ExistsByIPV_DATA_AVALQuery(DateTime value );
        public QueryModel ExistsByTIV_IDQuery(int value );
        public QueryModel ExistsByTURN_IDQuery(string value );
        public QueryModel ExistsByTURM_IDQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByROT_PRO_IDQuery(string value );
        public QueryModel ExistsByROT_MAQ_IDQuery(string value );
        public QueryModel ExistsByROT_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByIPV_STATUS_LIBERACAOQuery(string value );
        public QueryModel ExistsByIPV_VALOR_MEDIDAQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIPV_IDQuery(int value );
        public QueryModel FirstByIPV_VALORQuery(string value );
        public QueryModel FirstByIPV_ID_OPERADORQuery(int value );
        public QueryModel FirstByIPV_ID_LIBERACAOQuery(int value );
        public QueryModel FirstByIPV_OBSQuery(string value );
        public QueryModel FirstByIPV_DATA_COLETAQuery(DateTime value );
        public QueryModel FirstByIPV_DATA_AVALQuery(DateTime value );
        public QueryModel FirstByTIV_IDQuery(int value );
        public QueryModel FirstByTURN_IDQuery(string value );
        public QueryModel FirstByTURM_IDQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByROT_PRO_IDQuery(string value );
        public QueryModel FirstByROT_MAQ_IDQuery(string value );
        public QueryModel FirstByROT_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByIPV_STATUS_LIBERACAOQuery(string value );
        public QueryModel FirstByIPV_VALOR_MEDIDAQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration