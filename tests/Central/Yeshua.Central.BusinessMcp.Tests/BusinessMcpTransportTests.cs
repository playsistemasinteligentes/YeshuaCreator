using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Central.BusinessMcp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using static Yeshua.Central.BusinessMcp.Tests.BusinessMcpTests;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class BusinessMcpTransportTests
{
    [Fact]
    public async Task OfficialClientDiscoversAndExecutesAgainstAnIndependentlyAuthorizedDestination()
    {
        await using var host = await Host.Start();
        using var http = host.App.GetTestClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token());
        await using var client = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        { Endpoint = new Uri(BusinessMcpTests.Resource), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        var tools = await client.ListToolsAsync();
        Assert.Equal(3, tools.Count);
        Assert.DoesNotContain(tools, t => t.Name.Contains("deploy") || t.Name.Contains("sql") || t.Name.Contains("task_send"));
        var apps = await client.CallToolAsync("yeshua_business_applications", new Dictionary<string, object?>());
        Assert.Contains("Sample", Text(apps));
        var ops = await client.CallToolAsync("yeshua_business_operations", new Dictionary<string, object?> { ["application"] = "Sample" });
        Assert.Contains("Sample.Commands.Execute", Text(ops));
        Assert.Contains("inputSchema", Text(ops));
        Assert.Contains("outputSchema", Text(ops));
        var result = await client.CallToolAsync("yeshua_business_execute", Arguments());
        Assert.False(result.IsError ?? false);
        Assert.Contains("completed", Text(result));
        Assert.Equal(1, host.Sender.Calls);
        Assert.Equal("17:7", host.Sender.DestinationIdentity);
        Assert.NotEqual(Token(), host.Sender.DestinationToken);
        host.Sender.DenyAtDestination = true;
        result = await client.CallToolAsync("yeshua_business_execute", Arguments());
        Assert.True(result.IsError);
        Assert.Contains("destination_denied", Text(result));
        host.Store.Value = host.Store.Value! with { Revoked = true };
        using var rejected = await http.PostAsync("/business/mcp", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Unauthorized, rejected.StatusCode);
        Assert.Equal(2, host.Sender.Calls);
    }
    [Theory]
    [InlineData("missing")]
    [InlineData("audience")]
    [InlineData("issuer")]
    [InlineData("expired")]
    [InlineData("signature")]
    [InlineData("tenant")]
    [InlineData("client")]
    [InlineData("legacy")]
    public async Task ResourceServerRejectsInvalidTokensBeforeDispatch(string scenario)
    {
        await using var host = await Host.Start();
        using var client = host.App.GetTestClient();
        var token = scenario switch
        {
            "audience" => Token(audience: "https://other.test/"),
            "issuer" => Token(issuer: "https://other-issuer.test/"),
            "expired" => Token(expired: true),
            "signature" => Token(key: DestinationKey),
            "tenant" => Token(Principal(tenant: 8)),
            "client" => Token(Principal(client: "other-client")),
            "legacy" => Token(new ClaimsPrincipal(new ClaimsIdentity([new Claim("sub", "17"), new Claim("role", "Admin")], "test"))),
            _ => Token()
        };
        if (scenario != "missing") client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        using var response = await client.PostAsync("/business/mcp", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Contains("oauth-protected-resource/business/mcp", response.Headers.WwwAuthenticate.ToString());
        Assert.Equal(0, host.Sender.Calls);
    }
    [Fact]
    public async Task ForeignBrowserOriginIsRejectedBeforeMcpDispatch()
    {
        await using var host = await Host.Start();
        using var client = host.App.GetTestClient();
        client.DefaultRequestHeaders.Authorization = new("Bearer", Token());
        client.DefaultRequestHeaders.Add("Origin", "https://evil.test");
        using var response = await client.PostAsync("/business/mcp", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        Assert.Equal(0, host.Sender.Calls);
    }
    [Fact]
    public async Task ToolBoundaryRejectsUrlArgumentsAndNullApplication()
    {
        await using var host = await Host.Start();
        using var http = host.App.GetTestClient();
        http.DefaultRequestHeaders.Authorization = new("Bearer", Token());
        await using var client = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        { Endpoint = new Uri(BusinessMcpTests.Resource), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        var arguments = Arguments(); arguments["url"] = "https://evil.test";
        var result = await client.CallToolAsync("yeshua_business_execute", arguments);
        Assert.True(result.IsError);
        result = await client.CallToolAsync("yeshua_business_operations", new Dictionary<string, object?> { ["application"] = null });
        Assert.True(result.IsError);
        Assert.Equal(0, host.Sender.Calls);
    }
    [Fact]
    public async Task MetadataAdvertisesOnlyTheConfiguredResourceAndIssuer()
    {
        await using var host = await Host.Start();
        using var client = host.App.GetTestClient();
        using var response = await client.GetAsync("/.well-known/oauth-protected-resource/business/mcp");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var doc = BusinessMcpTests.Json(await response.Content.ReadAsStringAsync());
        Assert.Equal(BusinessMcpTests.Resource, doc.GetProperty("resource").GetString());
        Assert.Equal(Issuer, doc.GetProperty("authorization_servers")[0].GetString());
        Assert.DoesNotContain("offline_access", doc.GetRawText());
    }
    [Fact]
    public async Task StartupFailsWithoutMandatorySecurityAdapters()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddCentralBusinessMcp(new(new Uri(BusinessMcpTests.Resource), new Uri(Issuer)), Catalog());
        await using var app = builder.Build();
        Assert.Throws<InvalidOperationException>(() => app.MapCentralBusinessMcp());
    }
    private static string Text(CallToolResult result) => ((TextContentBlock)result.Content[0]).Text;
    private static Dictionary<string, object?> Arguments() => new()
    {
        ["application"] = "Sample", ["operation"] = "Sample.Commands.Execute",
        ["parameters"] = new { quantity = 2, items = new[] { new { kind = "A" } } }
    };

    private sealed class Host(WebApplication app, WebApplication destination, Store store, DestinationSender sender) : IAsyncDisposable
    {
        internal WebApplication App = app;
        internal Store Store = store;
        internal DestinationSender Sender = sender;
        public static async Task<Host> Start()
        {
            var db = WebApplication.CreateBuilder();
            db.WebHost.UseTestServer();
            db.Services.AddAuthentication("destination").AddJwtBearer("destination", o =>
            {
                o.MapInboundClaims = false;
                o.TokenValidationParameters = new()
                {
                    ValidateIssuer = true, ValidIssuer = Issuer,
                    ValidateAudience = true, ValidAudience = "https://sample.test/",
                    ValidateIssuerSigningKey = true, IssuerSigningKey = DestinationKey, ValidateLifetime = true
                };
            });
            db.Services.AddAuthorization();
            var destination = db.Build();
            destination.UseAuthentication(); destination.UseAuthorization();
            destination.MapPost("/yapi/Sample/Execute", (HttpContext http) =>
            {
                // This independent API validates identity and grant again, even though
                // the MCP has already allowed the call. No business database is used.
                if (http.User.FindFirst("sub")?.Value != "17" || http.User.FindFirst("tenantId")?.Value != "7"
                    || http.User.FindFirst("scope")?.Value != "sample.execute") return Results.Forbid();
                return Results.Json(new { ok = true });
            }).RequireAuthorization();
            await destination.StartAsync();
            var store = new Store();
            var sender = new DestinationSender(destination.GetTestClient());
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseTestServer();
            builder.Services.AddSingleton<IDelegationRepository>(store);
            builder.Services.AddSingleton<IBusinessPermissionReader>(new Permissions());
            builder.Services.AddSingleton<IBusinessAuditWriter>(new Audit());
            builder.Services.AddSingleton<IApplicationDelegationSender>(sender);
            builder.Services.AddCentralBusinessMcp(new(new Uri(BusinessMcpTests.Resource), new Uri(Issuer)), Catalog());
            // Synthetic AS key material is injected locally. No live discovery or
            // authorization server is contacted, and no OAuth code flow is claimed.
            builder.Services.Configure<JwtBearerOptions>(BusinessOAuthResource.Scheme, options =>
            {
                var config = new OpenIdConnectConfiguration { Issuer = Issuer };
                config.SigningKeys.Add(Key);
                options.Configuration = config;
            });
            var app = builder.Build();
            app.UseAuthentication(); app.UseAuthorization(); app.MapCentralBusinessMcp();
            await app.StartAsync();
            return new(app, destination, store, sender);
        }
        public async ValueTask DisposeAsync()
        { await App.DisposeAsync(); await destination.DisposeAsync(); Sender.Client.Dispose(); }
    }
    private sealed class DestinationSender(HttpClient client) : IApplicationDelegationSender
    {
        internal HttpClient Client = client;
        internal int Calls;
        internal bool DenyAtDestination;
        internal string? DestinationIdentity, DestinationToken;
        public async Task<HttpResponseMessage> SendAsync(DelegatedIdentity identity, string application,
            string grant, HttpRequestMessage request, CancellationToken ct)
        {
            Calls++;
            Assert.Null(request.Headers.Authorization);
            var principal = Principal(identity.Subject, identity.TenantId, DenyAtDestination ? "denied" : grant, identity.ClientId);
            DestinationToken = Token(principal, audience: "https://sample.test/", key: DestinationKey);
            DestinationIdentity = identity.Subject + ":" + identity.TenantId;
            request.Headers.Authorization = new("Bearer", DestinationToken);
            return await Client.SendAsync(request, ct);
        }
    }
}
