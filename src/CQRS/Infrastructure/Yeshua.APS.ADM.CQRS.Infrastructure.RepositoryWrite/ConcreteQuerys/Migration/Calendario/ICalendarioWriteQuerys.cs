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

    public interface ICalendarioQueryWrite 
     {
        public QueryModel InserirCalendarioQuery(ICalendarioEntity Calendario);
        public QueryModel UpdateCalendarioQuery(ICalendarioEntity Calendario);
        QueryModel UpdateCAL_DESCRICAO(int cal_id, string value);
        QueryModel UpdateCAL_DIVIDE_DIA_EM(int cal_id, int value);
        QueryModel UpdateTenantID(int cal_id, int value);
        QueryModel UpdateDeleted(int cal_id, bool value);
        QueryModel UpdateChanged(int cal_id, DateTime value);
        QueryModel UpdateUserId(int cal_id, int value);
        public QueryModel DeleteCalendarioQuery(ICalendarioEntity Calendario);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration