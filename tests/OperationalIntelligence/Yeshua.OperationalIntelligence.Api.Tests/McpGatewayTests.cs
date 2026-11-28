using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ModelContextProtocol.Client;
using Yeshua.Central.BusinessMcp.Tests;

namespace Yeshua.OperationalIntelligence.Api.Tests;

public sealed partial class McpCompatibilityTests
{
    [TestMethod]
    public async Task NginxPublicRouteCannotPromoteBearerOrForwardedHeadersToAdministrativeMcp()
    {
        var binary = Environment.GetEnvironmentVariable("YESHUA_TEST_NGINX");
        if (string.IsNullOrWhiteSpace(binary)) Assert.Inconclusive("Set YESHUA_TEST_NGINX for the isolated TLS gateway test.");
        await using var host = await McpHost.StartAsync();
        var upstream = new Uri(host.PublicUrl).GetLeftPart(UriPartial.Authority);
        await using var gateway = await IsolatedNginxGateway.Start(binary!, upstream, upstream);
        using var http = gateway.Client();
        // Signed synthetic external-agent-shaped bearer. Operational MCP does not
        // authenticate OAuth bearers; its existing private listener policy decides.
        using var rsa = RSA.Create(2048);
        static string B64(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        var header = B64(Encoding.UTF8.GetBytes("{\"alg\":\"RS256\",\"typ\":\"at+jwt\"}"));
        var payload = B64(JsonSerializer.SerializeToUtf8Bytes(new { iss = "https://central.test/", aud = "https://central.test/business/mcp",
            sub = "17", tenantId = "7", client_id = "synthetic-agent", token_kind = "delegated", delegation_kind = "external_agent",
            exp = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds() }));
        var token = header + "." + payload;
        token += "." + B64(rsa.SignData(Encoding.ASCII.GetBytes(token), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        http.DefaultRequestHeaders.Add("X-Forwarded-For", "127.0.0.1");
        http.DefaultRequestHeaders.Add("X-Forwarded-Proto", "https");
        http.DefaultRequestHeaders.Add("X-Forwarded-Host", "localhost");
        await using var client = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
            { Endpoint = new Uri("https://central.test/operational/mcp"), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        CollectionAssert.AreEquivalent(new[] { "yeshua_health" }, (await client.ListToolsAsync()).Select(t => t.Name).ToArray());
        var denied = await client.CallToolAsync("yeshua_task_send", new Dictionary<string, object?> { ["requestId"] = "synthetic-gateway-denied", ["message"] = "synthetic" });
        Assert.AreEqual(true, denied.IsError);
        Assert.AreEqual(0, host.Repository.AcceptedCount);
        await using var privateClient = await ConnectAsync(host.PrivateUrl);
        Assert.IsTrue((await privateClient.ListToolsAsync()).Any(t => t.Name == "yeshua_task_send"));
    }
}
