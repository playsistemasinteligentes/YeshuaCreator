using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Media;
using Dominio.Patterns.Domain;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers.UseCase;
using Command.UseCase;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class VideoPresentationTests
{
    [Theory]
    [InlineData(null, null, null, true)]
    [InlineData(1, 0, 0, true)]
    [InlineData(2, 1, 35, true)]
    [InlineData(3, 2, 100, true)]
    [InlineData(4, 3, 50, true)]
    [InlineData(5, 0, 35, false)]
    [InlineData(2, 4, 35, false)]
    [InlineData(2, 1, -1, false)]
    [InlineData(2, 1, 101, false)]
    public void ValidateSelectionsAndKeepZeroVolume(int? model, int? music, int? volume, bool valid)
    {
        var album = new AlbumFactory(TestProxy.For<Dominio.Interfaces.ILogger>()).Create(1, "Album", "", 1, 4, 1, 2, model, music, volume);
        var result = AlbumDomainBehavior.Apply(album, DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "PostAlbum", 7, 9));
        Assert.Equal(valid, result.IsValid);
        Assert.Equal(volume ?? 35, album.VolumeMusica);
        Assert.Equal(model is null or 0 ? 1 : model, album.ModeloVideo);
    }

    [Fact]
    public async Task CatalogueReturnsLicensedTracksAndServerAvailability()
    {
        var handler = new ConsultarModelosVideoHandler(TestProxy.For<Dominio.Interfaces.ILogger>(),
            TestProxy.For<Aplication.Interfaces.Services.IExecutionContext>(),
            TestProxy.For<IFileStorage>((_, args) => Task.FromResult(args[0]!.ToString()!.Contains("carefree"))));
        var state = await handler.ExecuteAsync(new ConsultarModelosVideoInputCommand());
        Assert.Equal(200, state.StatusCode);
        Assert.Equal(4, state.Data!.Modelos.Count);
        Assert.Equal(3, state.Data.Musicas.Count);
        Assert.All(state.Data.Musicas, track =>
        {
            Assert.Equal("CC BY 4.0", track.Licenca);
            Assert.Contains("Kevin MacLeod", track.Creditos);
            Assert.Contains(track.Titulo, track.Creditos);
            Assert.StartsWith("https://", track.UrlLicenca);
        });
        Assert.Single(state.Data.Musicas.Where(track => track.Disponivel));
        Assert.Equal(0, VideoPresentation.Models[0].SuggestedMusicId);
    }
}
