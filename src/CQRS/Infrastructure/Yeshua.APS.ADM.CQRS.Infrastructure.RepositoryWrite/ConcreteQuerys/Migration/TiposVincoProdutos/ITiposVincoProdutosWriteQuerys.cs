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

    public interface ITiposVincoProdutosQueryWrite 
     {
        public QueryModel InserirTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos);
        public QueryModel UpdateTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos);
        QueryModel UpdateId2(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration