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
    public interface ITemplateTipoTesteQueryRead 
    {
        public QueryModel TemplateTipoTesteQuery(Command.Read.TemplateTipoTesteReadCommand Command );
        public QueryModel TemplateTipoTesteTT_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TemplateTipoTesteTEM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TemplateTipoTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TemplateTipoTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTTT_IDQuery(int value );
        public QueryModel ExistsByTT_IDQuery(int value );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByTTT_IDQuery(int value );
        public QueryModel FirstByTT_IDQuery(int value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration