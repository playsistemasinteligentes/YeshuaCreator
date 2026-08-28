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

    public interface IPlanoacaoQueryWrite 
     {
        public QueryModel InserirPlanoacaoQuery(IPlanoacaoEntity Planoacao);
        public QueryModel UpdatePlanoacaoQuery(IPlanoacaoEntity Planoacao);
        QueryModel UpdatePLA_DESCRICAO(int pla_id, string value);
        QueryModel UpdateMET_ID(int pla_id, int value);
        QueryModel UpdatePLA_STATUS(int pla_id, string value);
        QueryModel UpdatePLA_DATA(int pla_id, DateTime value);
        QueryModel UpdatePLA_METAPERIODO(int pla_id, string value);
        QueryModel UpdatePLA_VLRPERIODO(int pla_id, string value);
        QueryModel UpdatePLA_METACULADO(int pla_id, string value);
        QueryModel UpdatePLA_VLRACUMULADO(int pla_id, string value);
        QueryModel UpdatePLA_REFERENCIA(int pla_id, string value);
        QueryModel UpdateUSE_ID(int pla_id, int value);
        QueryModel UpdateTenantID(int pla_id, int value);
        QueryModel UpdateDeleted(int pla_id, bool value);
        QueryModel UpdateChanged(int pla_id, DateTime value);
        QueryModel UpdateUserId(int pla_id, int value);
        public QueryModel DeletePlanoacaoQuery(IPlanoacaoEntity Planoacao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration