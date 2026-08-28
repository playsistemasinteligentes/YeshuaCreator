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

    public interface ICondicaoPagamentoQueryWrite 
     {
        public QueryModel InserirCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento);
        public QueryModel UpdateCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento);
        QueryModel UpdateCON_ID(int id, string value);
        QueryModel UpdateCON_DESCRICAO(int id, string value);
        QueryModel UpdateCON_PARCELAS(int id, int value);
        QueryModel UpdateCON_VALOR_ACRECIMO(int id, Decimal value);
        QueryModel UpdateCON_INTEGRACAO_ERP(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCondicaoPagamentoQuery(ICondicaoPagamentoEntity CondicaoPagamento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration