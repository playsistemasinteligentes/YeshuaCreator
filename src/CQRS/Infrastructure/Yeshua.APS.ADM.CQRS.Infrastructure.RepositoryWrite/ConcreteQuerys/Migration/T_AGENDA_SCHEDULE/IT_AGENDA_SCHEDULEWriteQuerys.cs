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

    public interface IT_AGENDA_SCHEDULEQueryWrite 
     {
        public QueryModel InserirT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE);
        public QueryModel UpdateT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE);
        QueryModel UpdateAGE_ID(int id, int value);
        QueryModel UpdateAGE_DATA_ESPECIFICA(int id, DateTime value);
        QueryModel UpdateAGE_HORARIO_INICIO(int id, string value);
        QueryModel UpdateAGE_HORARIO_FIM(int id, string value);
        QueryModel UpdateAGE_SEGUNDA(int id, string value);
        QueryModel UpdateAGE_TERCA(int id, string value);
        QueryModel UpdateAGE_QUARTA(int id, string value);
        QueryModel UpdateAGE_QUINTA(int id, string value);
        QueryModel UpdateAGE_SEXTA(int id, string value);
        QueryModel UpdateAGE_SABADO(int id, string value);
        QueryModel UpdateAGE_DOMINGO(int id, string value);
        QueryModel UpdateAGE_INTERVALO(int id, Decimal value);
        QueryModel UpdateAGE_ORDEM_EXECUCAO(int id, string value);
        QueryModel UpdateAGE_PARAMETROS(int id, string value);
        QueryModel UpdateAGE_EXCECAO(int id, string value);
        QueryModel UpdateAGE_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_AGENDA_SCHEDULEQuery(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration