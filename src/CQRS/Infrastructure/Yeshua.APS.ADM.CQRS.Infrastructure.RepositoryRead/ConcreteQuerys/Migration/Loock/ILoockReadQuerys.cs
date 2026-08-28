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
    public interface ILoockQueryRead 
    {
        public QueryModel LoockQuery(Command.Read.LoockReadCommand Command );
        public QueryModel LoockTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LoockUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByLOO_IDQuery(string value );
        public QueryModel ExistsByLOO_DESCRICAOQuery(string value );
        public QueryModel ExistsByLOO_CONTEUDOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByLOO_IDQuery(string value );
        public QueryModel FirstByLOO_DESCRICAOQuery(string value );
        public QueryModel FirstByLOO_CONTEUDOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration