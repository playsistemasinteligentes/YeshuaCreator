using Shered.DB;
namespace IQuery.Read
{
    public interface IyFileUploadQueryRead 
    {
        public QueryModel yFileUploadQuery(Command.Read.yFileUploadReadCommand Command );
        public QueryModel yFileUploadTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yFileUploadUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByIdempotencyKeyQuery(string value );
        public QueryModel ExistsByTypeQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByFilePathQuery(string value );
        public QueryModel ExistsByFileSizeQuery(int value );
        public QueryModel ExistsByContentTypeQuery(string value );
        public QueryModel ExistsByCreatedAtQuery(DateTime value );
        public QueryModel ExistsByCompletedAtQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByIdempotencyKeyQuery(string value );
        public QueryModel FirstByTypeQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByFilePathQuery(string value );
        public QueryModel FirstByFileSizeQuery(int value );
        public QueryModel FirstByContentTypeQuery(string value );
        public QueryModel FirstByCreatedAtQuery(DateTime value );
        public QueryModel FirstByCompletedAtQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration