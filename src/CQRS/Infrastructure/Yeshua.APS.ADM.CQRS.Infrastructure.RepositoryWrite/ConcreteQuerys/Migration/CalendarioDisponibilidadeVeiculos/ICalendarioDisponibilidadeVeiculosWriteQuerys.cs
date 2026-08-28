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

    public interface ICalendarioDisponibilidadeVeiculosQueryWrite 
     {
        public QueryModel InserirCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos);
        public QueryModel UpdateCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos);
        QueryModel UpdateCDV_ID(int id, int value);
        QueryModel UpdateCDV_DATA_DE(int id, DateTime value);
        QueryModel UpdateCDV_DATA_ATE(int id, DateTime value);
        QueryModel UpdateCDV_SEGUNDA(int id, int value);
        QueryModel UpdateCDV_TERCA(int id, int value);
        QueryModel UpdateCDV_QUARTA(int id, int value);
        QueryModel UpdateCDV_QUINTA(int id, int value);
        QueryModel UpdateCDV_SEXTA(int id, int value);
        QueryModel UpdateCDV_SABADO(int id, int value);
        QueryModel UpdateCDV_DOMINGO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCalendarioDisponibilidadeVeiculosQuery(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration