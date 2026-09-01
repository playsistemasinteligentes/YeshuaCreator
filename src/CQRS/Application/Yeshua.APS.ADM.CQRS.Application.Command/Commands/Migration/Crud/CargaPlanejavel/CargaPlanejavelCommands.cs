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
    public struct CargaPlanejavelCrudCommand : ICommand
    {
        public string CargaId { get; set; }
        public string Status { get; set; }
        public string TransportadoraId { get; set; }
        public string VeiculoId { get; set; }
        public int? TipoVeiculoId { get; set; }
        public Decimal? PesoTeorico { get; set; }
        public Decimal? VolumeTeorico { get; set; }
        public DateTime? InicioJanelaEmbarque { get; set; }
        public DateTime? FimJanelaEmbarque { get; set; }
        public DateTime? EmbarqueAlvo { get; set; }
        public int? QuantidadePedidos { get; set; }
        public string AlertasResumo { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration