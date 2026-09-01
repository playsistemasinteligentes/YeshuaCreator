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
public partial record CriarCargaDaSelecaoPlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public List<PedidoPlanejamentoRef> Pedidos { get; set; }
    public string TipoVeiculoId { get; set; }
    public string Observacao { get; set; }
}

public partial record CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand : ICommand
{
    public string CargaId { get; set; }
    public bool Criada { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup