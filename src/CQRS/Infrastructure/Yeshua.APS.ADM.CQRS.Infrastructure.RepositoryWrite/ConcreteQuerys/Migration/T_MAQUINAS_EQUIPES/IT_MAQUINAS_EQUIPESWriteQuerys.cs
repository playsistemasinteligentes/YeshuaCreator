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

    public interface IT_MAQUINAS_EQUIPESQueryWrite 
     {
        public QueryModel InserirT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES);
        public QueryModel UpdateT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdateEQU_ID(int id, string value);
        QueryModel UpdateCAL_ID(int id, int value);
        QueryModel UpdateCLI_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration