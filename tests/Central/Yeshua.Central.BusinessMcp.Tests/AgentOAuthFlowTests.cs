using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Central.AgentOAuth;
using Central.BusinessMcp;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using Central.Repository.AgentOAuth;
using Command.UseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class AgentOAuthFlowTests
{
    private const string Issuer = "https://central.test/";
    private const string Resource = "https://central.test/business/mcp";
    private const string Root = "synthetic-issue76-only-test-root-longer-than-32-bytes";
    private static readonly string SigningPem = RSA.Create(2048).ExportPkcs8PrivateKeyPem();
    private const string Callback = "https://agent.test/callback";
    private static readonly string Verifier = Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(32));
    private static string Challenge => Base64UrlEncoder.Encode(SHA256.HashData(Encoding.ASCII.GetBytes(Verifier)));
    private static JsonElement Json(string input) => JsonDocument.Parse(input).RootElement.Clone();
    private static Dictionary<string, string> Authorization(string? challenge = null) => new()
    {
        ["client_id"] = "test-agent", ["redirect_uri"] = Callback, ["response_type"] = "code",
        ["scope"] = "business:discover application:Central offline_access", ["resource"] = Resource,
        ["code_challenge"] = challenge ?? Challenge, ["code_challenge_method"] = "S256", ["state"] = "synthetic-state"
    };
    private static string Query(IDictionary<string, string> values) => string.Join('&', values.Select(p => Uri.EscapeDataString(p.Key) + "=" + Uri.EscapeDataString(p.Value)));

    [Fact]
    public async Task AuthorizationCodePkceRefreshRotationAndOwnerRevocationWorkWithPersistentProtocolStore()
    {
        await using var host = await Host.Start();
        using var browser = host.Client();
        var authorization = Authorization();
        using var approved = await host.Consent(browser, authorization);
        Assert.Equal(HttpStatusCode.Redirect, approved.StatusCode);
        var callback = approved.Headers.Location!.OriginalString;
        Assert.Contains("state=synthetic-state", callback);
        Assert.Contains("iss=", callback);
        var code = DecodeQuery(approved.Headers.Location!).GetValueOrDefault("code");
        Assert.False(string.IsNullOrWhiteSpace(code));
        var tokens = await host.Exchange(code!);
        Assert.True(tokens.TryGetProperty("access_token", out var access), tokens.GetRawText());
        Assert.InRange(tokens.GetProperty("expires_in").GetInt32(), 295, 300);
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(access.GetString());
        Assert.Equal(Resource, Assert.Single(jwt.Audiences));
        Assert.Equal("17", jwt.Subject);
        Assert.Equal("7", jwt.Claims.Single(c => c.Type == "tenantId").Value);
        Assert.Equal("test-agent", jwt.Claims.Single(c => c.Type == "client_id").Value);
        Assert.DoesNotContain(jwt.Claims, c => c.Type is "email" or "userName" or "tenantName" or "role");
        browser.DefaultRequestHeaders.Authorization = new("Bearer", access.GetString());
        using var delegated = await browser.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.OK, delegated.StatusCode);
        var renew = await host.Refresh(tokens.GetProperty("refresh_token").GetString()!);
        Assert.True(renew.TryGetProperty("refresh_token", out _), renew.GetRawText());
        Assert.NotEqual(tokens.GetProperty("refresh_token").GetString(), renew.GetProperty("refresh_token").GetString());
        var grant = jwt.Claims.Single(c => c.Type == "delegation_id").Value;
        using var owner = host.Client();
        owner.DefaultRequestHeaders.Authorization = new("Bearer", OwnerToken());
        using var revoked = await owner.PostAsync("/yapi/agents/revoke", new StringContent(JsonSerializer.Serialize(new { authorizationId = grant }), Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.NoContent, revoked.StatusCode);
        var rejected = await host.Refresh(renew.GetProperty("refresh_token").GetString()!);
        Assert.Equal("invalid_grant", rejected.GetProperty("error").GetString());
        using var residual = await browser.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.OK, residual.StatusCode); // Explicit five-minute residual window.
        Assert.True(host.Identity.ResolveCalls >= 2);
        using var scope = host.App.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AgentOAuthDbContext>();
        Assert.True(await db.Database.CanConnectAsync());
    }
    [Fact]
    public async Task OAuthIssuedTokenConnectsToTheExistingOfficialBusinessMcpTransport()
    {
        await using var host = await Host.Start(mcp: true); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var tokens = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        using var http = host.Client();
        http.DefaultRequestHeaders.Authorization = new("Bearer", tokens.GetProperty("access_token").GetString());
        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
            { Endpoint = new Uri(Resource), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        Assert.Equal(3, (await mcp.ListToolsAsync()).Count);
        var discovery = await mcp.CallToolAsync("yeshua_business_applications", new Dictionary<string, object?>());
        Assert.False(discovery.IsError ?? false);
        Assert.Equal("[]", ((TextContentBlock)discovery.Content[0]).Text);
    }
    [Fact]
    public async Task OAuthToOfficialMcpToApplicationAdapterReauthorizesWithDistinctCredential()
    {
        await using var host = await Host.Start(mcp: true, executableFixture: true); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var tokens = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        using var http = host.Client();
        http.DefaultRequestHeaders.Authorization = new("Bearer", tokens.GetProperty("access_token").GetString());
        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
            { Endpoint = new Uri(Resource), TransportMode = HttpTransportMode.StreamableHttp }, http, ownsHttpClient: false));
        var arguments = new Dictionary<string, object?> { ["application"] = "Central", ["operation"] = "Sample.Commands.Execute",
            ["parameters"] = new { quantity = 2, items = new[] { new { kind = "A" } } } };
        var result = await mcp.CallToolAsync("yeshua_business_execute", arguments);
        Assert.False(result.IsError ?? false);
        Assert.Contains("completed", ((TextContentBlock)result.Content[0]).Text);
        host.Destination.Allowed = false;
        result = await mcp.CallToolAsync("yeshua_business_execute", arguments);
        Assert.True(result.IsError);
        Assert.Contains("destination_denied", ((TextContentBlock)result.Content[0]).Text);
        Assert.Equal(2, host.Destination.Calls);
        Assert.Equal(2, host.Identity.ResolveCalls); // Issuance + once for the app session, no permission query per operation.
    }
    [Theory]
    [InlineData("wrong-verifier")]
    [InlineData("wrong-resource")]
    [InlineData("wrong-client")]
    [InlineData("wrong-redirect")]
    public async Task CodeIsBoundToPkceClientResourceAndRedirect(string scenario)
    {
        await using var host = await Host.Start();
        using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var code = DecodeQuery(consent.Headers.Location!).GetValueOrDefault("code");
        var fields = host.ExchangeFields(code!);
        switch (scenario)
        {
            case "wrong-verifier": fields["code_verifier"] = new string('a', 43); break;
            case "wrong-resource": fields["resource"] = "https://evil.test/mcp"; break;
            case "wrong-client": fields["client_id"] = "different-agent"; break;
            case "wrong-redirect": fields["redirect_uri"] = "https://evil.test/callback"; break;
        }
        var result = await host.PostToken(fields);
        Assert.True(result.TryGetProperty("error", out _), result.GetRawText());
        Assert.False(result.TryGetProperty("access_token", out _));
    }
    [Fact]
    public async Task OldRefreshAndAuthorizationCodesCannotBeReused()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var code = DecodeQuery(consent.Headers.Location!)["code"];
        var tokens = await host.Exchange(code);
        Assert.Equal("invalid_grant", (await host.Exchange(code)).GetProperty("error").GetString());
        // Independent grant: replaying a code may revoke its token chain.
        using var consent2 = await host.Consent(browser, Authorization());
        var tokens2 = await host.Exchange(DecodeQuery(consent2.Headers.Location!)["code"]);
        var refresh = tokens2.GetProperty("refresh_token").GetString()!;
        var renewed = await host.Refresh(refresh);
        Assert.True(renewed.TryGetProperty("access_token", out _), renewed.GetRawText());
        Assert.Equal("invalid_grant", (await host.Refresh(refresh)).GetProperty("error").GetString());
    }
    [Fact]
    public async Task CurrentAccessRemovalPreventsRefreshAndDoesNotCreateAnotherUser()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var tokens = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        host.Identity.Catalogs = [];
        Assert.Equal("invalid_grant", (await host.Refresh(tokens.GetProperty("refresh_token").GetString()!)).GetProperty("error").GetString());
        Assert.Equal(1, host.Identity.LoginCalls);
    }
    [Theory]
    [InlineData("pkce-plain")]
    [InlineData("missing-resource")]
    [InlineData("unknown-scope")]
    [InlineData("unknown-redirect")]
    public async Task InvalidAuthorizationNeverAuthenticatesOwner(string scenario)
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        var fields = Authorization();
        switch (scenario)
        {
            case "pkce-plain": fields["code_challenge_method"] = "plain"; break;
            case "missing-resource": fields.Remove("resource"); break;
            case "unknown-scope": fields["scope"] = "admin"; break;
            case "unknown-redirect": fields["redirect_uri"] = "https://evil.test/callback"; break;
        }
        using var result = await browser.GetAsync("/oauth/authorize?" + Query(fields));
        Assert.NotEqual(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(0, host.Identity.LoginCalls);
    }
    [Fact]
    public async Task ConsentRequiresCsrfAndExplicitDecision()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        var fields = Authorization(); fields["username"] = "owner@example.test"; fields["password"] = "synthetic-password"; fields["decision"] = "allow";
        using var badCsrf = await browser.PostAsync("/oauth/authorize", new FormUrlEncodedContent(fields));
        Assert.Equal(HttpStatusCode.BadRequest, badCsrf.StatusCode);
        Assert.Equal(0, host.Identity.LoginCalls);
        using var denied = await host.Consent(browser, Authorization(), "deny");
        Assert.Equal("access_denied", DecodeQuery(denied.Headers.Location!)["error"]);
        Assert.Equal(0, host.Identity.LoginCalls);
    }
    [Theory]
    [InlineData(18, 7)]
    [InlineData(17, 8)]
    public async Task AnotherOwnerOrTenantCannotRevokeConsent(int owner, int tenant)
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var tokens = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(tokens.GetProperty("access_token").GetString());
        var grant = jwt.Claims.Single(c => c.Type == "delegation_id").Value;
        browser.DefaultRequestHeaders.Authorization = new("Bearer", OwnerToken(owner, tenant));
        using var rejected = await browser.PostAsync("/yapi/agents/revoke", new StringContent(JsonSerializer.Serialize(new { authorizationId = grant }), Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.NotFound, rejected.StatusCode);
        Assert.True((await host.Refresh(tokens.GetProperty("refresh_token").GetString()!)).TryGetProperty("access_token", out _));
    }
    [Fact]
    public async Task ConsentCannotGrantAnApplicationTheOwnerDoesNotHave()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        host.Identity.Catalogs = ["Central"];
        var fields = Authorization(); fields["scope"] += " application:Clinica";
        using var denied = await host.Consent(browser, fields);
        Assert.Equal("access_denied", DecodeQuery(denied.Headers.Location!)["error"]);
    }
    [Fact]
    public async Task CodeCannotBeRedeemedAfterItsOwnerChangesTenant()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        host.Identity.Tenant = 8;
        Assert.Equal("invalid_grant", (await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"])).GetProperty("error").GetString());
    }
    [Fact]
    public async Task ProtocolPersistenceSurvivesRestartAndDoesNotStoreClientTokensOrPasswordInCleartext()
    {
        var path = Path.Combine(Path.GetTempPath(), "yeshua-agent-oauth-" + Guid.NewGuid().ToString("N") + ".db");
        string refresh;
        try
        {
            await using (var first = await Host.Start(databasePath: path))
            {
                using var browser = first.Client(); using var consent = await first.Consent(browser, Authorization());
                var tokens = await first.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
                refresh = tokens.GetProperty("refresh_token").GetString()!;
                using var scope = first.App.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AgentOAuthDbContext>();
                var stored = await db.Set<OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreToken>().AsNoTracking().ToListAsync();
                var json = JsonSerializer.Serialize(stored.Select(t => new { t.Payload, t.ReferenceId }));
                Assert.DoesNotContain(refresh, json);
                Assert.DoesNotContain("synthetic-password", json);
                Assert.DoesNotContain("owner@example.test", json);
            }
            await using var second = await Host.Start(databasePath: path);
            Assert.True((await second.Refresh(refresh)).TryGetProperty("access_token", out _));
        }
        finally { SqliteConnection.ClearAllPools(); if (File.Exists(path)) File.Delete(path); }
    }
    [Fact]
    public async Task RefreshCannotExpandTheScopesOfConsent()
    {
        await using var host = await Host.Start(); using var browser = host.Client();
        using var consent = await host.Consent(browser, Authorization());
        var tokens = await host.Exchange(DecodeQuery(consent.Headers.Location!)["code"]);
        var result = await host.PostToken(new() { ["grant_type"] = "refresh_token", ["client_id"] = "test-agent",
            ["refresh_token"] = tokens.GetProperty("refresh_token").GetString()!, ["resource"] = Resource,
            ["scope"] = "business:discover application:Central application:Clinica offline_access" });
        Assert.True(result.TryGetProperty("error", out _));
    }
    [Theory]
    [InlineData("expired")]
    [InlineData("audience")]
    [InlineData("type")]
    public async Task ResourceRejectsExpiredTokensOtherAudiencesAndNonAccessTokens(string scenario)
    {
        await using var host = await Host.Start(); using var client = host.Client();
        using var rsa = RSA.Create(); rsa.ImportFromPem(SigningPem);
        var claims = new Claim[] { new("sub", "17"), new("tenantId", "7"), new("client_id", "test-agent"), new("delegation_id", "synthetic"), new("token_kind", "delegated"), new("delegation_kind", "external_agent") };
        var jwt = new JwtSecurityToken(Issuer, scenario == "audience" ? "https://other.test/mcp" : Resource, claims,
            DateTime.UtcNow.AddMinutes(-10), scenario == "expired" ? DateTime.UtcNow.AddMinutes(-1) : DateTime.UtcNow.AddMinutes(5),
            new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256));
        jwt.Header["typ"] = scenario == "type" ? "JWT" : "at+jwt";
        client.DefaultRequestHeaders.Authorization = new("Bearer", new JwtSecurityTokenHandler().WriteToken(jwt));
        using var response = await client.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    [Fact]
    public void SqlServerDdlContainsOnlyTheFourProtocolTables()
    {
        var builder = new DbContextOptionsBuilder<AgentOAuthDbContext>();
        builder.UseSqlServer("Server=synthetic-never-connected;Database=Central;Integrated Security=true;TrustServerCertificate=true").UseOpenIddict();
        using var context = new AgentOAuthDbContext(builder.Options);
        var script = context.Database.GenerateCreateScript();
        foreach (var table in new[] { "OpenIddictApplications", "OpenIddictAuthorizations", "OpenIddictScopes", "OpenIddictTokens" }) Assert.Contains(table, script);
        Assert.DoesNotContain("CREATE TABLE [yUser]", script);
        Assert.DoesNotContain("DROP TABLE", script);
    }
    [Fact]
    public async Task DiscoveryAndChallengesUseFixedIssuerAndResource()
    {
        await using var host = await Host.Start(); using var client = host.Client();
        var metadata = Json(await client.GetStringAsync("/.well-known/oauth-authorization-server"));
        Assert.Equal(Issuer, metadata.GetProperty("issuer").GetString());
        Assert.Contains("S256", metadata.GetProperty("code_challenge_methods_supported").GetRawText());
        var keys = Json(await client.GetStringAsync(metadata.GetProperty("jwks_uri").GetString()));
        var key = keys.GetProperty("keys")[0];
        Assert.Equal("RSA", key.GetProperty("kty").GetString());
        Assert.False(key.TryGetProperty("d", out _));
        var resource = Json(await client.GetStringAsync("/.well-known/oauth-protected-resource/business/mcp"));
        Assert.Equal(Resource, resource.GetProperty("resource").GetString());
        using var rejected = await client.GetAsync("/business/mcp");
        Assert.Equal(HttpStatusCode.Unauthorized, rejected.StatusCode);
        Assert.Contains("resource_metadata", rejected.Headers.WwwAuthenticate.ToString());
    }
    private static Dictionary<string, string> DecodeQuery(Uri uri) => uri.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries)
        .Select(part => part.Split('=', 2)).ToDictionary(p => Uri.UnescapeDataString(p[0]), p => Uri.UnescapeDataString(p.ElementAtOrDefault(1) ?? ""));
    private static string OwnerToken(int owner = 17, int tenant = 7) => new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
        claims: [new(ClaimTypes.NameIdentifier, owner.ToString()), new("tenantId", tenant.ToString()), new("tokenOrigin", "Central"), new("application", "Central")],
        expires: DateTime.UtcNow.AddMinutes(5), signingCredentials: new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)), SecurityAlgorithms.HmacSha256)));
    private sealed class Destination : HttpMessageHandler
    {
        public int Calls; public bool Allowed = true;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            Calls++;
            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(request.Headers.Authorization!.Parameter!, new TokenValidationParameters
            { ValidateIssuer = false, ValidateAudience = true, ValidAudience = "https://destination.test", ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)) }, out _);
            Assert.Equal("17", principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Assert.Equal("17", principal.FindFirst("owner_sub")?.Value);
            Assert.Equal("7", principal.FindFirst("tenantId")?.Value);
            Assert.Equal("Central", principal.FindFirst("application")?.Value);
            Assert.Equal("test-agent", principal.FindFirst("client_id")?.Value);
            Assert.DoesNotContain(principal.Claims, c => c.Type == ClaimTypes.Role);
            return Task.FromResult(new HttpResponseMessage(Allowed ? HttpStatusCode.OK : HttpStatusCode.Forbidden)
                { Content = new StringContent("{\"ok\":true}", Encoding.UTF8, "application/json") });
        }
    }
    private sealed class Identity : ICentralAgentIdentity
    {
        public int LoginCalls, ResolveCalls;
        public int Tenant = 7;
        public List<string> Catalogs = ["Central", "Clinica"];
        public Task<LoginOutputCommand?> LoginAsync(string username, string password, CancellationToken ct)
        { LoginCalls++; return Task.FromResult(username == "owner@example.test" && password == "synthetic-password" ? Snapshot() : null); }
        public Task<LoginOutputCommand?> ResolveAsync(int owner, int tenant, CancellationToken ct)
        { ResolveCalls++; return Task.FromResult(owner == 17 && tenant == Tenant ? Snapshot() : null); }
        private LoginOutputCommand Snapshot() => new() { UserId = 17, tenantId = 7, catalogos = Catalogs, modulos = [], email = "owner@example.test", userName = "Synthetic" };
    }
    private sealed class Host(WebApplication app, SqliteConnection connection, Identity identity, Destination destination) : IAsyncDisposable
    {
        public WebApplication App = app; public Identity Identity = identity; public Destination Destination = destination;
        public HttpClient Client() { var client = App.GetTestClient(); client.BaseAddress = new Uri(Issuer); return client; }
        public static async Task<Host> Start(bool mcp = false, string? databasePath = null, bool executableFixture = false)
        {
            var connection = new SqliteConnection("Data Source=" + (databasePath ?? ":memory:")); await connection.OpenAsync();
            var builder = WebApplication.CreateBuilder(); builder.WebHost.UseTestServer(); builder.Logging.ClearProviders();
            var options = new AgentOAuthOptions { Enabled = true, Issuer = Issuer, Resource = Resource, SigningPrivateKeyPem = SigningPem,
                Clients = [new() { ClientId = "test-agent", DisplayName = "Synthetic agent", RedirectUris = [Callback], Applications = ["Central", "Clinica"] }] };
            builder.Services.AddCentralAgentOAuth(options, Root, db => db.UseSqlite(connection));
            builder.Services.AddSingleton(new JwtSettings { SecretKey = Root });
            if (mcp)
            {
                var catalogue = executableFixture ? new TrustedBusinessCatalog([new("Central", new Uri("https://destination.test/"),
                    Json(BusinessMcpTests.Document), [new("Sample.Commands.Execute", "existing-domain-policy", "application:Central")])]) : new TrustedBusinessCatalog([]);
                builder.Services.AddCentralBusinessMcp(new(new Uri(Resource), new Uri(Issuer)), catalogue);
            }
            var destination = new Destination();
            if (executableFixture) builder.Services.AddScoped<IApplicationDelegationSender>(sp => new AgentApplicationSender(new HttpClient(destination),
                sp.GetRequiredService<ICentralAgentIdentity>(), sp.GetRequiredService<IMemoryCache>(), sp.GetRequiredService<JwtSettings>()));
            var identity = new Identity(); builder.Services.AddSingleton<ICentralAgentIdentity>(identity);
            builder.Services.AddAuthentication("conventional").AddJwtBearer("conventional", bearer => bearer.TokenValidationParameters = new()
            { ValidateIssuer = false, ValidateAudience = false, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)) });
            var app = builder.Build();
            using (var scope = app.Services.CreateScope()) await scope.ServiceProvider.GetRequiredService<AgentOAuthDbContext>().Database.EnsureCreatedAsync();
            await AgentOAuthRegistration.ProvisionClientsAsync(app.Services);
            app.UseAuthentication(); app.UseAuthorization(); app.MapCentralAgentOAuth();
            if (mcp) app.MapCentralBusinessMcp();
            else app.MapGet("/business/mcp", (HttpContext http) => Results.Json(new { owner = http.User.FindFirst("sub")?.Value,
                tenant = http.User.FindFirst("tenantId")?.Value, client = http.User.FindFirst("client_id")?.Value }))
                .RequireAuthorization(AgentOAuthOptions.ResourcePolicy);
            await app.StartAsync(); return new(app, connection, identity, destination);
        }
        public async Task<HttpResponseMessage> Consent(HttpClient client, Dictionary<string, string> fields, string decision = "allow")
        {
            using var page = await client.GetAsync("/oauth/authorize?" + Query(fields));
            var html = await page.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, page.StatusCode);
            var csrf = Regex.Match(html, "name=\"__RequestVerificationToken\" value=\"([^\"]+)\"").Groups[1].Value;
            Assert.False(string.IsNullOrEmpty(csrf), html);
            if (page.Headers.TryGetValues("Set-Cookie", out var cookies))
            {
                client.DefaultRequestHeaders.Remove("Cookie");
                client.DefaultRequestHeaders.Add("Cookie", cookies.First().Split(';')[0]);
            }
            var form = new Dictionary<string, string>(fields) { ["__RequestVerificationToken"] = WebUtility.HtmlDecode(csrf),
                ["username"] = "owner@example.test", ["password"] = "synthetic-password", ["decision"] = decision };
            return await client.PostAsync("/oauth/authorize", new FormUrlEncodedContent(form));
        }
        public Dictionary<string, string> ExchangeFields(string code) => new() { ["grant_type"] = "authorization_code", ["client_id"] = "test-agent",
            ["code"] = code, ["redirect_uri"] = Callback, ["code_verifier"] = Verifier, ["resource"] = Resource };
        public Task<JsonElement> Exchange(string code) => PostToken(ExchangeFields(code));
        public Task<JsonElement> Refresh(string refresh) => PostToken(new() { ["grant_type"] = "refresh_token", ["client_id"] = "test-agent", ["refresh_token"] = refresh, ["resource"] = Resource });
        public async Task<JsonElement> PostToken(Dictionary<string, string> fields)
        { using var client = Client(); using var response = await client.PostAsync("/oauth/token", new FormUrlEncodedContent(fields)); return Json(await response.Content.ReadAsStringAsync()); }
        public async ValueTask DisposeAsync() { await App.DisposeAsync(); await connection.DisposeAsync(); }
    }
}
