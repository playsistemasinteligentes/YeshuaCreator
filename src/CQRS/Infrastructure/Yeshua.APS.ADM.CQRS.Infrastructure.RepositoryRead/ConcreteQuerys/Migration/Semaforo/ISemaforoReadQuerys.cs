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
    public interface ISemaforoQueryRead 
    {
        public QueryModel SemaforoQuery(Command.Read.SemaforoReadCommand Command );
        public QueryModel SemaforoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SemaforoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsBySEM_IDQuery(string value );
        public QueryModel ExistsBySEM_STATUSQuery(string value );
        public QueryModel ExistsBySEM_ORIGEMQuery(string value );
        public QueryModel ExistsBySEM_EMISSAOQuery(DateTime value );
        public QueryModel ExistsBySEM_ID_CONEXAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstBySEM_IDQuery(string value );
        public QueryModel FirstBySEM_STATUSQuery(string value );
        public QueryModel FirstBySEM_ORIGEMQuery(string value );
        public QueryModel FirstBySEM_EMISSAOQuery(DateTime value );
        public QueryModel FirstBySEM_ID_CONEXAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration