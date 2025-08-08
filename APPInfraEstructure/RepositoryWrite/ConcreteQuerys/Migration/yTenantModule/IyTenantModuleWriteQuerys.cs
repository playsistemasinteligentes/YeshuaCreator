using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyTenantModuleQueryWrite 
     {
        public QueryModel InseriryTenantModuleQuery(IyTenantModuleEntity yTenantModule);
        public QueryModel UpdateyTenantModuleQuery(IyTenantModuleEntity yTenantModule);
        public QueryModel UpdateModuleId(IyTenantModuleEntity entity);
        public QueryModel UpdateTenantID(IyTenantModuleEntity entity);
        public QueryModel UpdateValidUntil(IyTenantModuleEntity entity);
        public QueryModel UpdateDeleted(IyTenantModuleEntity entity);
        public QueryModel UpdateChanged(IyTenantModuleEntity entity);
        public QueryModel UpdateUserId(IyTenantModuleEntity entity);
        public QueryModel DeleteyTenantModuleQuery(IyTenantModuleEntity yTenantModule);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration