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
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateStatus(string id, string value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        public QueryModel DeleteGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration