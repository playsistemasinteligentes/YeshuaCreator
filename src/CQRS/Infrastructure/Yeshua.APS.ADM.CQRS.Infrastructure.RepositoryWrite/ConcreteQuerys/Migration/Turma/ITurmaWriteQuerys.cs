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

    public interface ITurmaQueryWrite 
     {
        public QueryModel InserirTurmaQuery(ITurmaEntity Turma);
        public QueryModel UpdateTurmaQuery(ITurmaEntity Turma);
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateTURM_HORA_INI_DIA1(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA1(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA2(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA2(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA3(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA3(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA4(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA4(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA5(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA5(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA6(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA6(string id, DateTime value);
        QueryModel UpdateTURM_HORA_INI_DIA7(string id, DateTime value);
        QueryModel UpdateTURM_HORA_FIM_DIA7(string id, DateTime value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        public QueryModel DeleteTurmaQuery(ITurmaEntity Turma);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration