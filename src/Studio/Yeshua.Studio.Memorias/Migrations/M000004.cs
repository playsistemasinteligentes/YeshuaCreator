using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000004)]
public sealed class M000004 : MigrationBase
{
    public override void Up()
    {
        var commands = AddUsecaseGroup("Memorias").AddUseCaseSubGrup("YouTube");
        commands.AddCommand("ConsultarConfiguracaoYouTube", new YouTubeConfigurationReadInput(), new YouTubeConfigurationOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.configurar");
        commands.AddCommand("SalvarConfiguracaoYouTube", new YouTubeConfigurationSaveInput(), new YouTubeConfigurationOutput())
            .Authorization(Authorization.User).AddScope("memorias.youtube.configurar");
    }
}

public sealed record YouTubeConfigurationReadInput();
public sealed record YouTubeConfigurationSaveInput(string ClientId = "", string ClientSecret = "");
public sealed record YouTubeConfigurationOutput(
    bool PodeConfigurar = false, bool Configurado = false, string ClientId = "",
    string RedirectUri = "", bool SegredoSalvo = false, string AtualizadoEmUtc = "");
