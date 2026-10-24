using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class AgentTaskRecoveryTests
{
    [TestMethod]
    public async Task NumberedSelectionReadsTheDisplayedTaskWithoutSendingOrdersOrSharingSelection()
    {
        var repository = new AgentTaskTestRepository();
        var control = new AgentTaskExecutionControl();
        var reader = new ReadAgentTaskReceiver(repository, control);
        for (var index = 0; index < 5; index++)
            await repository.AcceptAsync(new($"order-{index}", $"Task {index}"), 10, default);
        var listed = await reader.ExecuteAsync(new(), default);
        CollectionAssert.AreEqual(new int?[] { 1, 2, 3, 4, 5 }, listed.Tasks.Select(task => task.SelectionNumber).ToArray());
        var chosen = listed.Tasks.Single(task => task.SelectionNumber == 3).TaskId;
        await repository.AcceptAsync(new("new-task", "New task after listing"), 10, default);
        var selected = await reader.ExecuteAsync(new(chosen), default);
        Assert.AreEqual(chosen, selected.Tasks.Single().TaskId);
        Assert.IsNull(selected.Tasks.Single().SelectionNumber);
        Assert.AreEqual(6, repository.AcceptedCount);
        var anotherConversation = new ReadAgentTaskReceiver(repository, control);
        Assert.AreEqual(6, (await anotherConversation.ExecuteAsync(new(), default)).Tasks.Count);
        Assert.IsTrue(listed.Instruction.Contains("numero -> taskId"));
    }

    [TestMethod]
    public async Task RestartRequiresConfirmationValidTargetAndEnabledAgent()
    {
        var control = new AgentTaskExecutionControl();
        var receiver = new RestartAgentReceiver(control, Options.Create(new AgentTaskOptions { Enabled = true }));
        var id = Guid.NewGuid();
        foreach (var command in new[]
        {
            new RestartAgentCommand(id, "order"), new RestartAgentCommand(Guid.Empty, "order", true),
            new RestartAgentCommand(id, "", true), new RestartAgentCommand(id, " order", true),
            new RestartAgentCommand(id, new string('x', 101), true)
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => receiver.ExecuteAsync(command, default));
        var disabled = new RestartAgentReceiver(control, Options.Create(new AgentTaskOptions()));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => disabled.ExecuteAsync(new(id, "order", true), default));
        Assert.AreEqual("NotRunning", (await receiver.ExecuteAsync(new(id, "order", true), default)).Status);
    }

    [TestMethod]
    public async Task RestartIsScopedToExactOrderAndCannotInterruptItsSuccessor()
    {
        var control = new AgentTaskExecutionControl();
        var taskId = Guid.NewGuid();
        using (var first = control.Begin(new() { TaskId = taskId, RequestId = "first" }, default))
        {
            Assert.AreEqual("NotRunning", (await control.RequestRestartAsync(new(taskId, "wrong", true))).Status);
            Assert.AreEqual("NotRunning", (await control.RequestRestartAsync(new(Guid.NewGuid(), "first", true))).Status);
            Assert.IsFalse(first.Token.IsCancellationRequested);
            Assert.AreEqual("RestartRequested", (await control.RequestRestartAsync(new(taskId, "first", true))).Status);
            Assert.IsTrue(first.Token.IsCancellationRequested);
            Assert.AreEqual("AlreadyRequested", (await control.RequestRestartAsync(new(taskId, "first", true))).Status);
            Assert.IsTrue(first.Finish());
        }
        using var second = control.Begin(new() { TaskId = taskId, RequestId = "second" }, default);
        Assert.AreEqual("NotRunning", (await control.RequestRestartAsync(new(taskId, "first", true))).Status);
        Assert.IsFalse(second.Token.IsCancellationRequested);
    }

    [TestMethod]
    public async Task RestartPersistsInterruptionAndNextOrderCanResumeSameThreadWithoutReplay()
    {
        var repository = new AgentTaskTestRepository();
        var control = new AgentTaskExecutionControl();
        var options = Options.Create(new AgentTaskOptions { Enabled = true });
        var receipt = await repository.AcceptAsync(new("stuck", "First order"), 10, default);
        var executor = new BlockingExecutor();
        var processor = new ProcessAgentTaskReceiver(repository, executor, options, control);
        var processing = processor.ExecuteAsync((await repository.ClaimAsync(default))!, default);
        await executor.Started.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var read = await new ReadAgentTaskReceiver(repository, control).ExecuteAsync(new(receipt.TaskId), default);
        Assert.AreEqual("stuck", read.ActiveExecution!.RequestId);
        await new RestartAgentReceiver(control, options).ExecuteAsync(new(receipt.TaskId, "stuck", true), default);
        await processing.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.IsTrue(executor.Stopped);
        var state = await repository.ReadAsync(new(receipt.TaskId), default);
        Assert.AreEqual("Interrupted", state.Messages.Single().Status);
        Assert.IsNull(control.Read());
        Assert.IsNull(await repository.ClaimAsync(default));
        await repository.AcceptAsync(new("continue", "Continue after checking workspace", receipt.TaskId), 10, default);
        var next = await repository.ClaimAsync(default);
        Assert.AreEqual(receipt.TaskId, next!.TaskId);
        Assert.AreEqual("existing-thread", next.ThreadId);
        Assert.AreEqual("continue", next.RequestId);
        Assert.AreEqual(2, repository.AcceptedCount);
    }

    [TestMethod]
    public async Task CompletedExecutionIsNoLongerRestartable()
    {
        var control = new AgentTaskExecutionControl();
        var id = Guid.NewGuid();
        using var execution = control.Begin(new() { TaskId = id, RequestId = "finished" }, default);
        Assert.IsFalse(execution.Finish());
        Assert.AreEqual("NotRunning", (await control.RequestRestartAsync(new(id, "finished", true))).Status);
        Assert.IsFalse(execution.Token.IsCancellationRequested);
    }

    private sealed class BlockingExecutor : IAgentTaskExecutor
    {
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public bool Stopped { get; private set; }
        public async Task<AgentTaskExecutionResult> ExecuteAsync(AgentTaskWorkItem item,
            Func<AgentTaskProgress, CancellationToken, Task> progress, CancellationToken cancellationToken)
        {
            try
            {
                await progress(new("existing-thread", "Working"), cancellationToken);
                Started.TrySetResult();
                await Task.Delay(Timeout.Infinite, cancellationToken);
                return new("Not reached", true);
            }
            finally { Stopped = true; }
        }
    }
}
