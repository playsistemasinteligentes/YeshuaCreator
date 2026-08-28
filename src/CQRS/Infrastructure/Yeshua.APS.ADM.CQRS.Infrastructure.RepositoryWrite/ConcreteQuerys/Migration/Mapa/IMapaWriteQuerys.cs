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

    public interface IMapaQueryWrite 
     {
        public QueryModel InserirMapaQuery(IMapaEntity Mapa);
        public QueryModel UpdateMapaQuery(IMapaEntity Mapa);
        QueryModel UpdateMAP_ID(int id, int value);
        QueryModel UpdatePON_ID(int id, string value);
        QueryModel UpdatePON_ID_VIZINHO(int id, string value);
        QueryModel UpdateMAP_DISTANCIA(int id, Decimal value);
        QueryModel UpdateMAP_CUSTO_PEDAGIO_POR_EIXO(int id, Decimal value);
        QueryModel UpdateROD_ID(int id, int value);
        QueryModel UpdateMAP_ALTURA_ROD(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMapaQuery(IMapaEntity Mapa);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration