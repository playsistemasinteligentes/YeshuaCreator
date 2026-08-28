using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;
using Shered.DB.Connection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Yeshua.CQRS.Tests.Application;

public sealed class OperationalTelemetryTests
{
    [Fact]
    public async Task Receiver_tracks_success_and_worker_cycle_measurements()
    {
        var logger = new Shered.Logger.Logger();
        var receiver = new TestReceiver(logger, new TestExecutionContext(), command =>
            new State<WorkerResult>(200, "ok", command.Result));

        var result = await receiver.ExecuteAsync(new TestCommand(new WorkerResult(10, 8, 7, 1)));

        Assert.Equal(200, result.StatusCode);
        var telemetry = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(0, telemetry.Active);
        Assert.Equal(1, telemetry.Executions);
        Assert.Equal(0, telemetry.Failures);
        Assert.Equal(200, telemetry.LastStatusCode);
        Assert.Equal(10, telemetry.Measurements["BatchLimit"]);
        Assert.Equal(8, telemetry.Measurements["Claimed"]);
        Assert.Equal(7, telemetry.Measurements["Processed"]);
        Assert.Equal(1, telemetry.Measurements["Failed"]);
    }

    [Fact]
    public async Task Receiver_tracks_returned_failure()
    {
        var logger = new Shered.Logger.Logger();
        var receiver = new TestReceiver(logger, new TestExecutionContext(), command =>
            new State<WorkerResult>(422, "invalid", command.Result, propagation: false));

        var result = await receiver.ExecuteAsync(new TestCommand(new WorkerResult(1, 0, 0, 0)));

        Assert.Equal(422, result.StatusCode);
        var telemetry = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, telemetry.Executions);
        Assert.Equal(1, telemetry.Failures);
        Assert.Equal(422, telemetry.LastStatusCode);
    }

    [Fact]
    public async Task Receiver_tracks_exception_and_preserves_original_exception()
    {
        var logger = new Shered.Logger.Logger();
        var expected = new InvalidOperationException("business failure");
        var receiver = new TestReceiver(logger, new TestExecutionContext(), _ => throw expected);

        var actual = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            receiver.ExecuteAsync(new TestCommand(new WorkerResult(1, 0, 0, 0))));

        Assert.Same(expected, actual);
        var telemetry = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(0, telemetry.Active);
        Assert.Equal(1, telemetry.Executions);
        Assert.Equal(1, telemetry.Failures);
        Assert.Equal(500, telemetry.LastStatusCode);
    }

    [Fact]
    public async Task Receiver_result_is_not_changed_when_policy_fails()
    {
        var logger = new Shered.Logger.Logger(new ThrowingPolicy());
        var receiver = new TestReceiver(
            logger,
            new TestExecutionContext(),
            command => new State<WorkerResult>(200, "ok", command.Result));

        var result = await receiver.ExecuteAsync(new TestCommand(new WorkerResult(1, 1, 1, 0)));

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(1, result.Data.Processed);
    }

    [Fact]
    public void Repository_telemetry_tracks_success_failure_and_metrics()
    {
        var logger = new Shered.Logger.Logger();
        var telemetry = new RepositoryTelemetry(logger, new TestExecutionContext());
        const string sql = "SELECT Id FROM Sesoes WHERE Id = @Id";

        var queryId = telemetry.GetQueryId(sql);
        telemetry.Complete("Query", queryId, System.Diagnostics.Stopwatch.GetTimestamp(), true);
        telemetry.Complete(
            "Query",
            queryId,
            System.Diagnostics.Stopwatch.GetTimestamp(),
            false,
            new InvalidOperationException("sql failure"));
        telemetry.Observe("SesoesRepository", "Backlog", 12);

        var snapshot = logger.Snapshot();
        var repository = Assert.Single(snapshot.Repositories);
        Assert.Equal(2, repository.Executions);
        Assert.Equal(1, repository.Failures);
        Assert.Equal(16, repository.QueryId.Length);
        var metric = Assert.Single(snapshot.Metrics);
        Assert.Equal("SesoesRepository", metric.Component);
        Assert.Equal("Backlog", metric.Metric);
        Assert.Equal(12, metric.Value);
    }

    private sealed record TestCommand(WorkerResult Result) : ICommand;

    private sealed record WorkerResult(
        int BatchLimit,
        int Claimed,
        int Processed,
        int Failed) : IWorkerCycleResult;

    private sealed class TestReceiver : ReciverBase<TestCommand, WorkerResult>
    {
        private readonly Func<TestCommand, State<WorkerResult>> _action;

        public TestReceiver(
            Dominio.Interfaces.ILogger logger,
            IExecutionContext context,
            Func<TestCommand, State<WorkerResult>> action)
            : base(logger, context)
        {
            _action = action;
        }

        protected override Task<State<WorkerResult>> ActionAsync(
            TestCommand command,
            CancellationToken cancellationToken = default) =>
            Task.FromResult(_action(command));
    }

    private sealed class TestExecutionContext : IExecutionContext
    {
        public int UserId { get; private set; }
        public int TenantID { get; private set; }
        public IEnumerable<Claim> Claims => [];
        public string TraceId { get; private set; } = "trace-test";
        public ExecutionOrigin Origem { get; private set; } = ExecutionOrigin.Worker;
        public void SetTenantId(int id) => TenantID = id;
        public void SetUserId(int id) => UserId = id;
        public void SetTraceId(string traceId) => TraceId = traceId;
        public void SetOrigem(ExecutionOrigin origem) => Origem = origem;
    }

    private sealed class ThrowingPolicy : IOperationalTelemetryPolicy
    {
        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null) =>
            throw new InvalidOperationException("policy unavailable");
    }
}
