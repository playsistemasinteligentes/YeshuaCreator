using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class PublicHealthTests
{
    [TestMethod]
    public async Task GetEchoesOnlyTheTestMessageAndCallsTheExistingHealthToolWithoutLogin()
    {
        await using var host = await HealthHost.StartAsync();
        const string message = "teste gratis: acao & conexao <ok>";
        using var response = await host.Client.GetAsync("/health?mensagem=" + Uri.EscapeDataString(message));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("application/json", response.Content.Headers.ContentType!.MediaType);
        Assert.IsTrue(response.Headers.CacheControl!.NoStore);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.AreEqual("yeshua_health", body.RootElement.GetProperty("tool").GetString());
        Assert.AreEqual("ok", body.RootElement.GetProperty("status").GetString());
        Assert.AreEqual(message, body.RootElement.GetProperty("received").GetString());
        Assert.AreEqual(TimeSpan.Zero, body.RootElement.GetProperty("checkedAtUtc").GetDateTimeOffset().Offset);
        Assert.AreEqual(1, host.Tool.Calls);
        Assert.IsFalse(body.RootElement.ToString().Contains("internal-fixture-only"));
        Assert.IsFalse(body.RootElement.TryGetProperty("loki", out _));
    }

    [TestMethod]
    public async Task GetWorksWithoutAQueryAndDoesNotTreatOtherParametersAsToolNames()
    {
        await using var host = await HealthHost.StartAsync();
        using var response = await host.Client.GetAsync("/health?tool=yeshua_task_send");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.AreEqual(JsonValueKind.Null, body.RootElement.GetProperty("received").ValueKind);
        Assert.AreEqual("yeshua_health", body.RootElement.GetProperty("tool").GetString());
        Assert.AreEqual(1, host.Tool.Calls);
    }

    [TestMethod]
    public async Task InvalidMessagesAreRejectedBeforeCallingTheTool()
    {
        await using var host = await HealthHost.StartAsync();
        foreach (var query in new[] { "mensagem=" + new string('x', 201), "mensagem=one&mensagem=two" })
        {
            using var response = await host.Client.GetAsync("/health?" + query);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        Assert.AreEqual(0, host.Tool.Calls);
    }

    [TestMethod]
    public async Task HealthFailureReturnsUnavailableWithoutRawDiagnostics()
    {
        await using var host = await HealthHost.StartAsync(fail: true);
        using var response = await host.Client.GetAsync("/health?mensagem=check");
        Assert.AreEqual(HttpStatusCode.ServiceUnavailable, response.StatusCode);
        var raw = await response.Content.ReadAsStringAsync();
        Assert.IsFalse(raw.Contains("internal-fixture-only"));
        using var body = JsonDocument.Parse(raw);
        Assert.AreEqual("unavailable", body.RootElement.GetProperty("status").GetString());
        Assert.AreEqual("check", body.RootElement.GetProperty("received").GetString());
    }

    [TestMethod]
    public async Task DisabledMcpDoesNotExposeTheGetAdapter()
    {
        await using var host = await HealthHost.StartAsync(enabled: false);
        using var response = await host.Client.GetAsync("/health?mensagem=check");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        Assert.AreEqual(0, host.Tool.Calls);
    }

    private sealed class HealthHost(WebApplication app, HttpClient client, HealthFixture tool) : IAsyncDisposable
    {
        public HttpClient Client => client;
        public HealthFixture Tool => tool;

        public static async Task<HealthHost> StartAsync(bool fail = false, bool enabled = true)
        {
            var builder = WebApplication.CreateSlimBuilder();
            builder.Logging.ClearProviders();
            builder.WebHost.UseUrls("http://127.0.0.1:0");
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Mcp:Enabled"] = enabled.ToString()
            });
            builder.Services.AddYeshuaMcp();
            builder.Services.RemoveAll<IMcpTool>();
            var tool = new HealthFixture(fail);
            builder.Services.AddSingleton<IMcpTool>(tool);
            var app = builder.Build();
            app.MapMcpEndpoints();
            await app.StartAsync();
            return new(app, new HttpClient { BaseAddress = new Uri(app.Urls.Single()) }, tool);
        }

        public async ValueTask DisposeAsync()
        {
            client.Dispose();
            await app.DisposeAsync();
        }
    }

    private sealed class HealthFixture(bool fail) : IMcpTool
    {
        public string Name => "yeshua.health";
        public string Description => "Connectivity fixture.";
        public bool IsPublic => true;
        public object InputSchema => new { type = "object" };
        public int Calls { get; private set; }

        public Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
        {
            Calls++;
            Assert.AreEqual(0, arguments.EnumerateObject().Count());
            return Task.FromResult(fail
                ? McpToolResult.Error("internal-fixture-only")
                : McpToolResult.Ok("internal-fixture-only", new { mcp = "healthy", loki = "internal-fixture-only" }));
        }
    }
}
