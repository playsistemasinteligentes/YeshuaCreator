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
public partial record CriarIdentidadeInputCommand : ICommand
{
    public string IdentidadeId { get; set; } = string.Empty;
    public string RegistroId { get; set; } = string.Empty;
    public string Chave { get; set; } = string.Empty;
    public int VersaoEsperada { get; set; }
    public string Dados { get; set; } = string.Empty;
}

public partial record CriarIdentidadeOutputCommand : ICommand
{
    public string Resultado { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup