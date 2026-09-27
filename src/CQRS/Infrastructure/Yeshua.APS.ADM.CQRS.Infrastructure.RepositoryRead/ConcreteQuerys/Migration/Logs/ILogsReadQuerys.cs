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
    public interface ILogsQueryRead 
    {
        public QueryModel LogsQuery(Command.Read.LogsReadCommand Command );
        public QueryModel LogsTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LogsUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByLOG_CHAVEQuery(string value );
        public QueryModel ExistsByLOG_CONTEXTOQuery(string value );
        public QueryModel ExistsByLOG_CONTEUDOQuery(string value );
        public QueryModel ExistsByLOG_IDQuery(int value );
        public QueryModel ExistsByLOG_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByLOG_CHAVEQuery(string value );
        public QueryModel FirstByLOG_CONTEXTOQuery(string value );
        public QueryModel FirstByLOG_CONTEUDOQuery(string value );
        public QueryModel FirstByLOG_IDQuery(int value );
        public QueryModel FirstByLOG_EMISSAOQuery(DateTime value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration