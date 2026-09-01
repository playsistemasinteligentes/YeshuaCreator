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
public partial record GerarCenariosPlanejamentoTransporteInputCommand : ICommand
{
    public string ContextoId { get; set; }
    public string Objetivo { get; set; }
}

public partial record GerarCenariosPlanejamentoTransporteOutputCommand : ICommand
{
    public List<CenarioPlanejamentoEnvelope> Cenarios { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup