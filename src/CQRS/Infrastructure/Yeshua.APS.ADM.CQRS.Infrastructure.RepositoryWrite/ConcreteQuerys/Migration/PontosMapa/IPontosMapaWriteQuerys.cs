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

    public interface IPontosMapaQueryWrite 
     {
        public QueryModel InserirPontosMapaQuery(IPontosMapaEntity PontosMapa);
        public QueryModel UpdatePontosMapaQuery(IPontosMapaEntity PontosMapa);
        QueryModel UpdatePON_DESCRICAO(string pon_id, string value);
        QueryModel UpdatePON_TIPO(string pon_id, string value);
        QueryModel UpdatePON_LATITUDE(string pon_id, Decimal value);
        QueryModel UpdatePON_LONGITUDE(string pon_id, Decimal value);
        QueryModel UpdatePON_DISTANCIA_KM(string pon_id, Decimal value);
        QueryModel UpdateTenantID(string pon_id, int value);
        QueryModel UpdateDeleted(string pon_id, bool value);
        QueryModel UpdateChanged(string pon_id, DateTime value);
        QueryModel UpdateUserId(string pon_id, int value);
        public QueryModel DeletePontosMapaQuery(IPontosMapaEntity PontosMapa);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration