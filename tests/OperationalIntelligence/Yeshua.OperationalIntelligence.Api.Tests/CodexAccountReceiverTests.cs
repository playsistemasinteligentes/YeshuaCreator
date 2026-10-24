using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class CodexAccountReceiverTests
{
    [TestMethod]
    public async Task StatusProjectsOnlySafeAccountAndLimitFields()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(true, default);
        Assert.AreEqual("Ready", status.State);
        Assert.AreEqual("account-a@example.test", status.Account!.Email);
        Assert.AreEqual(25d, status.Limits.Single().Primary!.UsedPercent);
        Assert.IsNull(status.Limits.Single().Secondary);
        Assert.IsFalse(JsonSerializer.Serialize(status).Contains(CodexAccountTestFactory.Secret));
        Assert.IsFalse(fixture.Factory.Calls.Any(call => call == "account/logout"));
    }

    [TestMethod]
    public async Task ExplicitLoginPausesDispatchAndKeepsOneIdempotentAuthorization()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        var command = new CodexAuthCommand("login-1", "login", status.SessionId, true);
        var login = await fixture.Receiver.ExecuteAsync(command, default);
        Assert.AreEqual("LoginPending", login.Status.State);
        Assert.IsNull(fixture.Control.TryReserveDispatch());
        Assert.IsFalse(await fixture.Receiver.CanExecuteAsync(default));
        var duplicate = await fixture.Receiver.ExecuteAsync(command, default);
        Assert.IsTrue(duplicate.Duplicate);
        Assert.AreEqual(login.Status.Login!.LoginId, duplicate.Status.Login!.LoginId);
        Assert.AreEqual(1, fixture.Factory.Calls.Count(call => call == "account/login/start"));
        fixture.Factory.CompleteLogin();
        var completed = await fixture.WaitForAsync("Ready");
        Assert.AreEqual("account-b@example.test", completed.Account!.Email);
        Assert.IsNull(completed.Login);
        using var dispatch = fixture.Control.TryReserveDispatch();
        Assert.IsNotNull(dispatch);
        Assert.IsFalse(JsonSerializer.Serialize(completed).Contains(CodexAccountTestFactory.Secret));
    }

    [TestMethod]
    public async Task StaleMutationCannotDisconnectNewlyAuthorizedAccount()
    {
        await using var fixture = new Fixture();
        var initial = await fixture.Receiver.ReadAsync(false, default);
        var command = new CodexAuthCommand("login", "login", initial.SessionId, true);
        await fixture.Receiver.ExecuteAsync(command, default);
        fixture.Factory.CompleteLogin();
        await fixture.WaitForAsync("Ready");
        Assert.IsTrue((await fixture.Receiver.ExecuteAsync(command, default)).Duplicate);
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Receiver.ExecuteAsync(new("late-logout", "logout", initial.SessionId, true), default));
        Assert.AreEqual("account-b@example.test", fixture.Factory.Account!.Email);
        Assert.AreEqual(1, fixture.Factory.Calls.Count(call => call == "account/logout"));
    }

    [TestMethod]
    public async Task ActiveOrClaimingTaskPreventsAnyAuthenticationMutation()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        using (fixture.Control.Begin(new() { TaskId = Guid.NewGuid(), RequestId = "active" }, default))
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Receiver.ExecuteAsync(new("busy-1", "login", status.SessionId, true), default));
        using (fixture.Control.TryReserveDispatch())
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Receiver.ExecuteAsync(new("busy-2", "logout", status.SessionId, true), default));
        Assert.IsFalse(fixture.Factory.Calls.Any(call => call == "account/logout"));
    }

    [TestMethod]
    public async Task CancelAndTimeoutLeaveQueuePausedWithoutReusingOldAccount()
    {
        await using var fixture = new Fixture(loginSeconds: 1);
        var status = await fixture.Receiver.ReadAsync(false, default);
        var login = await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Receiver.ExecuteAsync(
            new("wrong-cancel", "cancel", login.Status.SessionId, true, Guid.NewGuid().ToString()), default));
        var terminal = await fixture.WaitForAsync("SignedOut");
        Assert.IsTrue(terminal.QueuePaused);
        Assert.IsFalse(await fixture.Receiver.CanExecuteAsync(default));
        Assert.IsNull(fixture.Control.TryReserveDispatch());
        Assert.AreEqual(1, fixture.Factory.Calls.Count(call => call == "account/login/start"));
    }

    [TestMethod]
    public async Task ExplicitCancellationClosesOnlyThePendingLogin()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        var pending = await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
        var client = fixture.Factory.Latest!;
        var cancel = new CodexAuthCommand("cancel", "cancel", pending.Status.SessionId, true, pending.Status.Login!.LoginId);
        var result = await fixture.Receiver.ExecuteAsync(cancel, default);
        Assert.AreEqual("SignedOut", result.Status.State);
        Assert.IsTrue(client.Disposed);
        Assert.IsTrue((await fixture.Receiver.ExecuteAsync(cancel, default)).Duplicate);
        Assert.AreEqual(1, fixture.Factory.Calls.Count(call => call == "account/login/cancel"));
    }

    [TestMethod]
    public async Task FailedSwitchPersistsTechnicalPauseAcrossApiRestartWithoutLeakingErrors()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        fixture.Factory.FailLogout = true;
        var result = await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
        Assert.AreEqual("Unavailable", result.Status.State);
        Assert.IsFalse(JsonSerializer.Serialize(result).Contains(CodexAccountTestFactory.Secret));
        await using var restarted = new CodexAccountReceiver(fixture.Factory, new AgentTaskExecutionControl(), fixture.Options);
        Assert.AreEqual("ReauthenticationRequired", (await restarted.ReadAsync(false, default)).State);
        Assert.IsFalse(await restarted.CanExecuteAsync(default));
    }

    [TestMethod]
    public async Task UnsafeAuthorizationAddressIsNeverReturned()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        fixture.Factory.VerificationUrl = "https://untrusted.example/?token=" + CodexAccountTestFactory.Secret;
        var result = await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
        Assert.AreEqual("Unavailable", result.Status.State);
        Assert.IsNull(result.Status.Login);
        Assert.IsFalse(JsonSerializer.Serialize(result).Contains("untrusted.example"));
    }

    [TestMethod]
    public async Task LoginCompletionBeforeReceiptIsNotLost()
    {
        await using var fixture = new Fixture();
        fixture.Factory.CompleteImmediately = true;
        var status = await fixture.Receiver.ReadAsync(false, default);
        await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
        Assert.AreEqual("account-b@example.test", (await fixture.WaitForAsync("Ready")).Account!.Email);
    }

    [TestMethod]
    public async Task ConfirmationAndValidArgumentsAreRequiredBeforeAnyMutation()
    {
        await using var fixture = new Fixture();
        var status = await fixture.Receiver.ReadAsync(false, default);
        foreach (var command in new[]
        {
            new CodexAuthCommand("x", "login", status.SessionId, false), new("", "logout", status.SessionId, true),
            new("x", "rotate", status.SessionId, true), new("x", "login", Guid.Empty, true),
            new("x", "cancel", status.SessionId, true, "invalid")
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => fixture.Receiver.ExecuteAsync(command, default));
        Assert.IsFalse(fixture.Factory.Calls.Any(call => call == "account/logout"));
    }

    [TestMethod]
    public async Task ConfirmedLogoutPausesQueuedWorkAndNeverDeletesNativeSessions()
    {
        await using var fixture = new Fixture();
        Directory.CreateDirectory(Path.Combine(fixture.Home, "sessions"));
        var transcript = Path.Combine(fixture.Home, "sessions", "fixture.jsonl");
        await File.WriteAllTextAsync(transcript, "fixture-history");
        var status = await fixture.Receiver.ReadAsync(false, default);
        var command = new CodexAuthCommand("logout", "logout", status.SessionId, true);
        var result = await fixture.Receiver.ExecuteAsync(command, default);
        Assert.AreEqual("SignedOut", result.Status.State);
        Assert.IsTrue(result.Status.QueuePaused);
        Assert.IsNull(fixture.Control.TryReserveDispatch());
        Assert.AreEqual("fixture-history", await File.ReadAllTextAsync(transcript));
        Assert.IsTrue((await fixture.Receiver.ExecuteAsync(command, default)).Duplicate);
    }

    [TestMethod]
    public async Task DisabledChatGptModeDoesNotStartAnAccountProcess()
    {
        var factory = new CodexAccountTestFactory();
        await using var receiver = new CodexAccountReceiver(factory, new AgentTaskExecutionControl(),
            Microsoft.Extensions.Options.Options.Create(new AgentTaskOptions { Enabled = true }));
        var status = await receiver.ReadAsync(true, default);
        Assert.AreEqual("Disabled", status.State);
        Assert.IsFalse(status.QueuePaused);
        Assert.IsNull(factory.Latest);
        Assert.IsTrue(await receiver.CanExecuteAsync(default));
    }

    [TestMethod]
    public async Task ShutdownCancelsPendingLoginWithoutMakingOldAccountRunnable()
    {
        var fixture = new Fixture();
        CodexAccountTestFactory.Client? client = null;
        try
        {
            var status = await fixture.Receiver.ReadAsync(false, default);
            await fixture.Receiver.ExecuteAsync(new("login", "login", status.SessionId, true), default);
            client = fixture.Factory.Latest!;
        }
        finally { await fixture.DisposeAsync(); }
        Assert.IsTrue(client!.Disposed);
        Assert.IsNull(fixture.Control.TryReserveDispatch());
    }

    [TestMethod]
    public void ChatGptProcessesUseSharedHomeAndDoNotInheritApiOrServiceSecrets()
    {
        var start = new ProcessStartInfo("node");
        start.Environment["OPENAI_API_KEY"] = "fixture";
        start.Environment["McpTunnel__ApiKey"] = "fixture";
        start.Environment["ConnectionStrings__OperationalIntelligence"] = "fixture";
        var home = Path.Combine(Path.GetTempPath(), "codex-shared-fixture");
        CodexProcessEnvironment.Apply(start, new() { ChatGptAuthentication = true, CodexHomePath = home });
        Assert.AreEqual(home, start.Environment["CODEX_HOME"]);
        Assert.IsFalse(start.Environment.ContainsKey("OPENAI_API_KEY"));
        Assert.IsFalse(start.Environment.ContainsKey("McpTunnel__ApiKey"));
        Assert.IsFalse(start.Environment.ContainsKey("ConnectionStrings__OperationalIntelligence"));
    }

    private sealed class Fixture : IAsyncDisposable
    {
        public string Home { get; } = Path.Combine(Path.GetTempPath(), "yeshua-codex-auth-test-" + Guid.NewGuid());
        public CodexAccountTestFactory Factory { get; } = new();
        public AgentTaskExecutionControl Control { get; } = new();
        public IOptions<AgentTaskOptions> Options { get; }
        public CodexAccountReceiver Receiver { get; }
        public Fixture(int loginSeconds = 30)
        {
            Options = Microsoft.Extensions.Options.Options.Create(new AgentTaskOptions
            {
                Enabled = true, ChatGptAuthentication = true, CodexHomePath = Home, LoginTimeoutSeconds = loginSeconds
            });
            Receiver = new(Factory, Control, Options);
        }
        public async Task<CodexAccountStatus> WaitForAsync(string state)
        {
            using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            while (true)
            {
                var status = await Receiver.ReadAsync(false, deadline.Token);
                if (status.State == state) return status;
                await Task.Delay(10, deadline.Token);
            }
        }
        public async ValueTask DisposeAsync()
        {
            await Receiver.DisposeAsync();
            if (Directory.Exists(Home)) Directory.Delete(Home, recursive: true);
        }
    }
}
