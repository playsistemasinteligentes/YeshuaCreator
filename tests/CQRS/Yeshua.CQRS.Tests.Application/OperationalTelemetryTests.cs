using Aplication.Interfaces.Services;
using Command.Interfaces;
using Command.Patterns;
using Command.Patterns.Command;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
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
    public async Task Receiver_off_executes_business_without_collecting_telemetry()
    {
        var policy = new DisabledPolicy();
        var logger = new Shered.Logger.Logger(policy);
        var executions = 0;
        var receiver = new TestReceiver(
            logger,
            new TestExecutionContext(),
            command =>
            {
                executions++;
                return new State<WorkerResult>(200, "ok", command.Result);
            });

        var result = await receiver.ExecuteAsync(
            new TestCommand(new WorkerResult(10, 8, 7, 1)));

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(1, executions);
        Assert.Equal(1, policy.Evaluations);
        Assert.Empty(logger.Snapshot().Commands);
    }

    [Fact]
    public async Task Receiver_off_preserves_exception_without_collecting_telemetry()
    {
        var logger = new Shered.Logger.Logger(new DisabledPolicy());
        var expected = new InvalidOperationException("business failure");
        var receiver = new TestReceiver(
            logger,
            new TestExecutionContext(),
            _ => throw expected);

        var actual = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            receiver.ExecuteAsync(new TestCommand(new WorkerResult(1, 0, 0, 0))));

        Assert.Same(expected, actual);
        Assert.Empty(logger.Snapshot().Commands);
    }

    [Fact]
    public async Task Receiver_passes_generated_command_target_to_central_policy()
    {
        var policy = new CapturingPolicy();
        var logger = new Shered.Logger.Logger(policy);
        var receiver = new TrackedTestReceiver(
            logger,
            new TestExecutionContext(),
            command => new State<WorkerResult>(200, "ok", command.Result));

        var result = await receiver.ExecuteAsync(new TrackedTestCommand(
            "EntradaFiscalContingencia",
            "correlation-123",
            new WorkerResult(1, 1, 1, 0)));

        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Command", policy.Component);
        Assert.Contains(nameof(TrackedTestCommand), policy.Operation);
        Assert.Equal("EntradaFiscalContingencia", policy.Entity);
        Assert.Equal("correlation-123", policy.RecordId);
    }

    [Fact]
    public async Task Receiver_applies_runtime_target_without_restart_or_cross_record_capture()
    {
        var policy = new RuntimeTargetPolicy();
        var logger = new Shered.Logger.Logger(policy);
        var receiver = new TrackedTestReceiver(
            logger,
            new TestExecutionContext(),
            command => new State<WorkerResult>(200, "ok", command.Result));

        policy.Replace("EntradaFiscalContingencia", "correlation-selected");

        await receiver.ExecuteAsync(new TrackedTestCommand(
            "EntradaFiscalContingencia",
            "correlation-selected",
            new WorkerResult(1, 1, 1, 0)));
        await receiver.ExecuteAsync(new TrackedTestCommand(
            "EntradaFiscalContingencia",
            "correlation-other",
            new WorkerResult(1, 1, 1, 0)));

        var enabledSnapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, enabledSnapshot.Executions);

        policy.Disable();

        await receiver.ExecuteAsync(new TrackedTestCommand(
            "EntradaFiscalContingencia",
            "correlation-selected",
            new WorkerResult(1, 1, 1, 0)));

        var disabledSnapshot = Assert.Single(logger.Snapshot().Commands);
        Assert.Equal(1, disabledSnapshot.Executions);
    }

    [Fact]
    public void Repository_off_is_rejected_before_query_identification_and_measurement()
    {
        var policy = new DisabledPolicy();
        var logger = new Shered.Logger.Logger(policy);
        var telemetry = new RepositoryTelemetry(logger, new TestExecutionContext());

        var selection = telemetry.Evaluate("Query");

        Assert.False(selection.Enabled);
        Assert.Equal(2, policy.Evaluations);
        Assert.Empty(logger.Snapshot().Repositories);
    }

    [Fact]
    public void Repository_telemetry_tracks_success_failure_and_metrics()
    {
        var logger = new Shered.Logger.Logger();
        var telemetry = new RepositoryTelemetry(logger, new TestExecutionContext());
        const string sql = "SELECT Id FROM Sesoes WHERE Id = @Id";

        var selection = telemetry.Evaluate("Query");
        var queryId = telemetry.GetQueryId(sql);
        telemetry.Complete(
            "Query",
            queryId,
            System.Diagnostics.Stopwatch.GetTimestamp(),
            true,
            selection);
        telemetry.Complete(
            "Query",
            queryId,
            System.Diagnostics.Stopwatch.GetTimestamp(),
            false,
            selection,
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

    [Fact]
    public void Repository_counters_and_events_are_selected_independently_at_runtime()
    {
        var policy = new RepositoryCapabilityPolicy();
        var logger = new Shered.Logger.Logger(policy);
        var telemetry = new RepositoryTelemetry(logger, new TestExecutionContext());
        const string sql = "SELECT Id FROM CTeSolicitacao WHERE Id = @Id";
        var queryId = telemetry.GetQueryId(sql);

        policy.Set(counters: true, events: false);
        var countersOnly = telemetry.Evaluate("Query");
        Assert.True(countersOnly.CaptureCounters);
        Assert.False(countersOnly.EmitEvents);
        telemetry.Complete(
            "Query",
            queryId,
            System.Diagnostics.Stopwatch.GetTimestamp(),
            true,
            countersOnly);

        policy.Set(counters: false, events: true);
        var eventsOnly = telemetry.Evaluate("Query");
        Assert.False(eventsOnly.CaptureCounters);
        Assert.True(eventsOnly.EmitEvents);
        telemetry.Complete(
            "Query",
            queryId,
            System.Diagnostics.Stopwatch.GetTimestamp(),
            true,
            eventsOnly);

        policy.Set(counters: false, events: false);
        var disabled = telemetry.Evaluate("Query");
        Assert.False(disabled.Enabled);

        var repository = Assert.Single(logger.Snapshot().Repositories);
        Assert.Equal(1, repository.Executions);
    }

    [Fact]
    public void Saga_executor_records_wait_resume_transitions_and_completion()
    {
        var logger = new Shered.Logger.Logger(new SagaEnabledPolicy());
        var executor = new SagaExecutor(logger);
        var saga = new TestSaga();
        saga.Start("fiscal-1", "EntradaFiscalContingencia");
        var resolver = new TestSagaResolver(
            new TestSagaHandler("WaitStep", requiresExternalStimulus: true),
            new TestSagaHandler("FinalStep", requiresExternalStimulus: false));

        executor.ExecuteUntilWait(saga, resolver);

        Assert.Equal(SagaStepStatus.WaitingResponse, saga.GetCurrent()!.Status);

        saga.GetCurrent()!.SetPendingApply();
        executor.ExecuteUntilWait(saga, resolver);

        Assert.Equal(SagaStatus.Completed, saga.Status);
        Assert.Equal(
            [
                "SagaStarted",
                "StepStarted",
                "Waiting",
                "Resumed",
                "StepCompleted",
                "StepStarted",
                "Resumed",
                "StepCompleted",
                "SagaCompleted"
            ],
            logger.Snapshot().Sagas.Select(item => item.Phase));
        Assert.All(logger.Snapshot().Sagas, item =>
        {
            Assert.Equal(nameof(TestSaga), item.Saga);
            Assert.Equal(saga.CorrelationId.ToString("D"), item.CorrelationId);
            Assert.False(string.IsNullOrWhiteSpace(item.ExecutionId));
        });
    }

    [Fact]
    public void Saga_executor_identifies_each_retry_attempt()
    {
        var logger = new Shered.Logger.Logger(new SagaEnabledPolicy());
        var executor = new SagaExecutor(logger);
        var saga = new TestSaga();
        saga.Start("fiscal-retry", "EntradaFiscalContingencia");
        var resolver = new TestSagaResolver(
            new FailingSagaHandler("WaitStep"),
            new TestSagaHandler("FinalStep", requiresExternalStimulus: false));

        executor.Execute(saga, resolver);
        executor.Execute(saga, resolver);

        var starts = logger.Snapshot().Sagas
            .Where(item => item.Phase == "StepStarted")
            .ToArray();

        Assert.Equal([1, 2], starts.Select(item => item.Attempt));
        Assert.NotEqual(starts[0].ExecutionId, starts[1].ExecutionId);
        Assert.Equal(2, logger.Snapshot().Sagas.Count(item => item.Phase == "RetryScheduled"));
    }

    [Fact]
    public void Saga_module_transition_preserves_root_and_message_cause()
    {
        var logger = new Shered.Logger.Logger(new SagaEnabledPolicy());
        var rootCorrelationId = Guid.NewGuid().ToString("D");
        var messageId = Guid.NewGuid().ToString("D");

        logger.Saga(
            "ContingenciaFiscalStandardSaga",
            "PublicarPlanoParaSagaFiscal",
            rootCorrelationId,
            "ModuleEventPublished",
            1,
            "source-step:1",
            messageId);
        logger.Saga(
            "EmissaoFiscalCargaStandardSaga",
            "ReceberCargaProntaParaEmissaoFiscal",
            rootCorrelationId,
            "ModuleEventConsumed",
            0,
            "target-step:0",
            messageId);

        var transition = logger.Snapshot().Sagas;

        Assert.Equal(2, transition.Count);
        Assert.All(transition, item => Assert.Equal(rootCorrelationId, item.CorrelationId));
        Assert.All(transition, item => Assert.Equal(messageId, item.CausationId));
        Assert.Equal(
            ["ContingenciaFiscalStandardSaga", "EmissaoFiscalCargaStandardSaga"],
            transition.Select(item => item.Saga));
    }

    [Fact]
    public void Saga_executor_off_does_not_collect_narrative()
    {
        var logger = new Shered.Logger.Logger(new DisabledPolicy());
        var executor = new SagaExecutor(logger);
        var saga = new TestSaga();
        saga.Start("fiscal-2", "EntradaFiscalContingencia");
        var resolver = new TestSagaResolver(
            new TestSagaHandler("WaitStep", requiresExternalStimulus: true),
            new TestSagaHandler("FinalStep", requiresExternalStimulus: false));

        executor.ExecuteUntilWait(saga, resolver);

        Assert.Equal(SagaStepStatus.WaitingResponse, saga.GetCurrent()!.Status);
        Assert.Empty(logger.Snapshot().Sagas);
    }

    private sealed record TestCommand(WorkerResult Result) : ICommand;

    private sealed record TrackedTestCommand(
        string OperationalEntity,
        string? OperationalRecordId,
        WorkerResult Result) : ICommand, IOperationalTelemetryCommand;

    private sealed record WorkerResult(
        int BatchLimit,
        int Claimed,
        int Processed,
        int Failed) : IWorkerCycleResult;

    private sealed class TestSaga : SagaBase
    {
        public TestSaga()
        {
            AddStep(new TestSagaStep("WaitStep", 1));
            AddStep(new TestSagaStep("FinalStep", 2));
        }
    }

    private sealed class TestSagaStep : SagaStepBase
    {
        public TestSagaStep(string key, int order) : base(key)
        {
            SetOrder(order);
        }
    }

    private sealed class TestSagaHandler : ISagaStepHandler
    {
        public TestSagaHandler(string key, bool requiresExternalStimulus)
        {
            Key = key;
            RequiresExternalStimulus = requiresExternalStimulus;
        }

        public string Key { get; }
        public bool RequiresExternalStimulus { get; }

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            if (RequiresExternalStimulus)
                step.SetWaiting();
            else
                step.SetPendingApply();
        }

        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
        }
    }

    private sealed class FailingSagaHandler : ISagaStepHandler
    {
        public FailingSagaHandler(string key)
        {
            Key = key;
        }

        public string Key { get; }
        public bool RequiresExternalStimulus => false;

        public void Execute(SagaBase saga, SagaStepBase step) =>
            throw new InvalidOperationException("controlled retry");

        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
        }
    }

    private sealed class TestSagaResolver : ISagaHandlerResolver
    {
        private readonly Dictionary<string, ISagaStepHandler> _handlers;

        public TestSagaResolver(params ISagaStepHandler[] handlers)
        {
            _handlers = handlers.ToDictionary(handler => handler.Key);
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers() => _handlers;
    }

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

    private sealed class TrackedTestReceiver : ReciverBase<TrackedTestCommand, WorkerResult>
    {
        private readonly Func<TrackedTestCommand, State<WorkerResult>> _action;

        public TrackedTestReceiver(
            Dominio.Interfaces.ILogger logger,
            IExecutionContext context,
            Func<TrackedTestCommand, State<WorkerResult>> action)
            : base(logger, context)
        {
            _action = action;
        }

        protected override Task<State<WorkerResult>> ActionAsync(
            TrackedTestCommand command,
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

    private sealed class DisabledPolicy : IOperationalTelemetryPolicy
    {
        public int Evaluations { get; private set; }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
        {
            Evaluations++;
            return new OperationalTelemetryDecision(false, "None", "D0");
        }
    }

    private sealed class CapturingPolicy : IOperationalTelemetryPolicy
    {
        public string Component { get; private set; } = string.Empty;
        public string Operation { get; private set; } = string.Empty;
        public string? Entity { get; private set; }
        public string? RecordId { get; private set; }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
        {
            Component = component;
            Operation = operation ?? string.Empty;
            Entity = entity;
            RecordId = recordId;
            return new OperationalTelemetryDecision(false, "None", "D0");
        }
    }

    private sealed class RuntimeTargetPolicy : IOperationalTelemetryPolicy
    {
        private Target? _target;

        public void Replace(string entity, string recordId)
        {
            Interlocked.Exchange(ref _target, new Target(entity, recordId));
        }

        public void Disable()
        {
            Interlocked.Exchange(ref _target, null);
        }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
        {
            var target = Volatile.Read(ref _target);
            var enabled = target is not null &&
                          component.Equals("Command", StringComparison.OrdinalIgnoreCase) &&
                          string.Equals(target.Entity, entity, StringComparison.OrdinalIgnoreCase) &&
                          string.Equals(target.RecordId, recordId, StringComparison.OrdinalIgnoreCase);

            return enabled
                ? new OperationalTelemetryDecision(true, "Information", "D0")
                : new OperationalTelemetryDecision(false, "None", "D0");
        }

        private sealed record Target(string Entity, string RecordId);
    }

    private sealed class SagaEnabledPolicy : IOperationalTelemetryPolicy
    {
        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null) =>
            component.Equals("Saga", StringComparison.OrdinalIgnoreCase)
                ? new OperationalTelemetryDecision(true, "Information", "D1")
                : new OperationalTelemetryDecision(false, "None", "D0");
    }

    private sealed class RepositoryCapabilityPolicy : IOperationalTelemetryPolicy
    {
        private int _counters;
        private int _events;

        public void Set(bool counters, bool events)
        {
            Volatile.Write(ref _counters, counters ? 1 : 0);
            Volatile.Write(ref _events, events ? 1 : 0);
        }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
        {
            if (component.Equals("RepositoryCounters", StringComparison.OrdinalIgnoreCase))
            {
                return Volatile.Read(ref _counters) == 1
                    ? new OperationalTelemetryDecision(true, "Information", "D0")
                    : new OperationalTelemetryDecision(false, "None", "D0");
            }

            if (component.Equals("RepositoryEvents", StringComparison.OrdinalIgnoreCase))
            {
                return Volatile.Read(ref _events) == 1
                    ? new OperationalTelemetryDecision(true, "Information", "D1")
                    : new OperationalTelemetryDecision(false, "None", "D0");
            }

            return new OperationalTelemetryDecision(false, "None", "D0");
        }
    }
}
