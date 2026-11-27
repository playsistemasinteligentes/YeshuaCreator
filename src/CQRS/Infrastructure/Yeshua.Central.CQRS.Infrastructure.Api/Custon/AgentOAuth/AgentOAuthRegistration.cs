using Central.Repository.AgentOAuth;
using Central.BusinessMcp;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Command.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Central.AgentOAuth;

public static class AgentOAuthRegistration
{
    public static IServiceCollection AddCentralAgentOAuth(this IServiceCollection services, AgentOAuthOptions options,
        string jwtRoot, Action<DbContextOptionsBuilder> database)
    {
        options.Validate();
        services.AddSingleton(options);
        services.Configure<ForwardedHeadersOptions>(forwarding =>
        {
            forwarding.ForwardedHeaders = ForwardedHeaders.XForwardedProto;
            forwarding.ForwardLimit = 1;
            foreach (var proxy in options.KnownProxies) forwarding.KnownProxies.Add(System.Net.IPAddress.Parse(proxy));
        });
        services.AddScoped<CentralLoginSessionReader>();
        services.AddScoped<ICentralAgentIdentity, CentralAgentIdentity>();
        services.AddScoped<AgentOAuthReceiver>();
        services.TryAddSingleton(TimeProvider.System);
        services.TryAddSingleton(new TrustedBusinessCatalog([]));
        services.AddSingleton<AgentApplicationCredentials>();
        // No manager/repository is resolved by authorization on MCP requests.
        services.AddScoped<DelegatedAccess>(sp => new DelegatedAccess(null, sp.GetRequiredService<TimeProvider>(),
            new DelegationValidationOptions(UseShortLivedTokenSnapshot: true)));
        services.AddHttpClient<AgentApplicationPreparation>(http => http.Timeout = TimeSpan.FromSeconds(30))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false });
        services.AddScoped<IBusinessPermissionReader, AgentBusinessPermissionReader>();
        services.AddScoped<IBusinessAuditWriter, AgentBusinessAudit>();
        services.AddHttpClient<IApplicationDelegationSender, AgentApplicationSender>(http => http.Timeout = TimeSpan.FromSeconds(30))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false });
        services.AddHttpContextAccessor();
        // Used only for CSRF form tickets; restarting requires reloading the form.
        // OAuth codes/tokens use the separate stable protocol encryption key.
        services.AddDataProtection().UseEphemeralDataProtectionProvider();
        services.AddAntiforgery(o => { o.Cookie.Name = "__Host-Yeshua-Agent-CSRF"; o.Cookie.SecurePolicy = CookieSecurePolicy.Always; o.Cookie.SameSite = SameSiteMode.Strict; });
        services.AddDbContext<AgentOAuthDbContext>(builder => { database(builder); builder.UseOpenIddict(); });
        services.AddOpenIddict().AddCore(core =>
        {
            core.UseEntityFrameworkCore().UseDbContext<AgentOAuthDbContext>();
            // Status changes must be visible to refresh requests in other processes.
            core.DisableEntityCaching();
        }).AddServer(server =>
        {
            server.SetIssuer(options.Issuer);
            server.SetAuthorizationEndpointUris("oauth/authorize").SetTokenEndpointUris("oauth/token")
                .SetRevocationEndpointUris("oauth/revoke");
            server.AllowAuthorizationCodeFlow().AllowRefreshTokenFlow().RequireProofKeyForCodeExchange();
            server.RegisterScopes(options.SupportedScopes.ToArray());
            server.RegisterResources(options.Resource);
            server.Configure(configuration => configuration.CodeChallengeMethods.Remove(CodeChallengeMethods.Plain));
            server.SetAuthorizationCodeLifetime(TimeSpan.FromMinutes(2));
            server.SetAccessTokenLifetime(TimeSpan.FromMinutes(5));
            server.SetRefreshTokenLifetime(TimeSpan.FromDays(7));
            server.DisableSlidingRefreshTokenExpiration().SetRefreshTokenReuseLeeway(TimeSpan.Zero);
            server.AddSigningKey(options.SigningKey());
            server.AddEncryptionKey(AgentOAuthOptions.Key(jwtRoot, "Encryption"));
            server.DisableAccessTokenEncryption();
            server.UseAspNetCore().EnableAuthorizationEndpointPassthrough().EnableTokenEndpointPassthrough();
            server.AddEventHandler<OpenIddictServerEvents.ValidateAuthorizationRequestContext>(b => b.UseInlineHandler(context =>
            {
                if (context.Request.GetResources() is not { Length: 1 } resources || resources[0] != options.Resource)
                    context.Reject(Errors.InvalidTarget, "The configured MCP resource is required.");
                if (context.Request.CodeChallengeMethod != CodeChallengeMethods.Sha256)
                    context.Reject(Errors.InvalidRequest, "PKCE S256 is required.");
                if (context.Request.ResponseMode is not (null or "query")) context.Reject(Errors.InvalidRequest, "Only query code responses are supported.");
                return default;
            }));
            server.AddEventHandler<OpenIddictServerEvents.ValidateTokenRequestContext>(b => b.UseInlineHandler(context =>
            {
                if (context.Request.GetResources() is not { Length: 1 } resources || resources[0] != options.Resource)
                    context.Reject(Errors.InvalidTarget, "The configured MCP resource is required.");
                return default;
            }));
        });
        services.AddAuthentication().AddJwtBearer(AgentOAuthOptions.ResourceScheme, bearer =>
        {
            bearer.MapInboundClaims = false;
            bearer.Configuration = new OpenIdConnectConfiguration { Issuer = options.Issuer };
            bearer.TokenValidationParameters = new()
            {
                ValidateIssuer = true, ValidIssuer = options.Issuer,
                ValidateAudience = true, ValidAudience = options.Resource,
                ValidateLifetime = true, ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true, RequireSignedTokens = true, ValidateIssuerSigningKey = true,
                IssuerSigningKey = options.SigningKey(), ValidTypes = ["at+jwt"]
            };
            bearer.Events = new JwtBearerEvents { OnChallenge = context =>
            {
                context.HandleResponse(); context.Response.StatusCode = 401;
                context.Response.Headers.WWWAuthenticate = $"Bearer resource_metadata=\"{MetadataUri(options)}\", scope=\"business:discover\"";
                return Task.CompletedTask;
            } };
        });
        services.AddAuthorization(authorization => authorization.AddPolicy(AgentOAuthOptions.ResourcePolicy, policy =>
            policy.AddAuthenticationSchemes(AgentOAuthOptions.ResourceScheme).RequireAuthenticatedUser()
                .RequireClaim("token_kind", "delegated").RequireClaim("delegation_kind", "external_agent").RequireClaim("tenantId").RequireClaim("client_id").RequireClaim("delegation_id")));
        return services;
    }
    public static string MetadataUri(AgentOAuthOptions options) => new Uri(options.Resource).GetLeftPart(UriPartial.Authority)
        + "/.well-known/oauth-protected-resource" + new Uri(options.Resource).AbsolutePath;

    // Explicit provisioning step; never creates/updates database schema or clients
    // on ordinary API startup. Configuration is authoritative for registered clients.
    public static async Task ProvisionClientsAsync(IServiceProvider provider, CancellationToken ct = default)
    {
        using var scope = provider.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<AgentOAuthOptions>();
        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
        foreach (var client in options.Clients)
        {
            var descriptor = new OpenIddictApplicationDescriptor
            {
                ClientId = client.ClientId, DisplayName = client.DisplayName,
                ClientType = ClientTypes.Public, ConsentType = ConsentTypes.Explicit
            };
            foreach (var redirect in client.RedirectUris) descriptor.RedirectUris.Add(new Uri(redirect));
            descriptor.Permissions.UnionWith([Permissions.Endpoints.Authorization, Permissions.Endpoints.Token,
                Permissions.Endpoints.Revocation, Permissions.GrantTypes.AuthorizationCode,
                Permissions.GrantTypes.RefreshToken, Permissions.ResponseTypes.Code,
                Permissions.Prefixes.Scope + "business:discover"]);
            descriptor.AddResourcePermissions(options.Resource);
            foreach (var app in client.Applications) descriptor.Permissions.Add(Permissions.Prefixes.Scope + AgentOAuthOptions.ApplicationScope(app));
            descriptor.Requirements.Add(Requirements.Features.ProofKeyForCodeExchange);
            var existing = await manager.FindByClientIdAsync(client.ClientId, ct);
            if (existing is null) await manager.CreateAsync(descriptor, ct);
            else await manager.UpdateAsync(existing, descriptor, ct);
        }
    }
}
