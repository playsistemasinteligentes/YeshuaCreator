using Shered.DB;
namespace IQuery.Read
{
    public interface IyOutboxQueryRead 
    {
        public QueryModel yOutboxQuery(Command.Read.yOutboxReadCommand Command );
        public QueryModel yOutboxTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yOutboxUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMessageIdQuery(string value );
        public QueryModel ExistsByJobIdQuery(string value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByTypeQuery(string value );
        public QueryModel ExistsByPayloadQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByCreatedAtQuery(DateTime value );
        public QueryModel ExistsBySentAtQuery(DateTime value );
        public QueryModel ExistsByRetryCountQuery(int value );
        public QueryModel ExistsByLastErrorQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMessageIdQuery(string value );
        public QueryModel FirstByJobIdQuery(string value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByTypeQuery(string value );
        public QueryModel FirstByPayloadQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByCreatedAtQuery(DateTime value );
        public QueryModel FirstBySentAtQuery(DateTime value );
        public QueryModel FirstByRetryCountQuery(int value );
        public QueryModel FirstByLastErrorQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration