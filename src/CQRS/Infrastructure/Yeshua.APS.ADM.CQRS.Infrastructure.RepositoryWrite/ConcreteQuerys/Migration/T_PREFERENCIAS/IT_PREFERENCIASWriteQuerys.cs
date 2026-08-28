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

    public interface IT_PREFERENCIASQueryWrite 
     {
        public QueryModel InserirT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS);
        public QueryModel UpdateT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS);
        QueryModel UpdatePRE_ID(int id, int value);
        QueryModel UpdatePRE_DESCRICAO(int id, string value);
        QueryModel UpdatePRE_NAMESPACE(int id, string value);
        QueryModel UpdatePRE_TIPO(int id, string value);
        QueryModel UpdatePRE_VALOR(int id, string value);
        QueryModel UpdateUSE_ID(int id, int value);
        QueryModel UpdatePER_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_PREFERENCIASQuery(IT_PREFERENCIASEntity T_PREFERENCIAS);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration