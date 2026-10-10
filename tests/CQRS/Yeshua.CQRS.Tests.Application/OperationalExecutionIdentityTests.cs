using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Command.Patterns.Queue;
using Dominio.Interfaces;
using Dominio.Operational;
using RepositoryInterfaces.Patterns.Command;
using Shered.DB.Connection;
using Shared.Operational;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Yeshua.CQRS.Tests.Application;

public sealed class OperationalExecutionIdentityTests
{
    [Fact]
    public void ReadingInactiveStateDoesNotCreateAnExecutionIdentity()
    {
        var state = new OperationalExecutionIdentityState("root-client");

        Assert.False(state.TryGetCurrent(out var inactive));
        Assert.Equal(default, inactive);

        using (state.Begin("Command"))
        {
            Assert.True(state.TryGetCurrent(out var active));
            Assert.Equal("root-client", active.RootOperationId);
            Assert.False(string.IsNullOrWhiteSpace(active.ExecutionId));
        }

        Assert.False(state.TryGetCurrent(out _));
    }

    [Fact]
    public void NestedOperationsPreserveRootAndLinkCausation()
    {
        var state = new OperationalExecutionIdentityState("root-client", "cause-client");

        using var parentScope = state.Begin("Parent");
        var parent = state.Current;
        using (state.Begin("Child"))
        {
            var child = state.Current;
            Assert.Equal(parent.RootOperationId, child.RootOperationId);
            Assert.NotEqual(parent.OperationId, child.OperationId);
            Assert.NotEqual(parent.ExecutionId, child.ExecutionId);
            Assert.Equal(parent.ExecutionId, child.CausationId);
        }

        Assert.Equal(parent, state.Current);
    }

    [Fact]
    public async Task ReceiverAndRepositoryPublishTheSameSynchronousIdentity()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(new EnabledPolicy(), sink);
        var context = new TestExecutionContext("root-http", "caller-execution");
        var repositoryTelemetry = new RepositoryTelemetry(logger, context);
        var receiver = new CorrelatedReceiver(logger, context, repositoryTelemetry);

        await receiver.ExecuteAsync(new CorrelatedCommand());

        using var command = sink.Single("Command", "Command.Completed");
        using var repository = sink.Single("Repository");
        var commandData = command.RootElement.GetProperty("Data");
        var repositoryData = repository.RootElement.GetProperty("Data");

        Assert.Equal("root-http", commandData.GetProperty("RootOperationId").GetString());
        Assert.Equal("caller-execution", commandData.GetProperty("CausationId").GetString());
        Assert.Equal(
            commandData.GetProperty("RootOperationId").GetString(),
            repositoryData.GetProperty("RootOperationId").GetString());
        Assert.Equal(
            commandData.GetProperty("OperationId").GetString(),
            repositoryData.GetProperty("OperationId").GetString());
        Assert.Equal(
            commandData.GetProperty("ExecutionId").GetString(),
            repositoryData.GetProperty("ExecutionId").GetString());
        Assert.NotEqual(
            commandData.GetProperty("OperationId").GetString(),
            commandData.GetProperty("ExecutionId").GetString());
    }

    [Fact]
    public void ExternalIdsRejectUnsafeCharactersAndExcessiveLength()
    {
        Assert.Null(OperationalExecutionIdentityState.NormalizeExternalId("unsafe value"));
        Assert.Null(OperationalExecutionIdentityState.NormalizeExternalId(new string('a', 129)));
        Assert.Equal(
            "safe-id:01",
            OperationalExecutionIdentityState.NormalizeExternalId(" safe-id:01 "));
    }

    [Fact]
    public void AsyncAttemptsPreserveRootAndOperationAndChainExecutions()
    {
        var state = new OperationalExecutionIdentityState();
        var producer = new OperationalExecutionIdentity(
            "root-1",
            "operation-1",
            "execution-producer",
            null);

        OperationalExecutionIdentity firstAttempt;
        using (state.BeginFrom(producer, "Worker.Record"))
        {
            firstAttempt = state.Current;
            Assert.Equal("root-1", firstAttempt.RootOperationId);
            Assert.Equal("operation-1", firstAttempt.OperationId);
            Assert.Equal("execution-producer", firstAttempt.CausationId);
            Assert.NotEqual(producer.ExecutionId, firstAttempt.ExecutionId);
        }

        using (state.BeginFrom(firstAttempt, "Worker.Record"))
        {
            var retry = state.Current;
            Assert.Equal(firstAttempt.RootOperationId, retry.RootOperationId);
            Assert.Equal(firstAttempt.OperationId, retry.OperationId);
            Assert.Equal(firstAttempt.ExecutionId, retry.CausationId);
            Assert.NotEqual(firstAttempt.ExecutionId, retry.ExecutionId);
        }
    }

    [Fact]
    public void IncomingAsyncHeadersBecomeTheParentOfTheLocalExecution()
    {
        var state = new OperationalExecutionIdentityState(
            "root-http",
            null,
            "operation-http",
            "execution-http");

        using (state.Begin("Command"))
        {
            var local = state.Current;
            Assert.Equal("root-http", local.RootOperationId);
            Assert.Equal("operation-http", local.OperationId);
            Assert.Equal("execution-http", local.CausationId);
            Assert.NotEqual("execution-http", local.ExecutionId);
        }
    }

    [Fact]
    public void HttpToWorkerChainPreservesOperationAndLinksEveryAttempt()
    {
        var producerState = new OperationalExecutionIdentityState();
        OperationalExecutionIdentity producer;
        using (producerState.Begin("Producer.Command", "operation-order-1"))
            producer = producerState.Current;

        var transportState = new OperationalExecutionIdentityState();
        OperationalExecutionIdentity transport;
        using (transportState.BeginFrom(producer, "Outbox.YeshuaApi.Deliver"))
            transport = transportState.Current;

        var headers = new Dictionary<string, string?>
        {
            [OperationalExecutionHeaders.RootOperationId] = transport.RootOperationId,
            [OperationalExecutionHeaders.OperationId] = transport.OperationId,
            [OperationalExecutionHeaders.ExecutionId] = transport.ExecutionId,
            [OperationalExecutionHeaders.CausationId] = transport.CausationId
        };
        var ingressState = new OperationalExecutionIdentityState(
            headers[OperationalExecutionHeaders.RootOperationId],
            headers[OperationalExecutionHeaders.CausationId],
            headers[OperationalExecutionHeaders.OperationId],
            headers[OperationalExecutionHeaders.ExecutionId]);

        OperationalExecutionIdentity ingress;
        using (ingressState.Begin("Inbox.Command"))
            ingress = ingressState.Current;

        var bridgeState = new OperationalExecutionIdentityState();
        OperationalExecutionIdentity bridge;
        using (bridgeState.BeginFrom(ingress, "Inbox.SagaBridge"))
            bridge = bridgeState.Current;

        var workerState = new OperationalExecutionIdentityState();
        OperationalExecutionIdentity firstWorkerAttempt;
        using (workerState.BeginFrom(bridge, "SagaWorker.Record"))
            firstWorkerAttempt = workerState.Current;

        OperationalExecutionIdentity retry;
        using (workerState.BeginFrom(firstWorkerAttempt, "SagaWorker.Record"))
            retry = workerState.Current;

        Assert.Equal(producer.RootOperationId, retry.RootOperationId);
        Assert.Equal(producer.OperationId, retry.OperationId);
        Assert.Equal(producer.ExecutionId, transport.CausationId);
        Assert.Equal(transport.ExecutionId, ingress.CausationId);
        Assert.Equal(ingress.ExecutionId, bridge.CausationId);
        Assert.Equal(bridge.ExecutionId, firstWorkerAttempt.CausationId);
        Assert.Equal(firstWorkerAttempt.ExecutionId, retry.CausationId);
    }

    [Fact]
    public void QueueEnvelopeSerializesTheOperationalIdentity()
    {
        var identity = new OperationalExecutionIdentity(
            "root-queue",
            "operation-queue",
            "execution-queue",
            "cause-queue");
        var message = new QueueMessage("OrderReady", new { Id = 10 }, identity);

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(message));
        var root = document.RootElement;

        Assert.Equal("root-queue", root.GetProperty("RootOperationId").GetString());
        Assert.Equal("operation-queue", root.GetProperty("OperationId").GetString());
        Assert.Equal("execution-queue", root.GetProperty("ExecutionId").GetString());
        Assert.Equal("cause-queue", root.GetProperty("CausationId").GetString());
        Assert.Equal(identity, message.OperationalIdentity);
    }

    private sealed class CorrelatedReceiver : ReciverBase<CorrelatedCommand, string>
    {
        private readonly RepositoryTelemetry _repositoryTelemetry;

        public CorrelatedReceiver(
            Dominio.Interfaces.ILogger logger,
            IExecutionContext context,
            RepositoryTelemetry repositoryTelemetry)
            : base(logger, context)
        {
            _repositoryTelemetry = repositoryTelemetry;
        }

        protected override Task<State<string>> ActionAsync(
            CorrelatedCommand command,
            CancellationToken cancellationToken = default)
        {
            var selection = _repositoryTelemetry.Evaluate("Query");
            _repositoryTelemetry.Complete(
                "Query",
                "query-1",
                Stopwatch.GetTimestamp(),
                true,
                selection);
            return Task.FromResult(new State<string>(200, "ok", "done"));
        }
    }

    private sealed class CorrelatedCommand : ICommand
    {
    }

    private sealed class TestExecutionContext : IExecutionContext
    {
        private readonly OperationalExecutionIdentityState _identity;

        public TestExecutionContext(string rootOperationId, string causationId)
        {
            _identity = new OperationalExecutionIdentityState(rootOperationId, causationId);
        }

        public int UserId { get; private set; }
        public int TenantID { get; private set; }
        public IEnumerable<Claim> Claims => [];
        public string TraceId { get; private set; } = "trace-http";
        public ExecutionOrigin Origem { get; private set; } = ExecutionOrigin.Http;
        public string ProcessingScope => "test";
        public OperationalExecutionIdentity OperationalIdentity => _identity.Current;

        public IDisposable BeginOperationalExecution(
            string operation,
            string? operationId = null,
            string? causationId = null) =>
            _identity.Begin(operation, operationId, causationId);

        public void SetOperationalIdentity(
            string rootOperationId,
            string? causationId = null) =>
            _identity.Set(rootOperationId, causationId);

        public void SetTenantId(int id) => TenantID = id;
        public void SetUserId(int id) => UserId = id;
        public void SetTraceId(string traceId) => TraceId = traceId;
        public void SetOrigem(ExecutionOrigin origem) => Origem = origem;
    }

    private sealed class EnabledPolicy : IOperationalTelemetryPolicy
    {
        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null) =>
            new(true, "Information", "D1", "Live");
    }

    private sealed class CapturingSink : IOperationalLogSink
    {
        private readonly List<string> _payloads = [];

        public void Write(string level, string category, ReadOnlySpan<byte> payload)
        {
            _payloads.Add(Encoding.UTF8.GetString(payload));
        }

        public JsonDocument Single(string category, string? eventName = null)
        {
            return JsonDocument.Parse(_payloads.Single(payload =>
            {
                using var document = JsonDocument.Parse(payload);
                var root = document.RootElement;
                if (root.GetProperty("Category").GetString() != category)
                    return false;

                return eventName is null ||
                       root.GetProperty("Data").GetProperty("EventName").GetString() == eventName;
            }));
        }
    }
}
