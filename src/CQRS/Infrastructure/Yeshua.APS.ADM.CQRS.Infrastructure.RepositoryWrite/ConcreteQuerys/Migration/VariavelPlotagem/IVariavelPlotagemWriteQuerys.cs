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

    public interface IVariavelPlotagemQueryWrite 
     {
        public QueryModel InserirVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem);
        public QueryModel UpdateVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem);
        QueryModel UpdateVAR_ID(int id, int value);
        QueryModel UpdatePLO_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteVariavelPlotagemQuery(IVariavelPlotagemEntity VariavelPlotagem);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration