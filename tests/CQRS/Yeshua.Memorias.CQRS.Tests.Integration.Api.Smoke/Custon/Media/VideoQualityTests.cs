using System.Text.Json;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Media;
using Dominio.Patterns.Domain;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class VideoQualityTests
{
    [Theory]
    [InlineData(null, 2, 1920, 1080, 18)]
    [InlineData(0, 2, 1920, 1080, 18)]
    [InlineData(1, 1, 1280, 720, 23)]
    [InlineData(2, 2, 1920, 1080, 18)]
    [InlineData(3, 3, 3840, 2160, 18)]
    public void ProfilesHaveStableIdsAndLegacyDefault(int? selected, int id, int width, int height, int crf)
    {
        Assert.True(VideoQualityProfiles.TryResolve(selected, out var profile));
        Assert.Equal(new VideoQualityProfile((VideoQuality)id, width, height, crf), profile);
    }

    [Theory]
    [InlineData(null, 2)]
    [InlineData(0, 2)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    public void AlbumDomainNormalizesLegacyAndAcceptsAllClasses(int? selected, int expected)
    {
        var album = new AlbumFactory(TestProxy.For<Dominio.Interfaces.ILogger>()).Create(
            id: 1, titulo: "Album", descricao: "", privacidade: 1, segundosporfoto: 4,
            status: 1, qualidadevideo: selected, modelovideo: null, musicaid: null, volumemusica: null);
        var result = AlbumDomainBehavior.Apply(album, DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "PostAlbum", 7, 9));
        Assert.True(result.IsValid, string.Join("; ", result.Errors));
        Assert.Equal(expected, album.QualidadeVideo);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    [InlineData(99)]
    public void InvalidQualityIsNotSilentlyReplaced(int quality)
    {
        Assert.False(VideoQualityProfiles.TryResolve(quality, out _));
        var album = new AlbumFactory(TestProxy.For<Dominio.Interfaces.ILogger>()).Create(
            id: 1, titulo: "Album", descricao: "", privacidade: 1, segundosporfoto: 4,
            status: 1, qualidadevideo: quality, modelovideo: null, musicaid: null, volumemusica: null);
        var result = AlbumDomainBehavior.Apply(album, DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "PutAlbum", 7, 9));
        Assert.Contains(result.Errors, error => error.Contains("qualidade de video valida"));
    }

    [Theory]
    [InlineData(0, 2, 1920, 1080, 18)]
    [InlineData(1, 1, 1280, 720, 23)]
    [InlineData(2, 2, 1920, 1080, 18)]
    [InlineData(3, 3, 3840, 2160, 18)]
    public void ManifestUsesPublicationQualityNotCurrentAlbumChoice(int quality, int expected, int width, int height, int crf)
    {
        using var stream = new MemoryStream();
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var handler = ManifestHandler(quality, stream);
        handler.Execute(saga, saga.Steps.First());
        using var json = JsonDocument.Parse(stream.ToArray());
        var root = json.RootElement;
        Assert.Equal(expected, root.GetProperty("qualityClass").GetInt32());
        Assert.Equal(width, root.GetProperty("width").GetInt32());
        Assert.Equal(height, root.GetProperty("height").GetInt32());
        Assert.Equal(crf, root.GetProperty("crf").GetInt32());
        Assert.Equal(30, root.GetProperty("fps").GetInt32());
        Assert.Equal(180, root.GetProperty("photos")[0].GetProperty("rotationDegrees").GetInt32());
        Assert.Equal("pan", root.GetProperty("motion").GetString());
        Assert.Equal("volatile/memorias/music/adventure-meme-v1.mp3", root.GetProperty("audioStorageKey").GetString());
        Assert.Equal(0, root.GetProperty("audioVolume").GetDouble());
        Assert.Equal("volatile/memorias/publicacoes/3/video.mp4", root.GetProperty("outputStorageKey").GetString());
    }

    [Fact]
    public void InvalidPublicationClassFailsBeforeSavingManifest()
    {
        using var stream = new MemoryStream();
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var exception = Assert.Throws<SagaStepExecutionException>(() => ManifestHandler(99, stream).Execute(saga, saga.Steps.First()));
        Assert.False(exception.Retryable);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void MissingVolatilePhotoRequiresResendAndDoesNotRetryOrWriteManifest()
    {
        using var stream = new MemoryStream();
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var error = Assert.Throws<SagaStepExecutionException>(() => ManifestHandler(2, stream, false).Execute(saga, saga.Steps.First()));
        Assert.False(error.Retryable);
        Assert.Contains("Reenvie", error.Message);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void MissingManifestDoesNotPublishRenderingWork()
    {
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var handler = new RenderizarVideoAlbumHandler(
            TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => new PublicacaoAlbumDTO { manifeststoragekey = "volatile/memorias/publicacoes/3/manifest.json" }),
            TestProxy.For<IPublicacaoAlbumWriteRepository>(), null!,
            TestProxy.For<IFileStorage>((_, _) => Task.FromResult(false)));
        var error = Assert.Throws<SagaStepExecutionException>(() => handler.Execute(saga, saga.Steps.First()));
        Assert.False(error.Retryable);
        Assert.Contains("nova publicacao", error.Message);
    }

    private static PrepararManifestoAlbumHandler ManifestHandler(int quality, Stream output, bool photosExist = true) => new(
        TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => new PublicacaoAlbumDTO { id = 3, albumid = 5, qualidadevideo = quality, modelovideo = 3, musicaid = 2, volumemusica = 0 }),
        TestProxy.For<IPublicacaoAlbumWriteRepository>(),
        TestProxy.For<IAlbumReadRepository>((_, _) => new AlbumDTO { id = 5, segundosporfoto = 4, qualidadevideo = 99 }),
        TestProxy.For<IAlbumFotoReadRepository>((_, _) => new[] { new AlbumFotoDTO { fotoid = 1, rotacao = 180 } }),
        TestProxy.For<IFotoReadRepository>((_, _) => new FotoDTO { storagekey = "volatile/memorias/photos/7/9/1.png" }),
        TestProxy.For<IFileStorage>((method, _) => method == "ExistsAsync" ? Task.FromResult(photosExist) : output));
}
