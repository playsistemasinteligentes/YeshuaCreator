using System.Diagnostics;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class CodexAccountClientTests
{
    [TestMethod]
    public async Task OptionalNativeCodexProbeUsesEmptyHomeAndDoesNotStartLoginOrModel()
    {
        var executable = Environment.GetEnvironmentVariable("YESHUA_CODEX_AUTH_SMOKE_BINARY");
        if (string.IsNullOrWhiteSpace(executable)) Assert.Inconclusive("Set YESHUA_CODEX_AUTH_SMOKE_BINARY for the optional native CLI handshake probe.");
        var home = Path.Combine(Path.GetTempPath(), "yeshua-codex-native-probe-" + Guid.NewGuid());
        try
        {
            var factory = new CodexAccountClientFactory(Options.Create(new AgentTaskOptions
            {
                ChatGptAuthentication = true, CodexHomePath = home, CodexExecutable = executable!, AccountRpcTimeoutSeconds = 10
            }));
            await using var client = await factory.CreateAsync(default);
            var response = await client.CallAsync("account/read", new { refreshToken = false }, default);
            Assert.AreEqual(System.Text.Json.JsonValueKind.Null, response.GetProperty("account").ValueKind);
            Assert.IsFalse(File.Exists(Path.Combine(home, "auth.json")));
        }
        finally { if (Directory.Exists(home)) Directory.Delete(home, recursive: true); }
    }

    [TestMethod]
    public async Task StdioHandshakeAndEarlyLoginNotificationWorkWithoutNetworkOrCredentials()
    {
        await using var client = await StartAsync();
        var account = await client.CallAsync("account/read", new { refreshToken = false }, default);
        Assert.AreEqual("test@example.test", account.GetProperty("account").GetProperty("email").GetString());
        var login = await client.CallAsync("account/login/start", new { type = "chatgptDeviceCode" }, default);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        Assert.IsTrue(await client.WaitForLoginAsync(login.GetProperty("loginId").GetString()!, deadline.Token));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => client.CallAsync("turn/start", null, default));
    }

    [TestMethod]
    public async Task RawAuthenticationErrorsAreNotPublished()
    {
        await using var client = await StartAsync();
        var error = await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
            client.CallAsync("account/read", new { fixtureError = true }, default));
        Assert.IsFalse(error.Message.Contains("fixture-secret"));
    }

    private static Task<CodexAccountClient> StartAsync()
    {
        var start = new ProcessStartInfo("node")
        {
            UseShellExecute = false, CreateNoWindow = true,
            RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true
        };
        start.ArgumentList.Add(Path.Combine(AppContext.BaseDirectory, "Fixtures", "account-server.cjs"));
        return CodexAccountClient.StartAsync(start, TimeSpan.FromSeconds(3), default);
    }
}
