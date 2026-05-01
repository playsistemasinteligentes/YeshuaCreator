using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyPerfilGrantQueryWrite 
     {
        public QueryModel InseriryPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
        public QueryModel UpdateyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
        QueryModel UpdatePerfilId(int id, int value);
        QueryModel UpdateGrantId(int id, string value);
        QueryModel UpdateGrant(int id, bool value);
        QueryModel UpdateCreate(int id, bool value);
        QueryModel UpdateRead(int id, bool value);
        QueryModel UpdateUpdate(int id, bool value);
        QueryModel UpdateDelete(int id, bool value);
        QueryModel UpdateValidUntil(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyPerfilGrantQuery(IyPerfilGrantEntity yPerfilGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration