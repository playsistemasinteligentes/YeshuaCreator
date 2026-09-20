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
public partial record CriarCargaDaSelecaoPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ContextoId { get; set; } = string.Empty;
    public List<PedidoPlanejamentoRef> Pedidos { get; set; } = default!;
    public string TipoVeiculoId { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;

    public string OperationalEntity => "Carga";
    public string? OperationalRecordId => null;
}

public partial record CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand : ICommand
{
    public string CargaId { get; set; } = string.Empty;
    public bool Criada { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup