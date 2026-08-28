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

    public interface IMedidasTesteQueryWrite 
     {
        public QueryModel InserirMedidasTesteQuery(IMedidasTesteEntity MedidasTeste);
        public QueryModel UpdateMedidasTesteQuery(IMedidasTesteEntity MedidasTeste);
        QueryModel UpdateMDT_ID(int id, int value);
        QueryModel UpdateMDT_DESC(int id, string value);
        QueryModel UpdateMDT_VALOR_ESPERADO(int id, Decimal value);
        QueryModel UpdateMDT_ENCONTRADO(int id, Decimal value);
        QueryModel UpdateUNI_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMedidasTesteQuery(IMedidasTesteEntity MedidasTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration