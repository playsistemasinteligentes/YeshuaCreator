using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Patterns;
using Command.Patterns.OutBox;
using Command.Receivers;
using Command.Receivers.UseCase;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using Microsoft.AspNetCore.Http;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Saga;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Saga;

public class SessionInsightFlowTests
{
    private static readonly string UploadOperationId = Guid.NewGuid().ToString("N");
    private static readonly JsonSerializerOptions Json = new() { PropertyNameCaseInsensitive = true };
    private static string Transcript() => JsonSerializer.Serialize(new
        { status = "audio.transcription.completed", result = new { text = "relato de teste" } });
    private static string Summary() => JsonSerializer.Serialize(new
        { status = "text.summarize.completed", result = new { fields = new[]
        {
            new { key = "Prontuario", value = "registro de teste" },
            new { key = "QueixaPrincipal", value = "" },
            new { key = "RegistroDocumental", value = "fatos explicitamente relatados" }
        } } });

    [Fact]
    public void Transcription_waits_and_summary_is_a_separate_order_for_the_correct_session()
    {
        var fixture = new Fixture();
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStepStatus.WaitingResponse, fixture.Saga.GetCurrent().Status);
        Assert.Equal(1, fixture.Saga.GetCurrent().ExecutionCount);
        Assert.Single(fixture.Requests);
        Assert.Equal(0, fixture.Applied);
        using (var doc = JsonDocument.Parse(fixture.Requests[0]))
            Assert.Equal(71, doc.RootElement.GetProperty("uploadId").GetInt32());

        fixture.Receive(Transcript());
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStepStatus.Completed, fixture.Saga.Steps.First().Status);
        Assert.Equal(0, fixture.Applied); // Literal transcription is not written to Prontuario.
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStepStatus.WaitingResponse, fixture.Saga.GetCurrent().Status);
        Assert.Equal(2, fixture.Requests.Count);
        using (var doc = JsonDocument.Parse(fixture.Requests[1]))
        {
            Assert.Equal(509, doc.RootElement.GetProperty("sessaoId").GetInt32());
            Assert.Equal("relato de teste", doc.RootElement.GetProperty("context").GetProperty("transcricao").GetString());
        }
        fixture.Receive(Summary());
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStatus.Completed, fixture.Saga.Status);
        Assert.Equal(0, fixture.Applied); // A completed suggestion must never overwrite a human chart.
        Assert.Equal("registro de teste", SessionInsightContract.ReadSummary(fixture.Saga.Steps.Last().Payload)["Prontuario"]);
    }

    [Fact]
    public void Incomplete_summary_fails_without_applying_any_field()
    {
        var fixture = new Fixture();
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Receive(Transcript());
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Receive("{\"status\":\"text.summarize.completed\",\"result\":{\"fields\":[]}}");
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStatus.Failed, fixture.Saga.Status);
        Assert.True(fixture.Saga.LastExecutionFailed);
        Assert.Equal(0, fixture.Applied);
        Assert.Equal(SagaStepStatus.Completed, fixture.Saga.Steps.First().Status);
    }

    [Fact]
    public void Technical_result_failure_schedules_retry_and_does_not_retranscribe_a_completed_step()
    {
        var fixture = new Fixture();
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Receive(Transcript());
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        fixture.Receive("{\"status\":\"text.summarize.failed\",\"error\":{\"retryable\":true}}");
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(SagaStatus.InProgress, fixture.Saga.Status);
        Assert.True(fixture.Saga.LastExecutionFailed);
        Assert.Equal(SagaStepStatus.Pending, fixture.Saga.GetCurrent().Status);
        Assert.True(fixture.Saga.NextExecutionAt > DateTime.UtcNow);
        Assert.Equal(SagaStepStatus.Completed, fixture.Saga.Steps.First().Status);
        Assert.Equal(0, fixture.Applied);
        fixture.Executor.Execute(fixture.Saga, fixture.Resolver);
        Assert.Equal(2, fixture.Requests.Count); // Backoff is respected.
    }

    [Fact]
    public void Duplicated_final_chunk_returns_existing_saga_without_writing_or_starting_again()
    {
        var fixture = new Fixture();
        var context = new Context();
        var work = Fake<IUnitOfWork>((_, _) => null);
        var uploads = Fake<IyFileUploadReadRepository>((_, _) => new yFileUploadDTO
        { id = 71, status = 1, entityid = "509", entitytype = "Sesoes", operationalentityid = UploadOperationId });
        var write = Fake<IyFileUploadWriteRepository>((name, _) => name == "LockUploadForCurrentActor" ? true : null);
        var sagaReads = Fake<IySagaReadRepository>((_, _) => new ySagaDTO { id = 80, correlationid = Guid.Parse(UploadOperationId).ToString("D") });
        var saves = 0;
        var sagaWrites = Fake<IySagaWriteRepository>((_, _) => { saves++; return null; });
        var token = new UploadTokenHelper(new string('x', 32));
        var handler = new SendFileHandler(work, uploads, write, fixture.Storage, token, sagaReads, sagaWrites,
            Fake<ISesoesReadRepository>((_, _) => new global::Clinica.Atendimentos.RegistroAtendimentoInfo(Id: 509)), fixture.Sessions, fixture.Logger, context);
        var input = new SendFileInputCommand
        {
            token = token.Generate(71, 7, 1), IsFinalChunk = true, ChunkIndex = 2,
            FileStream = new FormFile(new MemoryStream(new byte[] { 1 }), 0, 1, "audio", "audio.webm")
        };
        var result = handler.ExecuteAsync(input).GetAwaiter().GetResult();
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(80, result.Data.SagaId);
        Assert.Equal(0, saves);
        Assert.Empty(fixture.Requests);
    }

    [Theory]
    [InlineData("{\"text\":\"\"}")]
    [InlineData("{\"status\":\"audio.transcription.failed\",\"error\":{}}")]
    [InlineData("{\"result\":{\"text\":\"texto\"}}")]
    public void Invalid_transcriptions_are_rejected(string payload)
        => Assert.Throws<SagaStepExecutionException>(() => SessionInsightContract.ReadTranscript(payload));

    [Fact]
    public void Summary_rejects_unknown_or_duplicated_fields()
    {
        var valid = Summary();
        Assert.Throws<SagaStepExecutionException>(() => SessionInsightContract.ReadSummary(valid.Replace("QueixaPrincipal", "Prontuario")));
        Assert.Throws<SagaStepExecutionException>(() => SessionInsightContract.ReadSummary(valid.Replace("QueixaPrincipal", "Outro")));
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void Result_entry_restores_actor_and_stores_only_an_accepted_attempt(bool accepted, int expectedWrites)
    {
        var context = new Context();
        var logger = new Shered.Logger.Logger();
        var writes = 0;
        var steps = Fake<IySagaStepReadRepository>((name, _) => name == "CanReceiveResult" ? accepted :
            new ySagaStepDTO { id = 91, sagaid = 80, stepkey = "AudioTranscriptRequested" });
        var sagas = Fake<IySagaReadRepository>((_, _) => new ySagaDTO
        {
            id = 80, type = "PsychologySessionInsightSaga", entitytype = "Sesoes", entityid = "509",
            processingscope = "clinica-test", tenantid = 2, userid = 9, correlationid = Guid.NewGuid().ToString()
        });
        var service = new OutboxService(Fake<IyOutboxWriteRepository>((_, _) => null),
            Fake<IyInboxWriteRepository>((name, _) =>
            {
                if (name == "Insert")
                {
                    writes++;
                    Assert.Equal(2, context.TenantID);
                    Assert.Equal(9, context.UserId);
                }
                return null;
            }), context, logger);
        var receiver = new InboxListenerHandler(steps, sagas, service, Fake<IUnitOfWork>((_, _) => null), logger, context);
        var command = JsonSerializer.Deserialize<InboxInputCommand>(
            "{\"messageId\":\"result\",\"requestId\":\"request\",\"correlationId\":\"step\",\"status\":\"audio.transcription.completed\",\"result\":{\"text\":\"teste\"},\"error\":null}")!;
        command.QueueName = "audio.transcribed.inbox";
        var state = receiver.ExecuteAsync(command).GetAwaiter().GetResult();
        Assert.Equal(200, state.StatusCode);
        Assert.Equal(expectedWrites, writes);
    }

    [Fact]
    public void Message_body_cannot_select_its_own_queue_route()
    {
        var command = JsonSerializer.Deserialize<InboxInputCommand>("{\"QueueName\":\"audio.transcribed.inbox\"}")!;
        Assert.Equal("", command.QueueName);
    }

    private sealed class Fixture
    {
        public readonly Shered.Logger.Logger Logger = new();
        public readonly PsychologySessionInsightSaga Saga = new();
        public readonly SagaExecutor Executor;
        public readonly Resolver Resolver;
        public readonly List<string> Requests = new();
        public readonly IFileStorage Storage;
        public readonly ISesoesWriteRepository Sessions;
        public int Applied, AppliedSession;
        public Fixture()
        {
            var context = new Context();
            Storage = Fake<IFileStorage>((name, _) => name switch
            { "ExistsAsync" => Task.FromResult(true), "GetBaseUrl" => "https://fixture.invalid/audio", _ => null });
            Sessions = Fake<ISesoesWriteRepository>((name, args) =>
            {
                if (name == "ApplyInsight") { Applied++; AppliedSession = (int)args![0]!; }
                return null;
            });
            var uploads = Fake<IyFileUploadReadRepository>((_, _) => new yFileUploadDTO
            { id = 71, entityid = "509", entitytype = "Sesoes", filepath = "volatile/ia/transcriptions/input/1/71/audio.webm" });
            var outbox = new OutboxService(Fake<IyOutboxWriteRepository>((name, args) =>
            {
                if (name == "Insert") Requests.Add(((IyOutboxEntity)args![0]!).Payload);
                return null;
            }), Fake<IyInboxWriteRepository>((_, _) => null), context, Logger);
            var transcribe = new AudioTranscriptRequestedHandler(uploads, Storage, outbox);
            var summarize = new ReportEndProntuaryRequestedHandler(uploads, Sessions, outbox);
            Resolver = new Resolver(transcribe, summarize);
            Executor = new SagaExecutor(Logger);
            Saga.Start("509", "Sesoes");
            Saga.SetCorrelationId(UploadOperationId);
        }
        public void Receive(string payload) { Saga.GetCurrent().SetPayload(payload); Saga.GetCurrent().SetPendingApply(); }
    }
    private sealed class Resolver(params ISagaStepHandler[] handlers) : ISagaHandlerResolver
    {
        public Dictionary<string, ISagaStepHandler> GetHandlers() => handlers.ToDictionary(h => h.Key);
    }
    internal sealed class Context : IExecutionContext
    {
        public int UserId { get; private set; } = 7;
        public int TenantID { get; private set; } = 1;
        public string TraceId => "test";
        public string ProcessingScope => "clinica-test";
        public ExecutionOrigin Origem => (ExecutionOrigin)0;
        public IEnumerable<Claim> Claims => [];
        public void SetTenantId(int id) => TenantID = id;
        public void SetUserId(int id) => UserId = id;
        public void SetTraceId(string id) { }
        public void SetOrigem(ExecutionOrigin origin) { }
    }
    public class Stub<T> : DispatchProxy
    {
        public Func<string, object?[]?, object?> Call = default!;
        protected override object? Invoke(MethodInfo? method, object?[]? args) => Call(method!.Name, args);
    }
    internal static T Fake<T>(Func<string, object?[]?, object?> call) where T : class
    {
        var proxy = DispatchProxy.Create<T, Stub<T>>();
        ((Stub<T>)(object)proxy).Call = call;
        return proxy;
    }
}
