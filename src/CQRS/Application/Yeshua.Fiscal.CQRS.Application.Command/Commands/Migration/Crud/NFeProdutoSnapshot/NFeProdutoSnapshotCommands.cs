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
    public struct NFeProdutoSnapshotCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public string CorrelationId { get; set; }
        public string CargaId { get; set; }
        public string PedidoId { get; set; }
        public string ChaveAcesso { get; set; }
        public string EmitenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public string UFOrigem { get; set; }
        public string UFDestino { get; set; }
        public string MunicipioOrigemCodigoIbge { get; set; }
        public string MunicipioDestinoCodigoIbge { get; set; }
        public Decimal? ValorDocumento { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string XmlStorageKey { get; set; }
        public string SnapshotJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration