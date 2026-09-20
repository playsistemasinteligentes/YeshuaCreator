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
public partial record AplicarCenarioPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public string CenarioId { get; set; } = string.Empty;

    public string OperationalEntity => "CenarioPlanejamentoTransporte";
    public string? OperationalRecordId => null;
}

public partial record AplicarCenarioPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup