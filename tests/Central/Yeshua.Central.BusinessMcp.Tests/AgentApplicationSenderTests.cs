using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Central.AgentOAuth;
using Central.BusinessMcp;
using Command.UseCase;
using Microsoft.IdentityModel.Tokens;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class AgentApplicationSenderTests
{
    private const string Root = "synthetic-destination-test-root-at-least-32-bytes";
    private static AgentOAuthOptions Options() => new() { Issuer = "https://central.test/", Resource = "https://central.test/business/mcp" };
    private static TrustedBusinessCatalog Catalog() => new([new("Clinica", new Uri("https://clinica.test/"),
        JsonDocument.Parse(BusinessMcpTests.Document).RootElement.Clone(), [new("Sample.Commands.Execute", "existing", "application:Clinica")])]);
    private static LoginOutputCommand Owner() => new() { UserId = 17, tenantId = 7, catalogos = ["Clinica"], modulos = [], email = "owner@example.test" };
    private static AgentApplicationCredentials Codec(TimeProvider? clock = null) => new(Options(), new JwtSettings { SecretKey = Root }, clock ?? TimeProvider.System);
    private static DelegatedIdentity Identity(string? snapshot, IReadOnlySet<string>? scopes = null)
    {
        var claims = new List<Claim> { new("sub", "17"), new("tenantId", "7"), new("client_id", "agent"), new("delegation_id", "grant"),
            new("exp", DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds().ToString()) };
        if (snapshot is not null) claims.Add(new(AgentApplicationCredentials.ClaimType, snapshot));
        return new("17", 7, "agent", "grant", scopes ?? new HashSet<string>(["application:Clinica"]))
            { Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "verified")) };
    }
    [Fact]
    public async Task SessionExchangeHappensOnlyDuringIssuanceAndWorksWithoutCacheAfterRestart()
    {
        using var handler = new Destination(); using var http = new HttpClient(handler);
        var codec = Codec();
        var preparer = new AgentApplicationPreparation(http, Catalog(), codec, new JwtSettings { SecretKey = Root }, TimeProvider.System);
        var prepared = await preparer.PrepareAsync(Owner(), "agent", "grant", new HashSet<string>(["application:Clinica"]), default);
        Assert.Equal(1, handler.Exchanges);
        handler.AllowExchange = false;
        var identity = Identity(prepared.ProtectedValue);
        var sender = new AgentApplicationSender(http, codec);
        using var first = await sender.SendAsync(identity, "Clinica", "existing", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default);
        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        handler.AllowOperation = false;
        using var denied = await sender.SendAsync(identity, "Clinica", "existing", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default);
        Assert.Equal(HttpStatusCode.Forbidden, denied.StatusCode);
        // A new instance has no session cache or identity/permission repository.
        var restarted = new AgentApplicationSender(http, Codec());
        using var again = await restarted.SendAsync(identity, "Clinica", "existing", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default);
        Assert.Equal(HttpStatusCode.Forbidden, again.StatusCode);
        Assert.Equal(1, handler.Exchanges); Assert.Equal(3, handler.Commands);
        Assert.DoesNotContain("owner@example.test", prepared.ProtectedValue);
    }
    [Theory]
    [InlineData("missing-scope")]
    [InlineData("missing-snapshot")]
    [InlineData("tenant")]
    [InlineData("owner")]
    [InlineData("client")]
    [InlineData("grant")]
    [InlineData("origin")]
    [InlineData("application")]
    [InlineData("tampered")]
    public async Task InvalidSnapshotsNeverFetchIdentityOpenSessionOrDeliverCommand(string scenario)
    {
        using var handler = new Destination { AllowExchange = false }; using var http = new HttpClient(handler);
        var codec = Codec();
        var prepared = codec.Protect("17", 7, "agent", "grant",
            [new("Clinica", "https://clinica.test", "synthetic-not-a-live-bearer", DateTimeOffset.UtcNow.AddMinutes(5))], DateTimeOffset.UtcNow.AddMinutes(5));
        var identity = Identity(prepared.ProtectedValue);
        var application = "Clinica"; var origin = "https://clinica.test";
        identity = scenario switch
        {
            "missing-scope" => Identity(prepared.ProtectedValue, new HashSet<string>()),
            "missing-snapshot" => Identity(null),
            "tenant" => identity with { TenantId = 8 },
            "owner" => identity with { Subject = "18" },
            "client" => identity with { ClientId = "another-agent" },
            "grant" => identity with { DelegationId = "another-grant" },
            "tampered" => Identity(prepared.ProtectedValue[..^8] + "tampered"),
            _ => identity
        };
        if (scenario == "origin") origin = "https://other.test";
        if (scenario == "application") { application = "Fiscal"; identity = identity with { Scopes = new HashSet<string>(["application:Fiscal"]) }; }
        var sender = new AgentApplicationSender(http, codec);
        await Assert.ThrowsAsync<BusinessAccessException>(() => sender.SendAsync(identity, application, "existing", new(HttpMethod.Post, origin + "/yapi/synthetic"), default));
        Assert.Equal(0, handler.Exchanges); Assert.Equal(0, handler.Commands);
    }
    [Fact]
    public async Task ExpiredCredentialDeniesLocallyWithoutRefreshingOrSending()
    {
        using var handler = new Destination { AllowExchange = false }; using var http = new HttpClient(handler);
        var codec = Codec();
        var prepared = codec.Protect("17", 7, "agent", "grant",
            [new("Clinica", "https://clinica.test", "synthetic-expired-bearer", DateTimeOffset.UtcNow.AddSeconds(-1))], DateTimeOffset.UtcNow.AddMinutes(5));
        var sender = new AgentApplicationSender(http, codec);
        await Assert.ThrowsAsync<BusinessAccessException>(() => sender.SendAsync(Identity(prepared.ProtectedValue), "Clinica", "existing", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default));
        Assert.Equal(0, handler.Commands); Assert.Equal(0, handler.Exchanges);
    }
    [Fact]
    public async Task IssuanceRejectsWrongTenantFromExistingSessionExchange()
    {
        using var handler = new Destination { ReturnedTenant = 8 }; using var http = new HttpClient(handler);
        var preparer = new AgentApplicationPreparation(http, Catalog(), Codec(), new JwtSettings { SecretKey = Root }, TimeProvider.System);
        await Assert.ThrowsAsync<BusinessAccessException>(() => preparer.PrepareAsync(Owner(), "agent", "grant", new HashSet<string>(["application:Clinica"]), default));
        Assert.Equal(1, handler.Exchanges); Assert.Equal(0, handler.Commands);
    }
    [Fact]
    public void OversizedSelfContainedSnapshotIsRejectedInsteadOfCreatingLookupFallback()
    {
        var codec = Codec();
        Assert.Throws<BusinessAccessException>(() => codec.Protect("17", 7, "agent", "grant",
            [new("Clinica", "https://clinica.test", new string('x', 20000), DateTimeOffset.UtcNow.AddMinutes(5))], DateTimeOffset.UtcNow.AddMinutes(5)));
    }
    private sealed class Destination : HttpMessageHandler
    {
        internal int Exchanges, Commands;
        internal bool AllowOperation = true;
        internal bool AllowExchange = true;
        internal int ReturnedTenant = 7;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var parser = new JwtSecurityTokenHandler { MapInboundClaims = false };
            var principal = parser.ValidateToken(request.Headers.Authorization!.Parameter!, new TokenValidationParameters
            { ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = true, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)) }, out var token);
            if (request.RequestUri!.AbsolutePath == "/yapi/getMenu")
            {
                if (!AllowExchange) throw new InvalidOperationException("Authorization HTTP is forbidden after issuance.");
                Exchanges++;
                Assert.Equal("17", principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Assert.Equal("Central", principal.FindFirst("tokenOrigin")?.Value);
                Assert.Equal("17", principal.FindFirst("owner_sub")?.Value);
                Assert.Equal("agent", principal.FindFirst("client_id")?.Value);
                Assert.Equal("grant", principal.FindFirst("delegation_id")?.Value);
                Assert.Equal("Clinica", principal.FindFirst("userCatalogs")?.Value);
                var claims = new Claim[] { new(ClaimTypes.NameIdentifier, "99"), new("tenantId", ReturnedTenant.ToString()), new("application", "Clinica"),
                    new("tokenOrigin", "Application"), new(ClaimTypes.Role, "Admin") };
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Headers.Add("X-Yeshua-Application-Token", new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                    claims: claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)), SecurityAlgorithms.HmacSha256))));
                return Task.FromResult(result);
            }
            Commands++;
            Assert.Equal("99", principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Assert.Equal("17", principal.FindFirst("owner_sub")?.Value);
            Assert.Equal("7", principal.FindFirst("tenantId")?.Value);
            Assert.Equal("agent", principal.FindFirst("client_id")?.Value);
            Assert.Equal("grant", principal.FindFirst("delegation_id")?.Value);
            Assert.Equal("Clinica", principal.FindFirst("application")?.Value);
            Assert.Equal("https://clinica.test", ((JwtSecurityToken)token).Audiences.Single());
            Assert.DoesNotContain(principal.Claims, c => c.Type == ClaimTypes.Role || c.Value == "Admin");
            Assert.InRange(token.ValidTo - DateTime.UtcNow, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.FromResult(new HttpResponseMessage(AllowOperation ? HttpStatusCode.OK : HttpStatusCode.Forbidden));
        }
    }
}
