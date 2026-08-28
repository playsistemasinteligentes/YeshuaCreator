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

    public interface IItensEstruturaImpressaoQueryWrite 
     {
        public QueryModel InserirItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao);
        public QueryModel UpdateItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao);
        QueryModel UpdateIES_CUSTOM_FONT_SIZE(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration