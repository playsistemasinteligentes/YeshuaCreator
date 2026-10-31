using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Client;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class PublicAppExplorerTests
{
    [TestMethod]
    public async Task DiscoversAccessAndReadsCurrentInterfaceInsteadOfPreparedInstructions()
    {
        var source = new PublicFront();
        var explorer = new PublicAppExplorer(new HttpClient(source) { BaseAddress = new Uri("https://public.example/") });
        var result = await explorer.Explore(new("Memorias", "register"), default);
        Assert.AreEqual("https://public.example/spa/index.html#register", result.Applications.Single().RegisterUrl);
        Assert.AreEqual("https://public.example/spa/?app=Memorias#dashboard", result.Applications.Single().EntryUrl);
        Assert.AreEqual(2, result.Sources.Length);
        Assert.IsTrue(result.Sources[0].Content.Contains("versao-1"));
        source.Html = "<form><input name='novo-campo' required></form>";
        var changed = await explorer.Explore(new("Memorias", "register"), default);
        Assert.IsTrue(changed.Sources[0].Content.Contains("novo-campo"));
        Assert.AreEqual(TimeSpan.Zero, changed.RetrievedAtUtc.Offset);
        Assert.IsTrue(source.Paths.All(path => !path.Contains("yapi") && !path.Contains("token")));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => explorer.Explore(new("Memorias", "../../secret"), default));
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => explorer.Explore(new("unknown", "register"), default));
        Assert.IsFalse(source.Paths.Any(path => path.Contains("secret")));
    }

    [TestMethod]
    public async Task OversizedPublicSourceIsNotSilentlyTruncated()
    {
        var source = new PublicFront { Html = new string('x', 128_001) };
        var explorer = new PublicAppExplorer(new HttpClient(source) { BaseAddress = new Uri("https://public.example/") });
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => explorer.Explore(new("Memorias", "register"), default));
    }

    [TestMethod]
    public async Task GetAndMcpExposeEquivalentPublicEvidenceAndRejectExtraArguments()
    {
        var builder = WebApplication.CreateSlimBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Services.AddYeshuaMcp();
        builder.Services.RemoveAll<IMcpTool>();
        builder.Services.AddScoped<IMcpTool, PublicAppExploreTool>();
        builder.Services.AddSingleton(new PublicAppExplorer(new HttpClient(new PublicFront()) { BaseAddress = new Uri("https://public.example/") }));
        await using var app = builder.Build();
        app.MapMcpEndpoints();
        await app.StartAsync();
        using var http = new HttpClient { BaseAddress = new Uri(app.Urls.Single()) };
        using var response = await http.GetAsync("/explorer/apps?application=Memorias&screen=register");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("text/plain", response.Content.Headers.ContentType!.MediaType);
        Assert.IsTrue(response.Headers.CacheControl!.NoStore);
        using var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.AreEqual("public-ui", json.RootElement.GetProperty("scope").GetString());
        Assert.AreEqual(2, json.RootElement.GetProperty("sources").GetArrayLength());
        using var attributed = await http.GetAsync("/explorer/apps?application=Memorias&screen=register&utm_source=chatgpt.com");
        Assert.AreEqual(HttpStatusCode.OK, attributed.StatusCode);
        using var attributedJson = JsonDocument.Parse(await attributed.Content.ReadAsStringAsync());
        Assert.AreEqual(json.RootElement.GetProperty("sources").ToString(), attributedJson.RootElement.GetProperty("sources").ToString());
        using var explicitText = await http.GetAsync("/explorer/apps?application=Memorias&screen=register&format=text");
        Assert.AreEqual("text/plain", explicitText.Content.Headers.ContentType!.MediaType);
        using var explicitJson = await http.GetAsync("/explorer/apps?application=Memorias&screen=register&format=json");
        Assert.AreEqual("application/json", explicitJson.Content.Headers.ContentType!.MediaType);
        using var jsonFormat = JsonDocument.Parse(await explicitJson.Content.ReadAsStringAsync());
        Assert.AreEqual(json.RootElement.GetProperty("applications").ToString(), jsonFormat.RootElement.GetProperty("applications").ToString());
        Assert.AreEqual(json.RootElement.GetProperty("sources").ToString(), jsonFormat.RootElement.GetProperty("sources").ToString());
        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        {
            Endpoint = new Uri(http.BaseAddress, "/mcp"), TransportMode = HttpTransportMode.StreamableHttp
        }));
        var tool = (await mcp.ListToolsAsync()).Single();
        Assert.AreEqual(true, tool.ProtocolTool.Annotations!.OpenWorldHint);
        Assert.AreEqual(true, tool.ProtocolTool.Annotations.ReadOnlyHint);
        var result = await mcp.CallToolAsync("yeshua_app_explore", new Dictionary<string, object?> { ["application"] = "Memorias", ["screen"] = "register" });
        Assert.IsFalse(result.IsError ?? false);
        Assert.AreEqual(json.RootElement.GetProperty("applications").ToString(), result.StructuredContent!.Value.GetProperty("applications").ToString());
        Assert.AreEqual(json.RootElement.GetProperty("sources").ToString(), result.StructuredContent.Value.GetProperty("sources").ToString());
        using var invalid = await http.GetAsync("/explorer/apps?url=https://internal.example");
        Assert.AreEqual(HttpStatusCode.BadRequest, invalid.StatusCode);
        using var duplicate = await http.GetAsync("/explorer/apps?application=Memorias&screen=register&screen=login&utm_source=chatgpt.com");
        Assert.AreEqual(HttpStatusCode.BadRequest, duplicate.StatusCode);
        foreach (var format in new[] { "format=html", "format=json&format=text", "format=" })
        {
            using var badFormat = await http.GetAsync("/explorer/apps?" + format);
            Assert.AreEqual(HttpStatusCode.BadRequest, badFormat.StatusCode);
        }
        Assert.AreEqual(true, (await mcp.CallToolAsync("yeshua_app_explore", new Dictionary<string, object?> { ["url"] = "https://internal.example" })).IsError);
        Assert.AreEqual(true, (await mcp.CallToolAsync("yeshua_database_select")).IsError);
    }

    private sealed class PublicFront : HttpMessageHandler
    {
        public string Html = "<form><input name='versao-1' required></form>";
        public List<string> Paths { get; } = [];
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.IsNull(request.Headers.Authorization);
            Assert.IsFalse(request.Headers.Contains("Cookie"));
            var path = request.RequestUri!.AbsolutePath;
            Paths.Add(path);
            var text = path switch
            {
                "/applications.json" => "[{\"application\":\"Central\",\"title\":\"Central\"},{\"application\":\"Memorias\",\"title\":\"Memórias\"}]",
                "/spa/views/register.html" => Html,
                "/spa/scripts/viewsScripts/register.js" => "document.getElementById('versao-1');",
                _ => throw new InvalidOperationException("Unexpected source request: " + path)
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(text, Encoding.UTF8) });
        }
    }
}
