// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// </yeshua>

using Command.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.UseCase
{
    public partial record RetrySagaStepInputCommand : ICommand, IOperationalTelemetryCommand
    {
        public int SagaId { get; set; }
        public int SagaStepId { get; set; }
        public string OperationalEntity => "ySagaStep";
        public string? OperationalRecordId => SagaStepId > 0 ? SagaStepId.ToString() : null;
    }

    public partial record RetrySagaStepOutputCommand : ICommand
    {
        public int SagaId { get; set; }
        public int SagaStepId { get; set; }
        public string StepKey { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
