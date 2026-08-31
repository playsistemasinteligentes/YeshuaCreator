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
    public interface ICTeEntradaOficialQueryRead 
    {
        public QueryModel CTeEntradaOficialQuery(Command.Read.CTeEntradaOficialReadCommand Command );
        public QueryModel CTeEntradaOficialTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeEntradaOficialUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsBySourceApplicationQuery(string value );
        public QueryModel ExistsBySourceModuleQuery(string value );
        public QueryModel ExistsBySourceMessageIdQuery(string value );
        public QueryModel ExistsByMessageTypeQuery(string value );
        public QueryModel ExistsByMessageVersionQuery(string value );
        public QueryModel ExistsByReceivedAtUtcQuery(DateTime value );
        public QueryModel ExistsByPayloadHashQuery(string value );
        public QueryModel ExistsByPayloadStorageKeyQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstBySourceApplicationQuery(string value );
        public QueryModel FirstBySourceModuleQuery(string value );
        public QueryModel FirstBySourceMessageIdQuery(string value );
        public QueryModel FirstByMessageTypeQuery(string value );
        public QueryModel FirstByMessageVersionQuery(string value );
        public QueryModel FirstByReceivedAtUtcQuery(DateTime value );
        public QueryModel FirstByPayloadHashQuery(string value );
        public QueryModel FirstByPayloadStorageKeyQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration