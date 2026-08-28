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

    public interface IParametrosDeCustoQueryWrite 
     {
        public QueryModel InserirParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto);
        public QueryModel UpdateParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto);
        QueryModel UpdatePAR_ID(int id, int value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateCUS_ID(int id, string value);
        QueryModel UpdatePAR_VALOR(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteParametrosDeCustoQuery(IParametrosDeCustoEntity ParametrosDeCusto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration