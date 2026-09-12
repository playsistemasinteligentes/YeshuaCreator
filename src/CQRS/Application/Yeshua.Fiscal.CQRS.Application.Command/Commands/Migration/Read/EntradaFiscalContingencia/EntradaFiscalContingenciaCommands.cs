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
namespace Command.Read
{
    public struct EntradaFiscalContingenciaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string? CorrelationId { get; set; }
        public string? CargaId { get; set; }
        public int? TipoSolicitante { get; set; }
        public int? Ambiente { get; set; }
        public string? SourceApplication { get; set; }
        public string? SourceModule { get; set; }
        public string? SourceMessageId { get; set; }
        public string? EmitenteFiscalDocumento { get; set; }
        public string? TomadorDocumento { get; set; }
        public string? TransportadorDocumento { get; set; }
        public string? RemetenteDocumento { get; set; }
        public string? DestinatarioDocumento { get; set; }
        public string? UFInicio { get; set; }
        public string? UFFim { get; set; }
        public string? MunicipioInicioCodigoIbge { get; set; }
        public string? MunicipioFimCodigoIbge { get; set; }
        public string? RNTRC { get; set; }
        public string? PlacaVeiculo { get; set; }
        public string? UFVeiculo { get; set; }
        public string? CondutorDocumento { get; set; }
        public string? CondutorNome { get; set; }
        public int? QuantidadeDocumentos { get; set; }
        public Decimal? ValorCarga { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string? PendenciasJson { get; set; }
        public string? SnapshotJson { get; set; }
        public string? EmissaoFiscalCorrelationId { get; set; }
        public int? EmissaoFiscalSagaId { get; set; }
        public DateTime? CriadoEmUtc { get; set; }
        public DateTime? AtualizadoEmUtc { get; set; }
        public int? Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration