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

    public interface IEstruturaCustoQueryWrite 
     {
        public QueryModel InserirEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto);
        public QueryModel UpdateEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto);
        QueryModel UpdateITO_ID(int est_id, int value);
        QueryModel UpdateORD_ID(int est_id, string value);
        QueryModel UpdatePRO_ID(int est_id, string value);
        QueryModel UpdatePRO_ID_PRODUTO(int est_id, string value);
        QueryModel UpdatePRO_ID_COMPONENTE(int est_id, string value);
        QueryModel UpdatePRO_TIPO_CUSTO(int est_id, string value);
        QueryModel UpdatePRO_GRUPO_CONTABIL(int est_id, string value);
        QueryModel UpdateEST_ORDEM(int est_id, int value);
        QueryModel UpdateEST_GRUPO(int est_id, string value);
        QueryModel UpdateEST_QUANT(int est_id, Decimal value);
        QueryModel UpdateEST_VALOR_TOTAL(int est_id, Decimal value);
        QueryModel UpdateEST_DATA_BASE(int est_id, string value);
        QueryModel UpdateEST_BASE_PRODUCAO(int est_id, Decimal value);
        QueryModel UpdateEST_NIVEL(int est_id, Decimal value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int est_id, int value);
        QueryModel UpdateTenantID(int est_id, int value);
        QueryModel UpdateDeleted(int est_id, bool value);
        QueryModel UpdateChanged(int est_id, DateTime value);
        QueryModel UpdateUserId(int est_id, int value);
        public QueryModel DeleteEstruturaCustoQuery(IEstruturaCustoEntity EstruturaCusto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration