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

    public interface IT_MetasQueryWrite 
     {
        public QueryModel InserirT_MetasQuery(IT_MetasEntity T_Metas);
        public QueryModel UpdateT_MetasQuery(IT_MetasEntity T_Metas);
        QueryModel UpdateMET_DTINICIO(int met_id, string value);
        QueryModel UpdateMET_DTFIM(int met_id, string value);
        QueryModel UpdateMET_ALVO(int met_id, string value);
        QueryModel UpdateMET_TIPOALVO(int met_id, int value);
        QueryModel UpdateIND_ID(int met_id, int value);
        QueryModel UpdateMET_RANGE01(int met_id, Decimal value);
        QueryModel UpdateMET_RANGE02(int met_id, Decimal value);
        QueryModel UpdateMET_RANGE03(int met_id, Decimal value);
        QueryModel UpdateDIM_ID(int met_id, int value);
        QueryModel UpdateFAT_ID(int met_id, string value);
        QueryModel UpdateDIM_SUBDIMENSAO_ID(int met_id, string value);
        QueryModel UpdatePER_ID(int met_id, string value);
        QueryModel UpdateDOM_EMPRESA(int met_id, string value);
        QueryModel UpdateDOM_FILIAL(int met_id, string value);
        QueryModel UpdateTenantID(int met_id, int value);
        QueryModel UpdateDeleted(int met_id, bool value);
        QueryModel UpdateChanged(int met_id, DateTime value);
        QueryModel UpdateUserId(int met_id, int value);
        public QueryModel DeleteT_MetasQuery(IT_MetasEntity T_Metas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration