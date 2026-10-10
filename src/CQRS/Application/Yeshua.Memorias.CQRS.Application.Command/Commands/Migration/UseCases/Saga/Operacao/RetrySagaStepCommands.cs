// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Command.Interfaces;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record RetrySagaStepInputCommand : ICommand, IOperationalTelemetryCommand
{
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }

    public string OperationalEntity => "ySagaStep";
    public string? OperationalRecordId => null;
}

public partial record RetrySagaStepOutputCommand : ICommand
{
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public string StepKey { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup