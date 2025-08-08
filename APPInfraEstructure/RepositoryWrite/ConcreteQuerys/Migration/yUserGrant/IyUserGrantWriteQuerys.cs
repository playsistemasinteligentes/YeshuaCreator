using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyUserGrantQueryWrite 
     {
        public QueryModel InseriryUserGrantQuery(IyUserGrantEntity yUserGrant);
        public QueryModel UpdateyUserGrantQuery(IyUserGrantEntity yUserGrant);
        public QueryModel UpdatePerfilId(IyUserGrantEntity entity);
        public QueryModel UpdateGrantId(IyUserGrantEntity entity);
        public QueryModel UpdateGrant(IyUserGrantEntity entity);
        public QueryModel UpdateCreate(IyUserGrantEntity entity);
        public QueryModel UpdateRead(IyUserGrantEntity entity);
        public QueryModel UpdateUpdate(IyUserGrantEntity entity);
        public QueryModel UpdateDelete(IyUserGrantEntity entity);
        public QueryModel UpdateValidUntil(IyUserGrantEntity entity);
        public QueryModel UpdateTenantID(IyUserGrantEntity entity);
        public QueryModel UpdateDeleted(IyUserGrantEntity entity);
        public QueryModel UpdateChanged(IyUserGrantEntity entity);
        public QueryModel UpdateUserId(IyUserGrantEntity entity);
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration