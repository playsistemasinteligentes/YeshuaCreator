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
    public partial class MemoriasHubCommand : ICommand
    {
    }

public partial record YouTubeConnectionInfo : ICommand
{
    public string ConexaoId { get; set; } = string.Empty;
    public string CanalId { get; set; } = string.Empty;
    public string CanalTitulo { get; set; } = string.Empty;
    public bool Conectado { get; set; }
}

public partial record VideoModelInfo : ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Movimento { get; set; } = string.Empty;
    public string Transicao { get; set; } = string.Empty;
    public int MusicaSugeridaId { get; set; }
}

public partial record MusicInfo : ICommand
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Licenca { get; set; } = string.Empty;
    public string UrlFonte { get; set; } = string.Empty;
    public string UrlLicenca { get; set; } = string.Empty;
    public string Creditos { get; set; } = string.Empty;
    public bool Disponivel { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup