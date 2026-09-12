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
    public struct EmissaoFiscalTransporteDocumentoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int EmissaoFiscalTransporteId { get; set; }
        public int? DocumentoFiscalId { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public int? NFeProdutoSnapshotId { get; set; }
        public int ProdutoFiscal { get; set; }
        public int Papel { get; set; }
        public string? TipoEvento { get; set; }
        public string? ChaveAcesso { get; set; }
        public string? XmlStorageKey { get; set; }
        public string? PdfStorageKey { get; set; }
        public string? Protocolo { get; set; }
        public string? CodigoRetorno { get; set; }
        public string? MensagemRetorno { get; set; }
        public DateTime CriadoEmUtc { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration