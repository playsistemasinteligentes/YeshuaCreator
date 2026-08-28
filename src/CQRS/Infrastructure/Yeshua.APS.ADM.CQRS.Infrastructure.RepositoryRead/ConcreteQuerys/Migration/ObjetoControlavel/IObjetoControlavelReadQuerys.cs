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
    public interface IObjetoControlavelQueryRead 
    {
        public QueryModel ObjetoControlavelQuery(Command.Read.ObjetoControlavelReadCommand Command );
        public QueryModel ObjetoControlavelTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ObjetoControlavelUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByOBJ_IDQuery(string value );
        public QueryModel ExistsByOBJ_DESCRICAOQuery(string value );
        public QueryModel ExistsByOBJ_TIPOQuery(string value );
        public QueryModel ExistsByOBJ_GRUPOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByOBJ_IDQuery(string value );
        public QueryModel FirstByOBJ_DESCRICAOQuery(string value );
        public QueryModel FirstByOBJ_TIPOQuery(string value );
        public QueryModel FirstByOBJ_GRUPOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration