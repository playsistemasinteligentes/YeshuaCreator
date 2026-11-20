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
        await fixture.GitAsync("checkout", "main");
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
        Assert.AreEqual(fixture.Seed, await fixture.Workspaces.PrepareAsync(item, default));
        Assert.AreEqual("", await fixture.Workspaces.PublishAsync(item, fixture.Root, "Consulta", default));
        Assert.IsFalse(Directory.Exists(fixture.Path));
    }

    [TestMethod]
    public async Task NewTaskDefaultsToFetchedMainInAnIsolatedCheckout()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        var main = (await fixture.SeedGitAsync("rev-parse", "HEAD")).Trim();
        var item = fixture.Work();
        item.IsContinuation = false;
        await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(main, (await fixture.GitAsync("rev-parse", "HEAD")).Trim());
        Assert.AreEqual(main, (await fixture.GitAsync("rev-parse", "refs/yeshua/base")).Trim());
        Assert.AreEqual("main", (await fixture.SeedGitAsync("symbolic-ref", "--short", "HEAD")).Trim());
        Assert.AreEqual(AgentGitWorkspace.Branch(fixture.TaskId), (await fixture.GitAsync("symbolic-ref", "--short", "HEAD")).Trim());
    }

    [TestMethod]
    public async Task NewDefaultMainFetchesRemoteChangesMissingFromTheSeed()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        var updated = await fixture.AddRemoteFeatureAsync();
        await fixture.RemoteGitAsync("update-ref", "refs/heads/main", updated);
        Assert.AreNotEqual(updated, (await fixture.SeedGitAsync("rev-parse", "main")).Trim());
        var item = fixture.Work();
        item.IsContinuation = false;
        await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(updated, (await fixture.GitAsync("rev-parse", "HEAD")).Trim());
    }

    [TestMethod]
    public async Task MissingExplicitRefNeverFallsBackToPreviouslyFetchedBase()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        var item = fixture.Work();
        await fixture.Workspaces.PrepareAsync(item, default);
        var head = await fixture.GitAsync("rev-parse", "HEAD");
        item.BaseRef = "missing-ref";
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        Assert.AreEqual(head, await fixture.GitAsync("rev-parse", "HEAD"));
    }

    [DataTestMethod]
    [DataRow("feature/m00")]
    [DataRow("refs/heads/feature/m00")]
    [DataRow("refs/pull/63/head")]
    [DataRow("refs/tags/m00")]
    [DataRow("sha")]
    public async Task ExplicitBaseFetchesCommitOutsideMain(string requested)
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        var sha = await fixture.AddRemoteFeatureAsync();
        var item = fixture.Work();
        item.IsContinuation = false;
        item.BaseRef = requested == "sha" ? sha : requested;
        await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(sha, (await fixture.GitAsync("rev-parse", "HEAD")).Trim());
        Assert.AreEqual("M00 fixture", await File.ReadAllTextAsync(System.IO.Path.Combine(fixture.Path, "m00.txt")));
        Assert.IsFalse(File.Exists(System.IO.Path.Combine(fixture.Seed, "m00.txt")));
        var original = await fixture.GitAsync("rev-parse", "HEAD");
        await File.WriteAllTextAsync(System.IO.Path.Combine(fixture.Path, "pending.txt"), "keep");
        item.IsContinuation = true;
        item.BaseRef = null;
        // Main and the branch may move after creation; omission keeps the pinned SHA.
        var later = await fixture.AddRemoteFeatureAsync();
        await fixture.RemoteGitAsync("update-ref", "refs/heads/main", later);
        await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(original, await fixture.GitAsync("rev-parse", "HEAD"));
        Assert.AreEqual("keep", await File.ReadAllTextAsync(System.IO.Path.Combine(fixture.Path, "pending.txt")));
        Assert.AreEqual("0", (await fixture.GitAsync("rev-list", "--count", "refs/yeshua/base..HEAD")).Trim());
    }

    [TestMethod]
    public async Task ResumeFetchesMissingRemoteBranchButRejectsUnrelatedHeadWithoutReset()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        var head = await fixture.GitAsync("rev-parse", "HEAD");
        var sha = await fixture.AddRemoteFeatureAsync();
        var item = fixture.Work();
        item.BaseRef = "feature/m00";
        await File.WriteAllTextAsync(System.IO.Path.Combine(fixture.Path, "pending.txt"), "keep");
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        StringAssert.Contains(error.Message, "nao contem a base " + sha);
        Assert.AreEqual(sha, (await fixture.GitAsync("rev-parse", "refs/yeshua/fetched-base")).Trim());
        Assert.AreEqual(head, await fixture.GitAsync("rev-parse", "HEAD"));
        Assert.AreEqual("keep", await File.ReadAllTextAsync(System.IO.Path.Combine(fixture.Path, "pending.txt")));
    }

    [TestMethod]
    public async Task ResumePreservesLocalCommitsAndDoesNotCloneOrRepeatWork()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        await fixture.GitAsync("-c", "user.name=fixture", "-c", "user.email=fixture@example.com", "-c", "commit.gpgsign=false",
            "commit", "--allow-empty", "-m", "Work already done");
        var head = await fixture.GitAsync("rev-parse", "HEAD");
        var item = fixture.Work();
        await fixture.Workspaces.PrepareAsync(item, default);
        await fixture.Workspaces.PrepareAsync(item, default);
        Assert.AreEqual(head, await fixture.GitAsync("rev-parse", "HEAD"));
        Assert.AreEqual("1", (await fixture.GitAsync("rev-list", "--count", "refs/yeshua/base..HEAD")).Trim());
    }

    [DataTestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public async Task MissingRefOrAccessFailsBeforeCheckoutAndLeavesNoPartialTask(bool accessFailure)
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        var item = fixture.Work();
        item.IsContinuation = false;
        item.BaseRef = accessFailure ? "main" : "missing-ref";
        if (accessFailure) Directory.Move(fixture.Remote, fixture.Remote + "-unavailable");
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        StringAssert.Contains(error.Message, "Ref ausente ou acesso Git indisponivel");
        Assert.IsFalse(Directory.Exists(fixture.Path));
        Assert.AreEqual(0, Directory.GetDirectories(fixture.Root, ".prepare-*").Length);
    }

    [DataTestMethod]
    [DataRow("--upload-pack=bad")]
    [DataRow("main:refs/heads/main")]
    [DataRow("HEAD~1")]
    [DataRow("../main")]
    [DataRow("refs/heads/../main")]
    [DataRow("https://other/repo")]
    [DataRow("refs/yeshua/base")]
    public void UnsafeRefIsRejected(string value) =>
        Assert.ThrowsException<ArgumentException>(() => AgentGitWorkspace.ValidateBaseRef(value));

    [TestMethod]
    public async Task AuthenticatedFetchKeepsCredentialOutOfRemoteConfigAndErrors()
    {
        using var fixture = new WorkspaceFixture(authenticated: true);
        await fixture.InitializeRemoteAsync();
        var item = fixture.Work();
        item.IsContinuation = false;
        await fixture.Workspaces.PrepareAsync(item, default);
        var config = await File.ReadAllTextAsync(System.IO.Path.Combine(fixture.Path, ".git", "config"));
        Assert.IsFalse(config.Contains("fixture-private-token", StringComparison.Ordinal));
        Assert.IsFalse(config.Contains("extraheader", StringComparison.OrdinalIgnoreCase));
        Assert.AreEqual("https://github.com/playsistemasinteligentes/YeshuaCreator.git",
            (await fixture.GitAsync("remote", "get-url", "origin")).Trim());
        Directory.Move(fixture.Remote, fixture.Remote + "-unavailable");
        item.IsContinuation = true;
        item.BaseRef = "main";
        var head = await fixture.GitAsync("rev-parse", "HEAD");
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        Assert.IsFalse(error.Message.Contains("fixture-private-token", StringComparison.Ordinal));
        Assert.AreEqual(head, await fixture.GitAsync("rev-parse", "HEAD"));
    }

    [TestMethod]
    public async Task DeniedGitHubAccessBlocksPreparationWithoutPublishingResponseBody()
    {
        using var fixture = new WorkspaceFixture(authenticated: true, denyAccess: true);
        await fixture.InitializeRemoteAsync();
        var item = fixture.Work();
        item.IsContinuation = false;
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(item, default));
        StringAssert.Contains(error.Message, "HTTP 403");
        Assert.IsFalse(error.Message.Contains("fixture-private-token", StringComparison.Ordinal));
        Assert.IsFalse(Directory.Exists(fixture.Path));
    }

    [TestMethod]
    public async Task GitMetadataSymlinkIsRejectedBeforeFetching()
    {
        if (OperatingSystem.IsWindows()) Assert.Inconclusive("Symbolic link fixture requires Linux permissions.");
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeAsync();
        var metadata = System.IO.Path.Combine(fixture.Path, ".git");
        var moved = System.IO.Path.Combine(fixture.Root, "original-metadata");
        Directory.Move(metadata, moved);
        Directory.CreateSymbolicLink(metadata, moved);
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(fixture.Work(), default));
        StringAssert.Contains(error.Message, "link simbolico");
        Directory.Delete(metadata);
        Directory.Move(moved, metadata);
    }

    private sealed class GitHubAccessFixture(bool denyAccess) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token) =>
            Task.FromResult(new HttpResponseMessage(denyAccess ? System.Net.HttpStatusCode.Forbidden : System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(denyAccess ? "fixture-private-token" : request.RequestUri!.AbsolutePath == "/user"
                    ? "{\"login\":\"fixture\"}" : "{\"permissions\":{\"push\":true}}")
            });
    }

    [TestMethod]
    public async Task StructuredTaskRunsAdapterOnlyAfterExactPrCommitAndPersistsWorkspaceEvidence()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        var expected = await fixture.AddRemoteFeatureAsync();
        // Move the PR ahead: baseSha must select the exact original commit, not its new head.
        await fixture.SeedGitAsync("checkout", "feature/m00");
        await fixture.AddRemoteFeatureAsync();
        var repository = new AgentTaskTestRepository();
        var receiver = new SendAgentTaskReceiver(repository, fixture.Options);
        var tool = new SendAgentTaskTool(receiver, fixture.Options);
        var args = System.Text.Json.JsonSerializer.SerializeToElement(new
        {
            requestId = "m01-pr-base", message = "M01 fixture", mode = "workspace-write",
            baseRef = "refs/pull/63/head", baseSha = expected
        });
        await tool.CallAsync(args, default);
        var work = (await repository.ClaimAsync(default))!;
        var executor = new CodexTaskExecutor(fixture.Options, fixture.Workspaces);
        var result = await executor.ExecuteAsync(work, (progress, token) => repository.ProgressAsync(work, progress, token), default);
        Assert.IsTrue(result.Success);
        Assert.AreEqual(expected, work.WorkspaceBaseSha);
        Assert.AreEqual(expected, work.WorkspaceHeadSha);
        await repository.CompleteAsync(work, "Completed", result.Response, default);
        var message = (await repository.ReadAsync(new(work.TaskId), default)).Messages.Single();
        Assert.AreEqual(expected, message.BaseSha);
        Assert.AreEqual(expected, message.WorkspaceBaseSha);
        Assert.AreEqual(expected, message.WorkspaceHeadSha);
        StringAssert.Contains(result.Response, "fixture adapter completed");
    }

    [TestMethod]
    public async Task WrongExpectedShaBlocksBeforeCreatingCheckout()
    {
        using var fixture = new WorkspaceFixture();
        await fixture.InitializeRemoteAsync();
        await fixture.AddRemoteFeatureAsync();
        var work = fixture.Work();
        work.IsContinuation = false;
        work.BaseRef = "refs/pull/63/head";
        work.BaseSha = new string('0', 40);
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Workspaces.PrepareAsync(work, default));
        Assert.IsFalse(Directory.Exists(fixture.Path));
    }

    [TestMethod]
    public async Task OptionalRealM00RefIsFetchedAndCheckedOutByTheActualPreparer()
    {
        if (Environment.GetEnvironmentVariable("YESHUA_WORKSPACE_REMOTE_PROBE") != "1")
            Assert.Inconclusive("Opt in to a read-only remote fetch into a disposable test workspace.");
        using var fixture = new WorkspaceFixture();
        var actual = new AgentGitWorkspace(fixture.Options, new AgentGitHubClient(new HttpClient(), fixture.Options));
        var work = fixture.Work();
        work.IsContinuation = false;
        work.BaseRef = "refs/pull/63/head";
        work.BaseSha = "8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1";
        using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(3));
        await actual.PrepareAsync(work, timeout.Token);
        Assert.AreEqual(work.BaseSha, work.WorkspaceBaseSha);
        Assert.AreEqual(work.BaseSha, work.WorkspaceHeadSha);
        Assert.AreEqual(work.BaseSha, (await fixture.GitAsync("rev-parse", "HEAD")).Trim());
        Console.WriteLine($"Actual PR #63 fetched and validated: base={work.WorkspaceBaseSha}; HEAD={work.WorkspaceHeadSha}");
    }

    // Only transport is redirected to a local fixture. All validation/checkout commands use real Git.
    private sealed class LocalGitWorkspace(IOptions<AgentTaskOptions> options, AgentGitHubClient github, string remote)
        : AgentGitWorkspace(options, github)
    {
        protected override Task<string> RunAsync(string directory, AgentGitIdentity? identity,
            CancellationToken token, params string[] arguments)
        {
            if (arguments[0] is "fetch" or "clone")
                arguments = arguments.Select(arg => arg == "https://github.com/playsistemasinteligentes/YeshuaCreator.git" ? remote : arg).ToArray();
            return base.RunAsync(directory, identity, token, arguments);
        }
    }

    private sealed class WorkspaceFixture : IDisposable
    {
        public Guid TaskId { get; } = Guid.NewGuid();
        public string Root { get; } = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "yeshua-git-test-" + Guid.NewGuid().ToString("N"));
        public string Seed => System.IO.Path.Combine(Root, "seed");
        public string Remote => System.IO.Path.Combine(Root, "remote.git");
        public string Path => System.IO.Path.Combine(Root, TaskId.ToString("N"));
        public AgentGitWorkspace Workspaces { get; }
        public IOptions<AgentTaskOptions> Options { get; }
        public WorkspaceFixture(bool authenticated = false, bool denyAccess = false)
        {
            Directory.CreateDirectory(Root);
            var options = Microsoft.Extensions.Options.Options.Create(new AgentTaskOptions
            {
                WorkspacePath = Seed,
                Enabled = true, AllowWorkspaceWrite = true,
                RuntimeScript = System.IO.Path.Combine(AppContext.BaseDirectory, "Fixtures", "agent-workspace.cjs"),
                Git = new()
                {
                    Enabled = true, WorkspacesRoot = Root,
                    UserName = authenticated ? "fixture" : "",
                    Email = authenticated ? "fixture@example.com" : "",
                    Token = authenticated ? "fixture-private-token" : ""
                }
            });
            Options = options;
            Workspaces = new LocalGitWorkspace(options, new AgentGitHubClient(new HttpClient(new GitHubAccessFixture(denyAccess)), options), Remote);
        }
        public AgentTaskWorkItem Work() => new() { TaskId = TaskId, Mode = "workspace-write", IsContinuation = true };
        public async Task InitializeRemoteAsync()
        {
            Directory.CreateDirectory(Seed);
            await SeedGitAsync("init", "-b", "main");
            await SeedGitAsync("-c", "user.name=fixture", "-c", "user.email=fixture@example.com", "-c", "commit.gpgsign=false",
                "commit", "--allow-empty", "-m", "Main fixture");
            await SeedGitAsync("clone", "--bare", Seed, Remote);
        }
        public async Task<string> AddRemoteFeatureAsync()
        {
            await SeedGitAsync("checkout", "-B", "feature/m00");
            await File.WriteAllTextAsync(System.IO.Path.Combine(Seed, "m00.txt"), "M00 fixture");
            await SeedGitAsync("add", "m00.txt");
            await SeedGitAsync("-c", "user.name=fixture", "-c", "user.email=fixture@example.com", "-c", "commit.gpgsign=false",
                "commit", "--allow-empty", "-m", "M00 fixture");
            var sha = (await SeedGitAsync("rev-parse", "HEAD")).Trim();
            await GitInAsync(Remote, "fetch", Seed, "+refs/heads/feature/m00:refs/heads/feature/m00");
            await GitInAsync(Remote, "update-ref", "refs/pull/63/head", sha);
            await GitInAsync(Remote, "update-ref", "refs/tags/m00", sha);
            await SeedGitAsync("checkout", "main");
            return sha;
        }
        public async Task InitializeAsync()
        {
            await InitializeRemoteAsync();
            await SeedGitAsync("clone", "--single-branch", "--branch", "main", Seed, Path);
            await GitAsync("checkout", "-b", AgentGitWorkspace.Branch(TaskId));
            await GitAsync("remote", "set-url", "origin", "https://github.com/playsistemasinteligentes/YeshuaCreator.git");
        }
        public Task<string> RemoteGitAsync(params string[] args) => GitInAsync(Remote, args);
        public Task<string> SeedGitAsync(params string[] args) => GitInAsync(Seed, args);
        public Task<string> GitAsync(params string[] args) => GitInAsync(Path, args);
        private async Task<string> GitInAsync(string directory, params string[] args)
        {
            var start = new ProcessStartInfo("git") { WorkingDirectory = directory, RedirectStandardOutput = true, RedirectStandardError = true };
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
