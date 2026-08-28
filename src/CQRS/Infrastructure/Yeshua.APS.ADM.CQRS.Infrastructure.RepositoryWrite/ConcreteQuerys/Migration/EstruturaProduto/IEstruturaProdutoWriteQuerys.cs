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

    public interface IEstruturaProdutoQueryWrite 
     {
        public QueryModel InserirEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto);
        public QueryModel UpdateEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto);
        QueryModel UpdateEST_DATA_VALIDADE(int id, DateTime value);
        QueryModel UpdatePRO_ID_PRODUTO(int id, string value);
        QueryModel UpdatePRO_ID_COMPONENTE(int id, string value);
        QueryModel UpdateEST_QUANT(int id, Decimal value);
        QueryModel UpdateEST_DATA_INCLUSAO(int id, DateTime value);
        QueryModel UpdateEST_BASE_PRODUCAO(int id, Decimal value);
        QueryModel UpdateEST_TIPO_REQUISICAO(int id, string value);
        QueryModel UpdateEST_CODIGO_DE_EXCECAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration