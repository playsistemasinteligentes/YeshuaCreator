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

    public interface IOcorrenciaQueryWrite 
     {
        public QueryModel InserirOcorrenciaQuery(IOcorrenciaEntity Ocorrencia);
        public QueryModel UpdateOcorrenciaQuery(IOcorrenciaEntity Ocorrencia);
        QueryModel UpdateOCO_DESCRICAO(string oco_id, string value);
        QueryModel UpdateTIP_ID(string oco_id, int value);
        QueryModel UpdateGMA_ID(string oco_id, string value);
        QueryModel UpdateMAQ_ID(string oco_id, string value);
        QueryModel UpdateSPR(string oco_id, int value);
        QueryModel UpdateOCO_SUB_TIPO(string oco_id, string value);
        QueryModel UpdateSUB_ID(string oco_id, string value);
        QueryModel UpdateTenantID(string oco_id, int value);
        QueryModel UpdateDeleted(string oco_id, bool value);
        QueryModel UpdateChanged(string oco_id, DateTime value);
        QueryModel UpdateUserId(string oco_id, int value);
        public QueryModel DeleteOcorrenciaQuery(IOcorrenciaEntity Ocorrencia);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration