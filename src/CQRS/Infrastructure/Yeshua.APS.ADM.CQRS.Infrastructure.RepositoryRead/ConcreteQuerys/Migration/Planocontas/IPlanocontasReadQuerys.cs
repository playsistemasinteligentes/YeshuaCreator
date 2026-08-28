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
    public interface IPlanocontasQueryRead 
    {
        public QueryModel PlanocontasQuery(Command.Read.PlanocontasReadCommand Command );
        public QueryModel PlanocontasTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlanocontasUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPLA_IDQuery(int value );
        public QueryModel ExistsByPLA_CODIGOQuery(string value );
        public QueryModel ExistsByPLA_DESCRICAOQuery(string value );
        public QueryModel ExistsByPLA_TIPOQuery(int value );
        public QueryModel ExistsByPLA_NATUREZAQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPLA_IDQuery(int value );
        public QueryModel FirstByPLA_CODIGOQuery(string value );
        public QueryModel FirstByPLA_DESCRICAOQuery(string value );
        public QueryModel FirstByPLA_TIPOQuery(int value );
        public QueryModel FirstByPLA_NATUREZAQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration