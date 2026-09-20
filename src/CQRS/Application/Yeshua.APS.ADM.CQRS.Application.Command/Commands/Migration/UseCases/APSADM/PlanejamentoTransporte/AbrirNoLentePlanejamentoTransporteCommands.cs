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
public partial record AbrirNoLentePlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public string LenteId { get; set; } = string.Empty;
    public string NoId { get; set; } = string.Empty;
    public int Nivel { get; set; }

    public string OperationalEntity => "PedidoPlanejavel";
    public string? OperationalRecordId => null;
}

public partial record AbrirNoLentePlanejamentoTransporteOutputCommand : ICommand
{
    public List<PlanejamentoNoLenteResumo> Nos { get; set; } = default!;
    public List<PedidoPlanejamentoEnvelope> Pedidos { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup