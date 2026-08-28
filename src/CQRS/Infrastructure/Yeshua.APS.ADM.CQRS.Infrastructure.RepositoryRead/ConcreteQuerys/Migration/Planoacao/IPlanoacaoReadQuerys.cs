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
    public interface IPlanoacaoQueryRead 
    {
        public QueryModel PlanoacaoQuery(Command.Read.PlanoacaoReadCommand Command );
        public QueryModel PlanoacaoMET_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlanoacaoUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlanoacaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlanoacaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPLA_IDQuery(int value );
        public QueryModel ExistsByPLA_DESCRICAOQuery(string value );
        public QueryModel ExistsByMET_IDQuery(int value );
        public QueryModel ExistsByPLA_STATUSQuery(string value );
        public QueryModel ExistsByPLA_DATAQuery(DateTime value );
        public QueryModel ExistsByPLA_METAPERIODOQuery(string value );
        public QueryModel ExistsByPLA_VLRPERIODOQuery(string value );
        public QueryModel ExistsByPLA_METACULADOQuery(string value );
        public QueryModel ExistsByPLA_VLRACUMULADOQuery(string value );
        public QueryModel ExistsByPLA_REFERENCIAQuery(string value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPLA_IDQuery(int value );
        public QueryModel FirstByPLA_DESCRICAOQuery(string value );
        public QueryModel FirstByMET_IDQuery(int value );
        public QueryModel FirstByPLA_STATUSQuery(string value );
        public QueryModel FirstByPLA_DATAQuery(DateTime value );
        public QueryModel FirstByPLA_METAPERIODOQuery(string value );
        public QueryModel FirstByPLA_VLRPERIODOQuery(string value );
        public QueryModel FirstByPLA_METACULADOQuery(string value );
        public QueryModel FirstByPLA_VLRACUMULADOQuery(string value );
        public QueryModel FirstByPLA_REFERENCIAQuery(string value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration