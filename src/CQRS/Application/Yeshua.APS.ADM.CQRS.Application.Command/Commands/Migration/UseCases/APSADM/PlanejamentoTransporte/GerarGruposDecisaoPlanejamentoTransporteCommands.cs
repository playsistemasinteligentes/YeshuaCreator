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
public partial record GerarGruposDecisaoPlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public string Objetivo { get; set; }
    public List<PedidoPlanejamentoRef> Pedidos { get; set; }
}

public partial record PedidoPlanejamentoRef : ICommand
{
    public string PedidoId { get; set; }
    public string VersaoPlanejamento { get; set; }
}

public partial record GerarGruposDecisaoPlanejamentoTransporteOutputCommand : ICommand
{
    public List<OpcaoPlanejamentoEnvelope> Opcoes { get; set; }
}

public partial record OpcaoPlanejamentoEnvelope : ICommand
{
    public string OpcaoId { get; set; }
    public string GrupoDecisaoId { get; set; }
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public decimal CustoEstimado { get; set; }
    public decimal AderenciaCubagem { get; set; }
    public string RiscoResumo { get; set; }
    public string PedidosResumo { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup