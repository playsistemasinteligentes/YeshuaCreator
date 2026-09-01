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
public partial record AbrirNoLentePlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public string LenteId { get; set; }
    public string NoId { get; set; }
    public int Nivel { get; set; }
}

public partial record AbrirNoLentePlanejamentoTransporteOutputCommand : ICommand
{
    public List<PlanejamentoNoLenteResumo> Nos { get; set; }
    public List<PedidoPlanejamentoEnvelope> Pedidos { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup