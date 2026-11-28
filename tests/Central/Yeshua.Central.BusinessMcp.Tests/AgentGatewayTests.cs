using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Central.AgentOAuth;
using Microsoft.IdentityModel.Tokens;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class GatewayFactAttribute : FactAttribute
{
    public GatewayFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("YESHUA_TEST_NGINX")))
            Skip = "Set YESHUA_TEST_NGINX to an isolated local Nginx executable to run real TLS/gateway checks.";
    }
}

public sealed partial class AgentOAuthFlowTests
{
    [GatewayFact]
    public async Task GatewayPreservesCorrelationAuthorizationPrefixAndOverwritesSpoofedScheme()
    {
        await using var host = await Host.Start(); using var client = host.Client();
        client.DefaultRequestHeaders.Add("X-Forwarded-Proto", "http");
        client.DefaultRequestHeaders.Add("X-Forwarded-Host", "evil.test");
        client.DefaultRequestHeaders.Add("X-Correlation-ID", "synthetic-gateway-76");
        client.DefaultRequestHeaders.Add("traceparent", "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01");
        client.DefaultRequestHeaders.Authorization = new("Bearer", OwnerToken());
        var probe = Json(await client.GetStringAsync("/apps/central/yapi/gateway-probe"));
        Assert.Equal("https", probe.GetProperty("scheme").GetString());
        Assert.Equal("central.test", probe.GetProperty("host").GetString());
        Assert.Equal("/apps/central/yapi", probe.GetProperty("forwardedPrefix").GetString());
        Assert.Equal("synthetic-gateway-76", probe.GetProperty("correlation").GetString());
        Assert.Equal("00-0123456789abcdef0123456789abcdef-0123456789abcdef-01", probe.GetProperty("traceparent").GetString());
        Assert.True(probe.GetProperty("authorizationPresent").GetBoolean());
        var metadata = Json(await client.GetStringAsync("/.well-known/oauth-authorization-server"));
        Assert.Equal(Issuer, metadata.GetProperty("issuer").GetString());
        using var plain = host.Gateway!.Client(tls: false);
        plain.DefaultRequestHeaders.Add("X-Forwarded-Proto", "https");
        using var rejected = await plain.GetAsync("/oauth/authorize?" + Query(Authorization()));
        Assert.Equal(HttpStatusCode.BadRequest, rejected.StatusCode);
        Assert.Equal(0, host.Identity.LoginCalls);
        // An empty allowlist must not become ASP.NET's 'trust all proxies' mode.
        foreach (var trustedProxy in new string?[] { null, "192.0.2.10" })
        {
            await using var untrusted = await Host.Start(trustedProxy: trustedProxy);
            using var spoof = untrusted.Client();
            spoof.DefaultRequestHeaders.Add("X-Forwarded-Proto", "https");
            using var response = await spoof.GetAsync("/oauth/authorize?" + Query(Authorization()));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

    [GatewayFact]
    public async Task GatewayCarriesLargeSignedSelfContainedTokenAndKeepsAdministrativeSessionSeparate()
    {
        await using var host = await Host.Start(); using var client = host.Client();
        using var rsa = RSA.Create(); rsa.ImportFromPem(SigningPem);
        var jwt = new JwtSecurityToken(Issuer, Resource,
            [new("sub", "17"), new("tenantId", "7"), new("client_id", "test-agent"), new("delegation_id", "synthetic"),
             new("token_kind", "delegated"), new("delegation_kind", "external_agent"), new("synthetic_padding", new string('x', 16000))],
            DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow.AddMinutes(5), new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256));
        jwt.Header["typ"] = "at+jwt";
        var access = new JwtSecurityTokenHandler().WriteToken(jwt);
        Assert.InRange(Encoding.UTF8.GetByteCount(access), 20000, 30000);
        client.DefaultRequestHeaders.Authorization = new("Bearer", access);
        using var accepted = await client.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.OK, accepted.StatusCode);
        using var administrative = await client.GetAsync("/apps/central/yapi/agents/grants");
        Assert.Equal(HttpStatusCode.Unauthorized, administrative.StatusCode);
        client.DefaultRequestHeaders.Authorization = new("Bearer", OwnerToken());
        using var owner = await client.GetAsync("/apps/central/yapi/agents/grants");
        Assert.Equal(HttpStatusCode.OK, owner.StatusCode);
        using var conventionalAtMcp = await client.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.Unauthorized, conventionalAtMcp.StatusCode);
        client.DefaultRequestHeaders.Authorization = new("Bearer", new string('x', 40000));
        using var oversized = await client.GetAsync("/business/mcp");
        Assert.Contains(oversized.StatusCode, new[] { HttpStatusCode.BadRequest, HttpStatusCode.RequestHeaderFieldsTooLarge });
    }

    [Fact]
    public async Task ProtocolRevocationEndpointDeniesRenewalAndMcpRejectsInvalidSyntheticCommandsBeforeDelivery()
    {
        await using var host = await Host.Start(mcp: true, executableFixture: true);
        using var browser = host.Client(); using var consent = await host.Consent(browser, Authorization());
        var token = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        using var http = host.Client(); http.DefaultRequestHeaders.Authorization = new("Bearer", token.GetProperty("access_token").GetString());
        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
            { Endpoint = new Uri(Resource), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        foreach (var args in new Dictionary<string, object?>[] {
            new() { ["application"] = "Central", ["operation"] = "Sample.Commands.Execute", ["parameters"] = new { quantity = -1 } },
            new() { ["application"] = "Central", ["operation"] = "Internal.Commands.Admin", ["parameters"] = new { } },
            new() { ["application"] = "Clinica", ["operation"] = "Sample.Commands.Execute", ["parameters"] = new { } },
            new() { ["application"] = "Central", ["operation"] = "Sample.Commands.Execute", ["parameters"] = new { tenantId = 8, quantity = 2 } }
        }) Assert.True((await mcp.CallToolAsync("yeshua_business_execute", args)).IsError);
        Assert.Equal(0, host.Destination.Calls);
        using var client = host.Client();
        using var revoked = await client.PostAsync("/oauth/revoke", new FormUrlEncodedContent(new Dictionary<string, string> {
            ["client_id"] = "test-agent", ["token"] = token.GetProperty("refresh_token").GetString()!, ["token_type_hint"] = "refresh_token" }));
        Assert.Equal(HttpStatusCode.OK, revoked.StatusCode);
        Assert.Equal("invalid_grant", (await host.Refresh(token.GetProperty("refresh_token").GetString()!)).GetProperty("error").GetString());
    }

    [Theory]
    [InlineData("wrong@example.test", "synthetic-password")]
    [InlineData("owner@example.test", "wrong-password")]
    public async Task WrongLoginCannotProduceAuthorizationCode(string username, string password)
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var denied = await host.Consent(browser, Authorization(), username: username, password: password);
        var result = DecodeQuery(denied.Headers.Location!);
        Assert.Equal("access_denied", result["error"]);
        Assert.False(result.ContainsKey("code"));
        Assert.Equal(1, host.Identity.LoginCalls); Assert.Equal(0, host.Identity.ResolveCalls);
    }

    [Theory]
    [InlineData("timeout")]
    [InlineData("signature")]
    [InlineData("expired")]
    [InlineData("multiple")]
    public async Task InvalidDestinationPreparationReturnsProtocolErrorWithoutEmittingToken(string failure)
    {
        await using var host = await Host.Start(mcp: true, executableFixture: true, fixtureApplication: "Clinica");
        host.Destination.SessionFailure = failure;
        var fields = Authorization(); fields["scope"] = "business:discover application:Clinica offline_access";
        using var browser = host.Client(); using var consent = await host.Consent(browser, fields);
        var result = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        Assert.Equal("invalid_grant", result.GetProperty("error").GetString());
        Assert.False(result.TryGetProperty("access_token", out _));
        Assert.Equal(0, host.Destination.Calls);
    }

    [Theory]
    [InlineData("null")]
    [InlineData("\"\"")]
    [InlineData("\" \"")]
    public async Task MalformedRevokeDoesNotThrowOrTouchOtherGrants(string value)
    {
        await using var host = await Host.Start(); using var owner = host.Client();
        owner.DefaultRequestHeaders.Authorization = new("Bearer", OwnerToken());
        using var response = await owner.PostAsync("/yapi/agents/revoke", new StringContent("{\"authorizationId\":" + value + "}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
