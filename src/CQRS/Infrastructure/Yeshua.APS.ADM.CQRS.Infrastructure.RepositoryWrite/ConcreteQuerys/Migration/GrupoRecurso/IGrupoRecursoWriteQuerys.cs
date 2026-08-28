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

    public interface IGrupoRecursoQueryWrite 
     {
        public QueryModel InserirGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso);
        public QueryModel UpdateGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso);
        QueryModel UpdateGRE_DESCRICAO(string gre_id, string value);
        QueryModel UpdateTenantID(string gre_id, int value);
        QueryModel UpdateDeleted(string gre_id, bool value);
        QueryModel UpdateChanged(string gre_id, DateTime value);
        QueryModel UpdateUserId(string gre_id, int value);
        public QueryModel DeleteGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration