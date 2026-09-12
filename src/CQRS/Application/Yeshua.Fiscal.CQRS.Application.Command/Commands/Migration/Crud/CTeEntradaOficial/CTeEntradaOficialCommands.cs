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
    public struct CTeEntradaOficialCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string SourceApplication { get; set; }
        public string? SourceModule { get; set; }
        public string SourceMessageId { get; set; }
        public string MessageType { get; set; }
        public string MessageVersion { get; set; }
        public DateTime ReceivedAtUtc { get; set; }
        public string PayloadHash { get; set; }
        public string? PayloadStorageKey { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration