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
    public interface ITempoSetupOnduladeiraQueryRead 
    {
        public QueryModel TempoSetupOnduladeiraQuery(Command.Read.TempoSetupOnduladeiraReadCommand Command );
        public QueryModel TempoSetupOnduladeiraOND_ID_DEQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TempoSetupOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TempoSetupOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByOND_ID_DEQuery(string value );
        public QueryModel ExistsByOND_ID_PARAQuery(string value );
        public QueryModel ExistsByTEM_RESINA_DEQuery(string value );
        public QueryModel ExistsByTEM_RESINA_PARAQuery(string value );
        public QueryModel ExistsByTEM_TEMPOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByOND_ID_DEQuery(string value );
        public QueryModel FirstByOND_ID_PARAQuery(string value );
        public QueryModel FirstByTEM_RESINA_DEQuery(string value );
        public QueryModel FirstByTEM_RESINA_PARAQuery(string value );
        public QueryModel FirstByTEM_TEMPOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration