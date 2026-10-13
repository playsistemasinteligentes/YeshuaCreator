using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Dominio.Patterns.Saga;
using Memorias.YouTube;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public sealed class YouTubeResumableUploadTests
{
    private const string Session = "https://www.googleapis.com/upload/youtube/v3/videos?upload_id=private-session";

    [Fact]
    public async Task LostFinalResponseIsRecoveredWithoutStartingAnotherUpload()
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => throw new HttpRequestException("SECRET session URI"));
        var failure = await Assert.ThrowsAsync<SagaStepExecutionException>(() => rig.Send());
        Assert.DoesNotContain("SECRET", failure.Message);
        rig.Http.Responses.Enqueue(request =>
        {
            Assert.Equal("bytes */6", request.Range);
            Assert.Empty(request.Bytes);
            return Completed();
        });
        Assert.Equal("video-test", await rig.Send());
        Assert.Equal(1, rig.Http.Requests.Count(request => request.Method == HttpMethod.Post));
        Assert.Equal(3, rig.Http.Requests.Count);
        var stored = Directory.GetFiles(rig.Connections.Root, "upload-*.bin", SearchOption.AllDirectories).Single();
        Assert.DoesNotContain("private-session", Encoding.UTF8.GetString(File.ReadAllBytes(stored)));
    }

    [Fact]
    public async Task ReceiptSurvivesDatabaseFailureAndDisconnectedCredential()
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => Completed());
        Assert.Equal("video-test", await rig.Send());
        await rig.Connections.Service.DisconnectAsync(new(7, 9), rig.Upload!.ConnectionId, default);
        // Simula outra instancia do Worker retomando depois de falha de persistencia.
        rig.Uploader = new(new EncryptedYouTubeAccountRepository(rig.Connections.Options), rig.Connections.Service, rig.Http);
        Assert.Equal("video-test", await rig.Send());
        Assert.Equal(2, rig.Http.Requests.Count);
    }

    [Fact]
    public async Task InterruptedUploadResumesFromAcknowledgedByte()
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => new(HttpStatusCode.ServiceUnavailable));
        await Assert.ThrowsAsync<SagaStepExecutionException>(() => rig.Send());
        rig.Http.Responses.Enqueue(_ => Incomplete("bytes=0-2"));
        rig.Http.Responses.Enqueue(request =>
        {
            Assert.Equal("bytes 3-5/6", request.Range);
            Assert.Equal(new byte[] { 4, 5, 6 }, request.Bytes);
            return Completed();
        });
        Assert.Equal("video-test", await rig.Send());
    }

    [Theory]
    [InlineData("bytes=1-2")]
    [InlineData("bytes=0-6")]
    [InlineData("bytes=0-2,4-5")]
    [InlineData("invalid")]
    public async Task InvalidAcknowledgmentStopsWithoutResending(string range)
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => new(HttpStatusCode.ServiceUnavailable));
        await Assert.ThrowsAsync<SagaStepExecutionException>(() => rig.Send());
        rig.Http.Responses.Enqueue(_ => Incomplete(range));
        await Assert.ThrowsAsync<YouTubeUploadReviewException>(() => rig.Send());
        Assert.Equal(3, rig.Http.Requests.Count);
    }

    [Theory]
    [InlineData(404)]
    [InlineData(410)]
    public async Task ExpiredSessionNeverCreatesAnotherVideoAutomatically(int code)
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => new(HttpStatusCode.ServiceUnavailable));
        await Assert.ThrowsAsync<SagaStepExecutionException>(() => rig.Send());
        rig.Http.Responses.Enqueue(_ => new((HttpStatusCode)code));
        await Assert.ThrowsAsync<YouTubeUploadReviewException>(() => rig.Send());
        Assert.Equal(1, rig.Http.Requests.Count(request => request.Method == HttpMethod.Post));
    }

    [Theory]
    [InlineData("https://evil.example/upload/youtube/v3/videos")]
    [InlineData("https://www.googleapis.com:8443/upload/youtube/v3/videos")]
    [InlineData("https://attacker@www.googleapis.com/upload/youtube/v3/videos")]
    [InlineData("https://www.googleapis.com/other")]
    public async Task UnexpectedSessionAddressCannotReceiveTokenOrVideo(string uri)
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started(uri));
        await Assert.ThrowsAsync<YouTubeUploadReviewException>(() => rig.Send());
        Assert.Single(rig.Http.Requests);
        Assert.Empty(Directory.GetFiles(rig.Connections.Root, "upload-*.bin", SearchOption.AllDirectories));
    }

    [Theory]
    [InlineData("video")]
    [InlineData("channel")]
    [InlineData("connection")]
    public async Task ExistingSessionRejectsChangedMediaOrDestination(string changed)
    {
        using var rig = new Rig();
        await rig.Initialize();
        rig.Http.Responses.Enqueue(_ => Started());
        rig.Http.Responses.Enqueue(_ => new(HttpStatusCode.ServiceUnavailable));
        await Assert.ThrowsAsync<SagaStepExecutionException>(() => rig.Send());
        if (changed == "channel") rig.Upload = rig.Upload! with { ChannelId = "channel-b" };
        if (changed == "connection") rig.Upload = rig.Upload! with { ConnectionId = Guid.NewGuid().ToString("N") };
        if (changed == "video") rig.Bytes = [6, 5, 4, 3, 2, 1];
        await Assert.ThrowsAsync<YouTubeUploadReviewException>(() => rig.Send());
        Assert.Equal(2, rig.Http.Requests.Count);
    }

    private static HttpResponseMessage Started(string uri = Session)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Headers.Location = new(uri);
        return response;
    }
    private static HttpResponseMessage Completed() => new(HttpStatusCode.Created)
    {
        Content = new StringContent("{\"id\":\"video-test\"}")
    };
    private static HttpResponseMessage Incomplete(string range)
    {
        var response = new HttpResponseMessage((HttpStatusCode)308);
        response.Headers.TryAddWithoutValidation("Range", range);
        return response;
    }

    private sealed class Rig : IDisposable
    {
        public YouTubeConnectionTests.Rig Connections { get; } = new();
        public HttpStub Http { get; } = new();
        public ResumableYouTubeVideoUploader Uploader;
        public YouTubeVideoUpload? Upload;
        public byte[] Bytes = [1, 2, 3, 4, 5, 6];
        public Rig() => Uploader = new(Connections.Repository, Connections.Service, Http);
        public async Task Initialize()
        {
            var account = await Connections.Connect("channel-a");
            Upload = new(new(7, 9), 3, account.ConexaoId, "channel-a", "video.mp4", "Album", "", "private");
        }
        public async Task<string> Send()
        {
            using var video = new MemoryStream(Bytes);
            return await Uploader.UploadAsync(Upload!, video, default);
        }
        public void Dispose() => Connections.Dispose();
    }

    private sealed record Request(HttpMethod Method, string? Range, byte[] Bytes);
    private sealed class HttpStub : HttpMessageHandler, IHttpClientFactory
    {
        public Queue<Func<Request, HttpResponseMessage>> Responses { get; } = new();
        public List<Request> Requests { get; } = [];
        public HttpClient CreateClient(string name) => new(this, false);
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var captured = new Request(request.Method, request.Content?.Headers.ContentRange?.ToString(),
                request.Content == null ? [] : await request.Content.ReadAsByteArrayAsync(cancellationToken));
            Requests.Add(captured);
            return Responses.Dequeue()(captured);
        }
    }
}
