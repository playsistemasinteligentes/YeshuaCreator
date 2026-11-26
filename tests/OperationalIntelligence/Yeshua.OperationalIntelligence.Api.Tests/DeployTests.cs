using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yeshua.OperationalIntelligence.Api.Modules.Deploy;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class DeployTests
{
    private sealed class Bridge : IDeployBridge
    {
        public int Calls;
        public DeployCommand? LastCommand;
        public Task<JsonElement> SendAsync(DeployCommand command, CancellationToken cancellationToken)
        {
            Calls++;
            LastCommand = command;
            return Task.FromResult(JsonSerializer.SerializeToElement(new { requestId = command.RequestId, status = "Running", sha = "abc", heartbeatStale = true,
                currentStep = new { module = "central", stage = "build-runtime", timestampUtc = "2026-11-26T00:00:00Z", images = new[] { "central-api" } },
                checkpoints = new[] { new { @event = "step_started", sequence = 123L, timestampUtc = "2026-11-26T00:00:00Z", module = "central", stage = "build-runtime" } },
                nextCursor = "123", hasMore = false, cursorTruncated = false, telemetrySource = "persisted-script-journal" }));
        }
    }

    [TestMethod]
    public async Task ValidCommandsNeedOnlyPrivateConnectionAndInvalidCommandsNeverReachBridge()
    {
        var bridge = new Bridge();
        var receiver = new DeployReceiver(bridge);
        CollectionAssert.Contains(DeployReceiver.Targets, "presenca");
        foreach (var command in new[]
        {
            new DeployCommand("execute", "test"),
            new DeployCommand("execute", "test", "all; id"),
            new DeployCommand("execute", "../test", "all"),
            new DeployCommand("restart", "test"), new DeployCommand("status", "test", "all")
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => receiver.ExecuteAsync(command, default));
        Assert.AreEqual(0, bridge.Calls);
        foreach (var target in DeployReceiver.Targets)
            await receiver.ExecuteAsync(new("execute", "test", target), default);
        await receiver.ExecuteAsync(new("status", "test"), default);
        Assert.AreEqual(DeployReceiver.Targets.Length + 1, bridge.Calls);
        var schema = JsonSerializer.SerializeToElement(new DeployTool(receiver).InputSchema);
        Assert.IsFalse(schema.GetProperty("properties").TryGetProperty("confirm", out _));
        Assert.IsFalse(schema.GetProperty("properties").TryGetProperty("releaseTag", out _));
    }

    [TestMethod]
    public async Task PublicAndSpoofedConnectionsCannotDiscoverOrCallDeploy()
    {
        var bridge = new Bridge();
        var tool = new DeployTool(new(bridge));
        var context = new DefaultHttpContext();
        context.Connection.LocalPort = 8080;
        context.Connection.LocalIpAddress = IPAddress.Loopback;
        context.Connection.RemoteIpAddress = IPAddress.Loopback;
        context.Request.Headers["X-Forwarded-Port"] = "5729";
        var access = new McpAccessPolicy(new HttpContextAccessor { HttpContext = context }, Options.Create(new McpOptions()));
        var registry = new McpToolRegistry([tool], access);
        var arguments = JsonSerializer.SerializeToElement(new { action = "execute", requestId = "test", target = "all" });
        Assert.AreEqual(0, registry.List().Count);
        Assert.IsTrue((await registry.CallAsync("yeshua_deploy", arguments, default)).IsError ?? false);
        Assert.AreEqual(0, bridge.Calls);
        context.Connection.LocalPort = 5729;
        var definition = registry.List().Single();
        Assert.AreEqual(false, definition.Annotations!.ReadOnlyHint);
        Assert.AreEqual(true, definition.Annotations.DestructiveHint);
        Assert.IsFalse((await registry.CallAsync("yeshua_deploy", arguments, default)).IsError ?? false);
        Assert.AreEqual(1, bridge.Calls);
    }

    [TestMethod]
    public async Task SshTransportRejectsRootFreeformDestinationsAndRelativeKeysBeforeStartingProcess()
    {
        foreach (var config in new[]
        {
            new DeployOptions { Destination = "root@host", IdentityFile = "/private/key", KnownHostsFile = "/private/hosts" },
            new DeployOptions { Destination = "yeshua-deploy@host;id", IdentityFile = "/private/key", KnownHostsFile = "/private/hosts" },
            new DeployOptions { Destination = "yeshua-deploy@host", IdentityFile = "relative", KnownHostsFile = "/private/hosts" },
            new DeployOptions { Destination = "yeshua-deploy@host", IdentityFile = "/private/key", KnownHostsFile = "relative" }
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => new SshDeployBridge(Options.Create(config)).SendAsync(new("status", "test"), default));
    }


    private sealed class LokiHandler(bool unavailable) : HttpMessageHandler
    {
        public Uri? Requested;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            Requested = request.RequestUri;
            if (unavailable) throw new HttpRequestException("isolated unavailable fixture");
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"status":"success","data":{"resultType":"streams","result":[]}}""")
            });
        }
    }

    [TestMethod]
    public async Task StatusUsesSameLokiEventsAndKeepsReceiptWhenObservabilityUnavailable()
    {
        foreach (var unavailable in new[] { false, true })
        {
            var bridge = new Bridge();
            var handler = new LokiHandler(unavailable);
            var loki = new LokiClient(new HttpClient(handler) { BaseAddress = new Uri("http://fixture") });
            var tool = new DeployTool(new(bridge), loki);
            var result = await tool.CallAsync(JsonSerializer.Deserialize<JsonElement>(
                """{"action":"status","requestId":"test","cursor":"123"}"""), default);
            Assert.IsFalse(result.IsError);
            Assert.AreEqual("123", bridge.LastCommand!.Cursor);
            var body = (JsonElement)result.StructuredContent!;
            Assert.AreEqual("Running", body.GetProperty("status").GetString());
            Assert.AreEqual(!unavailable, body.GetProperty("observability").GetProperty("available").GetBoolean());
            Assert.AreEqual("yeshua-deploy", body.GetProperty("observability").GetProperty("dashboardUid").GetString());
            StringAssert.Contains(Uri.UnescapeDataString(handler.Requested!.Query), "requestId=\"test\"");
            McpOutputContractTests.Validate(McpOutputSchemas.For(tool.Name), body);
            Assert.AreEqual(1, bridge.Calls);
        }
    }

    [TestMethod]
    public async Task CursorCannotMutateExecutionOrContainFreeformInput()
    {
        var bridge = new Bridge();
        var tool = new DeployTool(new(bridge));
        foreach (var input in new[] {
            """{"action":"execute","requestId":"test","target":"all","cursor":"0"}""",
            """{"action":"status","requestId":"test","cursor":"../x"}""",
            """{"action":"status","requestId":"test","cursor":12}""",
            """{"action":"status","requestId":"test","cursor":"-1"}""" })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => tool.CallAsync(JsonSerializer.Deserialize<JsonElement>(input), default));
        Assert.AreEqual(0, bridge.Calls);
    }

    [TestMethod]
    public async Task UnknownArgumentsAndInvalidTypesAreRejected()
    {
        var bridge = new Bridge();
        var tool = new DeployTool(new(bridge));
        foreach (var json in new[]
        {
            """{"action":"execute","requestId":"test","target":"all","command":"id"}""",
            """{"action":"execute","requestId":"test","target":"all","confirm":true}""",
            """{"action":"status","requestId":"test","confirm":false}""",
            """{"action":"status","requestId":15}""",
            """{"action":"execute","requestId":"test","target":"all","releaseTag":"1.0.0"}""",
            """{"action":"execute","requestId":"test","target":"all","releaseTag":null}""",
            """{"action":"execute","requestId":"test","target":15}"""
        })
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => tool.CallAsync(JsonSerializer.Deserialize<JsonElement>(json), default));
        Assert.AreEqual(0, bridge.Calls);
    }
}
