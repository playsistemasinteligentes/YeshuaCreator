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
    public struct ySagaStepCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public int SagaId { get; set; }
        public string StepKey { get; set; }
        public int IndexOrder { get; set; }
        public string CorrelationId { get; set; }
        public int Status { get; set; }
        public int ExecutionCount { get; set; }
        public DateTime? LastExecutionAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Payload { get; set; }
        public int RetryCount { get; set; }
        public string? RootOperationId { get; set; }
        public string? OperationId { get; set; }
        public string? ExecutionId { get; set; }
        public string? CausationId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public string OperationalEntityId { get; set; }
 public string OperationalEntity => "ySagaStep";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration