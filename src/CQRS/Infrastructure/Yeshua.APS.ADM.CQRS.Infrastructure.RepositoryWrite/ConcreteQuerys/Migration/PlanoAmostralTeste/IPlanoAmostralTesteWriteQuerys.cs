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

    public interface IPlanoAmostralTesteQueryWrite 
     {
        public QueryModel InserirPlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste);
        public QueryModel UpdatePlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste);
        QueryModel UpdateGRP_TIPO(int pat_id, Decimal value);
        QueryModel UpdateTenantID(int pat_id, int value);
        QueryModel UpdateDeleted(int pat_id, bool value);
        QueryModel UpdateChanged(int pat_id, DateTime value);
        QueryModel UpdateUserId(int pat_id, int value);
        QueryModel UpdatePAT_QTD_CAIXAS_DE(int pat_id, int value);
        QueryModel UpdatePAT_QTD_CAIXAS_ATE(int pat_id, int value);
        QueryModel UpdatePAT_N_AMOSTRAGEM(int pat_id, int value);
        QueryModel UpdatePAT_PERCENT_ESPECIF(int pat_id, Decimal value);
        public QueryModel DeletePlanoAmostralTesteQuery(IPlanoAmostralTesteEntity PlanoAmostralTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration