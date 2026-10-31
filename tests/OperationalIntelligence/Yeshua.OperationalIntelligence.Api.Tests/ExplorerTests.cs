using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class ExplorerTests
{
    [TestMethod]
    public async Task BrowserAndOfficialMcpClientReceiveTheSameCompleteDocumentWithoutLogin()
    {
        await using var host = await ExplorerHost.StartAsync();
        using var response = await host.Http.GetAsync("/explorer");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("text/plain", response.Content.Headers.ContentType!.MediaType);
        Assert.IsTrue(response.Headers.CacheControl!.NoStore);
        var text = await response.Content.ReadAsStringAsync();
        Assert.AreEqual(host.Document.Text, text);
        await using var client = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        {
            Endpoint = new Uri(host.Http.BaseAddress!, "/mcp"),
            TransportMode = HttpTransportMode.StreamableHttp
        }));
        var tool = (await client.ListToolsAsync()).Single();
        Assert.AreEqual("yeshua_explorer", tool.Name);
        Assert.AreEqual(true, tool.ProtocolTool.Annotations!.ReadOnlyHint);
        Assert.AreEqual(false, tool.ProtocolTool.Annotations.DestructiveHint);
        var result = await client.CallToolAsync("yeshua_explorer");
        Assert.IsFalse(result.IsError ?? false);
        Assert.AreEqual(text, result.StructuredContent!.Value.GetProperty("guide").GetString());
        Assert.IsTrue(((TextContentBlock)result.Content.Single()).Text.Length < 200, "Do not duplicate the complete guide in content and structuredContent.");
    }

    [TestMethod]
    public async Task NeitherAdapterAcceptsAnApplicationQueryOrArbitraryToolDispatch()
    {
        await using var host = await ExplorerHost.StartAsync();
        using var response = await host.Http.GetAsync("/explorer?tool=yeshua_database_select&application=other-tenant");
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        await using var client = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        {
            Endpoint = new Uri(host.Http.BaseAddress!, "/mcp"),
            TransportMode = HttpTransportMode.StreamableHttp
        }));
        var result = await client.CallToolAsync("yeshua_explorer", new Dictionary<string, object?>
        {
            ["application"] = "other-tenant"
        });
        Assert.AreEqual(true, result.IsError);
        Assert.IsFalse(((TextContentBlock)result.Content.Single()).Text.Contains("other-tenant"));
        Assert.AreEqual(true, (await client.CallToolAsync("yeshua_database_select")).IsError);
    }

    [TestMethod]
    public async Task DisablingMcpAlsoDisablesTheExplorerGetAdapter()
    {
        await using var host = await ExplorerHost.StartAsync(enabled: false);
        using var response = await host.Http.GetAsync("/explorer");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    public async Task BrowserAttributionAndRefreshReturnCurrentGuideWithoutChangingToolArguments()
    {
        await using var host = await ExplorerHost.StartAsync();
        using var response = await host.Http.GetAsync("/explorer?refresh=free-test-3&utm_source=chatgpt.com&utm_medium=web");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(response.Headers.CacheControl!.NoStore);
        Assert.AreEqual(host.Document.Text, await response.Content.ReadAsStringAsync());
        foreach (var query in new[] { "refresh=a&refresh=b", "refresh=" + new string('x', 65), "utm_tool=yeshua_task_send" })
        {
            using var invalid = await host.Http.GetAsync("/explorer?" + query);
            Assert.AreEqual(HttpStatusCode.BadRequest, invalid.StatusCode);
        }
    }

    private sealed class ExplorerHost(WebApplication app, HttpClient http, ExplorerDocument document) : IAsyncDisposable
    {
        public HttpClient Http => http;
        public ExplorerDocument Document => document;

        public static async Task<ExplorerHost> StartAsync(bool enabled = true)
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
            builder.Services.AddScoped<IMcpTool, ExplorerTool>();
            var app = builder.Build();
            app.MapMcpEndpoints();
            await app.StartAsync();
            return new(app, new HttpClient { BaseAddress = new Uri(app.Urls.Single()) },
                app.Services.GetRequiredService<ExplorerDocument>());
        }

        public async ValueTask DisposeAsync()
        {
            http.Dispose();
            await app.DisposeAsync();
        }
    }
}
