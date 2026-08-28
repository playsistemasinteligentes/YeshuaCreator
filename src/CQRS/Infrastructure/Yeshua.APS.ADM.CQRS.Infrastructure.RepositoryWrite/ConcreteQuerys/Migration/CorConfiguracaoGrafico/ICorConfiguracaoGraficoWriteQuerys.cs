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

    public interface ICorConfiguracaoGraficoQueryWrite 
     {
        public QueryModel InserirCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico);
        public QueryModel UpdateCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico);
        QueryModel UpdateCOR_PERCENTUAL_INI(string cor_id, Decimal value);
        QueryModel UpdateCOR_PERCENTUAL_FIM(string cor_id, Decimal value);
        QueryModel UpdateCOR_DESCRICAO(string cor_id, string value);
        QueryModel UpdateTenantID(string cor_id, int value);
        QueryModel UpdateDeleted(string cor_id, bool value);
        QueryModel UpdateChanged(string cor_id, DateTime value);
        QueryModel UpdateUserId(string cor_id, int value);
        public QueryModel DeleteCorConfiguracaoGraficoQuery(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration