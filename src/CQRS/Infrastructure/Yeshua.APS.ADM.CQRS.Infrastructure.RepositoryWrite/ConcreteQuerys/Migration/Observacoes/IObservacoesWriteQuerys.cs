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

    public interface IObservacoesQueryWrite 
     {
        public QueryModel InserirObservacoesQuery(IObservacoesEntity Observacoes);
        public QueryModel UpdateObservacoesQuery(IObservacoesEntity Observacoes);
        QueryModel UpdateOBS_TIPO(int obs_id, string value);
        QueryModel UpdateOBS_DESCRICAO(int obs_id, string value);
        QueryModel UpdateCLI_ID(int obs_id, string value);
        QueryModel UpdateMAQ_ID(int obs_id, string value);
        QueryModel UpdatePRO_ID(int obs_id, string value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int obs_id, int value);
        QueryModel UpdateOBS_INTEGRACAO(int obs_id, string value);
        QueryModel UpdateTenantID(int obs_id, int value);
        QueryModel UpdateDeleted(int obs_id, bool value);
        QueryModel UpdateChanged(int obs_id, DateTime value);
        QueryModel UpdateUserId(int obs_id, int value);
        public QueryModel DeleteObservacoesQuery(IObservacoesEntity Observacoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration