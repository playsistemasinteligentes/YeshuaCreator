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

    public interface IGrupoSegmentoQueryWrite 
     {
        public QueryModel InserirGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento);
        public QueryModel UpdateGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento);
        QueryModel UpdateGRS_ID(int id, string value);
        QueryModel UpdateGRS_DESCRICAO(int id, string value);
        QueryModel UpdateGRS_INTEGRACAO_ERP(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration