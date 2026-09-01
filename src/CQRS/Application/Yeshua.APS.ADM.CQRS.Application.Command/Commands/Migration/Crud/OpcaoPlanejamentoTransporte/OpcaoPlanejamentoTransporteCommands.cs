// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct OpcaoPlanejamentoTransporteCrudCommand : ICommand
    {
        public string OpcaoId { get; set; }
        public string GrupoDecisaoId { get; set; }
        public Decimal? Peso { get; set; }
        public Decimal? Volume { get; set; }
        public Decimal? CustoEstimado { get; set; }
        public Decimal? AderenciaCubagem { get; set; }
        public Decimal? AderenciaJanelaEntrega { get; set; }
        public string RiscoResumo { get; set; }
        public string PedidosResumo { get; set; }
        public string OpcoesConflitantesResumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration