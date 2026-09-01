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
    public struct PedidoPlanejavelCrudCommand : ICommand
    {
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Regiao { get; set; }
        public string Bairro { get; set; }
        public string RotaId { get; set; }
        public DateTime? EmbarqueAlvo { get; set; }
        public DateTime? DataEntregaDe { get; set; }
        public DateTime? DataEntregaAte { get; set; }
        public Decimal? Peso { get; set; }
        public Decimal? Volume { get; set; }
        public Decimal? SaldoAExpedir { get; set; }
        public string Status { get; set; }
        public string CargaAtualId { get; set; }
        public string VersaoPlanejamento { get; set; }
        public string AlertasResumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration