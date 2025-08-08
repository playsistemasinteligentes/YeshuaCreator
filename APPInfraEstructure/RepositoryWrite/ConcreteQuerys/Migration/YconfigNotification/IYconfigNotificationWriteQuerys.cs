using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyConfigNotificationQueryWrite 
     {
        public QueryModel InseriryConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
        public QueryModel UpdateyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
        public QueryModel UpdateTenantID(IyConfigNotificationEntity entity);
        public QueryModel UpdateEmailSmtpClient(IyConfigNotificationEntity entity);
        public QueryModel UpdateEmailPort(IyConfigNotificationEntity entity);
        public QueryModel UpdateEmailUserName(IyConfigNotificationEntity entity);
        public QueryModel UpdateEmailPassword(IyConfigNotificationEntity entity);
        public QueryModel UpdateDeleted(IyConfigNotificationEntity entity);
        public QueryModel UpdateChanged(IyConfigNotificationEntity entity);
        public QueryModel UpdateUserId(IyConfigNotificationEntity entity);
        public QueryModel DeleteyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration