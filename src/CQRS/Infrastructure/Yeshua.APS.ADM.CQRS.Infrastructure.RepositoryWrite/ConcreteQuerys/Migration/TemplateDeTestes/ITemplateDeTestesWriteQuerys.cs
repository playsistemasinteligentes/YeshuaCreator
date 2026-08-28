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
        QueryModel UpdateDescricao(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        QueryModel UpdateObservacao(int id, string value);
        public QueryModel DeleteTemplateDeTestesQuery(ITemplateDeTestesEntity TemplateDeTestes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration