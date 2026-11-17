using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Command.Patterns.FileUpload;
using Command.Receivers.UseCase;
using Command.UseCase;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Yeshua.Central.CQRS.Tests.Integration.Api.Smoke.Custon.Support;

public sealed class HelpSupportTests
{
    [Fact]
    public async Task Preparing_does_not_submit_and_opening_is_idempotent_with_reviewed_text()
    {
        var fixture = new Fixture();
        var first = await fixture.Run("Preparar");
        Assert.Equal(200, first.StatusCode); Assert.False(first.Data.Aberto);
        Assert.Equal(0, fixture.Opened);
        await fixture.Run("Preparar"); Assert.Equal(1, fixture.Inserted);
        var submitted = await fixture.Run("Abrir", "Assunto", "Texto revisado pelo usuario.");
        Assert.True(submitted.Data.Aberto); Assert.Equal(1, fixture.Opened);
        var retried = await fixture.Run("Abrir", "Outra descricao", "Outro texto");
        Assert.Equal(1, fixture.Opened);
        Assert.Equal("Texto revisado pelo usuario.", retried.Data.Descricao);
        Assert.Matches(@"^\d+\.\d+\.\d+$", submitted.Data.Versao);
    }

    [Theory]
    [InlineData(9, 7)]
    [InlineData(2, 8)]
    public async Task Another_tenant_or_user_cannot_read_submit_or_record_for_the_draft(int tenant, int user)
    {
        var f = new Fixture(); await f.Run("Preparar");
        f.Context.SetTenantId(tenant); f.Context.SetUserId(user);
        foreach (var operation in new[] { "Consultar", "AutorizarGravacao", "Abrir" })
        {
            var result = await f.Run(operation, "Assunto", "Texto");
            Assert.Equal(400, result.StatusCode);
        }
        Assert.Equal(0, f.Opened);
    }

    [Fact]
    public async Task Transcription_is_returned_for_review_without_opening_or_replacing_the_ticket()
    {
        var f = new Fixture(); await f.Run("Preparar");
        f.Ticket!.UploadId = 1; f.Ticket.UploadStatus = 1; f.Ticket.SagaId = 71;
        f.Ticket.StepStatus = 5; f.Ticket.TranscriptPayload = "{\"text\":\"Relato transcrito.\"}";
        var result = await f.Run("Consultar");
        Assert.Equal("completed", result.Data.TranscricaoStatus);
        Assert.Equal("Relato transcrito.", result.Data.Transcricao);
        Assert.False(result.Data.Aberto); Assert.Empty(result.Data.Descricao); Assert.Equal(0, f.Opened);
        f.Ticket.StepStatus = 6;
        Assert.Equal("failed", (await f.Run("Consultar")).Data.TranscricaoStatus);
    }

    [Fact]
    public async Task Metadata_cannot_store_query_secrets_and_empty_description_cannot_open()
    {
        var f = new Fixture();
        var invalid = await f.Handler.ExecuteAsync(new ExecutarChamadoSuporteInputCommand {
            ChamadoId = f.Id, Operacao = "Preparar", Aplicativo = "Memorias", Caminho = "/spa?token=private" });
        Assert.NotEqual(200, invalid.StatusCode); Assert.Equal(0, f.Inserted);
        await f.Run("Preparar");
        Assert.Equal(400, (await f.Run("Abrir", "Assunto", " ")).StatusCode);
        Assert.Equal(0, f.Opened);
    }

    [Fact]
    public void Upload_tokens_are_actor_bound_and_separate_from_clinical_tokens()
    {
        var central = new UploadTokenHelper(new string('c', 64));
        var clinic = new UploadTokenHelper(new string('k', 64));
        var token = central.Generate(1, 7, 2);
        Assert.Equal((1, 7, 2), central.ValidateAndExtract(token));
        Assert.ThrowsAny<Exception>(() => clinic.ValidateAndExtract(token));
        Assert.NotEqual(AudioChunkStorage.AudioKey(2, 1), AudioChunkStorage.AudioKey(2, 1, "central"));
        Assert.ThrowsAny<Exception>(() => AudioChunkStorage.AudioKey(2, 1, "../escape"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Shared_http_transcriber_accepts_Central_contract_and_isolates_its_audio(bool groq)
    {
        var storage = Fake<Command.Interfaces.Patterns.FileStore.IFileStorage>((name, _) => name switch {
            "ExistsAsync" => Task.FromResult(true),
            "OpenRead" => new MemoryStream("RIFF0000WAVEfixture"u8.ToArray()), _ => null });
        using var client = new HttpClient(new MockHttp());
        var options = new global::Central.Infrastructure.OutboxDelivery.CentralTranscriptionOptions {
            ApiKey="fixture", Groq=new() { ApiKey="fixture" } };
        Command.Patterns.OutBox.IOutboxDeliveryStrategy strategy = groq
            ? new global::Central.Infrastructure.OutboxDelivery.GroqTranscriptionDeliveryStrategy(client,storage,options)
            : new global::Central.Infrastructure.OutboxDelivery.OpenAITranscriptionDeliveryStrategy(client,storage,options);
        var message = new Command.Patterns.Queue.QueueMessage("audio.transcribe",
            JsonSerializer.Serialize(new { StorageKey=AudioChunkStorage.AudioKey(2,1,"central"),uploadId=1 })) {
            MenssageId="support-request",CorrelationId="support-step" };
        var request = new Command.Patterns.OutBox.OutboxDeliveryRequest(message,"{}",2,2,"central.audio.transcribed");
        var result = await strategy.DeliverAsync(request,CancellationToken.None);
        Assert.Equal("Relato de suporte.",result!.result.GetProperty("text").GetString());
        Assert.Equal("support-request",result.requestId);
        await Assert.ThrowsAsync<Command.Patterns.OutBox.OutboxDeliveryException>(() =>
            strategy.DeliverAsync(request with { ResultContract="audio.transcribed" },CancellationToken.None));
    }
    private sealed class MockHttp : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK) {
                Content=new StringContent("{\"text\":\"Relato de suporte.\"}") });
    }

    private sealed class Fixture
    {
        public readonly string Id = Guid.NewGuid().ToString("N");
        public readonly Context Context = new();
        public readonly ExecutarChamadoSuporteHandler Handler;
        public SupportTicketData? Ticket;
        public int Inserted, Opened;
        public Fixture()
        {
            var read = Fake<IChamadoSuporteReadRepository>((_, args) =>
                Context.TenantID == 2 && Context.UserId == 7 && (string)args![0]! == Id ? Ticket : null);
            var write = Fake<IChamadoSuporteWriteRepository>((name, args) => {
                if (name == "InserirRascunho") { Ticket = (SupportTicketData)args![0]!; Inserted++; }
                if (name == "Abrir") { Opened++; return true; }
                return null;
            });
            Handler = new(new Shered.Logger.Logger(), Context, Fake<IUnitOfWork>((_, _) => null), read, write);
        }
        public Task<RepositoryInterfaces.Patterns.Command.State<ExecutarChamadoSuporteOutputCommand>> Run(string operation, string subject="", string text="")
            => Handler.ExecuteAsync(new ExecutarChamadoSuporteInputCommand {
                ChamadoId=Id, Operacao=operation, Aplicativo="Memorias", Modulo="Albuns", Tela="memorias-estudio",
                Caminho="/spa/", Rota="#dashboard", Assunto=subject, Descricao=text });
    }
    private sealed class Context : IExecutionContext
    {
        public int UserId { get; private set; } = 7;
        public int TenantID { get; private set; } = 2;
        public string TraceId => "help-test";
        public string ProcessingScope => "help-test";
        public ExecutionOrigin Origem => (ExecutionOrigin)0;
        public IEnumerable<Claim> Claims => [];
        public void SetTenantId(int id) => TenantID=id;
        public void SetUserId(int id) => UserId=id;
        public void SetTraceId(string id) { }
        public void SetOrigem(ExecutionOrigin origin) { }
    }
    public class Stub<T> : DispatchProxy
    {
        public Func<string, object?[]?, object?> Call = default!;
        protected override object? Invoke(MethodInfo? method, object?[]? args) => Call(method!.Name,args);
    }
    private static T Fake<T>(Func<string,object?[]?,object?> call) where T:class
    {
        var proxy=DispatchProxy.Create<T,Stub<T>>(); ((Stub<T>)(object)proxy).Call=call; return proxy;
    }
}
