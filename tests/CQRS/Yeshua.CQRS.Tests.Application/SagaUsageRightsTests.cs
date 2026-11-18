using Command.Patterns;
using Dominio.Commercial;
using Dominio.Patterns.Saga;
using RepositoryInterfaces.Commercial;
using RepositoryInterfaces.Patterns.Saga;

namespace Yeshua.CQRS.Tests.Application;

public sealed class SagaUsageRightsTests
{
    [Fact]
    public void No_usage_right_prevents_the_external_work()
    {
        var repository = new RecordingRights { Allowed = false };
        var handler = new BilledHandler(); var saga = Start();
        new SagaExecutor(new Shered.Logger.Logger(), repository).Execute(saga, new Resolver(handler));
        Assert.Equal(0, handler.Executions);
        Assert.Equal(SagaStatus.Failed, saga.Status);
        Assert.Equal(0, repository.Confirmations);
    }

    [Fact]
    public void Reservation_happens_before_dispatch_and_confirmation_only_after_response()
    {
        var repository = new RecordingRights(); var handler = new BilledHandler(); var saga = Start();
        var executor = new SagaExecutor(new Shered.Logger.Logger(), repository);
        var resolver = new Resolver(handler);
        executor.Execute(saga, resolver);
        Assert.Equal(1, repository.Reservations); Assert.Equal(1, handler.Executions);
        Assert.Equal(0, repository.Confirmations);
        executor.Execute(saga, resolver);
        Assert.Equal(1, repository.Reservations);
        saga.GetCurrent()!.SetPendingApply();
        executor.Execute(saga, resolver);
        Assert.Equal(1, repository.Confirmations); Assert.Equal(SagaStatus.Completed, saga.Status);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Only_terminal_failure_releases_the_reservation(bool retryable)
    {
        var repository = new RecordingRights(); var handler = new BilledHandler { Fail = true, Retryable = retryable };
        var saga = Start(); new SagaExecutor(new Shered.Logger.Logger(), repository).Execute(saga, new Resolver(handler));
        Assert.Equal(retryable ? 0 : 1, repository.Releases);
        Assert.Equal(0, repository.Confirmations);
    }

    private static TestSaga Start() { var saga = new TestSaga(); saga.Start("1", "Test"); return saga; }
    private sealed class TestSaga : SagaBase
    {
        public TestSaga() { AddStep(new TestStep()); }
    }
    private sealed class TestStep : SagaStepBase
    {
        public TestStep() : base("Transcribe") { SetOrder(1); }
    }
    private sealed class BilledHandler : ISagaStepHandler
    {
        public string Key => "Transcribe";
        public bool RequiresExternalStimulus => true;
        public string UsageResourceKey => "example.transcription";
        public int Executions { get; private set; }
        public bool Fail { get; init; }
        public bool Retryable { get; init; }
        public void Execute(SagaBase saga, SagaStepBase step)
        {
            Executions++;
            if (Fail) throw new SagaStepExecutionException("Test failure", Retryable);
            step.SetWaiting();
        }
        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload) { }
    }
    private sealed class Resolver(ISagaStepHandler handler) : ISagaHandlerResolver
    {
        public Dictionary<string, ISagaStepHandler> GetHandlers() => new() { [handler.Key] = handler };
    }
    private sealed class RecordingRights : IUsageRightsRepository
    {
        public bool Allowed { get; init; } = true;
        public int Reservations { get; private set; }
        public int Confirmations { get; private set; }
        public int Releases { get; private set; }
        public void Synchronize(IReadOnlyList<UsageRight> rights) { }
        public bool Reserve(string resource, string operationId, decimal units) { Reservations++; return Allowed; }
        public void Confirm(string resource, string operationId) => Confirmations++;
        public void Release(string resource, string operationId) => Releases++;
    }
}
