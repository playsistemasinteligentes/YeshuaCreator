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
    public interface IRegistrosOnduladeiraQueryRead 
    {
        public QueryModel RegistrosOnduladeiraQuery(Command.Read.RegistrosOnduladeiraReadCommand Command );
        public QueryModel RegistrosOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RegistrosOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByREG_IDQuery(int value );
        public QueryModel ExistsByREG_RESPOSTAQuery(string value );
        public QueryModel ExistsByREG_STATUSQuery(string value );
        public QueryModel ExistsByREG_DATA_INICIOQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByREG_IDQuery(int value );
        public QueryModel FirstByREG_RESPOSTAQuery(string value );
        public QueryModel FirstByREG_STATUSQuery(string value );
        public QueryModel FirstByREG_DATA_INICIOQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration