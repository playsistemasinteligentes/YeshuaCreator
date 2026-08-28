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

    public interface ITemplateTipoTesteQueryWrite 
     {
        public QueryModel InserirTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste);
        public QueryModel UpdateTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste);
        QueryModel UpdateTT_ID(int ttt_id, int value);
        QueryModel UpdateTEM_ID(int ttt_id, int value);
        QueryModel UpdateTenantID(int ttt_id, int value);
        QueryModel UpdateDeleted(int ttt_id, bool value);
        QueryModel UpdateChanged(int ttt_id, DateTime value);
        QueryModel UpdateUserId(int ttt_id, int value);
        public QueryModel DeleteTemplateTipoTesteQuery(ITemplateTipoTesteEntity TemplateTipoTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration