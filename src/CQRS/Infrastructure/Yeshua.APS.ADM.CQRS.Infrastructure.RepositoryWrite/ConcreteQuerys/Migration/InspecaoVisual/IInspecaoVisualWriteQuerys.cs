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

    public interface IInspecaoVisualQueryWrite 
     {
        public QueryModel InserirInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual);
        public QueryModel UpdateInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual);
        QueryModel UpdateIPV_VALOR(int ipv_id, string value);
        QueryModel UpdateIPV_ID_OPERADOR(int ipv_id, int value);
        QueryModel UpdateIPV_ID_LIBERACAO(int ipv_id, int value);
        QueryModel UpdateIPV_OBS(int ipv_id, string value);
        QueryModel UpdateIPV_DATA_COLETA(int ipv_id, DateTime value);
        QueryModel UpdateIPV_DATA_AVAL(int ipv_id, DateTime value);
        QueryModel UpdateTIV_ID(int ipv_id, int value);
        QueryModel UpdateTURN_ID(int ipv_id, string value);
        QueryModel UpdateTURM_ID(int ipv_id, string value);
        QueryModel UpdateORD_ID(int ipv_id, string value);
        QueryModel UpdateROT_PRO_ID(int ipv_id, string value);
        QueryModel UpdateROT_MAQ_ID(int ipv_id, string value);
        QueryModel UpdateROT_SEQ_TRANSFORMACAO(int ipv_id, int value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int ipv_id, int value);
        QueryModel UpdateIPV_STATUS_LIBERACAO(int ipv_id, string value);
        QueryModel UpdateIPV_VALOR_MEDIDA(int ipv_id, Decimal value);
        QueryModel UpdateTenantID(int ipv_id, int value);
        QueryModel UpdateDeleted(int ipv_id, bool value);
        QueryModel UpdateChanged(int ipv_id, DateTime value);
        QueryModel UpdateUserId(int ipv_id, int value);
        public QueryModel DeleteInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration