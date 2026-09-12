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
    public struct yOutboxCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string? MessageId { get; set; }
        public string Type { get; set; }
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? CorrelationId { get; set; }
        public string Payload { get; set; }
        public int Status { get; set; }
        public int TransportType { get; set; }
        public string? TransportData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int RetryCount { get; set; }
        public string? LastError { get; set; }
        public DateTime? ProcessingAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
        public int? SagaId { get; set; }
        public int? SagaStepId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration