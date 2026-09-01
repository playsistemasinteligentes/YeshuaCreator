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
    public struct CenarioPlanejamentoTransporteCrudCommand : ICommand
    {
        public string CenarioId { get; set; }
        public string Descricao { get; set; }
        public string Objetivo { get; set; }
        public int? QuantidadeCargas { get; set; }
        public int? QuantidadePedidosNaoAtendidos { get; set; }
        public Decimal? CustoTotal { get; set; }
        public Decimal? AderenciaCubagem { get; set; }
        public Decimal? AtrasoPrevisto { get; set; }
        public string AlertasResumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration