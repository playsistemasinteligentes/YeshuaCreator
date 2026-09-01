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
    public interface IyTenantModuleQueryRead 
    {
        public QueryModel yTenantModuleQuery(Command.Read.yTenantModuleReadCommand Command );
        public QueryModel yTenantModuleModuleIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yTenantModuleTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yTenantModuleUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByModuleIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByValidUntilQuery(DateTime value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByModuleIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByValidUntilQuery(DateTime value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration