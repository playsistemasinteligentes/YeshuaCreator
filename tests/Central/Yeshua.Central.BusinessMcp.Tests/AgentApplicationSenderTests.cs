using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Central.AgentOAuth;
using Central.BusinessMcp;
using Command.UseCase;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class AgentApplicationSenderTests
{
    private const string Root = "synthetic-destination-test-root-at-least-32-bytes";
    [Fact]
    public async Task ExistingSessionExchangeMapsLocalIdentityAndReauthorizesWithoutPassingMcpBearer()
    {
        var identities = new Mock<ICentralAgentIdentity>();
        identities.Setup(i => i.ResolveAsync(17, 7, It.IsAny<CancellationToken>())).ReturnsAsync(
            new LoginOutputCommand { UserId = 17, tenantId = 7, catalogos = ["Clinica"], modulos = [], email = "owner@example.test" });
        using var handler = new Destination(); using var http = new HttpClient(handler);
        using var cache = new MemoryCache(new MemoryCacheOptions());
        var sender = new AgentApplicationSender(http, identities.Object, cache, new JwtSettings { SecretKey = Root });
        var principal = new ClaimsPrincipal(new ClaimsIdentity([new("sub", "17"), new("tenantId", "7"), new("client_id", "agent"),
            new("exp", DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds().ToString()), new("jti", "synthetic-jti")], "verified"));
        var identity = new DelegatedIdentity("17", 7, "agent", "grant", new HashSet<string>(["application:Clinica"])) { Principal = principal };
        using var first = await sender.SendAsync(identity, "Clinica", "unused-business-grant", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default);
        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        handler.AllowOperation = false;
        using var denied = await sender.SendAsync(identity, "Clinica", "unused-business-grant", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default);
        Assert.Equal(HttpStatusCode.Forbidden, denied.StatusCode);
        Assert.Equal(1, handler.Exchanges); Assert.Equal(2, handler.Commands);
        identities.Verify(i => i.ResolveAsync(17, 7, It.IsAny<CancellationToken>()), Times.Once);
    }
    [Fact]
    public async Task MissingApplicationScopeNeverOpensASession()
    {
        var identities = new Mock<ICentralAgentIdentity>();
        using var handler = new Destination(); using var http = new HttpClient(handler); using var cache = new MemoryCache(new MemoryCacheOptions());
        var sender = new AgentApplicationSender(http, identities.Object, cache, new JwtSettings { SecretKey = Root });
        await Assert.ThrowsAsync<BusinessAccessException>(() => sender.SendAsync(new("17", 7, "agent", "grant", new HashSet<string>()),
            "Clinica", "unused", new(HttpMethod.Post, "https://clinica.test/yapi/synthetic"), default));
        identities.VerifyNoOtherCalls(); Assert.Equal(0, handler.Exchanges);
    }
    private sealed class Destination : HttpMessageHandler
    {
        internal int Exchanges, Commands;
        internal bool AllowOperation = true;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var parser = new JwtSecurityTokenHandler { MapInboundClaims = false };
            var principal = parser.ValidateToken(request.Headers.Authorization!.Parameter!, new TokenValidationParameters
            { ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = true, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Root)) }, out var token);
            if (request.RequestUri!.AbsolutePath == "/yapi/getMenu")
            {
                Exchanges++;
                Assert.Equal("17", principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Assert.Equal("Central", principal.FindFirst("tokenOrigin")?.Value);
                Assert.Equal("Clinica", principal.FindFirst("userCatalogs")?.Value);
                var claims = new Claim[] { new(ClaimTypes.NameIdentifier, "99"), new("tenantId", "7"), new("application", "Clinica"),
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
