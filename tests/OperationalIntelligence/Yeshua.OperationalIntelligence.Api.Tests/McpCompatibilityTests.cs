using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Client;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Database;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class McpCompatibilityTests
{
    [TestMethod]
    public async Task OfficialClientDiscoversTheCompleteProductionCatalogWithoutQueryingData()
    {
        await using var host = await McpHost.StartAsync(productionCatalog: true);
        await using var client = await ConnectAsync(host.PrivateUrl);
        var tools = await client.ListToolsAsync();
        Assert.AreEqual(13, tools.Count);
        foreach (var tool in tools)
        {
            Assert.IsFalse(tool.Name.Contains('.'));
            Assert.IsNotNull(tool.ProtocolTool.Annotations);
            Assert.AreEqual("object", tool.ProtocolTool.InputSchema.GetProperty("type").GetString());
        }
        Assert.AreEqual(0, host.Repository.AcceptedCount);
        Assert.IsTrue(client.ServerInstructions!.Contains("numero -> taskId"));
        Assert.IsTrue(client.ServerInstructions.Contains("yeshua_agent_restart"));
    }

    [TestMethod]
    public async Task OfficialClientDiscoversPublicHealthWithSchemasAndSafetyAnnotations()
    {
        await using var host = await McpHost.StartAsync();
        await using var client = await ConnectAsync(host.PublicUrl);
        var tools = await client.ListToolsAsync();
        Assert.AreEqual(1, tools.Count);
        Assert.AreEqual("yeshua_health", tools.Single().Name);
        Assert.AreEqual(true, tools.Single().ProtocolTool.Annotations!.ReadOnlyHint);
        Assert.AreEqual("object", tools.Single().ProtocolTool.InputSchema.GetProperty("type").GetString());
        var result = await client.CallToolAsync("yeshua_health");
        Assert.AreEqual(false, result.IsError ?? false);
        Assert.AreEqual("healthy", result.StructuredContent!.Value.GetProperty("mcp").GetString());
    }

    [TestMethod]
    public async Task PublicConnectionCannotSubmitTasksEvenWhenForwardedHeadersClaimLoopback()
    {
        await using var host = await McpHost.StartAsync();
        await using var client = await ConnectAsync(host.PublicUrl, spoofForwardedHeaders: true);
        var result = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "public-denied", ["message"] = "Teste"
        });
        Assert.AreEqual(true, result.IsError);
        Assert.AreEqual(0, host.Repository.AcceptedCount);
    }

    [TestMethod]
    public async Task PrivateConnectionQueuesOnceReadsProgressAndContinuesExactConversation()
    {
        await using var host = await McpHost.StartAsync();
        await using var client = await ConnectAsync(host.PrivateUrl);
        var tools = await client.ListToolsAsync();
        CollectionAssert.AreEquivalent(new[] { "yeshua_health", "yeshua_task_send", "yeshua_task_read", "yeshua_agent_restart", "yeshua_codex_status", "yeshua_codex_auth" }, tools.Select(tool => tool.Name).ToArray());
        Assert.AreEqual(false, tools.Single(tool => tool.Name == "yeshua_task_send").ProtocolTool.Annotations!.ReadOnlyHint);
        var arguments = new Dictionary<string, object?> { ["requestId"] = "first-order", ["message"] = "Analise o projeto." };
        var submitted = await client.CallToolAsync("yeshua_task_send", arguments);
        Assert.AreEqual(false, submitted.IsError ?? false);
        var taskId = submitted.StructuredContent!.Value.GetProperty("taskId").GetGuid();
        Assert.AreEqual(TimeSpan.Zero, submitted.StructuredContent.Value.GetProperty("acceptedAtUtc").GetDateTimeOffset().Offset);
        var repeated = await client.CallToolAsync("yeshua_task_send", arguments);
        Assert.IsTrue(repeated.StructuredContent!.Value.GetProperty("duplicate").GetBoolean());
        Assert.AreEqual(1, host.Repository.AcceptedCount);
        await host.Executor.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));

        var running = await client.CallToolAsync("yeshua_task_read", new Dictionary<string, object?> { ["taskId"] = taskId.ToString() });
        Assert.AreEqual("Running", running.StructuredContent!.Value.GetProperty("messages")[0].GetProperty("status").GetString());
        Assert.AreEqual(1, host.Repository.AcceptedCount);
        host.Executor.Release.TrySetResult();
        await WaitForCompletedAsync(client, taskId);

        var continued = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "second-order", ["message"] = "Agora explique a conclusao.", ["taskId"] = taskId.ToString()
        });
        Assert.AreEqual(false, continued.IsError ?? false);
        await WaitForCompletedAsync(client, taskId);
        Assert.AreEqual(2, host.Executor.Calls.Count);
        Assert.AreEqual("codex-conversation-1", host.Executor.Calls[1].ThreadId);
    }

    [TestMethod]
    public async Task LegacyInitializeIsHandledByStandardTransport()
    {
        await using var host = await McpHost.StartAsync();
        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        using var response = await http.PostAsync(host.PublicUrl, new StringContent("""
            {"jsonrpc":"2.0","id":1,"method":"initialize","params":{"protocolVersion":"2025-06-18","capabilities":{},"clientInfo":{"name":"legacy-compatibility-test","version":"1"}}}
            """, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var raw = await response.Content.ReadAsStringAsync();
        var json = raw.TrimStart().StartsWith('{') ? raw
            : raw.Split('\n').Last(line => line.StartsWith("data:", StringComparison.Ordinal))[5..].Trim();
        using var document = JsonDocument.Parse(json);
        Assert.AreEqual("2025-06-18", document.RootElement.GetProperty("result").GetProperty("protocolVersion").GetString());
    }

    [TestMethod]
    public async Task InvalidTaskArgumentsReturnToolErrorsWithoutExecution()
    {
        await using var host = await McpHost.StartAsync();
        await using var client = await ConnectAsync(host.PrivateUrl);
        var result = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "bad-mode", ["message"] = "Teste", ["mode"] = "full-access"
        });
        Assert.AreEqual(true, result.IsError);
        Assert.AreEqual(0, host.Repository.AcceptedCount);
    }

    [TestMethod]
    public async Task PrivateRecoveryInterruptsExactOrderWithoutReplayAndPublicRecoveryIsDenied()
    {
        await using var host = await McpHost.StartAsync();
        await using var client = await ConnectAsync(host.PrivateUrl);
        await using var publicClient = await ConnectAsync(host.PublicUrl, spoofForwardedHeaders: true);
        var catalog = await client.ListToolsAsync();
        var tool = catalog.Single(tool => tool.Name == "yeshua_agent_restart").ProtocolTool;
        Assert.AreEqual(false, tool.Annotations!.ReadOnlyHint);
        Assert.AreEqual(true, tool.Annotations.DestructiveHint);
        var sent = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "recover-order", ["message"] = "Observe o projeto"
        });
        var id = sent.StructuredContent!.Value.GetProperty("taskId").GetGuid();
        await host.Executor.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));
        var read = await client.CallToolAsync("yeshua_task_read");
        Assert.AreEqual(1, read.StructuredContent!.Value.GetProperty("tasks")[0].GetProperty("selectionNumber").GetInt32());
        var active = read.StructuredContent.Value.GetProperty("activeExecution");
        Assert.AreEqual(id, active.GetProperty("taskId").GetGuid());
        Assert.AreEqual("recover-order", active.GetProperty("requestId").GetString());
        var arguments = new Dictionary<string, object?>
        {
            ["taskId"] = id.ToString(), ["requestId"] = "recover-order", ["confirm"] = true
        };
        Assert.AreEqual(true, (await publicClient.CallToolAsync("yeshua_agent_restart", arguments)).IsError);
        arguments["confirm"] = false;
        Assert.AreEqual(true, (await client.CallToolAsync("yeshua_agent_restart", arguments)).IsError);
        Assert.IsFalse(host.Executor.Release.Task.IsCompleted);
        arguments["confirm"] = true;
        arguments["requestId"] = "wrong-order";
        Assert.AreEqual("NotRunning", (await client.CallToolAsync("yeshua_agent_restart", arguments))
            .StructuredContent!.Value.GetProperty("status").GetString());
        arguments["requestId"] = "recover-order";
        Assert.AreEqual("RestartRequested", (await client.CallToolAsync("yeshua_agent_restart", arguments))
            .StructuredContent!.Value.GetProperty("status").GetString());
        await WaitForStatusAsync(client, id, "Interrupted");
        Assert.AreEqual("NotRunning", (await client.CallToolAsync("yeshua_agent_restart", arguments))
            .StructuredContent!.Value.GetProperty("status").GetString());
        Assert.AreEqual(1, host.Executor.Calls.Count);
        Assert.IsNull(await host.Repository.ClaimAsync(default));
    }

    [TestMethod]
    public async Task PrivateMcpMediatesAccountSwitchAndPreservesTaskAndThreadWithoutReplayingOrders()
    {
        await using var host = await McpHost.StartAsync(authentication: true);
        await using var client = await ConnectAsync(host.PrivateUrl);
        await using var publicClient = await ConnectAsync(host.PublicUrl);
        var first = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "account-a-order", ["message"] = "First explicit order"
        });
        var taskId = first.StructuredContent!.Value.GetProperty("taskId").GetGuid();
        await host.Executor.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));
        var status = await client.CallToolAsync("yeshua_codex_status");
        var sessionId = status.StructuredContent!.Value.GetProperty("sessionId").GetGuid();
        var login = new Dictionary<string, object?>
        {
            ["requestId"] = "change-account", ["action"] = "login", ["expectedSessionId"] = sessionId.ToString(), ["confirm"] = true
        };
        login["password"] = "fixture-not-a-real-password";
        Assert.AreEqual(true, (await client.CallToolAsync("yeshua_codex_auth", login)).IsError);
        login.Remove("password");
        Assert.AreEqual(true, (await client.CallToolAsync("yeshua_codex_auth", login)).IsError);
        Assert.AreEqual(true, (await publicClient.CallToolAsync("yeshua_codex_auth", login)).IsError);
        Assert.AreEqual(true, (await publicClient.CallToolAsync("yeshua_codex_status")).IsError);
        Assert.IsFalse(host.Accounts.Calls.Any(call => call == "account/logout"));
        host.Executor.Release.TrySetResult();
        await WaitForCompletedAsync(client, taskId);
        var pending = await client.CallToolAsync("yeshua_codex_auth", login);
        Assert.AreEqual(false, pending.IsError ?? false);
        Assert.AreEqual("LoginPending", pending.StructuredContent!.Value.GetProperty("status").GetProperty("state").GetString());
        await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?>
        {
            ["requestId"] = "account-b-order", ["taskId"] = taskId.ToString(), ["message"] = "Second explicit order on the same task"
        });
        var queued = await client.CallToolAsync("yeshua_task_read", new Dictionary<string, object?> { ["taskId"] = taskId.ToString() });
        Assert.AreEqual("Queued", queued.StructuredContent!.Value.GetProperty("messages")[0].GetProperty("status").GetString());
        Assert.AreEqual(1, host.Executor.Calls.Count);
        host.Accounts.CompleteLogin();
        await WaitForCompletedAsync(client, taskId);
        Assert.AreEqual(2, host.Executor.Calls.Count);
        Assert.AreEqual(taskId, host.Executor.Calls[1].TaskId);
        Assert.AreEqual("codex-conversation-1", host.Executor.Calls[1].ThreadId);
        var current = await client.CallToolAsync("yeshua_codex_status", new Dictionary<string, object?> { ["includeLimits"] = true });
        Assert.AreEqual("account-b@example.test", current.StructuredContent!.Value.GetProperty("account").GetProperty("email").GetString());
        Assert.IsFalse(current.StructuredContent.Value.ToString().Contains(CodexAccountTestFactory.Secret));
        login["requestId"] = "late-logout";
        login["action"] = "logout";
        Assert.AreEqual(true, (await client.CallToolAsync("yeshua_codex_auth", login)).IsError);
        Assert.AreEqual("account-b@example.test", host.Accounts.Account!.Email);
    }

    private static Task<McpClient> ConnectAsync(string url, bool spoofForwardedHeaders = false) =>
        McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        {
            Endpoint = new Uri(url),
            TransportMode = HttpTransportMode.StreamableHttp,
            ConnectionTimeout = TimeSpan.FromSeconds(10),
            AdditionalHeaders = spoofForwardedHeaders ? new Dictionary<string, string>
            {
                ["X-Forwarded-For"] = "127.0.0.1", ["X-Forwarded-Port"] = "5729"
            } : null
        }));

    private static Task WaitForCompletedAsync(McpClient client, Guid taskId) => WaitForStatusAsync(client, taskId, "Completed");

    private static async Task WaitForStatusAsync(McpClient client, Guid taskId, string expectedStatus)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        while (true)
        {
            deadline.Token.ThrowIfCancellationRequested();
            var result = await client.CallToolAsync("yeshua_task_read", new Dictionary<string, object?> { ["taskId"] = taskId.ToString() }, cancellationToken: deadline.Token);
            if (result.StructuredContent!.Value.GetProperty("messages")[0].GetProperty("status").GetString() == expectedStatus)
                return;
            await Task.Delay(25, deadline.Token);
        }
    }

    private sealed class McpHost(WebApplication app, string publicUrl, string privateUrl,
        AgentTaskTestRepository repository, ControlledExecutor executor, CodexAccountTestFactory accounts, string authHome) : IAsyncDisposable
    {
        public string PublicUrl => publicUrl;
        public string PrivateUrl => privateUrl;
        public AgentTaskTestRepository Repository => repository;
        public ControlledExecutor Executor => executor;
        public CodexAccountTestFactory Accounts => accounts;

        public static async Task<McpHost> StartAsync(bool productionCatalog = false, bool authentication = false)
        {
            var authHome = Path.Combine(Path.GetTempPath(), "yeshua-mcp-auth-test-" + Guid.NewGuid());
            using var reservation = new TcpListener(IPAddress.Loopback, 0);
            reservation.Start();
            var privatePort = ((IPEndPoint)reservation.LocalEndpoint).Port;
            reservation.Stop();
            var builder = WebApplication.CreateSlimBuilder(new WebApplicationOptions { EnvironmentName = "Testing" });
            builder.Logging.ClearProviders();
            builder.WebHost.ConfigureKestrel(server =>
            {
                server.Listen(IPAddress.Loopback, 0);
                server.Listen(IPAddress.Loopback, privatePort);
            });
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Mcp:PrivatePort"] = privatePort.ToString(),
                ["AgentTasks:Enabled"] = "true", ["AgentTasks:PollSeconds"] = "1",
                ["AgentTasks:ChatGptAuthentication"] = authentication.ToString(), ["AgentTasks:CodexHomePath"] = authHome,
                ["ConnectionStrings:OperationalIntelligence"] = "Server=127.0.0.1,1;Database=UnusedCompatibilityFixture;Integrated Security=true;Connect Timeout=1"
            });
            builder.Services.AddYeshuaMcp();
            if (productionCatalog)
            {
                builder.Services.AddSingleton<OperationalIntelligenceDatabase>();
                builder.Services.AddScoped<ISourceContextRepository, SourceContextRepository>();
                builder.Services.AddScoped<QuestionContextBuilder>();
            }
            else
            {
                builder.Services.RemoveAll<IMcpTool>();
                builder.Services.AddSingleton<IMcpTool, HealthFixture>();
            }
            builder.Services.AddAgentTasks();
            builder.Services.RemoveAll<IAgentTaskRepository>();
            builder.Services.RemoveAll<IAgentTaskExecutor>();
            var repository = new AgentTaskTestRepository();
            var executor = new ControlledExecutor();
            var accounts = new CodexAccountTestFactory();
            builder.Services.RemoveAll<ICodexAccountClientFactory>();
            builder.Services.AddSingleton<ICodexAccountClientFactory>(accounts);
            builder.Services.AddSingleton<IAgentTaskRepository>(repository);
            builder.Services.AddSingleton<IAgentTaskExecutor>(executor);
            var app = builder.Build();
            app.MapMcpEndpoints();
            await app.StartAsync();
            var publicAddress = app.Urls.Single(url => new Uri(url).Port != privatePort);
            return new(app, publicAddress + "/mcp", $"http://127.0.0.1:{privatePort}/mcp", repository, executor, accounts, authHome);
        }

        public async ValueTask DisposeAsync()
        {
            executor.Release.TrySetResult();
            await app.DisposeAsync();
            if (Directory.Exists(authHome)) Directory.Delete(authHome, recursive: true);
        }
    }

    private sealed class HealthFixture : IMcpTool
    {
        public string Name => "yeshua.health";
        public string Description => "Safe MCP connectivity check.";
        public bool IsPublic => true;
        public object InputSchema => new { type = "object", properties = new { }, additionalProperties = false };
        public Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken) =>
            Task.FromResult(McpToolResult.Ok("Healthy.", new { mcp = "healthy" }));
    }

    private sealed class ControlledExecutor : IAgentTaskExecutor
    {
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public List<AgentTaskWorkItem> Calls { get; } = [];

        public async Task<AgentTaskExecutionResult> ExecuteAsync(AgentTaskWorkItem item,
            Func<AgentTaskProgress, CancellationToken, Task> progress, CancellationToken cancellationToken)
        {
            Calls.Add(item);
            await progress(new("codex-conversation-1", "Analisando."), cancellationToken);
            Started.TrySetResult();
            await Release.Task.WaitAsync(cancellationToken);
            return new("Analise concluida.", true);
        }
    }
}
