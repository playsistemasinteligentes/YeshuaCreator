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
    public interface IEstruturaImpressaoQueryRead 
    {
        public QueryModel EstruturaImpressaoQuery(Command.Read.EstruturaImpressaoReadCommand Command );
        public QueryModel EstruturaImpressaoCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstruturaImpressaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstruturaImpressaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByEST_IDQuery(int value );
        public QueryModel ExistsByHTML_ESTRUTURAQuery(string value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByEST_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByEST_IDQuery(int value );
        public QueryModel FirstByHTML_ESTRUTURAQuery(string value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByEST_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration