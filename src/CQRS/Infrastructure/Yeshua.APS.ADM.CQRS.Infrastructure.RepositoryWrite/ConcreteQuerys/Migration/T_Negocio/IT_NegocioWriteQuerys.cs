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

    public interface IT_NegocioQueryWrite 
     {
        public QueryModel InserirT_NegocioQuery(IT_NegocioEntity T_Negocio);
        public QueryModel UpdateT_NegocioQuery(IT_NegocioEntity T_Negocio);
        QueryModel UpdateNEG_DESCRICAO(int neg_id, string value);
        QueryModel UpdateTenantID(int neg_id, int value);
        QueryModel UpdateDeleted(int neg_id, bool value);
        QueryModel UpdateChanged(int neg_id, DateTime value);
        QueryModel UpdateUserId(int neg_id, int value);
        public QueryModel DeleteT_NegocioQuery(IT_NegocioEntity T_Negocio);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration