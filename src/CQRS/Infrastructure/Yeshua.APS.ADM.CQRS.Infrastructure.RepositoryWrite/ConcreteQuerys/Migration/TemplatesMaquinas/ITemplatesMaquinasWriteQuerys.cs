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

    public interface ITemplatesMaquinasQueryWrite 
     {
        public QueryModel InserirTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas);
        public QueryModel UpdateTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas);
        QueryModel UpdateTEM_ID(int id, int value);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTemplatesMaquinasQuery(ITemplatesMaquinasEntity TemplatesMaquinas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration