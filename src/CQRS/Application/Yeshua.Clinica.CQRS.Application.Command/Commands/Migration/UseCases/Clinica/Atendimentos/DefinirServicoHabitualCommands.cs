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
public partial record DefinirServicoHabitualInputCommand : ICommand
{
    public int ServicoId { get; set; }
}

public partial record DefinirServicoHabitualOutputCommand : ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int ModeloConsulta { get; set; }
    public int VersaoModeloConsulta { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup