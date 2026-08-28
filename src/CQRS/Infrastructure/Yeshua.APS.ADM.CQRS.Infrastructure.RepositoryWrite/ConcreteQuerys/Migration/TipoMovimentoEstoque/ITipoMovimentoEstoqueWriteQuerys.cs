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

    public interface ITipoMovimentoEstoqueQueryWrite 
     {
        public QueryModel InserirTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque);
        public QueryModel UpdateTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque);
        QueryModel UpdateTIP_DESCRICAO(string tip_id, string value);
        QueryModel UpdateTIP_TYPE(string tip_id, int value);
        QueryModel UpdateSPR(string tip_id, int value);
        QueryModel UpdateTenantID(string tip_id, int value);
        QueryModel UpdateDeleted(string tip_id, bool value);
        QueryModel UpdateChanged(string tip_id, DateTime value);
        QueryModel UpdateUserId(string tip_id, int value);
        public QueryModel DeleteTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration