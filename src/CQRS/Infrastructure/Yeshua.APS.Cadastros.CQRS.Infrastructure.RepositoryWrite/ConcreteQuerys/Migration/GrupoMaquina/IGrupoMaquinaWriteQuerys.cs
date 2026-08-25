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

    public interface IGrupoMaquinaQueryWrite 
     {
        public QueryModel InserirGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina);
        public QueryModel UpdateGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina);
        QueryModel UpdateGMA_DESCRICAO(string gma_id, string value);
        QueryModel UpdateGMA_STATUS(string gma_id, string value);
        QueryModel UpdateTenantID(string gma_id, int value);
        QueryModel UpdateDeleted(string gma_id, bool value);
        QueryModel UpdateChanged(string gma_id, DateTime value);
        QueryModel UpdateUserId(string gma_id, int value);
        public QueryModel DeleteGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration