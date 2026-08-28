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
    public interface IMaquinaImpressoraQueryRead 
    {
        public QueryModel MaquinaImpressoraQuery(Command.Read.MaquinaImpressoraReadCommand Command );
        public QueryModel MaquinaImpressoraIMP_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MaquinaImpressoraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MaquinaImpressoraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMAQ_IMP_IDQuery(int value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByIMP_IDQuery(int value );
        public QueryModel ExistsByMAI_FACAOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMAQ_IMP_IDQuery(int value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByIMP_IDQuery(int value );
        public QueryModel FirstByMAI_FACAOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration