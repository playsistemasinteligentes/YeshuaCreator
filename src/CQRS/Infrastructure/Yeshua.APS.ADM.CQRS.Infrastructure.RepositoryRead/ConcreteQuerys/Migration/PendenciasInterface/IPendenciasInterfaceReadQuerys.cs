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
    public interface IPendenciasInterfaceQueryRead 
    {
        public QueryModel PendenciasInterfaceQuery(Command.Read.PendenciasInterfaceReadCommand Command );
        public QueryModel PendenciasInterfaceTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PendenciasInterfaceUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPEN_STATUS_OUTQuery(string value );
        public QueryModel ExistsByPEN_PROTOCOLO_OUTQuery(string value );
        public QueryModel ExistsByPEN_ID_PROTOCOLO_OUTQuery(string value );
        public QueryModel ExistsByPEN_STATUS_INQuery(string value );
        public QueryModel ExistsByPEN_PROTOCOLO_INQuery(string value );
        public QueryModel ExistsByPEN_ID_PROTOCOLO_INQuery(string value );
        public QueryModel ExistsByDATA_ENTRADAQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByPEN_IDQuery(int value );
        public QueryModel FirstByPEN_STATUS_OUTQuery(string value );
        public QueryModel FirstByPEN_PROTOCOLO_OUTQuery(string value );
        public QueryModel FirstByPEN_ID_PROTOCOLO_OUTQuery(string value );
        public QueryModel FirstByPEN_STATUS_INQuery(string value );
        public QueryModel FirstByPEN_PROTOCOLO_INQuery(string value );
        public QueryModel FirstByPEN_ID_PROTOCOLO_INQuery(string value );
        public QueryModel FirstByDATA_ENTRADAQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByPEN_IDQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration