using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYconfigArctetureQueryWrite 
     {
        public QueryModel InserirYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture);
        public QueryModel UpdateYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture);
        public QueryModel UpdateAuditTrackerActived(IYconfigArctetureEntity entity);
        public QueryModel UpdateAuditCRUDActived(IYconfigArctetureEntity entity);
        public QueryModel UpdateTenantID(IYconfigArctetureEntity entity);
        public QueryModel DeleteYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration