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

    public interface IIndicadoresPeriodosDimencoesQueryWrite 
     {
        public QueryModel InserirIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes);
        public QueryModel UpdateIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes);
        QueryModel UpdatePER_ID(int id, string value);
        QueryModel UpdateIND_ID(int id, int value);
        QueryModel UpdateDIM_ID(int id, int value);
        QueryModel UpdatePER_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration