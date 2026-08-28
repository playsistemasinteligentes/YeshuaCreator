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

    public interface ICompensacaoQueryWrite 
     {
        public QueryModel InserirCompensacaoQuery(ICompensacaoEntity Compensacao);
        public QueryModel UpdateCompensacaoQuery(ICompensacaoEntity Compensacao);
        QueryModel UpdateCOM_ID(int id, int value);
        QueryModel UpdateGRP_ID(int id, string value);
        QueryModel UpdateOND_ID(int id, string value);
        QueryModel UpdateCOM_VINCO1_OND(int id, int value);
        QueryModel UpdateCOM_VINCO2_OND(int id, int value);
        QueryModel UpdateCOM_VINCO3_OND(int id, int value);
        QueryModel UpdateCOM_VINCO4_OND(int id, int value);
        QueryModel UpdateCOM_VINCO5_OND(int id, int value);
        QueryModel UpdateCOM_VINCO6_OND(int id, int value);
        QueryModel UpdateCOM_VINCO7_OND(int id, int value);
        QueryModel UpdateCOM_VINCO8_OND(int id, int value);
        QueryModel UpdateCOM_VINCO9_OND(int id, int value);
        QueryModel UpdateCOM_VINCO10_OND(int id, int value);
        QueryModel UpdateCOM_VINCO1_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO2_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO3_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO4_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO5_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO6_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO7_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO8_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO9_CONVERSAO(int id, int value);
        QueryModel UpdateCOM_VINCO10_CONVERSAO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCompensacaoQuery(ICompensacaoEntity Compensacao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration