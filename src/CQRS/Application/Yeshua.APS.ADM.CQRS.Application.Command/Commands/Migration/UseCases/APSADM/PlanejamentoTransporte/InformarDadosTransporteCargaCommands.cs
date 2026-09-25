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
public partial record InformarDadosTransporteCargaInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string CargaId { get; set; } = string.Empty;
    public string TransportadoraId { get; set; } = string.Empty;
    public string VeiculoPlaca { get; set; } = string.Empty;
    public int TipoVeiculoId { get; set; }
    public string VeiculoUf { get; set; } = string.Empty;
    public string CondutorNome { get; set; } = string.Empty;
    public string CondutorCpf { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;

    public string OperationalEntity => "Carga";
    public string? OperationalRecordId => CargaId;
}

public partial record InformarDadosTransporteCargaOutputCommand : ICommand, ISagaStepStimulusOutput
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string CargaId { get; set; } = string.Empty;
    public string ProximoStep { get; set; } = string.Empty;
    public bool Accepted { get; set; }
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public int InboxId { get; set; }
    public string CorrelationId { get; set; } = string.Empty;
    public string StepKey { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup