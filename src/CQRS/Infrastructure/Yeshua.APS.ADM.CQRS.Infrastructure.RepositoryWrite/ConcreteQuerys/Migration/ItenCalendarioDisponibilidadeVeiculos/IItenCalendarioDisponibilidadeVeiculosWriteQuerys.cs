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

    public interface IItenCalendarioDisponibilidadeVeiculosQueryWrite 
     {
        public QueryModel InserirItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos);
        public QueryModel UpdateItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos);
        QueryModel UpdateCDV_ID(int id, int value);
        QueryModel UpdateTIP_ID(int id, int value);
        QueryModel UpdateIDV_QTD(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration