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
    public struct PublicacaoAlbumReadCommand : ICommandRead, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public int? AlbumId { get; set; }
        public string? CorrelationId { get; set; }
        public string? ManifestStorageKey { get; set; }
        public string? VideoStorageKey { get; set; }
        public string? YouTubeVideoId { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? Mensagem { get; set; }
        public DateTime? SolicitadaEmUtc { get; set; }
        public DateTime? PublicadaEmUtc { get; set; }
        public int? Status { get; set; }
        public string? OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
 public string OperationalEntity => "PublicacaoAlbum";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration