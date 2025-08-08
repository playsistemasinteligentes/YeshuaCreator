using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyUserModuleQueryWrite 
     {
        public QueryModel InseriryUserModuleQuery(IyUserModuleEntity yUserModule);
        public QueryModel UpdateyUserModuleQuery(IyUserModuleEntity yUserModule);
        public QueryModel UpdateModuleId(IyUserModuleEntity entity);
        public QueryModel UpdateUserId(IyUserModuleEntity entity);
        public QueryModel UpdateValidUntil(IyUserModuleEntity entity);
        public QueryModel UpdateTenantID(IyUserModuleEntity entity);
        public QueryModel UpdateDeleted(IyUserModuleEntity entity);
        public QueryModel UpdateChanged(IyUserModuleEntity entity);
        public QueryModel DeleteyUserModuleQuery(IyUserModuleEntity yUserModule);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration