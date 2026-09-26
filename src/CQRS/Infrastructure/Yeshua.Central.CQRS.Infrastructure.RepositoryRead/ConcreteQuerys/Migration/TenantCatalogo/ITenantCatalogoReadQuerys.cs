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
    public interface ITenantCatalogoQueryRead 
    {
        public QueryModel TenantCatalogoQuery(Command.Read.TenantCatalogoReadCommand Command );
        public QueryModel TenantCatalogoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TenantCatalogoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCatalogoQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByValidUntilQuery(DateTime value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCatalogoQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByValidUntilQuery(DateTime value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration