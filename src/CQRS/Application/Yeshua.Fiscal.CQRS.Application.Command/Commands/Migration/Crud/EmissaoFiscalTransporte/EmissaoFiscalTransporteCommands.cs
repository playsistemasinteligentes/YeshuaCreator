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
    public struct EmissaoFiscalTransporteCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public int OrigemFluxo { get; set; }
        public string? CargaId { get; set; }
        public string? RomaneioId { get; set; }
        public int Ambiente { get; set; }
        public string? EmitenteDocumento { get; set; }
        public string? TomadorDocumento { get; set; }
        public string? TransportadorDocumento { get; set; }
        public string? UFInicio { get; set; }
        public string? UFFim { get; set; }
        public string? MunicipioInicioCodigoIbge { get; set; }
        public string? MunicipioFimCodigoIbge { get; set; }
        public int? QuantidadeNFe { get; set; }
        public int? QuantidadeCTe { get; set; }
        public int? QuantidadeMDFe { get; set; }
        public Decimal? ValorCarga { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string? UltimaMensagem { get; set; }
        public DateTime CriadoEmUtc { get; set; }
        public DateTime? AtualizadoEmUtc { get; set; }
        public DateTime? ConcluidoEmUtc { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration