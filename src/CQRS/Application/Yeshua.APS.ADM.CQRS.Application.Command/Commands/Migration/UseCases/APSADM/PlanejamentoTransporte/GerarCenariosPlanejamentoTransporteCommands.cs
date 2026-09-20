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
public partial record GerarCenariosPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public string Objetivo { get; set; } = string.Empty;

    public string OperationalEntity => "CenarioPlanejamentoTransporte";
    public string? OperationalRecordId => null;
}

public partial record GerarCenariosPlanejamentoTransporteOutputCommand : ICommand
{
    public List<CenarioPlanejamentoEnvelope> Cenarios { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup