using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class AgentTaskReceiverTests
{
    [TestMethod]
    public async Task RejectsUnsafeAndInvalidOrdersBeforePersistence()
    {
        var repository = new AgentTaskTestRepository();
        var receiver = new SendAgentTaskReceiver(repository, Options.Create(new AgentTaskOptions { Enabled = true }));
        foreach (var command in new[]
        {
            new SendAgentTaskCommand("", "Teste"), new SendAgentTaskCommand("1", ""),
            new SendAgentTaskCommand("2", "Teste", Mode: "full-access"),
            new SendAgentTaskCommand("3", "Teste", Mode: "workspace-write"),
            new SendAgentTaskCommand("4", "Teste", Guid.Empty),
            new SendAgentTaskCommand("5", new string('x', 16001))
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => receiver.ExecuteAsync(command, default));
        Assert.AreEqual(0, repository.AcceptedCount);
    }

    [TestMethod]
    public async Task DisabledExecutionDoesNotQueueOrders()
    {
        var repository = new AgentTaskTestRepository();
        var receiver = new SendAgentTaskReceiver(repository, Options.Create(new AgentTaskOptions()));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => receiver.ExecuteAsync(new("request", "Teste"), default));
        Assert.AreEqual(0, repository.AcceptedCount);
    }

    [TestMethod]
    public async Task ReadingNeverQueuesWorkAndRejectsUnboundedQueries()
    {
        var repository = new AgentTaskTestRepository();
        var receiver = new ReadAgentTaskReceiver(repository, new AgentTaskExecutionControl());
        await receiver.ExecuteAsync(new(), default);
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => receiver.ExecuteAsync(new(Limit: 100), default));
        Assert.AreEqual(0, repository.AcceptedCount);
    }

    [TestMethod]
    public async Task FailureIsSavedWithoutLeakingInternalExceptionOrRetrying()
    {
        var repository = new AgentTaskTestRepository();
        var receipt = await repository.AcceptAsync(new("failure", "Teste"), 10, default);
        var item = await repository.ClaimAsync(default);
        var executor = new FailureExecutor();
        var receiver = new ProcessAgentTaskReceiver(repository, executor, Options.Create(new AgentTaskOptions()), new AgentTaskExecutionControl());
        await receiver.ExecuteAsync(item!, default);
        var state = await repository.ReadAsync(new(receipt.TaskId), default);
        Assert.AreEqual("Failed", state.Messages.Single().Status);
        Assert.IsFalse(state.Messages.Single().Response!.Contains("private-token"));
        Assert.AreEqual(1, executor.Calls);
        Assert.IsNull(await repository.ClaimAsync(default));
    }

    [TestMethod]
    public async Task RestartMarksInFlightWorkInterruptedWithoutReplayingIt()
    {
        var repository = new AgentTaskTestRepository();
        var receipt = await repository.AcceptAsync(new("restart", "Teste"), 10, default);
        await repository.ClaimAsync(default);
        await repository.RecoverInterruptedAsync(default);
        var state = await repository.ReadAsync(new(receipt.TaskId), default);
        Assert.AreEqual("Interrupted", state.Messages.Single().Status);
        Assert.IsNull(await repository.ClaimAsync(default));
    }

    private sealed class FailureExecutor : IAgentTaskExecutor
    {
        public int Calls { get; private set; }
        public Task<AgentTaskExecutionResult> ExecuteAsync(AgentTaskWorkItem item,
            Func<AgentTaskProgress, CancellationToken, Task> progress, CancellationToken cancellationToken)
        {
            Calls++;
            throw new InvalidOperationException("private-token");
        }
    }

    [TestMethod]
    public async Task FailedCompletionWriteDoesNotLeaveQueuePermanentlyBlockedOrReplayWork()
    {
        var memory = new AgentTaskTestRepository();
        var receipt = await memory.AcceptAsync(new("completion-failure", "Teste"), 10, default);
        var repository = new CompletionFaultRepository(memory);
        var executor = new SuccessExecutor();
        var options = Options.Create(new AgentTaskOptions { Enabled = true, PollSeconds = 1 });
        var services = new ServiceCollection();
        services.AddSingleton<IAgentTaskRepository>(repository);
        services.AddSingleton<IAgentTaskExecutor>(executor);
        services.AddSingleton<IOptions<AgentTaskOptions>>(options);
        services.AddSingleton<AgentTaskExecutionControl>();
        services.AddScoped<ProcessAgentTaskReceiver>();
        using var provider = services.BuildServiceProvider();
        using var worker = new AgentTaskWorker(provider.GetRequiredService<IServiceScopeFactory>(), options,
            NullLogger<AgentTaskWorker>.Instance);
        await worker.StartAsync(default);
        try
        {
            await repository.RecoveredAfterFailure.Task.WaitAsync(TimeSpan.FromSeconds(10));
            var state = await memory.ReadAsync(new(receipt.TaskId), default);
            Assert.AreEqual("Interrupted", state.Messages.Single().Status);
            Assert.AreEqual(1, executor.Calls);
            Assert.IsNull(await memory.ClaimAsync(default));
        }
        finally
        {
            await worker.StopAsync(default);
        }
    }

    private sealed class SuccessExecutor : IAgentTaskExecutor
    {
        public int Calls { get; private set; }
        public Task<AgentTaskExecutionResult> ExecuteAsync(AgentTaskWorkItem item,
            Func<AgentTaskProgress, CancellationToken, Task> progress, CancellationToken cancellationToken)
        {
            Calls++;
            return Task.FromResult(new AgentTaskExecutionResult("Concluida.", true));
        }
    }

    private sealed class CompletionFaultRepository(AgentTaskTestRepository memory) : IAgentTaskRepository
    {
        private int _recoveries;
        public TaskCompletionSource RecoveredAfterFailure { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task<AgentTaskReceipt> AcceptAsync(SendAgentTaskCommand command, int maximumPending, CancellationToken token) => memory.AcceptAsync(command, maximumPending, token);
        public Task<AgentTaskReadResult> ReadAsync(ReadAgentTaskQuery query, CancellationToken token) => memory.ReadAsync(query, token);
        public Task<AgentTaskWorkItem?> ClaimAsync(CancellationToken token) => memory.ClaimAsync(token);
        public Task ProgressAsync(AgentTaskWorkItem item, AgentTaskProgress progress, CancellationToken token) => memory.ProgressAsync(item, progress, token);
        public Task CompleteAsync(AgentTaskWorkItem item, string status, string response, CancellationToken token) => throw new InvalidOperationException("Database unavailable.");
        public async Task RecoverInterruptedAsync(CancellationToken token)
        {
            await memory.RecoverInterruptedAsync(token);
            if (++_recoveries > 1) RecoveredAfterFailure.TrySetResult();
        }
    }
}
