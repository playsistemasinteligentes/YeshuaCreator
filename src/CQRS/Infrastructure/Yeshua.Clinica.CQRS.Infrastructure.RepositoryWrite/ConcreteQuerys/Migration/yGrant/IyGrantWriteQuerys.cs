using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyGrantQueryWrite 
     {
        public QueryModel InseriryGrantQuery(IyGrantEntity yGrant);
        public QueryModel UpdateyGrantQuery(IyGrantEntity yGrant);
        QueryModel UpdateDescription(string id, string value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        public QueryModel DeleteyGrantQuery(IyGrantEntity yGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration