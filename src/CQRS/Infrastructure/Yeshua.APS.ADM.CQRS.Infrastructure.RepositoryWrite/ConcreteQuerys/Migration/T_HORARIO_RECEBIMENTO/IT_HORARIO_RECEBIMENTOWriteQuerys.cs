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

    public interface IT_HORARIO_RECEBIMENTOQueryWrite 
     {
        public QueryModel InserirT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO);
        public QueryModel UpdateT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO);
        QueryModel UpdateHRE_DIA_DA_SEMANA(int hre_id, int value);
        QueryModel UpdateHRE_HORA_INICIAL(int hre_id, DateTime value);
        QueryModel UpdateHRE_HORA_FINAL(int hre_id, DateTime value);
        QueryModel UpdateCLI_ID(int hre_id, string value);
        QueryModel UpdateTenantID(int hre_id, int value);
        QueryModel UpdateDeleted(int hre_id, bool value);
        QueryModel UpdateChanged(int hre_id, DateTime value);
        QueryModel UpdateUserId(int hre_id, int value);
        public QueryModel DeleteT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration