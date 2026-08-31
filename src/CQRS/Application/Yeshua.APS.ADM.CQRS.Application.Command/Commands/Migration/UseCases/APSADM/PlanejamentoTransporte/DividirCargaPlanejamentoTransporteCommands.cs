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
public partial record DividirCargaPlanejamentoTransporteInputCommand : ICommand
{
    public string CargaId { get; set; }
    public List<PedidoPlanejamentoRef> PedidosPrimeiraCarga { get; set; }
    public List<PedidoPlanejamentoRef> PedidosSegundaCarga { get; set; }
}

public partial record PedidoPlanejamentoRef : ICommand
{
    public string PedidoId { get; set; }
    public string VersaoPlanejamento { get; set; }
}

public partial record DividirCargaPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup