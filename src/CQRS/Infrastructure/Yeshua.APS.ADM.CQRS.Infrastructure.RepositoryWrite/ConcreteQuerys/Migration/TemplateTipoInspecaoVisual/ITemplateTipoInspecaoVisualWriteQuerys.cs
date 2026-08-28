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

    public interface ITemplateTipoInspecaoVisualQueryWrite 
     {
        public QueryModel InserirTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual);
        public QueryModel UpdateTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual);
        QueryModel UpdateTIV_ID(int tti_id, int value);
        QueryModel UpdateTEM_ID(int tti_id, int value);
        QueryModel UpdateTenantID(int tti_id, int value);
        QueryModel UpdateDeleted(int tti_id, bool value);
        QueryModel UpdateChanged(int tti_id, DateTime value);
        QueryModel UpdateUserId(int tti_id, int value);
        public QueryModel DeleteTemplateTipoInspecaoVisualQuery(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration