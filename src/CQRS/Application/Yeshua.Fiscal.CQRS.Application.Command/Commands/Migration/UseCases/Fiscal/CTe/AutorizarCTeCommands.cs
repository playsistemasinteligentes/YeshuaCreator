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
public partial record AutorizarCTeInputCommand : ICommand
{
    public int SolicitacaoId { get; set; }
    public int SincronoAteAutorizacao { get; set; }
}

public partial record AutorizarCTeOutputCommand : ICommand
{
    public int TentativaId { get; set; }
    public string ChaveAcesso { get; set; } = string.Empty;
    public bool Autorizado { get; set; }
    public string Protocolo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup