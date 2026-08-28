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

    public interface ICotasQueryWrite 
     {
        public QueryModel InserirCotasQuery(ICotasEntity Cotas);
        public QueryModel UpdateCotasQuery(ICotasEntity Cotas);
        QueryModel UpdateCOT_ID(int id, int value);
        QueryModel UpdateCOT_DATA_DE(int id, DateTime value);
        QueryModel UpdateCOT_DATA_ATE(int id, DateTime value);
        QueryModel UpdateCOT_VALOR(int id, Decimal value);
        QueryModel UpdateCOT_OCUPADO(int id, Decimal value);
        QueryModel UpdateREP_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCotasQuery(ICotasEntity Cotas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration