using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyGrantQueryWrite 
     {
        public QueryModel InseriryGrantQuery(IyGrantEntity yGrant);
        public QueryModel UpdateyGrantQuery(IyGrantEntity yGrant);
        public QueryModel UpdateDescription(IyGrantEntity entity);
        public QueryModel UpdateTenantID(IyGrantEntity entity);
        public QueryModel UpdateDeleted(IyGrantEntity entity);
        public QueryModel UpdateChanged(IyGrantEntity entity);
        public QueryModel UpdateUserId(IyGrantEntity entity);
        public QueryModel DeleteyGrantQuery(IyGrantEntity yGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration