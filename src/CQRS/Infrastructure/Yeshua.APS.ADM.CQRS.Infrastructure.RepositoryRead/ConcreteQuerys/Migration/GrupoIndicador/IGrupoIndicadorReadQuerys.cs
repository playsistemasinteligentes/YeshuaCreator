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
    public interface IGrupoIndicadorQueryRead 
    {
        public QueryModel GrupoIndicadorQuery(Command.Read.GrupoIndicadorReadCommand Command );
        public QueryModel GrupoIndicadorGRU_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoIndicadorIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoIndicadorTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoIndicadorUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGRU_IND_IDQuery(int value );
        public QueryModel ExistsByGRU_IDQuery(int value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByGRU_IND_IDQuery(int value );
        public QueryModel FirstByGRU_IDQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration