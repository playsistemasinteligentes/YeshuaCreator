using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyConfigArctetureQueryWrite 
     {
        public QueryModel InseriryConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture);
        public QueryModel UpdateyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture);
        public QueryModel UpdateAuditTrackerActived(IyConfigArctetureEntity entity);
        public QueryModel UpdateAuditCRUDActived(IyConfigArctetureEntity entity);
        public QueryModel UpdateTenantID(IyConfigArctetureEntity entity);
        public QueryModel UpdateDeleted(IyConfigArctetureEntity entity);
        public QueryModel UpdateChanged(IyConfigArctetureEntity entity);
        public QueryModel UpdateUserId(IyConfigArctetureEntity entity);
        public QueryModel DeleteyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration