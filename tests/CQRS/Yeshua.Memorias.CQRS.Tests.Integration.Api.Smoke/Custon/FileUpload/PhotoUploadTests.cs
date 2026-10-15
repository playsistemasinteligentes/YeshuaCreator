using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class PhotoUploadTests
{
    private static readonly byte[] Png = Convert.FromBase64String(
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+aDaYAAAAASUVORK5CYII=");

    [Fact]
    public async Task CreatesUploadSessionForOwnedAlbum()
    {
        var rig = new UploadRig();
        var result = await rig.StartHandler.ExecuteAsync(new StarSessionUploadInputCommand
        {
            entityType = "Album", entityId = "5"
        });

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(rig.CreatedSession!.OperationalEntityId, result.Data.uploadToken);
        Assert.False(string.IsNullOrWhiteSpace(result.Data.uploadToken));
        Assert.Equal("memorias.photo", rig.CreatedSession.Type);
        Assert.Equal("5", rig.CreatedSession.EntityId);
        Assert.Equal(0, rig.CreatedSession.Status);
        Assert.Equal(new[] { "BeginTran", "InsertSession", "Commit" }, rig.Events);
    }

    [Theory]
    [InlineData("Foto", "5", false)]
    [InlineData("Album", "invalid", false)]
    [InlineData("Album", "5", true)]
    public async Task RejectsInvalidAlbumBeforeCreatingSession(string entityType, string entityId, bool otherOwner)
    {
        var rig = new UploadRig();
        if (otherOwner) rig.Album.userid = 99;
        var result = await rig.StartHandler.ExecuteAsync(new StarSessionUploadInputCommand
        {
            entityType = entityType, entityId = entityId
        });

        Assert.Equal(400, result.StatusCode);
        Assert.Null(rig.CreatedSession);
        Assert.DoesNotContain("InsertSession", rig.Events);
    }

    [Fact]
    public async Task CreatesPhotoAndAlbumLinkInOneTransactionUsingDetectedFormat()
    {
        var rig = new UploadRig();
        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data.IsFinalized);
        Assert.Equal(new[] { "BeginTran", "CompleteSession", "InsertPhoto", "InsertLink", "Commit" }, rig.Events);
        Assert.Equal("image/png", rig.Photo!.ContentType);
        Assert.Equal(Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Png)), rig.Photo.HashArquivo);
        Assert.StartsWith("persistent/memorias/photos/7/10/", rig.Photo.StorageKey);
        Assert.EndsWith(".png", rig.Photo.StorageKey);
        Assert.Equal(5, rig.Link!.AlbumId);
        Assert.Equal(42, rig.Link.FotoId);
        Assert.Equal(4, rig.Link.Ordem);
        Assert.Equal(Png.Length, rig.CompletedSize);
        Assert.False(rig.DeletedFile);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(90)]
    [InlineData(180)]
    [InlineData(270)]
    public async Task UploadPersistsOrientationWithoutChangingOriginal(int rotation)
    {
        var rig = new UploadRig();
        var command = CreateCommand();
        command.Rotacao = rotation;
        var result = await rig.Handler.ExecuteAsync(command);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(rotation, rig.Link!.Rotacao);
        Assert.Equal(Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Png)), rig.Photo!.HashArquivo);
        Assert.Equal(new[] { "BeginTran", "CompleteSession", "InsertPhoto", "InsertLink", "Commit" }, rig.Events);
    }

    [Theory]
    [InlineData(-90)]
    [InlineData(45)]
    [InlineData(360)]
    public async Task InvalidOrientationIsRejectedBeforeStorage(int rotation)
    {
        var rig = new UploadRig();
        var command = CreateCommand();
        command.Rotacao = rotation;
        Assert.Equal(400, (await rig.Handler.ExecuteAsync(command)).StatusCode);
        Assert.False(rig.SavedFile);
        Assert.Empty(rig.Events);
    }

    [Theory]
    [InlineData("expired")]
    [InlineData("other-user")]
    [InlineData("other-album-owner")]
    [InlineData("missing")]
    public async Task RejectsInvalidSessionBeforeSavingFile(string scenario)
    {
        var rig = new UploadRig();
        if (scenario == "expired") rig.Session.createdat = DateTime.UtcNow.AddHours(-2);
        if (scenario == "other-user") rig.Session.userid = 99;
        if (scenario == "other-album-owner") rig.Album.userid = 99;
        if (scenario == "missing") rig.MissingSession = true;

        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(400, result.StatusCode);
        Assert.False(rig.SavedFile);
        Assert.Null(rig.Photo);
    }

    [Fact]
    public async Task RepeatedCompletedSessionDoesNotCreateAnotherPhoto()
    {
        var rig = new UploadRig();
        rig.Session.status = 1;

        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data.IsFinalized);
        Assert.False(rig.SavedFile);
        Assert.Null(rig.Photo);
        Assert.Empty(rig.Events);
    }

    [Fact]
    public async Task LostConcurrentClaimRollsBackAndRemovesSavedFile()
    {
        var rig = new UploadRig { ClaimAccepted = false };

        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(400, result.StatusCode);
        Assert.Equal(new[] { "BeginTran", "CompleteSession", "Rollback" }, rig.Events);
        Assert.True(rig.DeletedFile);
        Assert.Null(rig.Photo);
    }

    [Fact]
    public async Task DatabaseFailureRollsBackAndRemovesSavedFile()
    {
        var rig = new UploadRig { FailLinkInsert = true };

        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(500, result.StatusCode);
        Assert.DoesNotContain("Commit", rig.Events);
        Assert.Equal("Rollback", rig.Events.Last());
        Assert.True(rig.DeletedFile);
    }

    [Fact]
    public async Task PartialStorageFailureRemovesIncompleteFile()
    {
        var rig = new UploadRig { FailStorage = true };

        var result = await rig.Handler.ExecuteAsync(CreateCommand());

        Assert.Equal(500, result.StatusCode);
        Assert.True(rig.DeletedFile);
        Assert.Null(rig.Photo);
    }

    [Fact]
    public async Task RejectsNonImageEvenWhenBrowserClaimsItIsPng()
    {
        var rig = new UploadRig();
        var command = CreateCommand();
        command.FileStream = new FormFile(new MemoryStream("plain text"u8.ToArray()), 0, 10, "FileStream", "photo.png");

        var result = await rig.Handler.ExecuteAsync(command);

        Assert.Equal(400, result.StatusCode);
        Assert.False(rig.SavedFile);
    }

    [Fact]
    public async Task MultipartRequestBindsGeneratedCommandAndReachesReceiver()
    {
        var rig = new UploadRig();
        var builder = WebApplication.CreateBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Services.AddSingleton(rig.Handler);
        await using var app = builder.Build();
        app.MapPost("/upload", async ([FromServices] SendFileHandler receiver, [FromForm] SendFileInputCommand command) =>
        {
            var result = await receiver.ExecuteAsync(command);
            return Results.Json(result.Data, statusCode: result.StatusCode);
        }).DisableAntiforgery().Accepts<SendFileInputCommand>("multipart/form-data");
        await app.StartAsync();
        try
        {
            using var client = new HttpClient { BaseAddress = new Uri(app.Urls.Single()) };
            using var form = new MultipartFormDataContent();
            form.Add(new StringContent("upload-token"), "token");
            form.Add(new StringContent("0"), "ChunkIndex");
            form.Add(new StringContent("true"), "IsFinalChunk");
            form.Add(new StringContent("180"), "Rotacao");
            var content = new ByteArrayContent(Png);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            form.Add(content, "FileStream", "photo.png");
            using var response = await client.PostAsync("/upload", form);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(rig.Photo);
            Assert.Equal("image/png", rig.Photo.ContentType);
            Assert.Equal(180, rig.Link!.Rotacao);
        }
        finally
        {
            await app.StopAsync();
        }
    }

    private static SendFileInputCommand CreateCommand() => new()
    {
        token = "upload-token", ChunkIndex = 0, IsFinalChunk = true,
        FileName = "photo.png", ContentType = "image/jpeg",
        FileStream = new FormFile(new MemoryStream(Png), 0, Png.Length, "FileStream", "photo.png")
    };

    private sealed class UploadRig
    {
        public readonly List<string> Events = new();
        public readonly yFileUploadDTO Session = new()
        {
            id = 10, userid = 8, tenantid = 7, type = "memorias.photo", entitytype = "Album",
            entityid = "5", createdat = DateTime.SpecifyKind(DateTime.UtcNow.AddMinutes(-5), DateTimeKind.Unspecified)
        };
        public readonly AlbumDTO Album = new() { id = 5, userid = 8, tenantid = 7 };
        public bool ClaimAccepted = true;
        public bool MissingSession;
        public bool FailLinkInsert;
        public bool FailStorage;
        public bool SavedFile;
        public bool DeletedFile;
        public long CompletedSize;
        public IFotoEntity? Photo;
        public IAlbumFotoEntity? Link;
        public IyFileUploadEntity? CreatedSession;
        public SendFileHandler Handler { get; }
        public StarSessionUploadHandler StartHandler { get; }

        public UploadRig()
        {
            var unitOfWork = TestProxy.For<IUnitOfWork>((method, _) => { Events.Add(method); return null; });
            var logger = TestProxy.For<Dominio.Interfaces.ILogger>();
            var context = TestProxy.For<IExecutionContext>((method, _) => method switch
            {
                "get_TenantID" => 7, "get_UserId" => 8, _ => null
            });
            var tracking = TestProxy.For<IDomainTrackingPolicy>();
            var albums = TestProxy.For<IAlbumReadRepository>((_, _) => Album);
            StartHandler = new StarSessionUploadHandler(unitOfWork, logger, context, tracking,
                TestProxy.For<IyFileUploadWriteRepository>((method, args) =>
                {
                    Assert.Equal("Insert", method);
                    Events.Add("InsertSession");
                    CreatedSession = (IyFileUploadEntity)args[0]!;
                    CreatedSession.Id = 10;
                    return null;
                }), albums);

            Handler = new SendFileHandler(
                unitOfWork, logger, context, tracking,
                TestProxy.For<IyFileUploadReadRepository>((_, _) => MissingSession ? null : Session),
                TestProxy.For<IyFileUploadWriteRepository>((method, args) =>
                {
                    Assert.Equal("TryCompletePhotoUpload", method);
                    Events.Add("CompleteSession");
                    CompletedSize = (long)args[5]!;
                    return ClaimAccepted;
                }),
                TestProxy.For<IFileStorage>((method, _) => method switch
                {
                    "SaveAsync" => SaveFile(),
                    "OpenRead" => new MemoryStream(Png),
                    "DeleteAsync" => DeleteFile(),
                    _ => throw new InvalidOperationException(method)
                }),
                albums,
                TestProxy.For<IFotoWriteRepository>((method, args) =>
                {
                    Assert.Equal("Insert", method);
                    Events.Add("InsertPhoto");
                    Photo = (IFotoEntity)args[0]!;
                    Photo.Id = 42;
                    return null;
                }),
                TestProxy.For<IAlbumFotoReadRepository>((_, _) => new[] { new AlbumFotoDTO { ordem = 3 } }),
                TestProxy.For<IAlbumFotoWriteRepository>((method, args) =>
                {
                    Assert.Equal("Insert", method);
                    Events.Add("InsertLink");
                    if (FailLinkInsert) throw new InvalidOperationException("Database unavailable");
                    Link = (IAlbumFotoEntity)args[0]!;
                    return null;
                }));
        }

        private Task<FileStorageResult> SaveFile()
        {
            SavedFile = true;
            return FailStorage
                ? Task.FromException<FileStorageResult>(new IOException("Incomplete save"))
                : Task.FromResult(new FileStorageResult());
        }

        private Task DeleteFile()
        {
            DeletedFile = true;
            return Task.CompletedTask;
        }
    }

    public class TestProxy : DispatchProxy
    {
        public Func<string, object?[], object?>? Callback { get; set; }

        public static T For<T>(Func<string, object?[], object?>? callback = null) where T : class
        {
            var result = Create<T, TestProxy>();
            ((TestProxy)(object)result).Callback = callback;
            return result;
        }

        protected override object? Invoke(MethodInfo? method, object?[]? args)
        {
            var parameters = method!.GetParameters();
            for (var index = 0; index < parameters.Length; index++)
            {
                if (parameters[index].IsOut && args![index] is null)
                    args[index] = Activator.CreateInstance(parameters[index].ParameterType.GetElementType()!);
            }
            var result = Callback?.Invoke(method!.Name, args ?? []);
            return result ?? (method!.ReturnType.IsValueType && method.ReturnType != typeof(void)
                ? Activator.CreateInstance(method.ReturnType) : null);
        }
    }
}
