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

    public interface IParamQueryWrite 
     {
        public QueryModel InserirParamQuery(IParamEntity Param);
        public QueryModel UpdateParamQuery(IParamEntity Param);
        QueryModel UpdatePAR_DESCRICAO(string par_id, string value);
        QueryModel UpdatePAR_VALOR_S(string par_id, string value);
        QueryModel UpdatePAR_VALOR_N(string par_id, Decimal value);
        QueryModel UpdatePAR_VALOR_D(string par_id, DateTime value);
        QueryModel UpdateTenantID(string par_id, int value);
        QueryModel UpdateDeleted(string par_id, bool value);
        QueryModel UpdateChanged(string par_id, DateTime value);
        QueryModel UpdateUserId(string par_id, int value);
        public QueryModel DeleteParamQuery(IParamEntity Param);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration