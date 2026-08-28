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

    public interface IItemInspecaoQueryWrite 
     {
        public QueryModel InserirItemInspecaoQuery(IItemInspecaoEntity ItemInspecao);
        public QueryModel UpdateItemInspecaoQuery(IItemInspecaoEntity ItemInspecao);
        QueryModel UpdateITI_ID(int id, int value);
        QueryModel UpdateITI_DESC(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItemInspecaoQuery(IItemInspecaoEntity ItemInspecao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration