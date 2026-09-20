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
public partial record BuscarContextoPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public DateTime EmbarqueDe { get; set; }
    public DateTime EmbarqueAte { get; set; }
    public string PlantaId { get; set; } = string.Empty;
    public int LimitePedidos { get; set; }

    public string OperationalEntity => "PedidoPlanejavel";
    public string? OperationalRecordId => null;
}

public partial record BuscarContextoPlanejamentoTransporteOutputCommand : ICommand
{
    public string ContextoId { get; set; } = string.Empty;
    public DateTime GeradoEm { get; set; }
    public int QuantidadePedidos { get; set; }
    public int QuantidadeCargas { get; set; }
    public List<PlanejamentoLenteResumo> Lentes { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup