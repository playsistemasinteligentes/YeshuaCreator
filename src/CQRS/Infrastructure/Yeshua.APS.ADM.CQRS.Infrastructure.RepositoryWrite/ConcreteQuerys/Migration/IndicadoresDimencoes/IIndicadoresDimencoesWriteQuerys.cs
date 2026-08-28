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

    public interface IIndicadoresDimencoesQueryWrite 
     {
        public QueryModel InserirIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes);
        public QueryModel UpdateIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes);
        QueryModel UpdateDIM_ID(int id, int value);
        QueryModel UpdateIND_ID(int id, int value);
        QueryModel UpdateDIM_DESCRICAO(int id, string value);
        QueryModel UpdateDIM_SQL(int id, string value);
        QueryModel UpdateDIM_CONEXAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration