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
    public interface ICabvisaoQueryRead 
    {
        public QueryModel CabvisaoQuery(Command.Read.CabvisaoReadCommand Command );
        public QueryModel CabvisaoUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CabvisaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CabvisaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByCAB_IDQuery(int value );
        public QueryModel ExistsByCAB_DESCQuery(string value );
        public QueryModel ExistsByCAB_STATUSQuery(int value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByCAB_IDQuery(int value );
        public QueryModel FirstByCAB_DESCQuery(string value );
        public QueryModel FirstByCAB_STATUSQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration