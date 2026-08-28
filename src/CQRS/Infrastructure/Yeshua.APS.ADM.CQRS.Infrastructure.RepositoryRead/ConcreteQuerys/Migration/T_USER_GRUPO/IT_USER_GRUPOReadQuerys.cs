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
    public interface IT_USER_GRUPOQueryRead 
    {
        public QueryModel T_USER_GRUPOQuery(Command.Read.T_USER_GRUPOReadCommand Command );
        public QueryModel T_USER_GRUPOGRU_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_USER_GRUPOID_USUARIOQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_USER_GRUPOTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_USER_GRUPOUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByGRU_IDQuery(int value );
        public QueryModel ExistsByID_USUARIOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByGRU_IDQuery(int value );
        public QueryModel FirstByID_USUARIOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration