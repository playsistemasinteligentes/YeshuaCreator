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

    public interface ICabvisaoQueryWrite 
     {
        public QueryModel InserirCabvisaoQuery(ICabvisaoEntity Cabvisao);
        public QueryModel UpdateCabvisaoQuery(ICabvisaoEntity Cabvisao);
        QueryModel UpdateCAB_DESC(int cab_id, string value);
        QueryModel UpdateCAB_STATUS(int cab_id, int value);
        QueryModel UpdateUSE_ID(int cab_id, int value);
        QueryModel UpdateTenantID(int cab_id, int value);
        QueryModel UpdateDeleted(int cab_id, bool value);
        QueryModel UpdateChanged(int cab_id, DateTime value);
        QueryModel UpdateUserId(int cab_id, int value);
        public QueryModel DeleteCabvisaoQuery(ICabvisaoEntity Cabvisao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration