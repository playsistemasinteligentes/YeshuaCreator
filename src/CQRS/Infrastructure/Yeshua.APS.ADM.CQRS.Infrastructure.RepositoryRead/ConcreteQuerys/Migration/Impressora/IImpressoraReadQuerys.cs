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
    public interface IImpressoraQueryRead 
    {
        public QueryModel ImpressoraQuery(Command.Read.ImpressoraReadCommand Command );
        public QueryModel ImpressoraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ImpressoraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIMP_IDQuery(int value );
        public QueryModel ExistsByIMP_IPQuery(string value );
        public QueryModel ExistsByIMP_NOMEQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIMP_IDQuery(int value );
        public QueryModel FirstByIMP_IPQuery(string value );
        public QueryModel FirstByIMP_NOMEQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration