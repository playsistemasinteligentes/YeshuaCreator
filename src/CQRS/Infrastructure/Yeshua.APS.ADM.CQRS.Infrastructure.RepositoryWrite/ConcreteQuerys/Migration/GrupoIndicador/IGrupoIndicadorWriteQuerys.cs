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

    public interface IGrupoIndicadorQueryWrite 
     {
        public QueryModel InserirGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador);
        public QueryModel UpdateGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador);
        QueryModel UpdateGRU_ID(int gru_ind_id, int value);
        QueryModel UpdateIND_ID(int gru_ind_id, int value);
        QueryModel UpdateTenantID(int gru_ind_id, int value);
        QueryModel UpdateDeleted(int gru_ind_id, bool value);
        QueryModel UpdateChanged(int gru_ind_id, DateTime value);
        QueryModel UpdateUserId(int gru_ind_id, int value);
        public QueryModel DeleteGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration