using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using Dominio.Entitys;
using IRepository.Read;
using IRepository.Write;
using Memorias.Media;
using Repositorio.Outputs;
using IQuery.Write;
using Input.Repository.AlbumFoto;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class PhotoRotationTests
{
    private static IExecutionContext Context(int tenant = 7, int user = 9) => TestProxy.For<IExecutionContext>((method, _) => method switch
    {
        "get_TenantID" => tenant, "get_UserId" => user, _ => null
    });

    [Theory]
    [InlineData(0)]
    [InlineData(90)]
    [InlineData(180)]
    [InlineData(270)]
    public async Task RotationCommandUsesAuthenticatedOwnerAndAbsoluteAngle(int rotation)
    {
        var writes = 0;
        var handler = new GirarFotoHandler(TestProxy.For<Dominio.Interfaces.ILogger>(), Context(),
            TestProxy.For<IAlbumFotoWriteRepository>((method, args) =>
            {
                Assert.Equal("TrySetRotation", method);
                Assert.Equal(new object[] { 5, 7, 9, rotation }, args.Take(4));
                ++writes;
                return true;
            }));
        var command = new GirarFotoInputCommand { AlbumFotoId = 5, Rotacao = rotation };
        var first = await handler.ExecuteAsync(command);
        var repeated = await handler.ExecuteAsync(command);
        Assert.Equal(200, first.StatusCode);
        Assert.Equal(rotation, repeated.Data.Rotacao);
        Assert.Equal(2, writes);
    }

    [Theory]
    [InlineData(0, 180, 7, 9, true)]
    [InlineData(5, 45, 7, 9, true)]
    [InlineData(5, 180, 0, 9, true)]
    [InlineData(5, 180, 7, 0, true)]
    [InlineData(5, 180, 7, 9, false)]
    public async Task InvalidRequestOrUnavailableOwnedPhotoCannotConfirmRotation(int id, int rotation, int tenant, int user, bool accepted)
    {
        var writes = 0;
        var handler = new GirarFotoHandler(TestProxy.For<Dominio.Interfaces.ILogger>(), Context(tenant, user),
            TestProxy.For<IAlbumFotoWriteRepository>((_, _) => { ++writes; return accepted; }));
        var result = await handler.ExecuteAsync(new GirarFotoInputCommand { AlbumFotoId = id, Rotacao = rotation });
        Assert.Equal(400, result.StatusCode);
        Assert.Equal(accepted ? 0 : 1, writes);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void RotationRepositoryUsesOwnerAndPublicationGuardsInSameWrite(int affected, bool accepted)
    {
        var now = DateTime.UtcNow;
        var calls = 0;
        var repository = new AlbumFotoWriteRepository(TestProxy.For<IUnitOfWork>((method, args) =>
        {
            Assert.Equal("ExecuteScalar", method);
            var sql = (string)args[0]!;
            Assert.Contains("af.TenantID = @TenantId AND af.UserId = @UserId", sql);
            Assert.Contains("a.TenantID = af.TenantID AND a.UserId = af.UserId", sql);
            Assert.Contains("af.Deleted = 0 AND a.Deleted = 0", sql);
            Assert.Contains("p.Status IN (10, 20, 30, 40, 45, 50)", sql);
            Assert.Contains("p.Status = 90 AND EXISTS", sql);
            Assert.Contains("s.Status = 1", sql);
            Assert.Contains("WITH (UPDLOCK, HOLDLOCK)", sql);
            var parameters = args[1]!;
            Assert.Equal(new object[] { 5, 7, 9, 180, now }, parameters.GetType().GetProperties().Select(property => property.GetValue(parameters)));
            ++calls;
            return affected;
        }), TestProxy.For<IAlbumFotoQueryWrite>());
        Assert.Equal(accepted, repository.TrySetRotation(5, 7, 9, 180, now));
        Assert.Equal(1, calls);
    }

    [Fact]
    public void CaptionAndOrderCrudCannotResetSavedOrientation()
    {
        var photo = new AlbumFotoFactory(TestProxy.For<Dominio.Interfaces.ILogger>()).Create(5, 6, 7, 1, "Caption", 180);
        var query = new Query.Write.AlbumFotoQueryWrite(Context()).UpdateAlbumFotoQuery(photo);
        Assert.DoesNotContain("Rotacao", query.Query);
    }

    [Theory]
    [InlineData("other-tenant")]
    [InlineData("other-user")]
    [InlineData("deleted")]
    [InlineData("mime")]
    [InlineData("traversal")]
    [InlineData("prefix")]
    [InlineData("empty-key")]
    [InlineData("missing")]
    public void PrivatePreviewRejectsUnavailablePhotoBeforeOpeningStorage(string scenario)
    {
        var photo = new FotoDTO { id = 1, tenantid = 7, userid = 9, contenttype = "image/png", storagekey = "persistent/memorias/photos/7/10/photo.png" };
        if (scenario == "other-tenant") photo.tenantid = 8;
        if (scenario == "other-user") photo.userid = 8;
        if (scenario == "deleted") photo.deleted = true;
        if (scenario == "mime") photo.contenttype = "text/html";
        if (scenario == "traversal") photo.storagekey = "persistent/memorias/photos/7/9/../8/photo.png";
        if (scenario == "prefix") photo.storagekey = "persistent/memorias/photos/8/10/photo.png";
        if (scenario == "empty-key") photo.storagekey = "";
        var reader = new PhotoFileReader(TestProxy.For<IFotoReadRepository>((_, _) => scenario == "missing" ? null : photo),
            TestProxy.For<IyFileUploadReadRepository>((_, _) => throw new InvalidOperationException("Upload should not be read")),
            TestProxy.For<IFileStorage>((_, _) => throw new InvalidOperationException("Storage should not be opened")), Context());
        Assert.Null(reader.Open(1));
    }

    [Fact]
    public void PrivatePreviewStreamsOnlyOwnedOriginalAndHandlesMissingFile()
    {
        var photo = new FotoDTO { id = 1, tenantid = 7, userid = 9, contenttype = "image/png", storagekey = "persistent/memorias/photos/7/10/photo.png" };
        var original = new byte[] { 1, 2, 3 };
        var repository = TestProxy.For<IFotoReadRepository>((_, _) => photo);
        var uploads = TestProxy.For<IyFileUploadReadRepository>((method, args) =>
        {
            Assert.Equal("FirstById",method); Assert.Equal(10,args[0]); Assert.Equal(false,args[1]);
            return new yFileUploadDTO { id=10,tenantid=7,userid=9,status=1,type="memorias.photo",entitytype="Album",filepath=photo.storagekey,filesize=original.Length };
        });
        var reader = new PhotoFileReader(repository, uploads, TestProxy.For<IFileStorage>((_, _) => new MemoryStream(original)), Context());
        var result = reader.Open(1)!;
        using (result.Stream)
        {
            Assert.Equal("image/png", result.ContentType);
            Assert.Equal(original, ((MemoryStream)result.Stream).ToArray());
        }
        Assert.Null(new PhotoFileReader(repository, uploads, TestProxy.For<IFileStorage>((_, _) => throw new FileNotFoundException()), Context()).Open(1));
        using var oversized = new MemoryStream(new byte[25 * 1024 * 1024 + 1]);
        Assert.Null(new PhotoFileReader(repository, uploads, TestProxy.For<IFileStorage>((_, _) => oversized), Context()).Open(1));
        Assert.False(oversized.CanRead);
    }

    [Theory]
    [InlineData("missing")]
    [InlineData("other-tenant")]
    [InlineData("other-user")]
    [InlineData("deleted")]
    [InlineData("pending")]
    [InlineData("type")]
    [InlineData("entity")]
    [InlineData("path")]
    [InlineData("empty-path")]
    public void PrivatePreviewRequiresCompletedUploadOfSameOwnerAndExactStorageKey(string scenario)
    {
        var photo = new FotoDTO { id=1,tenantid=7,userid=9,contenttype="image/png",storagekey="persistent/memorias/photos/7/10/photo.png" };
        var upload = new yFileUploadDTO { id=10,tenantid=7,userid=9,status=1,type="memorias.photo",entitytype="Album",filepath=photo.storagekey,filesize=3 };
        if(scenario=="other-tenant")upload.tenantid=8;
        if(scenario=="other-user")upload.userid=8;
        if(scenario=="deleted")upload.deleted=true;
        if(scenario=="pending")upload.status=0;
        if(scenario=="type")upload.type="other";
        if(scenario=="entity")upload.entitytype="other";
        if(scenario=="path")upload.filepath="persistent/memorias/photos/7/10/other.png";
        if(scenario=="empty-path")upload.filepath="";
        var reader = new PhotoFileReader(TestProxy.For<IFotoReadRepository>((_,_)=>photo),
            TestProxy.For<IyFileUploadReadRepository>((_,_)=>scenario=="missing"?null:upload),
            TestProxy.For<IFileStorage>((_,_)=>throw new InvalidOperationException("Storage should not be opened")),Context());
        Assert.Null(reader.Open(1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    public void PrivatePreviewRejectsFileWhoseSizeDiffersFromCompletedUpload(long expectedSize)
    {
        var photo = new FotoDTO { id=1,tenantid=7,userid=9,contenttype="image/png",storagekey="persistent/memorias/photos/7/10/photo.png" };
        var upload = new yFileUploadDTO { id=10,tenantid=7,userid=9,status=1,type="memorias.photo",entitytype="Album",filepath=photo.storagekey,filesize=expectedSize };
        using var stream = new MemoryStream(new byte[]{1,2,3});
        var reader = new PhotoFileReader(TestProxy.For<IFotoReadRepository>((_,_)=>photo),
            TestProxy.For<IyFileUploadReadRepository>((_,_)=>upload),TestProxy.For<IFileStorage>((_,_)=>stream),Context());
        Assert.Null(reader.Open(1));
        Assert.False(stream.CanRead);
    }

    [Fact]
    public void ManifestKeepsIndividualRotationAndLegacyZeroDefault()
    {
        using var stream = new MemoryStream();
        var photos = new[] { new AlbumFotoDTO { fotoid = 1, ordem = 1, rotacao = 90 }, new AlbumFotoDTO { fotoid = 2, ordem = 2, rotacao = 180 }, new AlbumFotoDTO { fotoid = 3, ordem = 3 } };
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var handler = CreateManifestHandler(photos, stream);
        handler.Execute(saga, saga.Steps.First());
        using var json = JsonDocument.Parse(stream.ToArray());
        Assert.Equal(new[] { 90, 180, 0 }, json.RootElement.GetProperty("photos").EnumerateArray().Select(photo => photo.GetProperty("rotationDegrees").GetInt32()));
        Assert.Equal("persistent/memorias/photos/7/9/1.png", json.RootElement.GetProperty("photos")[0].GetProperty("storageKey").GetString());
    }

    [Fact]
    public void InvalidStoredRotationFailsManifestWithoutWritingFile()
    {
        using var stream = new MemoryStream();
        var saga = new PublicarAlbumYouTubeSaga();
        saga.Start("3", "PublicacaoAlbumEntity");
        var exception = Assert.Throws<SagaStepExecutionException>(() => CreateManifestHandler([new AlbumFotoDTO { fotoid = 1, rotacao = 45 }], stream).Execute(saga, saga.Steps.First()));
        Assert.False(exception.Retryable);
        Assert.Equal(0, stream.Length);
    }

    private static PrepararManifestoAlbumHandler CreateManifestHandler(AlbumFotoDTO[] photos, MemoryStream stream) => new(
        TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => new PublicacaoAlbumDTO { id = 3, albumid = 5 }),
        TestProxy.For<IPublicacaoAlbumWriteRepository>(),
        TestProxy.For<IAlbumReadRepository>((_, _) => new AlbumDTO { id = 5, segundosporfoto = 4 }),
        TestProxy.For<IAlbumFotoReadRepository>((_, _) => photos),
        TestProxy.For<IFotoReadRepository>((_, args) => new FotoDTO { storagekey = $"persistent/memorias/photos/7/9/{args[0]}.png" }),
        TestProxy.For<IFileStorage>((_, _) => stream));
}
