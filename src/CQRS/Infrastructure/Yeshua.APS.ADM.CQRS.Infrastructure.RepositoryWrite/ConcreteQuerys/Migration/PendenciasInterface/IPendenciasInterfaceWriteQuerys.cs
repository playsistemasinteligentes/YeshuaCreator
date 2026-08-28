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

    public interface IPendenciasInterfaceQueryWrite 
     {
        public QueryModel InserirPendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface);
        public QueryModel UpdatePendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface);
        QueryModel UpdatePEN_STATUS_OUT(int pen_id, string value);
        QueryModel UpdatePEN_PROTOCOLO_OUT(int pen_id, string value);
        QueryModel UpdatePEN_ID_PROTOCOLO_OUT(int pen_id, string value);
        QueryModel UpdatePEN_STATUS_IN(int pen_id, string value);
        QueryModel UpdatePEN_PROTOCOLO_IN(int pen_id, string value);
        QueryModel UpdatePEN_ID_PROTOCOLO_IN(int pen_id, string value);
        QueryModel UpdateDATA_ENTRADA(int pen_id, DateTime value);
        QueryModel UpdateTenantID(int pen_id, int value);
        QueryModel UpdateDeleted(int pen_id, bool value);
        QueryModel UpdateChanged(int pen_id, DateTime value);
        QueryModel UpdateUserId(int pen_id, int value);
        public QueryModel DeletePendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration