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
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record RevalidarSelecaoPlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public List<PedidoPlanejamentoRef> Pedidos { get; set; }
}

public partial record RevalidarSelecaoPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Valida { get; set; }
    public string Mensagem { get; set; }
    public List<PedidoPlanejamentoEnvelope> PedidosInvalidos { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup