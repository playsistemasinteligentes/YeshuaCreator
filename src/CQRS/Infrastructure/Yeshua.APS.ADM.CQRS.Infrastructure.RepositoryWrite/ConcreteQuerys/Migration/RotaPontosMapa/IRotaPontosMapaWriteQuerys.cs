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

    public interface IRotaPontosMapaQueryWrite 
     {
        public QueryModel InserirRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa);
        public QueryModel UpdateRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa);
        QueryModel UpdateROT_ID(int id, string value);
        QueryModel UpdatePON_ID_DESTINO(int id, string value);
        QueryModel UpdatePON_ID_ORIGEM(int id, string value);
        QueryModel UpdateROT_CUSTO_TOTAL(int id, Decimal value);
        QueryModel UpdatePON_ID_ROTEIRO(int id, string value);
        QueryModel UpdateROT_ORDEM_ROTEIRO(int id, int value);
        QueryModel UpdateROT_TIPO(int id, string value);
        QueryModel UpdateROT_DISTANCIA(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration