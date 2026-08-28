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

    public interface ITipoInspecaoItensQueryWrite 
     {
        public QueryModel InserirTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens);
        public QueryModel UpdateTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens);
        QueryModel UpdateTII_ID(int id, int value);
        QueryModel UpdateTIV_ID(int id, int value);
        QueryModel UpdateITI_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration