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
    public interface IT_MetasQueryRead 
    {
        public QueryModel T_MetasQuery(Command.Read.T_MetasReadCommand Command );
        public QueryModel T_MetasIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_MetasTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_MetasUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMET_IDQuery(int value );
        public QueryModel ExistsByMET_DTINICIOQuery(string value );
        public QueryModel ExistsByMET_DTFIMQuery(string value );
        public QueryModel ExistsByMET_ALVOQuery(string value );
        public QueryModel ExistsByMET_TIPOALVOQuery(int value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByMET_RANGE01Query(Decimal value );
        public QueryModel ExistsByMET_RANGE02Query(Decimal value );
        public QueryModel ExistsByMET_RANGE03Query(Decimal value );
        public QueryModel ExistsByDIM_IDQuery(int value );
        public QueryModel ExistsByFAT_IDQuery(string value );
        public QueryModel ExistsByDIM_SUBDIMENSAO_IDQuery(string value );
        public QueryModel ExistsByPER_IDQuery(string value );
        public QueryModel ExistsByDOM_EMPRESAQuery(string value );
        public QueryModel ExistsByDOM_FILIALQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMET_IDQuery(int value );
        public QueryModel FirstByMET_DTINICIOQuery(string value );
        public QueryModel FirstByMET_DTFIMQuery(string value );
        public QueryModel FirstByMET_ALVOQuery(string value );
        public QueryModel FirstByMET_TIPOALVOQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByMET_RANGE01Query(Decimal value );
        public QueryModel FirstByMET_RANGE02Query(Decimal value );
        public QueryModel FirstByMET_RANGE03Query(Decimal value );
        public QueryModel FirstByDIM_IDQuery(int value );
        public QueryModel FirstByFAT_IDQuery(string value );
        public QueryModel FirstByDIM_SUBDIMENSAO_IDQuery(string value );
        public QueryModel FirstByPER_IDQuery(string value );
        public QueryModel FirstByDOM_EMPRESAQuery(string value );
        public QueryModel FirstByDOM_FILIALQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration