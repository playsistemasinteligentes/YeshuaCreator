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

    public interface IEstruturaImpressaoQueryWrite 
     {
        public QueryModel InserirEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao);
        public QueryModel UpdateEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao);
        QueryModel UpdateHTML_ESTRUTURA(int est_id, string value);
        QueryModel UpdateCLI_ID(int est_id, string value);
        QueryModel UpdateEST_DESCRICAO(int est_id, string value);
        QueryModel UpdateTenantID(int est_id, int value);
        QueryModel UpdateDeleted(int est_id, bool value);
        QueryModel UpdateChanged(int est_id, DateTime value);
        QueryModel UpdateUserId(int est_id, int value);
        public QueryModel DeleteEstruturaImpressaoQuery(IEstruturaImpressaoEntity EstruturaImpressao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration