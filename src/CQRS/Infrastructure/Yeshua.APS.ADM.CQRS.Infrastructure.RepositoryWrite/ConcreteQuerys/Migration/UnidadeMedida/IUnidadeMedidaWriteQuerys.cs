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

    public interface IUnidadeMedidaQueryWrite 
     {
        public QueryModel InserirUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida);
        public QueryModel UpdateUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida);
        QueryModel UpdateUNI_DESCRICAO(string uni_id, string value);
        QueryModel UpdateUNI_ESCALA_TEMPO(string uni_id, string value);
        QueryModel UpdateTenantID(string uni_id, int value);
        QueryModel UpdateDeleted(string uni_id, bool value);
        QueryModel UpdateChanged(string uni_id, DateTime value);
        QueryModel UpdateUserId(string uni_id, int value);
        public QueryModel DeleteUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration