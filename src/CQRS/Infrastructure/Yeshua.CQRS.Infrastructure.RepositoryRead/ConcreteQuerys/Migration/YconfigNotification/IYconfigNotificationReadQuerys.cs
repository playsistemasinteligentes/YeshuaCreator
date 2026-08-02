using Shered.DB;
namespace IQuery.Read
{
    public interface IyConfigNotificationQueryRead 
    {
        public QueryModel yConfigNotificationQuery(Command.Read.yConfigNotificationReadCommand Command );
        public QueryModel yConfigNotificationTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yConfigNotificationUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByEmailSmtpClientQuery(string value );
        public QueryModel ExistsByEmailPortQuery(int value );
        public QueryModel ExistsByEmailUserNameQuery(string value );
        public QueryModel ExistsByEmailPasswordQuery(string value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByEmailSmtpClientQuery(string value );
        public QueryModel FirstByEmailPortQuery(int value );
        public QueryModel FirstByEmailUserNameQuery(string value );
        public QueryModel FirstByEmailPasswordQuery(string value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration