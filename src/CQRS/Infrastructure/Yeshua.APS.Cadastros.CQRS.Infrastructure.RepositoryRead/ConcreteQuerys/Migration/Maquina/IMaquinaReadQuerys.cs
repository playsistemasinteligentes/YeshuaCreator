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
    public interface IMaquinaQueryRead 
    {
        public QueryModel MaquinaQuery(Command.Read.MaquinaReadCommand Command );
        public QueryModel MaquinaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MaquinaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByMAQ_DESCRICAOQuery(string value );
        public QueryModel ExistsByMAQ_STATUSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByMAQ_DESCRICAOQuery(string value );
        public QueryModel FirstByMAQ_STATUSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration