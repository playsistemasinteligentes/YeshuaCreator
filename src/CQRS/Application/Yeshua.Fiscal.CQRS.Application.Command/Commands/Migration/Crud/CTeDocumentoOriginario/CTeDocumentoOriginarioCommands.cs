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
    public struct CTeDocumentoOriginarioCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int CTeSolicitacaoFiscalId { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public string TipoDocumento { get; set; }
        public string? ChaveAcesso { get; set; }
        public string? Numero { get; set; }
        public string? Serie { get; set; }
        public string? EmitenteDocumento { get; set; }
        public string? DestinatarioDocumento { get; set; }
        public Decimal? ValorDocumento { get; set; }
        public Decimal? PesoBruto { get; set; }
        public string? SnapshotJson { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration