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
public partial record ConfirmarProfissionalClinicaInputCommand : ICommand
{
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public int ProfissionalId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}

public partial record ConfirmarProfissionalClinicaOutputCommand : ICommand, ISagaStepStimulusOutput
{
    public bool Accepted { get; set; }
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public int InboxId { get; set; }
    public string CorrelationId { get; set; } = string.Empty;
    public string StepKey { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup