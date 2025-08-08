using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyPerfilGrantQueryWrite 
     {
        public QueryModel InseriryPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
        public QueryModel UpdateyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
        public QueryModel UpdatePerfilId(IyPerfilGrantEntity entity);
        public QueryModel UpdateGrantId(IyPerfilGrantEntity entity);
        public QueryModel UpdateGrant(IyPerfilGrantEntity entity);
        public QueryModel UpdateCreate(IyPerfilGrantEntity entity);
        public QueryModel UpdateRead(IyPerfilGrantEntity entity);
        public QueryModel UpdateUpdate(IyPerfilGrantEntity entity);
        public QueryModel UpdateDelete(IyPerfilGrantEntity entity);
        public QueryModel UpdateValidUntil(IyPerfilGrantEntity entity);
        public QueryModel UpdateTenantID(IyPerfilGrantEntity entity);
        public QueryModel UpdateDeleted(IyPerfilGrantEntity entity);
        public QueryModel UpdateChanged(IyPerfilGrantEntity entity);
        public QueryModel UpdateUserId(IyPerfilGrantEntity entity);
        public QueryModel DeleteyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration