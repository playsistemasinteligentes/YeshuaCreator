// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyConfigNotificationQueryWrite 
     {
        public QueryModel InseriryConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
        public QueryModel UpdateyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateEmailSmtpClient(int id, string value);
        QueryModel UpdateEmailPort(int id, int value);
        QueryModel UpdateEmailUserName(int id, string value);
        QueryModel UpdateEmailPassword(int id, string value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration