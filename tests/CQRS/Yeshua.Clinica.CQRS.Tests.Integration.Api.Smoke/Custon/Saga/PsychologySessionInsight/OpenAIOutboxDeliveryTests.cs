using System.Net;
using System.Text;
using System.Text.Json;
using Clinica.Infrastructure.OutboxDelivery;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.OutBox;
using Command.Patterns.Queue;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Saga.SessionInsightFlowTests;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Saga;

public sealed class OpenAIOutboxDeliveryTests
{
    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Http_result_uses_the_same_Inbox_and_commits_with_Outbox_confirmation(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        await f.Run();
        Assert.Equal(1, f.HttpCalls);
        Assert.Equal(0, f.QueueCalls);
        Assert.Equal(1, f.InboxWrites);
        Assert.Equal(1, f.Done);
        Assert.Equal(new[] { "http", "begin", "inbox", "done", "commit" }, f.Events);
        using var body = JsonDocument.Parse(f.InboxPayload!);
        Assert.Equal("request-1", body.RootElement.GetProperty("requestId").GetString());
        Assert.Equal("step-1", body.RootElement.GetProperty("correlationId").GetString());
        Assert.Equal("audio.transcription.completed", body.RootElement.GetProperty("status").GetString());
        Assert.Equal("Relato fiel, com acentuação.", body.RootElement.GetProperty("result").GetProperty("text").GetString());
        Assert.Equal(provider.ToString(), JsonDocument.Parse(f.Event.transportdata).RootElement.GetProperty("DeliveryProvider").GetString());
        Assert.Equal(2, f.Event.transporttype);
        if (provider == TranscriptionDeliveryProvider.OpenAI)
        {
            Assert.Contains("name=languages[]", f.Multipart!.Replace("\"", ""));
            Assert.DoesNotContain("name=language;", f.Multipart.Replace("\"", ""));
            Assert.Contains("gpt-transcribe", f.Multipart);
            Assert.Equal("Bearer fixture-key", f.Authorization);
            Assert.Equal("https://api.openai.com/v1/audio/transcriptions", f.Endpoint);
        }
        else
        {
            Assert.Contains("name=language\r\n\r\npt", f.Multipart!.Replace("\"", ""));
            Assert.DoesNotContain("languages[]", f.Multipart);
            Assert.Contains("whisper-large-v3-turbo", f.Multipart);
            Assert.DoesNotContain("gpt-transcribe", f.Multipart);
            Assert.Equal("Bearer fixture-groq-key", f.Authorization);
            Assert.Equal("https://api.groq.com/openai/v1/audio/transcriptions", f.Endpoint);
        }
    }

    [Fact]
    public async Task Queue_strategy_preserves_delivery_and_receives_the_same_contract_later()
    {
        var f = new Fixture(TranscriptionDeliveryProvider.Queue);
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(1, f.QueueCalls);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(1, f.Done);
        var command = new InboxInputCommand
        {
            messageId = "queue-result", requestId = "request-1", correlationId = "step-1",
            status = "audio.transcription.completed", result = JsonSerializer.SerializeToElement(new { text = "texto" }),
            error = JsonSerializer.SerializeToElement<object?>(null), QueueName = "audio.transcribed.inbox"
        };
        await f.Inbox.ExecuteAsync(command);
        Assert.Equal(1, f.InboxWrites);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Summary_remains_a_separate_queue_request_when_transcription_uses_OpenAI(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        f.Event.type = "text.summarize";
        f.Event.transportdata = """{"Queue":"text.summarize.outbox","Exchange":"ai.tasks","RoutingKey":"text.summarize","TaskName":"app.tasks.summarize_session"}""";
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(1, f.QueueCalls);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(1, f.Done);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task A_lost_claim_rolls_back_Inbox_and_never_confirms_Outbox(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { LoseClaim = true };
        await f.Run();
        Assert.Equal(1, f.HttpCalls);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(0, f.Done);
        Assert.Contains("rollback", f.Events);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task An_already_received_result_is_not_sent_to_the_provider_again(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Accepted = true };
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(0, f.QueueCalls);
        Assert.Equal(1, f.Done);
        Assert.Equal(0, f.Bindings);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task An_obsolete_request_is_not_executed_or_applied(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Current = false };
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(1, f.Done);
    }

    [Fact]
    public async Task A_bound_provider_is_preserved_when_configuration_changes()
    {
        var f = new Fixture(TranscriptionDeliveryProvider.Queue);
        f.Event.transportdata = """{"DeliveryProvider":"OpenAI"}""";
        f.Event.transporttype = 2;
        await f.Run();
        Assert.Equal(1, f.HttpCalls);
        Assert.Equal(0, f.QueueCalls);
        Assert.Equal(0, f.Bindings);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Recovered_legacy_queue_request_does_not_silently_switch_to_OpenAI(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        f.Event.claimpreviousstatus = 9;
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(1, f.QueueCalls);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task A_transient_delivery_failure_only_schedules_Outbox_retry(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Status = HttpStatusCode.TooManyRequests, Response = """{"error":{"code":"rate_limit_exceeded"}}""" };
        await f.Run();
        Assert.Equal(1, f.Retries);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(0, f.DeadLetters);
        Assert.Equal("transcription_http_429", f.LastError);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Quota_failure_is_terminal_in_the_common_Inbox_without_exposing_provider_body(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Status = HttpStatusCode.TooManyRequests,
            Response = """{"error":{"code":"insufficient_quota","message":"fixture-private-body"}}""" };
        await f.Run();
        Assert.Equal(0, f.Retries);
        Assert.Equal(1, f.DeadLetters);
        Assert.Equal(1, f.InboxWrites);
        Assert.Equal("transcription_quota", f.LastError);
        Assert.DoesNotContain("fixture-private-body", f.InboxPayload!);
        Assert.DoesNotContain("fixture-key", f.InboxPayload!);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Exhausted_transport_retry_returns_terminal_failure_and_cannot_leave_an_invisible_wait(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Status = HttpStatusCode.ServiceUnavailable, Response = "{}" };
        f.Event.retrycount = 4;
        f.Event.transportdata = JsonSerializer.Serialize(new { DeliveryProvider = provider.ToString() });
        f.Event.transporttype = 2;
        await f.Run();
        Assert.Equal(1, f.DeadLetters);
        using var body = JsonDocument.Parse(f.InboxPayload!);
        Assert.Equal("external.delivery.failed", body.RootElement.GetProperty("status").GetString());
        Assert.False(body.RootElement.GetProperty("error").GetProperty("retryable").GetBoolean());
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task A_commit_failure_cannot_leave_only_the_Inbox_result_committed(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { FailCommitOnce = true };
        await f.Run();
        Assert.Equal(0, f.Done);
        Assert.Equal(0, f.InboxWrites);
        Assert.Equal(1, f.Retries);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Missing_credentials_produce_a_visible_terminal_failure_without_network(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider, apiKey: "", groqApiKey: "");
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal(1, f.InboxWrites);
        Assert.Equal(1, f.DeadLetters);
        Assert.Equal("transcription_credentials_missing", f.LastError);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task An_audio_reference_from_another_tenant_is_rejected_before_network(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        f.Event.payload = """{"StorageKey":"volatile/ia/transcriptions/input/2/71/audio.webm","uploadId":71}""";
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal("audio_reference_invalid", f.LastError);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Actual_mp4_content_is_sent_as_mp4_even_when_the_upload_filename_is_webm(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        f.Audio = new byte[] { 0, 0, 0, 24 }.Concat("ftypisom"u8.ToArray()).ToArray();
        await f.Run();
        Assert.Contains("audio.mp4", f.Multipart);
        Assert.Contains("audio/mp4", f.Multipart);
        Assert.Equal(1, f.InboxWrites);
    }

    [Theory]
    [InlineData(TranscriptionDeliveryProvider.OpenAI)]
    [InlineData(TranscriptionDeliveryProvider.Groq)]
    public async Task Failed_media_preparation_removes_temporary_audio_and_returns_common_failure(TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider);
        f.Audio = "unknown audio format"u8.ToArray();
        try
        {
            await f.Run();
            Assert.Equal(0, f.HttpCalls);
            Assert.Equal(1, f.DeadLetters);
            Assert.Equal(1, f.InboxWrites);
            Assert.Equal("ffmpeg_missing", f.LastError);
            var output = Path.Combine(f.StorageRoot, "volatile", "ia", "transcriptions", "output");
            Assert.Empty(Directory.GetFileSystemEntries(output));
        }
        finally
        {
            // The fixture creates this unique directory beneath the workspace test output only.
            if (Directory.Exists(f.StorageRoot)) Directory.Delete(f.StorageRoot, recursive: true);
        }
    }

    [Theory]
    [InlineData("{}", TranscriptionDeliveryProvider.OpenAI)]
    [InlineData("{\"text\":\"\"}", TranscriptionDeliveryProvider.OpenAI)]
    [InlineData("not-json", TranscriptionDeliveryProvider.OpenAI)]
    [InlineData("{}", TranscriptionDeliveryProvider.Groq)]
    [InlineData("{\"text\":\"\"}", TranscriptionDeliveryProvider.Groq)]
    [InlineData("not-json", TranscriptionDeliveryProvider.Groq)]
    public async Task Invalid_provider_success_cannot_be_applied_as_transcription(string response, TranscriptionDeliveryProvider provider)
    {
        var f = new Fixture(provider) { Response = response };
        await f.Run();
        Assert.Equal(1, f.DeadLetters);
        Assert.Contains("external.delivery.failed", f.InboxPayload);
    }

    [Fact]
    public void Request_body_cannot_inject_the_internal_HTTP_result_route()
    {
        var command = JsonSerializer.Deserialize<InboxInputCommand>(
            """{"QueueName":"audio.transcribed.inbox","ResultContract":"audio.transcribed"}""")!;
        Assert.Equal("", command.QueueName);
        Assert.Equal("", command.ResultContract);
    }

    [Fact]
    public async Task Bound_Groq_keeps_its_own_profile_after_switching_to_OpenAI()
    {
        var f = new Fixture();
        f.Event.transportdata = """{"DeliveryProvider":"Groq"}""";
        f.Event.transporttype = 2;
        await f.Run();
        Assert.Equal(1, f.HttpCalls);
        Assert.Equal("Bearer fixture-groq-key", f.Authorization);
        Assert.Equal("https://api.groq.com/openai/v1/audio/transcriptions", f.Endpoint);
        Assert.Equal(0, f.Bindings);
    }

    [Fact]
    public async Task Groq_does_not_fall_back_to_an_available_OpenAI_key()
    {
        var f = new Fixture(TranscriptionDeliveryProvider.Groq, groqApiKey: "");
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal("transcription_credentials_missing", f.LastError);
        Assert.Equal(1, f.DeadLetters);
    }

    [Fact]
    public async Task Groq_works_without_an_OpenAI_key()
    {
        var f = new Fixture(TranscriptionDeliveryProvider.Groq, apiKey: "");
        await f.Run();
        Assert.Equal(1, f.InboxWrites);
        Assert.Equal("Bearer fixture-groq-key", f.Authorization);
    }

    [Theory]
    [InlineData("http://api.groq.com/openai/v1")]
    [InlineData("https://user:password@api.groq.com/openai/v1")]
    [InlineData("https://api.groq.com/openai/v1?secret=value")]
    public async Task Invalid_Groq_endpoint_is_rejected_before_network(string endpoint)
    {
        var f = new Fixture(TranscriptionDeliveryProvider.Groq, groqBaseUrl: endpoint);
        await f.Run();
        Assert.Equal(0, f.HttpCalls);
        Assert.Equal("transcription_endpoint_invalid", f.LastError);
    }

    private sealed class Fixture
    {
        public readonly yOutboxDTO Event = new()
        {
            id = 4, messageid = "request-1", correlationid = "step-1", type = "audio.transcribe",
            payload = """{"StorageKey":"volatile/ia/transcriptions/input/1/71/audio.webm","uploadId":71}""",
            transportdata = """{"Queue":"audio.transcribe.outbox","Exchange":"ai.tasks","RoutingKey":"audio.transcribe","TaskName":"app.tasks.transcribe_audio"}""",
            transporttype = 1, tenantid = 1, userid = 7, processingscope = "clinica-test",
            processingat = DateTime.UtcNow, claimpreviousstatus = 0
        };
        public readonly InboxListenerHandler Inbox;
        private readonly yOutBoxWorkerHandler _worker;
        public readonly List<string> Events = [];
        public bool LoseClaim, Accepted, FailCommitOnce;
        public bool Current = true;
        public int HttpCalls, QueueCalls, InboxWrites, Done, Retries, DeadLetters, Bindings;
        public string? InboxPayload, Multipart, Authorization, LastError, Endpoint;
        public HttpStatusCode Status = HttpStatusCode.OK;
        public string Response = """{"text":"Relato fiel, com acentuação."}""";
        public byte[] Audio = new byte[] { 0x1a, 0x45, 0xdf, 0xa3 }.Concat(new byte[12]).ToArray();
        public readonly string StorageRoot = Path.Combine(AppContext.BaseDirectory, "audio-preparation-" + Guid.NewGuid().ToString("N"));
        private bool _transaction, _pendingInbox, _pendingDone, _pendingDeadLetter;

        public Fixture(TranscriptionDeliveryProvider provider = TranscriptionDeliveryProvider.OpenAI, string apiKey = "fixture-key",
            string groqApiKey = "fixture-groq-key", string groqBaseUrl = "https://api.groq.com/openai/v1")
        {
            var context = new Context();
            var logger = new Shered.Logger.Logger();
            var work = Fake<IUnitOfWork>((name, _) =>
            {
                switch (name)
                {
                    case "BeginTran": Assert.False(_transaction); _transaction = true; Events.Add("begin"); break;
                    case "Commit":
                        if (FailCommitOnce) { FailCommitOnce = false; throw new IOException("fixture commit"); }
                        if (_pendingInbox) { InboxWrites++; Accepted = true; }
                        if (_pendingDone) Done++;
                        if (_pendingDeadLetter) DeadLetters++;
                        _pendingInbox = _pendingDone = _pendingDeadLetter = false;
                        _transaction = false; Events.Add("commit"); break;
                    case "Rollback":
                        _pendingInbox = _pendingDone = _pendingDeadLetter = false;
                        _transaction = false; Events.Add("rollback"); break;
                }
                return null;
            });
            var steps = Fake<IySagaStepReadRepository>((name, _) => name == "CanReceiveResult" ? !Accepted && Current
                : new ySagaStepDTO { id = 3, sagaid = 2, stepkey = "AudioTranscriptRequested" });
            var sagas = Fake<IySagaReadRepository>((_, _) => new ySagaDTO
                { id = 2, type = "PsychologySessionInsightSaga", processingscope = "clinica-test",
                    tenantid = 1, userid = 7, entitytype = "Sesoes", entityid = "509" });
            var service = new OutboxService(Fake<IyOutboxWriteRepository>((_, _) => null),
                Fake<IyInboxWriteRepository>((name, args) =>
                {
                    if (name == "Insert")
                    {
                        Assert.True(_transaction);
                        _pendingInbox = true; Events.Add("inbox");
                        InboxPayload = ((Dominio.Entitys.IyInboxEntity)args![0]!).Payload;
                    }
                    return null;
                }), context, logger);
            Inbox = new(steps, sagas, service, work, logger, context);
            var reads = Fake<IyOutboxReadRepository>((name, args) => name switch
            {
                "ClaimBatch" => new List<yOutboxDTO> { Event },
                "HasAcceptedDeliveryResult" => Accepted,
                "IsCurrentDelivery" => Current,
                "BindDeliveryProvider" => Bind((string)args![2]!, (int)args[3]!),
                "MarkDeliveryDone" => MarkDone(),
                "MarkDeliveryRetry" => Retry((string)args![4]!),
                "MarkDeliveryDeadLetter" => DeadLetter((string)args![2]!),
                _ => throw new InvalidOperationException(name)
            });
            var publisher = Fake<IQueuePublisher>((_, _) =>
            {
                Assert.False(_transaction); QueueCalls++; Events.Add("queue"); return Task.FromResult(true);
            });
            var storage = Fake<IFileStorage>((name, _) => name switch
            {
                "ExistsAsync" => Task.FromResult(true),
                "OpenRead" => new MemoryStream(Audio),
                _ => throw new InvalidOperationException(name)
            });
            var options = new ClinicaTranscriptionOptions
            {
                Provider = provider, ApiKey = apiKey, StorageRoot = StorageRoot,
                Groq = new GroqTranscriptionOptions { ApiKey = groqApiKey, BaseUrl = groqBaseUrl },
                FFmpegExecutable = Path.Combine(StorageRoot, "missing-ffmpeg")
            };
            var http = new HttpClient(new HttpStub(async request =>
            {
                Assert.False(_transaction);
                HttpCalls++; Events.Add("http");
                Multipart = await request.Content!.ReadAsStringAsync();
                Authorization = request.Headers.Authorization?.ToString();
                Endpoint = request.RequestUri?.AbsoluteUri;
                return new HttpResponseMessage(Status) { Content = new StringContent(Response, Encoding.UTF8, "application/json") };
            }));
            var factory = new TranscriptionDeliveryFactory(new QueueOutboxDeliveryStrategy(publisher),
                new OpenAITranscriptionDeliveryStrategy(http, storage, options),
                new GroqTranscriptionDeliveryStrategy(http, storage, options), options);
            _worker = new(work, reads, Fake<IyOutboxWriteRepository>((_, _) => null), publisher, logger, context, Inbox, factory);
        }
        public async Task Run() => await _worker.ExecuteAsync(new yOutboxInputCommand());
        private string Bind(string provider, int type)
        {
            Bindings++; Event.transporttype = type;
            using var document = JsonDocument.Parse(Event.transportdata);
            var values = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(Event.transportdata)!;
            values["DeliveryProvider"] = JsonSerializer.SerializeToElement(provider);
            return Event.transportdata = JsonSerializer.Serialize(values);
        }
        private bool MarkDone()
        {
            Assert.True(_transaction);
            if (LoseClaim) return false;
            _pendingDone = true; Events.Add("done"); return true;
        }
        private bool Retry(string code)
        {
            Assert.True(_transaction); Retries++; LastError = code; return true;
        }
        private bool DeadLetter(string code)
        {
            Assert.True(_transaction); _pendingDeadLetter = true; LastError = code; return true;
        }
    }
    private sealed class HttpStub(Func<HttpRequestMessage, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => send(request);
    }
}
