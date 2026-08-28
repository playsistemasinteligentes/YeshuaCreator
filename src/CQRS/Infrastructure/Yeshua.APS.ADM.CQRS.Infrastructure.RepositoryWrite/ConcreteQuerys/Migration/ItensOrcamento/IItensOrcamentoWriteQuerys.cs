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

    public interface IItensOrcamentoQueryWrite 
     {
        public QueryModel InserirItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento);
        public QueryModel UpdateItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento);
        QueryModel UpdateITO_ID(int id, int value);
        QueryModel UpdateORC_ID(int id, int value);
        QueryModel UpdateTIP_ID(int id, int value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateITO_OBS(int id, string value);
        QueryModel UpdateITO_QUANTIDADE(int id, Decimal value);
        QueryModel UpdateITO_CUSTO(int id, Decimal value);
        QueryModel UpdateITO_MARGEM(int id, Decimal value);
        QueryModel UpdateITO_VALOR_UNITARIO(int id, Decimal value);
        QueryModel UpdateITO_VERSSAO_CUSTO(int id, DateTime value);
        QueryModel UpdateITO_STATUS(int id, string value);
        QueryModel UpdateITO_ERP_CUSTOS_FIXOS(int id, Decimal value);
        QueryModel UpdateITO_ERP_CUSTOS_VARIAVEIS(int id, Decimal value);
        QueryModel UpdateITO_ERP_DESPESAS_VAR_VENDA(int id, Decimal value);
        QueryModel UpdateITO_ERP_IMPOSTOS(int id, Decimal value);
        QueryModel UpdateGRP_ID_COMPOSICAO(int id, string value);
        QueryModel UpdateITO_LARGURA(int id, Decimal value);
        QueryModel UpdateITO_COMPRIMENTO(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItensOrcamentoQuery(IItensOrcamentoEntity ItensOrcamento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration