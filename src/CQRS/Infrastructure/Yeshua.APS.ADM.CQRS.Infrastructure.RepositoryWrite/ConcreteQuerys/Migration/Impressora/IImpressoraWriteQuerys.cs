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

    public interface IImpressoraQueryWrite 
     {
        public QueryModel InserirImpressoraQuery(IImpressoraEntity Impressora);
        public QueryModel UpdateImpressoraQuery(IImpressoraEntity Impressora);
        QueryModel UpdateIMP_IP(int imp_id, string value);
        QueryModel UpdateIMP_NOME(int imp_id, string value);
        QueryModel UpdateTenantID(int imp_id, int value);
        QueryModel UpdateDeleted(int imp_id, bool value);
        QueryModel UpdateChanged(int imp_id, DateTime value);
        QueryModel UpdateUserId(int imp_id, int value);
        public QueryModel DeleteImpressoraQuery(IImpressoraEntity Impressora);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration