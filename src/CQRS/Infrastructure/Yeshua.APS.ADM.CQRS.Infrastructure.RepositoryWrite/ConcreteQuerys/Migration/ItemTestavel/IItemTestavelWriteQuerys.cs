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

    public interface IItemTestavelQueryWrite 
     {
        public QueryModel InserirItemTestavelQuery(IItemTestavelEntity ItemTestavel);
        public QueryModel UpdateItemTestavelQuery(IItemTestavelEntity ItemTestavel);
        QueryModel UpdateITE_ID(int id, int value);
        QueryModel UpdateITE_DESCRICAO(int id, string value);
        QueryModel UpdateITE_OBS(int id, string value);
        QueryModel UpdateITE_NUMERO_DE_TESTES(int id, int value);
        QueryModel UpdateITE_CONDICIONAL_DE_AVALIACAO(int id, string value);
        QueryModel UpdateITE_VALOR_DA_CONDICIONAL(int id, Decimal value);
        QueryModel UpdateITE_VALOR_CALCULADO_DA_CONDICIONAL(int id, string value);
        QueryModel UpdateITE_TIPO_AVALIACAO_FINAL(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItemTestavelQuery(IItemTestavelEntity ItemTestavel);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration