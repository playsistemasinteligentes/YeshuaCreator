using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000007)]
public sealed class M000007 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Apresentacao")
            .AddCommand("ConsultarModelosVideo", new PresentationInput(), new PresentationOutput())
            .Authorization(Authorization.User).AddScope("memorias.album.consultar");
    }
}

public sealed record PresentationInput();
public sealed class PresentationOutput
{
    public List<VideoModelInfo> Modelos { get; set; } = [];
    public List<MusicInfo> Musicas { get; set; } = [];
}
public sealed record VideoModelInfo(int Id, string Nome, string Movimento, string Transicao, int MusicaSugeridaId);
public sealed record MusicInfo(int Id, string Titulo, string Autor, string Categoria, string Licenca,
    string UrlFonte, string UrlLicenca, string Creditos, bool Disponivel);
