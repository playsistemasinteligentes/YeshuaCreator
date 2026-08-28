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
    public interface IUnidadeQueryRead 
    {
        public QueryModel UnidadeQuery(Command.Read.UnidadeReadCommand Command );
        public QueryModel UnidadeTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UnidadeUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByUNI_IDQuery(int value );
        public QueryModel ExistsByDEESCRICAOQuery(string value );
        public QueryModel ExistsByUNQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByUNI_IDQuery(int value );
        public QueryModel FirstByDEESCRICAOQuery(string value );
        public QueryModel FirstByUNQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration