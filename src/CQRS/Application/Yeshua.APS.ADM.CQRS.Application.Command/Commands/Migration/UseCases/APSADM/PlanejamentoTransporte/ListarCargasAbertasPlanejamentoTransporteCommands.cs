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
public partial record ListarCargasAbertasPlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
}

public partial record ListarCargasAbertasPlanejamentoTransporteOutputCommand : ICommand
{
    public List<CargaPlanejamentoEnvelope> Cargas { get; set; }
}

public partial record CargaPlanejamentoEnvelope : ICommand
{
    public string CargaId { get; set; }
    public string Status { get; set; }
    public decimal Peso { get; set; }
    public decimal Volume { get; set; }
    public int QuantidadePedidos { get; set; }
    public string AlertasResumo { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup