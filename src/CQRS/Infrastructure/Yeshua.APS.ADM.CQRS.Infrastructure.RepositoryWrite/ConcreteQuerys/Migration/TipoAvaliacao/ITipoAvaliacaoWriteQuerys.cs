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

    public interface ITipoAvaliacaoQueryWrite 
     {
        public QueryModel InserirTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao);
        public QueryModel UpdateTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao);
        QueryModel UpdateTA_DESC(int ta_id, string value);
        QueryModel UpdateTenantID(int ta_id, int value);
        QueryModel UpdateDeleted(int ta_id, bool value);
        QueryModel UpdateChanged(int ta_id, DateTime value);
        QueryModel UpdateUserId(int ta_id, int value);
        public QueryModel DeleteTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration