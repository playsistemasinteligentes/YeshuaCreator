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

    public interface IItensPackedQueryWrite 
     {
        public QueryModel InserirItensPackedQuery(IItensPackedEntity ItensPacked);
        public QueryModel UpdateItensPackedQuery(IItensPackedEntity ItensPacked);
        QueryModel UpdateIPA_ID(int id, int value);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateIPA_COORDC(int id, Decimal value);
        QueryModel UpdateIPA_COORDL(int id, Decimal value);
        QueryModel UpdateIPA_COORDA(int id, Decimal value);
        QueryModel UpdateIPA_DIMC(int id, Decimal value);
        QueryModel UpdateIPA_DIML(int id, Decimal value);
        QueryModel UpdateIPA_DIMA(int id, Decimal value);
        QueryModel UpdateIPA_QTD_POR_PALETE(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteItensPackedQuery(IItensPackedEntity ItensPacked);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration