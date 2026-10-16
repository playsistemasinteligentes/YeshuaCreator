using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Receivers;
using Command.Receivers.UseCase;
using Command.UseCase;
using Command.Patterns;
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
using RepositoryInterfaces.Patterns.Saga;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class YouTubePublicationTests
{
    [Fact]
    public async Task UploadIncludesAttributionForPinnedMusic()
    {
        using var rig = new RenderedRig();
        rig.Publication.musicaid = 2;
        rig.Publication.conexaoyoutubeid = (await rig.Connections.Connect("channel-a")).ConexaoId;
        rig.Handler.Execute(rig.Saga, rig.Step);
        Assert.Contains("Adventure Meme", rig.Upload.Description);
        Assert.Contains("Kevin MacLeod", rig.Upload.Description);
        Assert.Contains("https://creativecommons.org/licenses/by/4.0/", rig.Upload.Description);
        Assert.DoesNotContain("Carefree", rig.Upload.Description);
    }

    [Fact]
    public async Task ExecutorWaitsForCredentialThenFinishesSameRenderedSaga()
    {
        using var rig = new RenderedRig();
        rig.Saga.CompleteCurrentStep("manifest");
        rig.Saga.CompleteCurrentStep("rendered");
        var finalize = new FinalizarPublicacaoAlbumHandler(
            TestProxy.For<IPublicacaoAlbumReadRepository>((_, _) => rig.Publication),
            TestProxy.For<IPublicacaoAlbumWriteRepository>((method, args) =>
            {
                if (method == "UpdateStatus") rig.Publication.status = (int)args[1]!;
                return null;
            }));
        var handlers = new Dictionary<string, ISagaStepHandler>
        {
            [PublicarAlbumYouTubeSaga.STEP_3] = rig.Handler,
            [PublicarAlbumYouTubeSaga.STEP_4] = finalize
        };
        var resolver = TestProxy.For<ISagaHandlerResolver>((_, _) => handlers);
        var executor = new SagaExecutor(TestProxy.For<ILogger>());
        executor.ExecuteUntilWait(rig.Saga, resolver);
        Assert.Equal(SagaStepStatus.WaitingResponse, rig.Step.Status);
        Assert.Equal(SagaStatus.InProgress, rig.Saga.Status);
        Assert.Equal(SagaStepStatus.Created, rig.Saga.Steps.Single(step => step.Key == PublicarAlbumYouTubeSaga.STEP_4).Status);
        Assert.Equal(0, rig.Upload.Requests);
        var destination = await rig.Connections.Connect("channel-a");
        rig.Publication.conexaoyoutubeid = destination.ConexaoId;
        rig.Step.SetPending(DateTime.UtcNow);
        executor.ExecuteUntilWait(rig.Saga, resolver);
        Assert.Equal(SagaStatus.Completed, rig.Saga.Status);
        Assert.All(rig.Saga.Steps, step => Assert.Equal(SagaStepStatus.Completed, step.Status));
        Assert.Equal(60, rig.Publication.status);
        Assert.Equal(2, rig.Upload.Requests);
    }

    [Theory]
    [InlineData(503, true)]
    [InlineData(403, false)]
    public async Task ExecutorControlsRetryAndPermanentFailure(int code, bool retryable)
    {
        using var rig = new RenderedRig();
        rig.Saga.CompleteCurrentStep("manifest");
        rig.Saga.CompleteCurrentStep("rendered");
        rig.Publication.conexaoyoutubeid = (await rig.Connections.Connect("channel-a")).ConexaoId;
        rig.Upload.Failure = (HttpStatusCode)code;
        var handlers = new Dictionary<string, ISagaStepHandler> { [PublicarAlbumYouTubeSaga.STEP_3] = rig.Handler };
        new SagaExecutor(TestProxy.For<ILogger>()).Execute(rig.Saga,
            TestProxy.For<ISagaHandlerResolver>((_, _) => handlers));
        Assert.Equal(retryable ? SagaStatus.InProgress : SagaStatus.Failed, rig.Saga.Status);
        Assert.Equal(retryable ? SagaStepStatus.Pending : SagaStepStatus.Failed, rig.Step.Status);
        Assert.Equal(retryable ? 1 : 0, rig.Step.RetryCount);
        Assert.Equal(90, rig.Publication.status);
    }

    [Theory]
    [InlineData(DomainOperation.Registro)]
    [InlineData(DomainOperation.Alteracao)]
    [InlineData(DomainOperation.Remocao)]
    public void CrudCannotBypassPublicationCommands(DomainOperation operation)
    {
        var context = DomainOperationContext.Create(operation, DomainEntryPoint.Crud, "Crud", 7, 9);
        var entity = new PublicacaoAlbumFactory(TestProxy.For<ILogger>()).Create(
            context, 3, 5, Guid.NewGuid().ToString(), null, null, null, null, null,
            DateTime.UtcNow, null, 45, Guid.NewGuid().ToString("N"), "channel-a", 9, 2, null, null, null);
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
        Assert.Equal(new[] { "BeginTran", "CheckRequestWindow", "Insert", "SaveSaga", "Commit" }, rig.Events);
        Assert.Equal(rig.Created.SolicitadaEmUtc.AddMinutes(-5), rig.LastRequestCutoff);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(30)]
    [InlineData(60)]
    [InlineData(90)]
    public async Task RecentRequestBlocksAnotherPublicationRegardlessOfStatus(int status)
    {
        using var rig = new RequestRig();
        var channel = await rig.Connections.Connect("channel-a");
        var command = new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId };
        Assert.Equal(200, (await rig.Handler.ExecuteAsync(command)).StatusCode);
        rig.Created!.SolicitadaEmUtc = DateTime.UtcNow.AddMinutes(-4);
        rig.Created.Status = status;
        rig.Events.Clear();

        var result = await rig.Handler.ExecuteAsync(command);

        Assert.Equal(400, result.StatusCode);
        Assert.Single(rig.Requests);
        Assert.Equal(new[] { "BeginTran", "CheckRequestWindow", "Rollback" }, rig.Events);
    }

    [Fact]
    public async Task ManualRequestAfterFiveMinutesCreatesAnotherPublicationWithoutReopeningPreviousSaga()
    {
        using var rig = new RequestRig();
        var channel = await rig.Connections.Connect("channel-a");
        var command = new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId };
        Assert.Equal(200, (await rig.Handler.ExecuteAsync(command)).StatusCode);
        var previous = rig.Created!;
        previous.SolicitadaEmUtc = DateTime.UtcNow.AddMinutes(-5).AddSeconds(-1);
        previous.Status = 30;
        rig.Events.Clear();

        var result = await rig.Handler.ExecuteAsync(command);

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(2, rig.Requests.Count);
        Assert.Equal(30, previous.Status);
        Assert.NotEqual(previous.CorrelationId, rig.Created!.CorrelationId);
        Assert.Equal(new[] { "BeginTran", "CheckRequestWindow", "Insert", "SaveSaga", "Commit" }, rig.Events);
    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    public async Task PublicationCapturesQualityBeforeAlbumChanges(int selected, int expected)
    {
        using var rig = new RequestRig();
        rig.Album.qualidadevideo = selected;
        var channel = await rig.Connections.Connect("channel-a");
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId });
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expected, rig.Created!.QualidadeVideo);
        rig.Album.qualidadevideo = 1;
        Assert.Equal(expected, rig.Created.QualidadeVideo);
    }

    [Fact]
    public async Task MissingSelectedTrackBlocksPublicationBeforeTransaction()
    {
        using var rig = new RequestRig();
        rig.Album.musicaid = 1; rig.MusicAvailable = false;
        var channel = await rig.Connections.Connect("channel-a");
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId });
        Assert.Equal(400, result.StatusCode); Assert.Null(rig.Created); Assert.Empty(rig.Events);
    }

    [Fact]
    public async Task PublicationPinsPresentationAndMusic()
    {
        using var rig = new RequestRig();
        rig.Album.modelovideo = 3; rig.Album.musicaid = 2; rig.Album.volumemusica = 0;
        var channel = await rig.Connections.Connect("channel-a");
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId });
        Assert.Equal(200, result.StatusCode);
        rig.Album.modelovideo = 1; rig.Album.musicaid = 0; rig.Album.volumemusica = 35;
        Assert.Equal(3, rig.Created!.ModeloVideo); Assert.Equal(2, rig.Created.MusicaId); Assert.Equal(0, rig.Created.VolumeMusica);
    }

    [Fact]
    public async Task InvalidAlbumQualityCannotCreatePublication()
    {
        using var rig = new RequestRig();
        rig.Album.qualidadevideo = 99;
        var channel = await rig.Connections.Connect("channel-a");
        var result = await rig.Handler.ExecuteAsync(new SolicitarPublicacaoAlbumInputCommand { AlbumId = 5, ConexaoYouTubeId = channel.ConexaoId });
        Assert.Equal(400, result.StatusCode);
        Assert.Null(rig.Created);
        Assert.Empty(rig.Events);
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

    [Theory]
    [InlineData(503, true)]
    [InlineData(429, true)]
    [InlineData(403, false)]
    public async Task FailedUploadUpdatesPublicationAndPreservesExecutorRetryDecision(int code, bool retryable)
    {
        using var rig = new RenderedRig();
        var destination = await rig.Connections.Connect("channel-a");
        rig.Publication.conexaoyoutubeid = destination.ConexaoId;
        rig.Upload.Failure = (HttpStatusCode)code;
        var exception = Assert.Throws<SagaStepExecutionException>(() => rig.Handler.Execute(rig.Saga, rig.Step));
        Assert.Equal(retryable, exception.Retryable);
        Assert.Equal(90, rig.Publication.status);
        Assert.DoesNotContain("SECRET", rig.Publication.mensagem);
        Assert.Equal(SagaStepStatus.InProgress, rig.Step.Status);
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
        public List<IPublicacaoAlbumEntity> Requests { get; } = [];
        public DateTime LastRequestCutoff;
        public List<string> Events { get; } = [];
        public ILogger Logger { get; } = TestProxy.For<ILogger>();
        public IExecutionContext Context { get; } = TestProxy.For<IExecutionContext>((name, _) => name switch
        {
            "get_TenantID" => 7, "get_UserId" => 9, "get_ProcessingScope" => "tests", "get_TraceId" => "trace",
            _ => null
        });
        public SolicitarPublicacaoAlbumHandler Handler { get; }
        public bool MusicAvailable = true;

        public RequestRig()
        {
            Handler = new(TestProxy.For<IUnitOfWork>((method, _) => { Events.Add(method); return null; }),
                Logger, Context, TestProxy.For<IDomainTrackingPolicy>(),
                TestProxy.For<IAlbumReadRepository>((_, _) => Album), TestProxy.For<IAlbumWriteRepository>(),
                TestProxy.For<IPublicacaoAlbumWriteRepository>((method, args) =>
                {
                    if (method == "CanRequestPublication")
                    {
                        Events.Add("CheckRequestWindow");
                        Assert.Equal(5, args[0]); Assert.Equal(7, args[1]); Assert.Equal(9, args[2]);
                        LastRequestCutoff = (DateTime)args[3]!;
                        return !Requests.Any(item => item.SolicitadaEmUtc > LastRequestCutoff);
                    }
                    Assert.Equal("Insert", method);
                    Events.Add("Insert"); Created = (IPublicacaoAlbumEntity)args[0]!;
                    Created.Id = Requests.Count + 3; Requests.Add(Created); return null;
                }),
                TestProxy.For<IySagaWriteRepository>((_, _) => { Events.Add("SaveSaga"); return null; }), Connections.Service,
                TestProxy.For<IFileStorage>((_, _) => Task.FromResult(MusicAvailable)));
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
                    if (method == "UpdateMensagem") Publication.mensagem = (string)args[1]!;
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
        public string Description = string.Empty;
        public HttpStatusCode? Failure;
        public HttpClient CreateClient(string name) => new(this, false);
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ++Requests;
            Token = request.Headers.Authorization?.Parameter;
            if (request.Method == HttpMethod.Post)
            {
                using var json = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
                Privacy = json.RootElement.GetProperty("status").GetProperty("privacyStatus").GetString();
                Description = json.RootElement.GetProperty("snippet").GetProperty("description").GetString()!;
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Location = new("https://www.googleapis.com/upload/youtube/v3/videos?upload_id=test");
                return response;
            }
            if (Failure.HasValue) return new(Failure.Value) { Content = new StringContent("SECRET upstream details") };
            return new(HttpStatusCode.OK) { Content = new StringContent("{\"id\":\"video-test\"}", Encoding.UTF8, "application/json") };
        }
    }
}
