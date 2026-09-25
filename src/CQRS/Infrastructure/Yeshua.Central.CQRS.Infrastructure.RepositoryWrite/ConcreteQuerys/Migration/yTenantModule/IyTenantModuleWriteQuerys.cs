// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyTenantModuleQueryWrite 
     {
        public QueryModel InseriryTenantModuleQuery(IyTenantModuleEntity yTenantModule);
        public QueryModel UpdateyTenantModuleQuery(IyTenantModuleEntity yTenantModule);
        QueryModel UpdateModuleId(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateValidUntil(int id, DateTime value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyTenantModuleQuery(IyTenantModuleEntity yTenantModule);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration