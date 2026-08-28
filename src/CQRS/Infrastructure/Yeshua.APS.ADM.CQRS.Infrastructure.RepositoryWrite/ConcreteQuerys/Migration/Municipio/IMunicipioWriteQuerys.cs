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

    public interface IMunicipioQueryWrite 
     {
        public QueryModel InserirMunicipioQuery(IMunicipioEntity Municipio);
        public QueryModel UpdateMunicipioQuery(IMunicipioEntity Municipio);
        QueryModel UpdateMUN_NOME(string mun_id, string value);
        QueryModel UpdateUF_COD(string mun_id, string value);
        QueryModel UpdateMUN_CODIGO_IBGE(string mun_id, string value);
        QueryModel UpdateMUN_LATITUDE(string mun_id, Decimal value);
        QueryModel UpdateMUN_LONGITUDE(string mun_id, Decimal value);
        QueryModel UpdateMUN_ID_INTEGRACAO_ERP(string mun_id, string value);
        QueryModel UpdateMUN_CODIGO_SIAFI(string mun_id, string value);
        QueryModel UpdateMUN_CODIGO_CNPJ(string mun_id, string value);
        QueryModel UpdateMUN_DISTANCIA_KM(string mun_id, Decimal value);
        QueryModel UpdateTenantID(string mun_id, int value);
        QueryModel UpdateDeleted(string mun_id, bool value);
        QueryModel UpdateChanged(string mun_id, DateTime value);
        QueryModel UpdateUserId(string mun_id, int value);
        public QueryModel DeleteMunicipioQuery(IMunicipioEntity Municipio);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration