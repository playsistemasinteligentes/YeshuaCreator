using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyUserModuleQueryWrite 
     {
        public QueryModel InseriryUserModuleQuery(IyUserModuleEntity yUserModule);
        public QueryModel UpdateyUserModuleQuery(IyUserModuleEntity yUserModule);
        QueryModel UpdateModuleId(int id, string value);
        QueryModel UpdateUserId(int id, int value);
        QueryModel UpdateValidUntil(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        public QueryModel DeleteyUserModuleQuery(IyUserModuleEntity yUserModule);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration