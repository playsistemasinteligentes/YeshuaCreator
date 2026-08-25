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
    public interface ITemplateDeTestesQueryRead 
    {
        public QueryModel TemplateDeTestesQuery(Command.Read.TemplateDeTestesReadCommand Command );
        public QueryModel TemplateDeTestesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TemplateDeTestesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByTEM_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByTEM_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration