using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000007)]
public sealed class M000007 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("Album")
            .AddColumn("ModeloVideo", "Modelo do Video").Int().Group("Apresentacao")
                .Enumerable(1, "Classico").Enumerable(2, "Romantico").Enumerable(3, "Aventura").Enumerable(4, "Celebracao")
            .AddColumn("MusicaId", "Musica").Int().Group("Apresentacao")
                .Enumerable(0, "Sem musica").Enumerable(1, "Air Prelude").Enumerable(2, "Adventure Meme").Enumerable(3, "Carefree")
            .AddColumn("VolumeMusica", "Volume da Musica (%)").Int().Group("Apresentacao");

        AlterEntity("PublicacaoAlbum")
            .AddColumn("ModeloVideo", "Modelo do Video").Int().Immutable().EditFront(false).Group("Apresentacao")
                .Enumerable(1, "Classico").Enumerable(2, "Romantico").Enumerable(3, "Aventura").Enumerable(4, "Celebracao")
            .AddColumn("MusicaId", "Musica").Int().Immutable().EditFront(false).Group("Apresentacao")
                .Enumerable(0, "Sem musica").Enumerable(1, "Air Prelude").Enumerable(2, "Adventure Meme").Enumerable(3, "Carefree")
            .AddColumn("VolumeMusica", "Volume da Musica (%)").Int().Immutable().EditFront(false).Group("Apresentacao");

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
