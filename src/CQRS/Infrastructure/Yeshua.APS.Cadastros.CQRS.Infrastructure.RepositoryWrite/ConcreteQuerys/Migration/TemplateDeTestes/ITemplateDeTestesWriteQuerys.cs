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

    public interface ITemplateDeTestesQueryWrite 
     {
        public QueryModel InserirTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes);
        public QueryModel UpdateTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes);
        QueryModel UpdateTEM_DESCRICAO(int tem_id, string value);
        QueryModel UpdateTenantID(int tem_id, int value);
        QueryModel UpdateDeleted(int tem_id, bool value);
        QueryModel UpdateChanged(int tem_id, DateTime value);
        QueryModel UpdateUserId(int tem_id, int value);
        public QueryModel DeleteTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration