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
public partial record RevalidarSelecaoPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public List<PedidoPlanejamentoRef> Pedidos { get; set; } = default!;

    public string OperationalEntity => "PedidoPlanejavel";
    public string? OperationalRecordId => null;
}

public partial record RevalidarSelecaoPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Valida { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public List<PedidoPlanejamentoEnvelope> PedidosInvalidos { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup