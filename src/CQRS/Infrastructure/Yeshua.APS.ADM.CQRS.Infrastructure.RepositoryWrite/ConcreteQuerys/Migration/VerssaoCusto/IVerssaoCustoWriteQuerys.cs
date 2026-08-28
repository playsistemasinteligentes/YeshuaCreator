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

    public interface IVerssaoCustoQueryWrite 
     {
        public QueryModel InserirVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto);
        public QueryModel UpdateVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto);
        QueryModel UpdateVER_ID(int id, int value);
        QueryModel UpdateVER_STATUS(int id, string value);
        QueryModel UpdateVER_DATA_VERSSAO_CUSTO(int id, DateTime value);
        QueryModel UpdateVER_OBS(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteVerssaoCustoQuery(IVerssaoCustoEntity VerssaoCusto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration