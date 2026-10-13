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
public partial record DesconectarYouTubeInputCommand : ICommand
{
    public string ConexaoId { get; set; } = string.Empty;
}

public partial record DesconectarYouTubeOutputCommand : ICommand
{
    public bool Configurado { get; set; }
    public bool Conectado { get; set; }
    public string CanalId { get; set; } = string.Empty;
    public string CanalTitulo { get; set; } = string.Empty;
    public string AuthorizationUrl { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public string ConexaoId { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup