using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Behaviors;
using Dominio.Patterns.Domain;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using Memorias.YouTube;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class YouTubePublicationTests
{
    [Theory]
    [InlineData(DomainOperation.Registro)]
    [InlineData(DomainOperation.Alteracao)]
    [InlineData(DomainOperation.Remocao)]
    public void CrudCannotBypassPublicationCommands(DomainOperation operation)
    {
        var context = DomainOperationContext.Create(operation, DomainEntryPoint.Crud, "Crud", 7, 9);
        var entity = new PublicacaoAlbumFactory(TestProxy.For<ILogger>()).Create(
            context, 3, 5, Guid.NewGuid().ToString(), null, null, null, null, null,
            DateTime.UtcNow, null, 45, Guid.NewGuid().ToString("N"), "channel-a", 9);
        var result = PublicacaoAlbumDomainBehavior.Apply(entity, context);
        Assert.Contains(result.Errors, error => error.Contains("comandos de solicitar e retomar"));
    }

    [Fact]
    public async Task PublicationRecordsSelectedChannelAndCredentialOwner()
    {
        using var rig = new RequestRig();
        var first = await rig.Connections.Connect("channel-a");
        await rig.Connections.Connect("channel-b");
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand
        {
            AlbumId = 5, ConexaoYouTubeId = first.ConexaoId
        });
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(first.ConexaoId, rig.Created!.ConexaoYouTubeId);
        Assert.Equal("channel-a", rig.Created.CanalYouTubeId);
        Assert.Equal(9, rig.Created.YouTubeCredentialUserId);
        Assert.Equal(new[] { "BeginTran", "Insert", "SaveSaga", "Commit" }, rig.Events);
    }

    [Theory]
    [InlineData("missing-channel")]
    [InlineData("other-album-user")]
    [InlineData("other-album-tenant")]
    [InlineData("unknown-connection")]
    public async Task InvalidOwnerOrDestinationCannotCreatePublication(string scenario)
    {
        using var rig = new RequestRig();
        var destination = await rig.Connections.Connect("channel-a");
        if (scenario == "other-album-user") rig.Album.userid = 99;
        if (scenario == "other-album-tenant") rig.Album.tenantid = 99;
        var id = scenario == "missing-channel" ? "" : scenario == "unknown-connection" ? Guid.NewGuid().ToString("N") : destination.ConexaoId;
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = id });
        Assert.Equal(400, result.StatusCode);
        Assert.Null(rig.Created);
        Assert.Empty(rig.Events);
    }

    [Fact]
    public async Task RenderedPublicationUsesPinnedChannelInsteadOfLastConnectedAccount()
    {
        using var rig = new RenderedRig();
        var destination = await rig.Connections.Connect("channel-a");
        await rig.Connections.Connect("channel-b");
        rig.Publication.conexaoyoutubeid = destination.ConexaoId;
        // O solicitante pode ser distinto do responsavel pela credencial.
        rig.Publication.userid = 101;
        rig.Handler.Execute(rig.Saga, rig.Step);
        Assert.Equal(SagaStepStatus.PendingApply, rig.Step.Status);
        Assert.Equal(2, rig.Upload.Requests);
        Assert.Equal("access-channel-a", rig.Upload.Token);
        Assert.Equal("private", rig.Upload.Privacy);
        Assert.Equal("video-test", rig.Publication.youtubevideoid);
    }

    [Theory]
    [InlineData("disconnected")]
    [InlineData("wrong-channel")]
    [InlineData("missing-destination")]
    public async Task InvalidPinnedDestinationWaitsWithoutFallingBackToAnotherConnection(string scenario)
    {
        using var rig = new RenderedRig();
        var destination = await rig.Connections.Connect("channel-a");
        await rig.Connections.Connect("channel-b");
        rig.Publication.conexaoyoutubeid = destination.ConexaoId;
        if (scenario == "disconnected") await rig.Connections.Service.DisconnectAsync(new(7, 9), destination.ConexaoId, default);
        if (scenario == "wrong-channel") rig.Publication.canalyoutubeid = "channel-b";
        if (scenario == "missing-destination") rig.Publication.conexaoyoutubeid = "";
        rig.Handler.Execute(rig.Saga, rig.Step);
        Assert.Equal(SagaStepStatus.WaitingResponse, rig.Step.Status);
        Assert.Equal(45, rig.Publication.status);
        Assert.Equal(0, rig.Upload.Requests);
    }

    [Fact]
    public void ConfirmedVideoIsNotUploadedAgain()
    {
        using var rig = new RenderedRig();
        rig.Publication.youtubevideoid = "already-confirmed";
        rig.Handler.Execute(rig.Saga, rig.Step);
        Assert.Equal(0, rig.Upload.Requests);
    }

    [Fact]
    public async Task ResumeCannotChangeDestination()
    {
        using var rig = new RequestRig();
        var first = await rig.Connections.Connect("channel-a");
        var second = await rig.Connections.Connect("channel-b");
        var publication = new PublicacaoAlbumDTO
        {
            id = 3, tenantid = 7, userid = 9, status = 45,
            conexaoyoutubeid = first.ConexaoId, canalyoutubeid = "channel-a", youtubecredentialuserid = 9
        };
        var writes = 0;
        var handler = new RetomarPublicacaoYouTubeHandler(rig.Logger, rig.Context, rig.Connections.Service,
            TestProxy.For<IPublicacaoAlbumWriteRepository>((_, _) => { ++writes; return true; }),
            TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => publication), TestProxy.For<IUnitOfWork>());
        var result = await handler.ExecuteAsync(new RetomarPublicacaoYouTubeInputCommand
        {
            PublicacaoAlbumId = 3, ConexaoYouTubeId = second.ConexaoId
        });
        Assert.Equal(400, result.StatusCode);
        Assert.Equal(0, writes);
    }

    private sealed class RequestRig : IDisposable
    {
        public YouTubeConnectionTests.Rig Connections { get; } = new();
        public AlbumDTO Album { get; } = new() { id = 5, tenantid = 7, userid = 9, titulo = "Album" };
        public IPublicacaoAlbumEntity? Created;
        public List<string> Events { get; } = [];
        public ILogger Logger { get; } = TestProxy.For<ILogger>();
        public IExecutionContext Context { get; } = TestProxy.For<IExecutionContext>((name, _) => name switch
        {
            "get_TenantID" => 7, "get_UserId" => 9, "get_ProcessingScope" => "tests", "get_TraceId" => "trace",
            _ => null
        });
        public SolicitarPublicacaoAlbumHandler Handler { get; }

        public RequestRig()
        {
            Handler = new(TestProxy.For<IUnitOfWork>((method, _) => { Events.Add(method); return null; }),
                Logger, Context, TestProxy.For<IDomainTrackingPolicy>(),
                TestProxy.For<IAlbumReadRepository>((_, _) => Album), TestProxy.For<IAlbumWriteRepository>(),
                TestProxy.For<IPublicacaoAlbumWriteRepository>((_, args) =>
                {
                    Events.Add("Insert"); Created = (IPublicacaoAlbumEntity)args[0]!; Created.Id = 3; return null;
                }),
                TestProxy.For<IySagaWriteRepository>((_, _) => { Events.Add("SaveSaga"); return null; }), Connections.Service);
        }
        public void Dispose() => Connections.Dispose();
    }

    private sealed class RenderedRig : IDisposable
    {
        public YouTubeConnectionTests.Rig Connections { get; } = new();
        public PublicacaoAlbumDTO Publication { get; } = new()
        {
            id = 3, albumid = 5, tenantid = 7, userid = 9, youtubecredentialuserid = 9,
            videostoragekey = "persistent/memorias/publicacoes/3/video.mp4", canalyoutubeid = "channel-a"
        };
        public PublicarAlbumYouTubeSaga Saga { get; } = new();
        public SagaStepBase Step => Saga.Steps.Single(step => step.Key == PublicarAlbumYouTubeSaga.STEP_3);
        public UploadStub Upload { get; } = new();
        public EnviarVideoParaYouTubeHandler Handler { get; }

        public RenderedRig()
        {
            Saga.Start("3", nameof(PublicacaoAlbumEntity));
            Handler = new(TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => Publication),
                TestProxy.For<IPublicacaoAlbumWriteRepository>((method, args) =>
                {
                    if (method == "UpdateStatus") Publication.status = (int)args[1]!;
                    if (method == "UpdateYouTubeVideoId") Publication.youtubevideoid = (string)args[1]!;
                    return null;
                }), TestProxy.For<IAlbumReadRepository>((_, _) => new AlbumDTO { id = 5, titulo = "Album", privacidade = 1 }),
                TestProxy.For<IFileStorage>((_, _) => new MemoryStream([1, 2, 3])),
                new ResumableYouTubeVideoUploader(Connections.Repository, Connections.Service, Upload));
        }
        public void Dispose() => Connections.Dispose();
    }

    private sealed class UploadStub : HttpMessageHandler, IHttpClientFactory
    {
        public int Requests;
        public string? Token;
        public string? Privacy;
        public HttpClient CreateClient(string name) => new(this, false);
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ++Requests;
            Token = request.Headers.Authorization?.Parameter;
            if (request.Method == HttpMethod.Post)
            {
                using var json = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
                Privacy = json.RootElement.GetProperty("status").GetProperty("privacyStatus").GetString();
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Location = new("https://www.googleapis.com/upload/youtube/v3/videos?upload_id=test");
                return response;
            }
            return new(HttpStatusCode.OK) { Content = new StringContent("{\"id\":\"video-test\"}", Encoding.UTF8, "application/json") };
        }
    }
}
