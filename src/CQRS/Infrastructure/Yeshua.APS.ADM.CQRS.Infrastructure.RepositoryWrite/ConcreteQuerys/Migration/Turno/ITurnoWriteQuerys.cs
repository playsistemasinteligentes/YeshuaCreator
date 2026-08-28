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

    public interface ITurnoQueryWrite 
     {
        public QueryModel InserirTurnoQuery(ITurnoEntity Turno);
        public QueryModel UpdateTurnoQuery(ITurnoEntity Turno);
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateTURN_PRIORIDADE(string id, int value);
        QueryModel UpdateTURN_HORA_INI_DIA1(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA1(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA2(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA2(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA3(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA3(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA4(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA4(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA5(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA5(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA6(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA6(string id, DateTime value);
        QueryModel UpdateTURN_HORA_INI_DIA7(string id, DateTime value);
        QueryModel UpdateTURN_HORA_FIM_DIA7(string id, DateTime value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        public QueryModel DeleteTurnoQuery(ITurnoEntity Turno);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration