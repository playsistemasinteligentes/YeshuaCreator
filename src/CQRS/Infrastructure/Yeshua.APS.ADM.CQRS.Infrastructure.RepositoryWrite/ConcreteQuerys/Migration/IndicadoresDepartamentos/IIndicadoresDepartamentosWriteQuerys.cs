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

    public interface IIndicadoresDepartamentosQueryWrite 
     {
        public QueryModel InserirIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos);
        public QueryModel UpdateIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos);
        QueryModel UpdateDEP_ID(int inddep_id, int value);
        QueryModel UpdateIND_ID(int inddep_id, int value);
        QueryModel UpdateTenantID(int inddep_id, int value);
        QueryModel UpdateDeleted(int inddep_id, bool value);
        QueryModel UpdateChanged(int inddep_id, DateTime value);
        QueryModel UpdateUserId(int inddep_id, int value);
        public QueryModel DeleteIndicadoresDepartamentosQuery(IIndicadoresDepartamentosEntity IndicadoresDepartamentos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration