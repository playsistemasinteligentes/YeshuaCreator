using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Central.AgentOAuth;
using Central.BusinessMcp;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Xunit.Abstractions;

namespace Yeshua.Central.BusinessMcp.Tests;

[CollectionDefinition("AgentAuthorizationCost", DisableParallelization = true)]
public sealed class AgentAuthorizationCostCollection;

[Collection("AgentAuthorizationCost")]
public sealed class LocalAuthorizationCostTests(ITestOutputHelper output)
{
    [Fact]
    public void MeasureLocalAuthorizationComparedWithConventionalJwtValidation()
    {
        const string root = "synthetic-authorization-cost-root-at-least-32-bytes";
        var clock = TimeProvider.System;
        var options = new AgentOAuthOptions { Issuer = "https://central.test/", Resource = "https://central.test/business/mcp" };
        var codec = new AgentApplicationCredentials(options, new JwtSettings { SecretKey = root }, clock);
        var expiration = clock.GetUtcNow().AddMinutes(5);
        var conventionalClaims = new Claim[] { new(ClaimTypes.NameIdentifier, "17"), new("tenantId", "7"),
            new("application", "Central"), new("tokenOrigin", "Central"), new("userCatalogs", "Central"),
            new("owner_sub", "17"), new("client_id", "agent"), new("delegation_id", "grant") };
        var conventionalJwt = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(claims: conventionalClaims,
            expires: expiration.UtcDateTime, signingCredentials: new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(root)), SecurityAlgorithms.HmacSha256)));
        var prepared = codec.Protect("17", 7, "agent", "grant", [new("Central", "https://central.test", conventionalJwt, expiration)], expiration);
        using var rsa = RSA.Create(2048);
        var signed = new JwtSecurityToken(options.Issuer, options.Resource,
            [new("sub", "17"), new("tenantId", "7"), new("client_id", "agent"), new("delegation_id", "grant"),
                new("token_kind", "delegated"), new("delegation_kind", "external_agent"), new("userCatalogs", "Central"),
                new("scope", "business:discover application:Central"), new(AgentApplicationCredentials.ClaimType, prepared.ProtectedValue)],
            expires: expiration.UtcDateTime, signingCredentials: new(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256));
        signed.Header["typ"] = "at+jwt";
        var mcpJwt = new JwtSecurityTokenHandler().WriteToken(signed);
        var oldSigned = new JwtSecurityToken(options.Issuer, options.Resource,
            signed.Claims.Where(c => c.Type is not ("exp" or "iss" or "aud") && c.Type != AgentApplicationCredentials.ClaimType),
            expires: expiration.UtcDateTime, signingCredentials: new(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256));
        oldSigned.Header["typ"] = "at+jwt";
        var oldMcpJwt = new JwtSecurityTokenHandler().WriteToken(oldSigned);
        // Control for the previous sender's warm local cache. This is not used
        // by the new implementation and does not model its noncompliant cold I/O.
        using var previousCache = new MemoryCache(new MemoryCacheOptions());
        previousCache.Set("previous-preloaded-application-session", conventionalJwt, expiration);
        var conventionalValidation = new TokenValidationParameters
        {
            ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(root))
        };
        var delegatedValidation = new TokenValidationParameters
        {
            ValidateIssuer = true, ValidIssuer = options.Issuer, ValidateAudience = true, ValidAudience = options.Resource,
            ValidateLifetime = true, ClockSkew = TimeSpan.Zero, RequireExpirationTime = true, RequireSignedTokens = true,
            ValidateIssuerSigningKey = true, IssuerSigningKey = new RsaSecurityKey(rsa), ValidTypes = ["at+jwt"]
        };
        var legacyHandler = new JsonWebTokenHandler { MapInboundClaims = true };
        var mcpHandler = new JsonWebTokenHandler { MapInboundClaims = false };
        var access = new DelegatedAccess(null, clock, new(UseShortLivedTokenSnapshot: true));
        var permissions = new AgentBusinessPermissionReader();
        int conventionalChecks = 0, previousChecks = 0, delegatedChecks = 0;
        void Conventional()
        {
            var validation = legacyHandler.ValidateTokenAsync(conventionalJwt, conventionalValidation).GetAwaiter().GetResult();
            if (!validation.IsValid) throw validation.Exception;
            // The existing Central policy is token origin/application plus its
            // locally evaluated claims; no profile/grant lookup is introduced.
            if (validation.ClaimsIdentity.FindFirst("tokenOrigin")?.Value != "Central"
                || validation.ClaimsIdentity.FindFirst("application")?.Value != "Central") throw new InvalidOperationException();
            conventionalChecks++;
        }
        void PreviousWarmMcp()
        {
            var validation = mcpHandler.ValidateTokenAsync(oldMcpJwt, delegatedValidation).GetAwaiter().GetResult();
            if (!validation.IsValid) throw validation.Exception;
            var identity = access.RequireAsync(new ClaimsPrincipal(validation.ClaimsIdentity), default).GetAwaiter().GetResult();
            if (!permissions.AllowsAsync(identity, "Central", "existing-domain-policy", default).GetAwaiter().GetResult()
                || !previousCache.TryGetValue<string>("previous-preloaded-application-session", out var token) || token != conventionalJwt)
                throw new InvalidOperationException();
            previousChecks++;
        }
        void Delegated()
        {
            var validation = mcpHandler.ValidateTokenAsync(mcpJwt, delegatedValidation).GetAwaiter().GetResult();
            if (!validation.IsValid) throw validation.Exception;
            var identity = access.RequireAsync(new ClaimsPrincipal(validation.ClaimsIdentity), default).GetAwaiter().GetResult();
            if (!permissions.AllowsAsync(identity, "Central", "existing-domain-policy", default).GetAwaiter().GetResult()) throw new InvalidOperationException();
            if (codec.Select(identity, "Central", "https://central.test") != conventionalJwt) throw new InvalidOperationException();
            delegatedChecks++;
        }
        for (var i = 0; i < 100; i++) { Conventional(); PreviousWarmMcp(); Delegated(); }
        const int iterations = 1000;
        var baseline = new List<double>(); var previous = new List<double>(); var delegated = new List<double>();
        double Measure(Action action)
        {
            var start = Stopwatch.GetTimestamp();
            for (var i = 0; i < iterations; i++) action();
            return Stopwatch.GetElapsedTime(start).TotalMicroseconds / iterations;
        }
        for (var batch = 0; batch < 5; batch++) { baseline.Add(Measure(Conventional)); previous.Add(Measure(PreviousWarmMcp)); delegated.Add(Measure(Delegated)); }
        var baselineMedian = baseline.Order().ElementAt(2); var delegatedMedian = delegated.Order().ElementAt(2);
        var previousMedian = previous.Order().ElementAt(2);
        Assert.Equal(5100, conventionalChecks); Assert.Equal(5100, previousChecks); Assert.Equal(5100, delegatedChecks);
#if DEBUG
        const string configuration = "Debug";
#else
        const string configuration = "Release";
#endif
        var evidence = new
        {
            runtime = Environment.Version.ToString(), configuration, processors = Environment.ProcessorCount,
            iterationsPerBatch = iterations, batches = 5, warmups = 100,
            measurement = "Local CPU only, warm crypto: conventional Central JWT/policy; previous MCP RSA JWT/claims with preloaded local cache; new self-contained MCP JWT/claims and protected credential. Excludes business execution, transport, issuance and destination JWT validation common to delivery.",
            conventionalMicrosecondsPerOperation = baselineMedian,
            previousWarmMcpMicrosecondsPerOperation = previousMedian,
            delegatedMicrosecondsPerOperation = delegatedMedian,
            additionalMicrosecondsVsPreviousWarmMcp = delegatedMedian - previousMedian,
            additionalLocalMicroseconds = delegatedMedian - baselineMedian,
            ratio = delegatedMedian / baselineMedian,
            conventionalSamples = baseline, previousWarmMcpSamples = previous, delegatedSamples = delegated,
            conventionalJwtBytes = Encoding.UTF8.GetByteCount(conventionalJwt), previousMcpJwtBytes = Encoding.UTF8.GetByteCount(oldMcpJwt), mcpJwtBytes = Encoding.UTF8.GetByteCount(mcpJwt),
            authorizationDatabaseCalls = 0, authorizationHttpCalls = 0, remoteCacheCalls = 0, introspectionCalls = 0,
            note = "The new path has no repository, identity service, cache or HTTP client. The previous warm control includes an explicitly preloaded in-process cache only; old cold session resolution is excluded and is not compliant. Not a production latency/SLO benchmark."
        };
        var json = JsonSerializer.Serialize(evidence, new JsonSerializerOptions { WriteIndented = true });
        output.WriteLine(json);
        var directory = Environment.GetEnvironmentVariable("YESHUA_AGENT_AUTH_EVIDENCE_DIR");
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
            File.WriteAllText(Path.Combine(directory, "local-authorization-cost.json"), json + Environment.NewLine);
        }
    }
}
