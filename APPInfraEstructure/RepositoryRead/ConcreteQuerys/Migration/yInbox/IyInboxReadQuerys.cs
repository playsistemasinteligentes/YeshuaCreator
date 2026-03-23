using Shered.DB;
namespace IQuery.Read
{
    public interface IyInboxQueryRead 
    {
        public QueryModel yInboxQuery(Command.Read.yInboxReadCommand Command , bool TakeOffTenantID = false);
        public QueryModel yInboxTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel yInboxUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByMessageIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByJobIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCorrelationIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByPayloadQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsBySentAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByRetryCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByLastErrorQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByMessageIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByJobIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByCorrelationIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByPayloadQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstBySentAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByRetryCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByLastErrorQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration