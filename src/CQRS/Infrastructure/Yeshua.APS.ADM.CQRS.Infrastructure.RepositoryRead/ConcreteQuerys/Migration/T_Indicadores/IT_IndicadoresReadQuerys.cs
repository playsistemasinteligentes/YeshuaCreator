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
    public interface IT_IndicadoresQueryRead 
    {
        public QueryModel T_IndicadoresQuery(Command.Read.T_IndicadoresReadCommand Command );
        public QueryModel T_IndicadoresNEG_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_IndicadoresTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_IndicadoresUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByIND_DESCRICAOQuery(string value );
        public QueryModel ExistsByNEG_IDQuery(int value );
        public QueryModel ExistsByDESC_CALCULOQuery(string value );
        public QueryModel ExistsByIND_TIPOCOMPARADORQuery(int value );
        public QueryModel ExistsByIND_GRAFICOQuery(int value );
        public QueryModel ExistsByIND_CONEXAOQuery(string value );
        public QueryModel ExistsByIND_DTCRIACAOQuery(DateTime value );
        public QueryModel ExistsByRESPOSAVELINDQuery(string value );
        public QueryModel ExistsByRESPOSAVELCARGAQuery(string value );
        public QueryModel ExistsByPROCEXTRACAOQuery(string value );
        public QueryModel ExistsByPER_IDQuery(string value );
        public QueryModel ExistsByDIM_IDQuery(string value );
        public QueryModel ExistsByDOM_EMPRESAQuery(string value );
        public QueryModel ExistsByDOM_FILIALQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByIND_DESCRICAOQuery(string value );
        public QueryModel FirstByNEG_IDQuery(int value );
        public QueryModel FirstByDESC_CALCULOQuery(string value );
        public QueryModel FirstByIND_TIPOCOMPARADORQuery(int value );
        public QueryModel FirstByIND_GRAFICOQuery(int value );
        public QueryModel FirstByIND_CONEXAOQuery(string value );
        public QueryModel FirstByIND_DTCRIACAOQuery(DateTime value );
        public QueryModel FirstByRESPOSAVELINDQuery(string value );
        public QueryModel FirstByRESPOSAVELCARGAQuery(string value );
        public QueryModel FirstByPROCEXTRACAOQuery(string value );
        public QueryModel FirstByPER_IDQuery(string value );
        public QueryModel FirstByDIM_IDQuery(string value );
        public QueryModel FirstByDOM_EMPRESAQuery(string value );
        public QueryModel FirstByDOM_FILIALQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration