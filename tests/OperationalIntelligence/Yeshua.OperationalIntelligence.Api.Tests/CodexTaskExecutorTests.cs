using System.Diagnostics;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class CodexTaskExecutorTests
{
    [TestMethod]
    public async Task LostContinuationCannotStartANewConversation()
    {
        var executor = new CodexTaskExecutor(Options.Create(new AgentTaskOptions { NodeExecutable = "must-not-run" }));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => executor.ExecuteAsync(
            new() { TaskId = Guid.NewGuid(), IsContinuation = true }, (_, _) => Task.CompletedTask, default));
    }
    [TestMethod]
    public async Task CancellationStopsAdapterAndItsChildWithoutCallingAnyModel()
    {
        var executor = new CodexTaskExecutor(Options.Create(new AgentTaskOptions
        {
            WorkspacePath = AppContext.BaseDirectory,
            RuntimeScript = Path.Combine(AppContext.BaseDirectory, "Fixtures", "agent-process.cjs"),
            NodeExecutable = "node"
        }));
        var started = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var stop = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var work = executor.ExecuteAsync(new() { TaskId = Guid.NewGuid(), RequestId = "process-test", Message = "Fixture" },
            (progress, _) => { started.TrySetResult(progress.ThreadId!); return Task.CompletedTask; }, stop.Token);
        int[] pids = [];
        try
        {
            var identity = await started.Task.WaitAsync(TimeSpan.FromSeconds(5));
            pids = identity.Split(':').Select(int.Parse).ToArray();
            stop.Cancel();
            try
            {
                await work.WaitAsync(TimeSpan.FromSeconds(8));
                Assert.Fail("Cancellation must interrupt the running adapter.");
            }
            catch (OperationCanceledException) { }
            foreach (var pid in pids)
                Assert.IsFalse(IsRunning(pid), $"Fixture process {pid} must not survive cancellation.");
        }
        finally
        {
            stop.Cancel();
            try { await work.WaitAsync(TimeSpan.FromSeconds(8)); } catch (OperationCanceledException) { }
            foreach (var pid in pids)
                if (IsRunning(pid))
                {
                    using var process = Process.GetProcessById(pid);
                    process.Kill(entireProcessTree: true);
                    await process.WaitForExitAsync();
                }
        }
    }

    private static bool IsRunning(int pid)
    {
        try { using var process = Process.GetProcessById(pid); return !process.HasExited; }
        catch (ArgumentException) { return false; }
    }
}
