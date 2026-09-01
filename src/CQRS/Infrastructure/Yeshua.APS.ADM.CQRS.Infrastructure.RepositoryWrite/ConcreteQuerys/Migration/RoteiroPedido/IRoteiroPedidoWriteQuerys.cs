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

    public interface IRoteiroPedidoQueryWrite 
     {
        public QueryModel InserirRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido);
        public QueryModel UpdateRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido);
        QueryModel UpdateStatusCadastro(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateTipoPlanejamento(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateCalendarioId(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdateHierarquiaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateProximaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdatePerformance(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateTempoSetup(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateTempoSetupAjuste(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdatePecasPorPulso(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdatePrioridadeInformada(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateStatus(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateExcecaoOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateLinhaDireta(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        QueryModel UpdateAvaliaCusto(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        QueryModel UpdatePercentualInicioPassoAnterior(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateMaquinaLarguraUtil(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateGrupoTipo(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        QueryModel UpdateGrupoPerformanceMetroLinear(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        public QueryModel DeleteRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration