using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyUserGrantQueryWrite 
     {
        public QueryModel InseriryUserGrantQuery(IyUserGrantEntity yUserGrant);
        public QueryModel UpdateyUserGrantQuery(IyUserGrantEntity yUserGrant);
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
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration