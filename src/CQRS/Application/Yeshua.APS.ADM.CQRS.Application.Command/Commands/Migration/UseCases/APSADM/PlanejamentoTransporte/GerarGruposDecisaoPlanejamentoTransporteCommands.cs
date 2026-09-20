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
public partial record GerarGruposDecisaoPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public string Objetivo { get; set; } = string.Empty;
    public List<PedidoPlanejamentoRef> Pedidos { get; set; } = default!;

    public string OperationalEntity => "OpcaoPlanejamentoTransporte";
    public string? OperationalRecordId => null;
}

public partial record GerarGruposDecisaoPlanejamentoTransporteOutputCommand : ICommand
{
    public List<OpcaoPlanejamentoEnvelope> Opcoes { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup