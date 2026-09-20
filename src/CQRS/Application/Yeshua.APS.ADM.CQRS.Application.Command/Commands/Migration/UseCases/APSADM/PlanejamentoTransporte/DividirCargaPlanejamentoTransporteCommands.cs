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
public partial record DividirCargaPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string CargaId { get; set; } = string.Empty;
    public List<PedidoPlanejamentoRef> PedidosPrimeiraCarga { get; set; } = default!;
    public List<PedidoPlanejamentoRef> PedidosSegundaCarga { get; set; } = default!;

    public string OperationalEntity => "Carga";
    public string? OperationalRecordId => CargaId;
}

public partial record DividirCargaPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup