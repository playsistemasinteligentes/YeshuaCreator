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

    public interface IInpecaoVisualQueryWrite 
     {
        public QueryModel InserirInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual);
        public QueryModel UpdateInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual);
        QueryModel UpdateIPV_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteInpecaoVisualQuery(IInpecaoVisualEntity InpecaoVisual);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration