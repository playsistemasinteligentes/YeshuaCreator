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
    public interface IUniuserQueryRead 
    {
        public QueryModel UniuserQuery(Command.Read.UniuserReadCommand Command );
        public QueryModel UniuserUNI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UniuserUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UniuserTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UniuserUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByUSERGRU_IDQuery(int value );
        public QueryModel ExistsByUNI_IDQuery(int value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByUSERGRU_IDQuery(int value );
        public QueryModel FirstByUNI_IDQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration