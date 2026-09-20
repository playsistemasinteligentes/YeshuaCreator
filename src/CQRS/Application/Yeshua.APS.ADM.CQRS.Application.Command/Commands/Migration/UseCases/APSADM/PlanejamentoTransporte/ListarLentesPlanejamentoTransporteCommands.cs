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
public partial record ListarLentesPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;

    public string OperationalEntity => "PedidoPlanejavel";
    public string? OperationalRecordId => null;
}

public partial record ListarLentesPlanejamentoTransporteOutputCommand : ICommand
{
    public List<PlanejamentoLenteResumo> Lentes { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup