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
public partial record PublicarCTeAutorizadoParaMDFeInputCommand : ICommand
{
    public int TentativaEmissaoId { get; set; }
    public string ChaveAcessoCTe { get; set; }
}

public partial record PublicarCTeAutorizadoParaMDFeOutputCommand : ICommand
{
    public bool Publicado { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup