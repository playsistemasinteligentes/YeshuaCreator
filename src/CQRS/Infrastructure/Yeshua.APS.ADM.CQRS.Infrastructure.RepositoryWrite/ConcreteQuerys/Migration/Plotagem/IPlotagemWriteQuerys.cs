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

    public interface IPlotagemQueryWrite 
     {
        public QueryModel InserirPlotagemQuery(IPlotagemEntity Plotagem);
        public QueryModel UpdatePlotagemQuery(IPlotagemEntity Plotagem);
        QueryModel UpdatePLO_ID(int id, int value);
        QueryModel UpdatePLO_NOME(int id, string value);
        QueryModel UpdatePLO_DIMENSAO(int id, string value);
        QueryModel UpdatePLO_X(int id, string value);
        QueryModel UpdatePLO_Y(int id, string value);
        QueryModel UpdatePLO_Z(int id, string value);
        QueryModel UpdatePLO_GRAFICO(int id, string value);
        QueryModel UpdateCON_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePlotagemQuery(IPlotagemEntity Plotagem);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration