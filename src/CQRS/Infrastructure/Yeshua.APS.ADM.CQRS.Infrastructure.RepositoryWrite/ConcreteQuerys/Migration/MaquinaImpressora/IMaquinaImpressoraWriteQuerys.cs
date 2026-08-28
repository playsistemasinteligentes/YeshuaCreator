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

    public interface IMaquinaImpressoraQueryWrite 
     {
        public QueryModel InserirMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora);
        public QueryModel UpdateMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora);
        QueryModel UpdateMAQ_ID(int maq_imp_id, string value);
        QueryModel UpdateIMP_ID(int maq_imp_id, int value);
        QueryModel UpdateMAI_FACAO(int maq_imp_id, int value);
        QueryModel UpdateTenantID(int maq_imp_id, int value);
        QueryModel UpdateDeleted(int maq_imp_id, bool value);
        QueryModel UpdateChanged(int maq_imp_id, DateTime value);
        QueryModel UpdateUserId(int maq_imp_id, int value);
        public QueryModel DeleteMaquinaImpressoraQuery(IMaquinaImpressoraEntity MaquinaImpressora);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration