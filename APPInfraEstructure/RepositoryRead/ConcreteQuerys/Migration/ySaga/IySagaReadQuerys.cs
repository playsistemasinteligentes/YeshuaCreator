using Shered.DB;
namespace IQuery.Read
{
    public interface IySagaQueryRead 
    {
        public QueryModel ySagaQuery(Command.Read.ySagaReadCommand Command , bool TakeOffTenantID = false);
        public QueryModel ySagaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ySagaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsBySagaIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByKeyCurrentStepQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByEntityTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByEntityIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstBySagaIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByKeyCurrentStepQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByEntityTypeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByEntityIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration