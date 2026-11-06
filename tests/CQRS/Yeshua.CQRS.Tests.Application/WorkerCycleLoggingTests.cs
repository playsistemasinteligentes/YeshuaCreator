using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Dominio.Interfaces;
using Dominio.Operational;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;
using Shared.Operational;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using Xunit.Abstractions;

namespace Yeshua.CQRS.Tests.Application;

public sealed class WorkerCycleLoggingTests(ITestOutputHelper output)
{
    [Fact]
    public async Task Idle_cycles_keep_health_counters_and_timestamps_without_publishing_logs()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var expected = new State<WorkerResult>(200, "ok", new(5, 0, 0, 0));
        var receiver = Receiver(logger, expected);
        var before = DateTimeOffset.UtcNow;

        for (var index = 0; index < 10; index++)
            Assert.Same(expected, await receiver.ExecuteAsync(new TestCommand()));

        var after = DateTimeOffset.UtcNow;
        var snapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Empty(sink.Payloads);
        Assert.Equal(10, snapshot.Executions);
        Assert.Equal(0, snapshot.Active);
        Assert.Equal(0, snapshot.Failures);
        Assert.InRange(snapshot.LastStartedAtUtc!.Value, before, after);
        Assert.InRange(snapshot.LastFinishedAtUtc!.Value, before, after);
        Assert.True(snapshot.LastFinishedAtUtc >= snapshot.LastStartedAtUtc);
        Assert.Equal(200, snapshot.LastStatusCode);
        Assert.Equal(5, snapshot.Measurements["BatchLimit"]);
        Assert.Equal(0, snapshot.Measurements["Claimed"]);
        Assert.Equal(0, snapshot.Measurements["Processed"]);
        Assert.Equal(0, snapshot.Measurements["Failed"]);
    }

    [Fact]
    public async Task Running_cycle_remains_visible_in_memory_before_it_finishes()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var completion = new TaskCompletionSource<State<WorkerResult>>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var receiver = new TestReceiver<WorkerResult>(logger, () => completion.Task);

        var execution = receiver.ExecuteAsync(new TestCommand());
        try
        {
            var running = Assert.Single(logger.Snapshot().Commands);
            Assert.Equal(1, running.Active);
            Assert.Equal(0, running.Executions);
            Assert.NotNull(running.LastStartedAtUtc);
            Assert.Null(running.LastFinishedAtUtc);
            Assert.Empty(sink.Payloads);
        }
        finally
        {
            completion.SetResult(new State<WorkerResult>(200, "ok", new(5, 0, 0, 0)));
            await execution;
        }

        var completed = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(0, completed.Active);
        Assert.Equal(1, completed.Executions);
        Assert.NotNull(completed.LastFinishedAtUtc);
        Assert.Empty(sink.Payloads);
    }

    [Theory]
    [InlineData(2, 2, 0)]
    [InlineData(1, 0, 0)]
    [InlineData(0, 1, 0)]
    [InlineData(0, 0, 1)]
    public async Task Cycle_with_work_or_item_failure_publishes_one_summary(
        int claimed, int processed, int failed)
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger,
            new State<WorkerResult>(200, "ok", new(5, claimed, processed, failed)));

        await receiver.ExecuteAsync(new TestCommand());

        using var payload = JsonDocument.Parse(Assert.Single(sink.Payloads));
        var data = payload.RootElement.GetProperty("Data");
        Assert.Equal("Command.Completed", data.GetProperty("EventName").GetString());
        Assert.Equal(5, data.GetProperty("BatchLimit").GetInt32());
        Assert.Equal(claimed, data.GetProperty("Claimed").GetInt32());
        Assert.Equal(processed, data.GetProperty("Processed").GetInt32());
        Assert.Equal(failed, data.GetProperty("Failed").GetInt32());
        var snapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, snapshot.Executions);
        Assert.Equal(claimed, snapshot.Measurements["Claimed"]);
        Assert.Equal(processed, snapshot.Measurements["Processed"]);
        Assert.Equal(failed, snapshot.Measurements["Failed"]);
    }

    [Theory]
    [InlineData(400, "Warning")]
    [InlineData(422, "Warning")]
    [InlineData(500, "Error")]
    public async Task Empty_cycle_with_unsuccessful_status_keeps_failure_evidence(
        int statusCode, string severity)
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger,
            new State<WorkerResult>(statusCode, "failure", new(5, 0, 0, 0), propagation: false));

        var result = await receiver.ExecuteAsync(new TestCommand());

        Assert.Equal(statusCode, result.StatusCode);
        using var payload = JsonDocument.Parse(Assert.Single(sink.Payloads));
        Assert.Equal(severity, payload.RootElement.GetProperty("Level").GetString());
        var data = payload.RootElement.GetProperty("Data");
        Assert.Equal("Command.Completed", data.GetProperty("EventName").GetString());
        Assert.Equal(statusCode, data.GetProperty("StatusCode").GetInt32());
        Assert.True(data.TryGetProperty("ErrorSummary", out _));
        var snapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, snapshot.Failures);
        Assert.Equal(0, snapshot.Active);
        Assert.NotNull(snapshot.LastFailureAtUtc);
    }

    [Fact]
    public async Task Worker_exception_is_published_and_rethrown_without_leaving_active_counter()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var expected = new InvalidOperationException("controlled failure");
        var receiver = new TestReceiver<WorkerResult>(logger,
            () => Task.FromException<State<WorkerResult>>(expected));

        var actual = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            receiver.ExecuteAsync(new TestCommand()));

        Assert.Same(expected, actual);
        using var payload = JsonDocument.Parse(Assert.Single(sink.Payloads));
        Assert.Equal("Error", payload.RootElement.GetProperty("Level").GetString());
        Assert.Equal("exception", payload.RootElement.GetProperty("Data")
            .GetProperty("Phase").GetString());
        var snapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, snapshot.Executions);
        Assert.Equal(1, snapshot.Failures);
        Assert.Equal(0, snapshot.Active);
    }

    [Fact]
    public async Task Business_command_running_in_worker_keeps_start_and_completion()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger, new State<string>(200, "ok", "business result"));

        var result = await receiver.ExecuteAsync(new TestCommand());

        Assert.Equal("business result", result.Data);
        Assert.Equal(2, sink.Payloads.Count);
        using var started = JsonDocument.Parse(sink.Payloads[0]);
        using var completed = JsonDocument.Parse(sink.Payloads[1]);
        Assert.Equal("Command.Started", started.RootElement.GetProperty("Data")
            .GetProperty("EventName").GetString());
        Assert.Equal("Command.Completed", completed.RootElement.GetProperty("Data")
            .GetProperty("EventName").GetString());
        Assert.Equal(1, Assert.Single(logger.Snapshot().Commands).Executions);
    }

    [Fact]
    public async Task Undeclared_worker_result_does_not_leave_an_orphan_start_event()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger,
            new State<object>(200, "ok", new WorkerResult(5, 0, 0, 0)));

        await receiver.ExecuteAsync(new TestCommand());

        Assert.Equal(2, sink.Payloads.Count);
        using var completed = JsonDocument.Parse(sink.Payloads[1]);
        Assert.Equal("Command.Completed", completed.RootElement.GetProperty("Data")
            .GetProperty("EventName").GetString());
    }

    [Fact]
    public async Task Missing_worker_result_does_not_suppress_completion()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger, new State<WorkerResult>(200, "ok", null!));

        await receiver.ExecuteAsync(new TestCommand());

        using var payload = JsonDocument.Parse(Assert.Single(sink.Payloads));
        Assert.Equal("Command.Completed", payload.RootElement.GetProperty("Data")
            .GetProperty("EventName").GetString());
    }

    [Fact]
    public void Idle_cycle_benchmark_avoids_event_allocations_and_bytes()
    {
        const int iterations = 5_000;
        var idle = MeasureCycles(new(5, 0, 0, 0), iterations);
        var busy = MeasureCycles(new(5, 1, 1, 0), iterations);

        output.WriteLine($"Idle: {iterations} cycles, {idle.Milliseconds:F2} ms, " +
            $"{idle.AllocatedBytes} allocated bytes, {idle.Events} events, {idle.PayloadBytes} payload bytes.");
        output.WriteLine($"Busy: {iterations} cycles, {busy.Milliseconds:F2} ms, " +
            $"{busy.AllocatedBytes} allocated bytes, {busy.Events} events, {busy.PayloadBytes} payload bytes.");
        Assert.Equal(0, idle.Events);
        Assert.Equal(0, idle.PayloadBytes);
        Assert.Equal(iterations, busy.Events);
        Assert.True(idle.AllocatedBytes < busy.AllocatedBytes);
    }

    private static (long AllocatedBytes, double Milliseconds, int Events, long PayloadBytes)
        MeasureCycles(WorkerResult result, int iterations)
    {
        var sink = new CountingSink();
        var logger = new Shered.Logger.Logger(null, sink);
        var receiver = Receiver(logger, new State<WorkerResult>(200, "ok", result));
        var command = new TestCommand();
        for (var index = 0; index < 100; index++)
            receiver.ExecuteAsync(command).GetAwaiter().GetResult();
        sink.Events = 0;
        sink.PayloadBytes = 0;

        var before = GC.GetAllocatedBytesForCurrentThread();
        var startedAt = Stopwatch.GetTimestamp();
        for (var index = 0; index < iterations; index++)
            receiver.ExecuteAsync(command).GetAwaiter().GetResult();
        return (GC.GetAllocatedBytesForCurrentThread() - before,
            Stopwatch.GetElapsedTime(startedAt).TotalMilliseconds, sink.Events, sink.PayloadBytes);
    }

    private static TestReceiver<T> Receiver<T>(ILogger logger, State<T> result)
    {
        var task = Task.FromResult(result);
        return new TestReceiver<T>(logger, () => task);
    }

    private sealed record TestCommand : ICommand;
    private sealed record WorkerResult(int BatchLimit, int Claimed, int Processed, int Failed)
        : IWorkerCycleResult;

    private sealed class TestReceiver<T>(ILogger logger, Func<Task<State<T>>> action)
        : ReciverBase<TestCommand, T>(logger, new TestExecutionContext())
    {
        protected override Task<State<T>> ActionAsync(TestCommand command,
            CancellationToken cancellationToken = default) => action();
    }

    private sealed class TestExecutionContext : IExecutionContext
    {
        public int UserId => 0;
        public int TenantID => 0;
        public IEnumerable<Claim> Claims => [];
        public string TraceId => "worker-cycle-test";
        public ExecutionOrigin Origem => ExecutionOrigin.Worker;
        public string ProcessingScope => "test";
        public void SetTenantId(int id) { }
        public void SetUserId(int id) { }
        public void SetTraceId(string traceId) { }
        public void SetOrigem(ExecutionOrigin origem) { }
    }

    private sealed class CapturingSink : IOperationalLogSink
    {
        public List<string> Payloads { get; } = [];
        public void Write(string level, string category, ReadOnlySpan<byte> json)
            => Payloads.Add(System.Text.Encoding.UTF8.GetString(json));
    }

    private sealed class CountingSink : IOperationalLogSink
    {
        public int Events;
        public long PayloadBytes;
        public void Write(string level, string category, ReadOnlySpan<byte> json)
        {
            Events++;
            PayloadBytes += json.Length;
        }
    }
}
