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

    public interface IT_DepartamentosQueryWrite 
     {
        public QueryModel InserirT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos);
        public QueryModel UpdateT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos);
        QueryModel UpdateDEP_NOME(int dep_id, string value);
        QueryModel UpdateTenantID(int dep_id, int value);
        QueryModel UpdateDeleted(int dep_id, bool value);
        QueryModel UpdateChanged(int dep_id, DateTime value);
        QueryModel UpdateUserId(int dep_id, int value);
        public QueryModel DeleteT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration