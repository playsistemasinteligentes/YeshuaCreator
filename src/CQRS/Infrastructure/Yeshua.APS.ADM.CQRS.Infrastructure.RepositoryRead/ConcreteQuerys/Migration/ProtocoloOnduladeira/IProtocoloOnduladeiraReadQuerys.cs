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
    public interface IProtocoloOnduladeiraQueryRead 
    {
        public QueryModel ProtocoloOnduladeiraQuery(Command.Read.ProtocoloOnduladeiraReadCommand Command );
        public QueryModel ProtocoloOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ProtocoloOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPTO_IDQuery(string value );
        public QueryModel ExistsByPTO_CHAVEQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByPTO_COMANDOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPTO_IDQuery(string value );
        public QueryModel FirstByPTO_CHAVEQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByPTO_COMANDOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration