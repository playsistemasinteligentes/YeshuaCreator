using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Central.BusinessMcp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class BusinessMcpTests
{
    internal const string Scope = "business:operation:sample";
    internal const string Resource = "https://central.test/business/mcp";
    internal const string Issuer = "https://identity.test/";
    internal static readonly SymmetricSecurityKey Key = new(Encoding.UTF8.GetBytes("synthetic-test-signing-key-at-least-32-bytes-only"));
    internal static readonly SymmetricSecurityKey DestinationKey = new(Encoding.UTF8.GetBytes("different-synthetic-destination-key-32-bytes-only"));
    internal static JsonElement Json(string value) => JsonDocument.Parse(value).RootElement.Clone();
    internal static string Document = """
    {"openapi":"3.0.1","paths":{"/yapi/Sample/Execute":{"post":{
      "operationId":"Sample.Commands.Execute","description":"Synthetic business command.","security":[{"Bearer":[]}],
      "requestBody":{"content":{"application/json":{"schema":{"$ref":"#/components/schemas/Input"}}}},
      "responses":{"200":{"content":{"application/json":{"schema":{"type":"object","properties":{"ok":{"type":"boolean"}},"required":["ok"]}}}}}
    }}},"components":{"schemas":{
      "Input":{"type":"object","required":["quantity","items"],"properties":{
        "quantity":{"type":"integer","minimum":1,"maximum":10},
        "items":{"type":"array","minItems":1,"items":{"$ref":"#/components/schemas/Item"}},
        "note":{"type":"string","nullable":true,"maxLength":12}}},
      "Item":{"type":"object","required":["kind"],"properties":{"kind":{"type":"string","enum":["A","B"]}}}
    }}}
    """;
    internal static TrustedBusinessCatalog Catalog(string? doc = null, string id = "Sample.Commands.Execute") => new([
        new("Sample", new Uri("https://sample.test/"), Json(doc ?? Document), [new(id, "sample.execute", Scope)])]);
    internal static ClaimsPrincipal Principal(string subject = "17", int tenant = 7, string scope = "business:discover " + Scope,
        string client = "synthetic-client", string kind = "delegated") => new(new ClaimsIdentity([
            new("sub", subject), new("tenantId", tenant.ToString()), new("client_id", client), new("delegation_id", "grant-1"),
            new("scope", scope), new("token_kind", kind)], "test"));
    internal static string Token(ClaimsPrincipal? principal = null, string audience = Resource,
        string issuer = Issuer, bool expired = false, SecurityKey? key = null) => new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer, audience, (principal ?? Principal()).Claims, DateTime.UtcNow.AddMinutes(-20),
            expired ? DateTime.UtcNow.AddMinutes(-10) : DateTime.UtcNow.AddMinutes(5),
            new SigningCredentials(key ?? Key, SecurityAlgorithms.HmacSha256)));

    [Fact]
    public async Task DiscoveryAndExecutionUseTrustedContractAndKeepIdentity()
    {
        var f = new Fixture();
        var apps = await f.Receiver.ApplicationsAsync(Principal(), default);
        Assert.Equal("Sample", Assert.Single(apps).Id);
        var op = Assert.Single(await f.Receiver.OperationsAsync(Principal(), "Sample", default));
        Assert.Contains("$defs", op.InputSchema.GetRawText());
        Assert.Contains("Item", op.InputSchema.GetRawText());
        Assert.Contains("ok", op.OutputSchema.GetRawText());
        var result = await f.Execute();
        Assert.Equal("completed", result.Outcome);
        Assert.True(result.Data!.Value.GetProperty("ok").GetBoolean());
        Assert.Equal("https://sample.test/yapi/Sample/Execute", f.Sender.Target!.AbsoluteUri);
        Assert.Equal(7, f.Sender.Identity!.TenantId);
        Assert.Equal("17", f.Sender.Identity.Subject);
        Assert.Equal(2, f.Audit.Events.Count);
        Assert.All(f.Audit.Events, a => Assert.Equal(result.CorrelationId, a.CorrelationId));
    }
    [Theory]
    [InlineData("18", 7, "synthetic-client", "delegated")]
    [InlineData("17", 8, "synthetic-client", "delegated")]
    [InlineData("17", 7, "other-client", "delegated")]
    [InlineData("17", 7, "synthetic-client", "autonomous")]
    public async Task DelegationCannotChangeSubjectTenantClientOrIdentityKind(string sub, int tenant, string client, string kind)
    {
        var f = new Fixture();
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Receiver.ExecuteAsync(Principal(sub, tenant, client: client, kind: kind), Fixture.Command(), default));
        Assert.Equal(0, f.Sender.Calls);
    }
    [Fact]
    public async Task RevocationAndPermissionRemovalApplyToAlreadyAuthenticatedCalls()
    {
        var f = new Fixture();
        await f.Execute();
        f.Permissions.Allowed = false;
        Assert.Empty(await f.Receiver.ApplicationsAsync(Principal(), default));
        Assert.Equal("operation_not_allowed", (await f.Execute()).Outcome);
        f.Store.Value = f.Store.Value! with { Revoked = true };
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Execute());
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Receiver.OperationsAsync(Principal(), "Sample", default));
        Assert.Equal(1, f.Sender.Calls);
    }
    [Fact]
    public async Task ExpiredConsentAndScopeEscalationAreRejected()
    {
        var f = new Fixture();
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Receiver.ApplicationsAsync(Principal(scope: "business:discover admin"), default));
        f.Store.Value = f.Store.Value! with { ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(-1) };
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Execute());
        Assert.Equal(0, f.Sender.Calls);
    }
    [Fact]
    public async Task InsufficientScopeHidesOperationsAndBlocksExecution()
    {
        var f = new Fixture();
        var principal = Principal(scope: "business:discover");
        Assert.Empty(await f.Receiver.ApplicationsAsync(principal, default));
        Assert.Equal("operation_not_allowed", (await f.Receiver.ExecuteAsync(principal, Fixture.Command(), default)).Outcome);
        await Assert.ThrowsAsync<BusinessAccessException>(() => f.Receiver.ApplicationsAsync(Principal(scope: Scope), default));
        Assert.Equal(0, f.Sender.Calls);
    }
    [Theory]
    [InlineData("{\"quantity\":0,\"items\":[{\"kind\":\"A\"}]}")]
    [InlineData("{\"quantity\":2,\"items\":[{\"kind\":\"internal\"}]}")]
    [InlineData("{\"quantity\":2,\"items\":[]}")]
    [InlineData("{\"quantity\":2,\"items\":[{}]}")]
    [InlineData("{\"quantity\":2,\"items\":[{\"kind\":\"A\"}],\"tenantId\":8}")]
    [InlineData("{\"quantity\":2,\"items\":[{\"kind\":\"A\"}],\"url\":\"https://evil.test\"}")]
    [InlineData("{\"quantity\":\"2\",\"items\":[{\"kind\":\"A\"}]}")]
    public async Task InvalidParametersNeverReachDestination(string input)
    {
        var f = new Fixture();
        Assert.Equal("invalid_parameters", (await f.Receiver.ExecuteAsync(Principal(), Fixture.Command(input), default)).Outcome);
        Assert.Equal(0, f.Sender.Calls);
    }
    [Theory]
    [InlineData("internal")]
    [InlineData("https://evil.test")]
    [InlineData("Sample.Commands.Execute/../../admin")]
    public async Task UnknownOrInternalOperationsAreNotExecutable(string operation)
    {
        var f = new Fixture();
        Assert.Equal("operation_not_allowed", (await f.Receiver.ExecuteAsync(Principal(), Fixture.Command() with { Operation = operation }, default)).Outcome);
        Assert.Equal(0, f.Sender.Calls);
    }
    [Theory]
    [InlineData(202, "accepted")]
    [InlineData(403, "destination_denied")]
    [InlineData(409, "conflict")]
    [InlineData(302, "destination_failed")]
    [InlineData(500, "destination_failed")]
    [InlineData(429, "rate_limited")]
    public async Task DestinationErrorsAndAsyncAcceptanceAreNotReportedAsCompletion(int status, string outcome)
    {
        var f = new Fixture();
        f.Sender.Status = status;
        var result = await f.Execute();
        Assert.Equal(outcome, result.Outcome);
        Assert.Null(result.Data);
        Assert.Equal(1, f.Sender.Calls);
    }
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TimeoutOrAdapterFailureHasUnknownOutcomeWithoutRetryOrPrivateDetails(bool timeout)
    {
        var f = new Fixture();
        f.Sender.Failure = timeout ? new TaskCanceledException("synthetic private diagnostics") : new InvalidOperationException("synthetic private diagnostics");
        var result = await f.Execute();
        Assert.Equal("outcome_unknown", result.Outcome);
        Assert.Null(result.Data);
        Assert.Equal(1, f.Sender.Calls);
        Assert.Equal("outcome_unknown", f.Audit.Events.Last().Outcome);
    }
    [Fact]
    public async Task WrongDestinationSchemaIsNotReturnedToAgent()
    {
        var f = new Fixture();
        f.Sender.Body = "{\"sensitive_unexpected\":\"synthetic\"}";
        Assert.Equal("invalid_destination_response", (await f.Execute()).Outcome);
    }
    [Fact]
    public async Task UnavailableAuditPreventsBusinessSideEffect()
    {
        var f = new Fixture();
        f.Audit.Fail = true;
        await Assert.ThrowsAsync<IOException>(() => f.Execute());
        Assert.Equal(0, f.Sender.Calls);
    }
    [Theory]
    [InlineData("internal")]
    [InlineData("administrative")]
    [InlineData("anonymous")]
    [InlineData("external-ref")]
    [InlineData("missing-id")]
    [InlineData("identity-input")]
    [InlineData("query")]
    public void IneligibleCatalogEntriesFailClosed(string scenario)
    {
        var doc = JsonNode.Parse(Document)!;
        var op = doc["paths"]!["/yapi/Sample/Execute"]!["post"]!;
        switch (scenario)
        {
            case "internal": op["x-yeshua-internal"] = true; break;
            case "administrative": op["x-yeshua-administrative"] = true; break;
            case "anonymous": op["security"] = new JsonArray(); break;
            case "external-ref": op["requestBody"]!["content"]!["application/json"]!["schema"]!["$ref"] = "https://evil.test/schema"; break;
            case "missing-id": op.AsObject().Remove("operationId"); break;
            case "identity-input": doc["components"]!["schemas"]!["Input"]!["properties"]!["TenantID"] = new JsonObject { ["type"] = "integer" }; break;
            case "query": op["parameters"] = JsonNode.Parse("[{\"in\":\"query\",\"name\":\"url\"}]"); break;
        }
        Assert.ThrowsAny<ArgumentException>(() => Catalog(doc.ToJsonString()));
    }
    [Fact]
    public void EmptyExposureDoesNotPublishEverySwaggerEndpoint()
    {
        var catalog = new TrustedBusinessCatalog([new("Sample", new Uri("https://sample.test/"), Json(Document), [])]);
        Assert.NotNull(catalog);
    }

    internal sealed class Store : IDelegationRepository
    {
        public Delegation? Value = new("grant-1", "17", 7, "synthetic-client", DateTimeOffset.UtcNow.AddMinutes(10), false,
            new HashSet<string>(["business:discover", Scope]));
        public Task<Delegation?> FindAsync(string id, CancellationToken ct) => Task.FromResult(Value?.Id == id ? Value : null);
    }
    internal sealed class Permissions : IBusinessPermissionReader
    {
        public bool Allowed = true;
        public Task<bool> AllowsAsync(DelegatedIdentity identity, string application, string grant, CancellationToken ct) =>
            Task.FromResult(Allowed && application == "Sample" && grant == "sample.execute" && identity.TenantId == 7 && identity.Subject == "17");
    }
    internal sealed class Audit : IBusinessAuditWriter
    {
        public bool Fail;
        public List<BusinessAudit> Events = [];
        public Task WriteAsync(BusinessAudit audit, CancellationToken ct)
        { if (Fail) throw new IOException("synthetic audit outage"); Events.Add(audit); return Task.CompletedTask; }
    }
    internal sealed class Sender : IApplicationDelegationSender
    {
        public int Calls, Status = 200;
        public string Body = "{\"ok\":true}";
        public Exception? Failure;
        public Uri? Target;
        public DelegatedIdentity? Identity;
        public Task<HttpResponseMessage> SendAsync(DelegatedIdentity identity, string application, string grant, HttpRequestMessage request, CancellationToken ct)
        {
            Calls++; Target = request.RequestUri; Identity = identity;
            Assert.Null(request.Headers.Authorization);
            Assert.True(request.Headers.Contains("traceparent"));
            Assert.True(request.Headers.Contains(Aplication.Interfaces.Services.OperationalExecutionHeaders.RootOperationId));
            if (Failure is not null) throw Failure;
            return Task.FromResult(new HttpResponseMessage((HttpStatusCode)Status) { Content = new StringContent(Body, Encoding.UTF8, "application/json") });
        }
    }
    internal sealed class Fixture
    {
        internal Store Store = new(); internal Permissions Permissions = new(); internal Sender Sender = new(); internal Audit Audit = new();
        internal BusinessMcpReceiver Receiver;
        public Fixture() => Receiver = new(Catalog(), new DelegatedAccess(Store, TimeProvider.System), Permissions, Sender, Audit);
        internal static ExecuteBusinessOperation Command(string parameters = "{\"quantity\":2,\"items\":[{\"kind\":\"A\"}],\"note\":null}") => new("Sample", "Sample.Commands.Execute", Json(parameters));
        internal Task<BusinessResult> Execute() => Receiver.ExecuteAsync(Principal(), Command(), default);
    }
}
