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
    public interface ITipoTesteQueryRead 
    {
        public QueryModel TipoTesteQuery(Command.Read.TipoTesteReadCommand Command );
        public QueryModel TipoTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoTesteTA_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTT_ESPECIFICACAOQuery(Decimal value );
        public QueryModel ExistsByTT_ORIGEM_ESPECIFICACAOQuery(string value );
        public QueryModel ExistsByTT_IMPRIME_NO_LAUDOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByTT_IDQuery(int value );
        public QueryModel ExistsByTT_NOMEQuery(string value );
        public QueryModel ExistsByTT_DESCQuery(string value );
        public QueryModel ExistsByTT_TOL_MAISQuery(Decimal value );
        public QueryModel ExistsByTT_TOL_MENOSQuery(Decimal value );
        public QueryModel ExistsByTT_NORMAQuery(string value );
        public QueryModel ExistsByTT_INICIO_PROCESSOQuery(string value );
        public QueryModel ExistsByTA_IDQuery(int value );
        public QueryModel ExistsByUNI_IDQuery(string value );
        public QueryModel ExistsByTT_N_AMOSTRAS_P_TESTEQuery(int value );
        public QueryModel ExistsByTT_MAX_DEF_CRITICOQuery(int value );
        public QueryModel ExistsByTT_MAX_DEF_GRAVEQuery(int value );
        public QueryModel FirstByTT_ESPECIFICACAOQuery(Decimal value );
        public QueryModel FirstByTT_ORIGEM_ESPECIFICACAOQuery(string value );
        public QueryModel FirstByTT_IMPRIME_NO_LAUDOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByTT_IDQuery(int value );
        public QueryModel FirstByTT_NOMEQuery(string value );
        public QueryModel FirstByTT_DESCQuery(string value );
        public QueryModel FirstByTT_TOL_MAISQuery(Decimal value );
        public QueryModel FirstByTT_TOL_MENOSQuery(Decimal value );
        public QueryModel FirstByTT_NORMAQuery(string value );
        public QueryModel FirstByTT_INICIO_PROCESSOQuery(string value );
        public QueryModel FirstByTA_IDQuery(int value );
        public QueryModel FirstByUNI_IDQuery(string value );
        public QueryModel FirstByTT_N_AMOSTRAS_P_TESTEQuery(int value );
        public QueryModel FirstByTT_MAX_DEF_CRITICOQuery(int value );
        public QueryModel FirstByTT_MAX_DEF_GRAVEQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration