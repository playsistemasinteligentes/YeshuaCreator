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

    public interface IT_GrupoQueryWrite 
     {
        public QueryModel InserirT_GrupoQuery(IT_GrupoEntity T_Grupo);
        public QueryModel UpdateT_GrupoQuery(IT_GrupoEntity T_Grupo);
        QueryModel UpdateNOME(int gru_id, string value);
        QueryModel UpdateEXIBELISTA(int gru_id, int value);
        QueryModel UpdateGRU_DESCRICAO(int gru_id, string value);
        QueryModel UpdateTenantID(int gru_id, int value);
        QueryModel UpdateDeleted(int gru_id, bool value);
        QueryModel UpdateChanged(int gru_id, DateTime value);
        QueryModel UpdateUserId(int gru_id, int value);
        public QueryModel DeleteT_GrupoQuery(IT_GrupoEntity T_Grupo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration