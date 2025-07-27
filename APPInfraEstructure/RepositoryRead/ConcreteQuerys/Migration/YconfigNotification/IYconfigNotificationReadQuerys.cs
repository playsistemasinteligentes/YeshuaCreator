using Shered.DB;
namespace IQuery.Read
{
    public interface IYconfigNotificationQueryRead 
    {
        public QueryModel YconfigNotificationQuery(Command.Read.YconfigNotificationReadCommand Command);
        public QueryModel YconfigNotificationTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByTenantIDQuery(int value);
        public QueryModel ExistsByEmailSmtpClientQuery(string value);
        public QueryModel ExistsByEmailPortQuery(int value);
        public QueryModel ExistsByEmailUserNameQuery(string value);
        public QueryModel ExistsByEmailPasswordQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByTenantIDQuery(int value);
        public QueryModel FirstByEmailSmtpClientQuery(string value);
        public QueryModel FirstByEmailPortQuery(int value);
        public QueryModel FirstByEmailUserNameQuery(string value);
        public QueryModel FirstByEmailPasswordQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration