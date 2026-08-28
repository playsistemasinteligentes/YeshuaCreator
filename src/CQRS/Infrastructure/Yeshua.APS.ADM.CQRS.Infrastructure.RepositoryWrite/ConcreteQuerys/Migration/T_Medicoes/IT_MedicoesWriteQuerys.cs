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

    public interface IT_MedicoesQueryWrite 
     {
        public QueryModel InserirT_MedicoesQuery(IT_MedicoesEntity T_Medicoes);
        public QueryModel UpdateT_MedicoesQuery(IT_MedicoesEntity T_Medicoes);
        QueryModel UpdateMED_ID(int id, int value);
        QueryModel UpdateIND_ID(int id, int value);
        QueryModel UpdateMET_ID(int id, int value);
        QueryModel UpdateUNI_ID(int id, int value);
        QueryModel UpdateMED_DATA(int id, DateTime value);
        QueryModel UpdateMED_VALOR(int id, string value);
        QueryModel UpdateMED_AC_ANO(int id, string value);
        QueryModel UpdateMED_DATAMEDICAO(int id, string value);
        QueryModel UpdateMED_PONDERACAO(int id, Decimal value);
        QueryModel UpdateDIM_ID(int id, string value);
        QueryModel UpdateDIM_DESCRICAO(int id, string value);
        QueryModel UpdateDIM_SUBDIMENSAO_ID(int id, string value);
        QueryModel UpdateDIM_SUB_DESCRICAO(int id, string value);
        QueryModel UpdatePER_ID(int id, string value);
        QueryModel UpdatePER_DESCRICAO(int id, string value);
        QueryModel UpdateFAT_ID(int id, string value);
        QueryModel UpdateFAT_DESCRICAO(int id, string value);
        QueryModel UpdateMED_SQL(int id, string value);
        QueryModel UpdateDOM_EMPRESA(int id, string value);
        QueryModel UpdateDOM_FILIAL(int id, string value);
        QueryModel UpdateMED_VALOR_DISPER(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_MedicoesQuery(IT_MedicoesEntity T_Medicoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration