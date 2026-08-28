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

    public interface IFechamentoTesteQueryWrite 
     {
        public QueryModel InserirFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste);
        public QueryModel UpdateFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste);
        QueryModel UpdateFEC_ID(int id, int value);
        QueryModel UpdateFEC_QTD(int id, int value);
        QueryModel UpdateGRP_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteFechamentoTesteQuery(IFechamentoTesteEntity FechamentoTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration