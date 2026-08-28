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

    public interface IItenCargaQueryWrite 
     {
        public QueryModel InserirItenCargaQuery(IItenCargaEntity ItenCarga);
        public QueryModel UpdateItenCargaQuery(IItenCargaEntity ItenCarga);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateITC_ENTREGA_PLANEJADA(int id, DateTime value);
        QueryModel UpdateITC_ENTREGA_REALIZADA(int id, DateTime value);
        QueryModel UpdateITC_ORDEM_ENTREGA(int id, int value);
        QueryModel UpdateITC_QTD_PLANEJADA(int id, Decimal value);
        QueryModel UpdateITC_QTD_REALIZADA(int id, Decimal value);
        QueryModel UpdateORD_HASH_KEY(int id, string value);
        QueryModel UpdateNOT_ID(int id, string value);
        QueryModel UpdateNOT_EMISSAO(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItenCargaQuery(IItenCargaEntity ItenCarga);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration