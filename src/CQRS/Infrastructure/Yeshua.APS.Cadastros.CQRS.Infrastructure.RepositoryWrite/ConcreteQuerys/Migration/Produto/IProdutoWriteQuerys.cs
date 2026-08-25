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

    public interface IProdutoQueryWrite 
     {
        public QueryModel InserirProdutoQuery(IProdutoEntity Produto);
        public QueryModel UpdateProdutoQuery(IProdutoEntity Produto);
        QueryModel UpdatePRO_DESCRICAO(string pro_id, string value);
        QueryModel UpdatePRO_STATUS(string pro_id, string value);
        QueryModel UpdateTenantID(string pro_id, int value);
        QueryModel UpdateDeleted(string pro_id, bool value);
        QueryModel UpdateChanged(string pro_id, DateTime value);
        QueryModel UpdateUserId(string pro_id, int value);
        public QueryModel DeleteProdutoQuery(IProdutoEntity Produto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration