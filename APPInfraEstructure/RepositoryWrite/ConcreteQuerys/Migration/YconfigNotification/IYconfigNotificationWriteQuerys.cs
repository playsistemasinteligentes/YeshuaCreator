using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYconfigNotificationQueryWrite 
     {
        public QueryModel InserirYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification);
        public QueryModel UpdateYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification);
        public QueryModel UpdateEmailAdress(IYconfigNotificationEntity entity);
        public QueryModel UpdateEmailPassword(IYconfigNotificationEntity entity);
        public QueryModel UpdateTenantID(IYconfigNotificationEntity entity);
        public QueryModel DeleteYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration