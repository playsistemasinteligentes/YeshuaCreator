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

    public interface IRoteiroQueryWrite 
     {
        public QueryModel InserirRoteiroQuery(IRoteiroEntity Roteiro);
        public QueryModel UpdateRoteiroQuery(IRoteiroEntity Roteiro);
        QueryModel UpdateGrupoMaquinaId(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdatePecasPorPulso(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdatePrioridadeInformada(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateAcao(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdatePerformance(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateTempoSetup(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateTempoSetupAjuste(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateProximaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdateStatus(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateHierarquiaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateAvaliaCusto(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdateOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateExcecaoOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdatePercentualInicioPassoAnterior(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateLinhaDireta(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateTemplateDeTestesId(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdateTenantID(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdateDeleted(string maquinaid, string produtoid, int sequenciatransformacao, bool value);
        QueryModel UpdateChanged(string maquinaid, string produtoid, int sequenciatransformacao, DateTime value);
        QueryModel UpdateUserId(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration