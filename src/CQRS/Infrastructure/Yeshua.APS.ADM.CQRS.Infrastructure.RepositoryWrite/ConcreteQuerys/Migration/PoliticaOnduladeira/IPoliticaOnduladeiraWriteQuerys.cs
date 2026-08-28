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

    public interface IPoliticaOnduladeiraQueryWrite 
     {
        public QueryModel InserirPoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira);
        public QueryModel UpdatePoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira);
        QueryModel UpdatePOL_ID(int id, int value);
        QueryModel UpdatePOL_NIVEL(int id, int value);
        QueryModel UpdatePOL_PROMOCAO(int id, int value);
        QueryModel UpdatePOL_DIAS_ANTECIPACAO(int id, int value);
        QueryModel UpdatePOL_METROS_LINEARES(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePoliticaOnduladeiraQuery(IPoliticaOnduladeiraEntity PoliticaOnduladeira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration