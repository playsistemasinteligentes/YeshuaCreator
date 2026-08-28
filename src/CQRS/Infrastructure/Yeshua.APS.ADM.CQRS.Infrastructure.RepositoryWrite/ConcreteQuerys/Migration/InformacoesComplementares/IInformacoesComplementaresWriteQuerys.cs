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

    public interface IInformacoesComplementaresQueryWrite 
     {
        public QueryModel InserirInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares);
        public QueryModel UpdateInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares);
        QueryModel UpdateINF_DESCRICAO(int inf_id, string value);
        QueryModel UpdateINF_VALOR(int inf_id, Decimal value);
        QueryModel UpdateMET_ID(int inf_id, int value);
        QueryModel UpdateINF_DATA(int inf_id, string value);
        QueryModel UpdateTenantID(int inf_id, int value);
        QueryModel UpdateDeleted(int inf_id, bool value);
        QueryModel UpdateChanged(int inf_id, DateTime value);
        QueryModel UpdateUserId(int inf_id, int value);
        public QueryModel DeleteInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration