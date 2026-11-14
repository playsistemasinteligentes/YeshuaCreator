using System.Diagnostics;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class AgentGitWorkspaceTests
{
    [TestMethod]
    public async Task DevelopmentKeepsItsOriginalTaskBranchAndDoesNotPublishWhenDisabled()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        var item = fixture.Work();
        var path = await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(fixture.Path, path);
        await File.WriteAllTextAsync(System.IO.Path.Combine(path, "change.txt"), "fixture");
        var status = await fixture.GitAsync("status", "--porcelain");
        var result = await fixture.Workspaces.PublishAsync(item, path, "Resumo", default);
        StringAssert.Contains(result, "ainda nao esta habilitado");
        Assert.AreEqual(status, await fixture.GitAsync("status", "--porcelain"));
        Assert.AreEqual("0", (await fixture.GitAsync("rev-list", "--count", "origin/main..HEAD")).Trim());
    }

    [TestMethod]
    public async Task MainAndOtherRemotesCannotBePublished()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        await fixture.GitAsync("checkout", "-b", "main");
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces
            .PublishAsync(fixture.Work(), fixture.Path, "Resumo", default));
        await fixture.GitAsync("checkout", AgentGitWorkspace.Branch(fixture.TaskId));
        await fixture.GitAsync("remote", "set-url", "origin", "https://github.com/another/repository.git");
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces
            .PublishAsync(fixture.Work(), fixture.Path, "Resumo", default));
    }

    [TestMethod]
    public async Task MissingContinuationWorkspaceIsNotReplacedAndObserveDoesNotClone()
    {
        using var fixture = new WorkspaceFixture();
        var item = fixture.Work();
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        Assert.IsFalse(Directory.Exists(fixture.Path));
        item.Mode = "observe";
        Assert.AreEqual(fixture.Root, await fixture.Workspaces.PrepareAsync(item, default));
        Assert.AreEqual("", await fixture.Workspaces.PublishAsync(item, fixture.Root, "Consulta", default));
        Assert.IsFalse(Directory.Exists(fixture.Path));
    }

    private sealed class WorkspaceFixture : IDisposable
    {
        public Guid TaskId { get; } = Guid.NewGuid();
        public string Root { get; } = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "yeshua-git-test-" + Guid.NewGuid().ToString("N"));
        public string Path => System.IO.Path.Combine(Root, TaskId.ToString("N"));
        public AgentGitWorkspace Workspaces { get; }
        public WorkspaceFixture()
        {
            Directory.CreateDirectory(Root);
            var options = Options.Create(new AgentTaskOptions
            {
                WorkspacePath = Root,
                Git = new() { Enabled = true, WorkspacesRoot = Root }
            });
            Workspaces = new(options, new AgentGitHubClient(new HttpClient(), options));
        }
        public AgentTaskWorkItem Work() => new() { TaskId = TaskId, Mode = "workspace-write", IsContinuation = true };
        public async Task InitializeAsync()
        {
            Directory.CreateDirectory(Path);
            await GitAsync("init", "-b", AgentGitWorkspace.Branch(TaskId));
            await GitAsync("-c", "user.name=agpsi0001-lgtm", "-c", "user.email=agpsi0001@gmail.com", "-c", "commit.gpgsign=false",
                "commit", "--allow-empty", "-m", "Fixture");
            await GitAsync("remote", "add", "origin", "https://github.com/playsistemasinteligentes/YeshuaCreator.git");
            await GitAsync("update-ref", "refs/remotes/origin/main", "HEAD");
        }
        public async Task<string> GitAsync(params string[] args)
        {
            var start = new ProcessStartInfo("git") { WorkingDirectory = Path, RedirectStandardOutput = true, RedirectStandardError = true };
            start.ArgumentList.Add("-c"); start.ArgumentList.Add("core.hooksPath=/dev/null");
            foreach (var arg in args) start.ArgumentList.Add(arg);
            using var process = Process.Start(start)!;
            var output = process.StandardOutput.ReadToEndAsync();
            var errors = process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            Assert.AreEqual(0, process.ExitCode, await errors);
            return await output;
        }
        public void Dispose()
        {
            var absolute = System.IO.Path.GetFullPath(Root);
            if (!absolute.StartsWith(System.IO.Path.GetFullPath(System.IO.Path.GetTempPath()), StringComparison.OrdinalIgnoreCase)
                || !System.IO.Path.GetFileName(absolute).StartsWith("yeshua-git-test-", StringComparison.Ordinal))
                throw new InvalidOperationException("Unexpected fixture directory.");
            foreach (var file in Directory.EnumerateFiles(absolute, "*", SearchOption.AllDirectories))
                File.SetAttributes(file, FileAttributes.Normal);
            Directory.Delete(absolute, true);
        }
    }
}
