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

    public interface IClpMedicoesHQueryWrite 
     {
        public QueryModel InserirClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH);
        public QueryModel UpdateClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH);
        QueryModel UpdateMAQUINA_ID(int id, string value);
        QueryModel UpdateDATA_INI(int id, DateTime value);
        QueryModel UpdateDATA_FIM(int id, DateTime value);
        QueryModel UpdateCLP_EMISSAO(int id, DateTime value);
        QueryModel UpdateQTD(int id, Decimal value);
        QueryModel UpdateGRUPO(int id, Decimal value);
        QueryModel UpdateSTATUS(int id, int value);
        QueryModel UpdateURN_ID(int id, string value);
        QueryModel UpdateURM_ID(int id, string value);
        QueryModel UpdateID_LOTE_CLP(int id, int value);
        QueryModel UpdateOCO_ID(int id, string value);
        QueryModel UpdateFASE(int id, int value);
        QueryModel UpdateCLP_ORIGEM(int id, string value);
        QueryModel UpdateCLP_LOTE(int id, int value);
        QueryModel UpdateCOMPACTA(int id, int value);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateCOR_SEQUENCIA(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteClpMedicoesHQuery(IClpMedicoesHEntity ClpMedicoesH);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration