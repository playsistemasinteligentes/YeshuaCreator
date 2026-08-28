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
    public interface ITipoInspecaoVisualQueryRead 
    {
        public QueryModel TipoInspecaoVisualQuery(Command.Read.TipoInspecaoVisualReadCommand Command );
        public QueryModel TipoInspecaoVisualTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoInspecaoVisualUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTIV_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByTIV_NOMEQuery(string value );
        public QueryModel ExistsByTIV_DESCRICAOQuery(string value );
        public QueryModel ExistsByTIV_FECHAMENTOQuery(string value );
        public QueryModel ExistsByTIV_AMOSTRA_ALEATORIAQuery(string value );
        public QueryModel ExistsByTIV_N_AMOSTRASQuery(int value );
        public QueryModel ExistsByTIV_MEDIDAQuery(string value );
        public QueryModel ExistsByTIV_ESPECIFICACAOQuery(Decimal value );
        public QueryModel ExistsByTIV_TOL_MAISQuery(Decimal value );
        public QueryModel ExistsByTIV_TOL_MENOSQuery(Decimal value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTIV_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByTIV_NOMEQuery(string value );
        public QueryModel FirstByTIV_DESCRICAOQuery(string value );
        public QueryModel FirstByTIV_FECHAMENTOQuery(string value );
        public QueryModel FirstByTIV_AMOSTRA_ALEATORIAQuery(string value );
        public QueryModel FirstByTIV_N_AMOSTRASQuery(int value );
        public QueryModel FirstByTIV_MEDIDAQuery(string value );
        public QueryModel FirstByTIV_ESPECIFICACAOQuery(Decimal value );
        public QueryModel FirstByTIV_TOL_MAISQuery(Decimal value );
        public QueryModel FirstByTIV_TOL_MENOSQuery(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration