using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ModelContextProtocol.AspNetCore;
using ModelContextProtocol.Protocol;
using Json.Schema;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http.Features;

namespace Central.BusinessMcp;

public static class BusinessMcpTransport
{
    // No call from Central's default composition root: production exposure is blocked
    // until the persistent consent/grant and destination delegation adapters exist.
    public static IServiceCollection AddCentralBusinessMcp(this IServiceCollection services,
        BusinessOAuthResource resource, TrustedBusinessCatalog catalog)
    {
        resource.Validate();
        services.AddSingleton(resource);
        services.AddSingleton(catalog);
        services.AddSingleton(TimeProvider.System);
        services.AddHttpContextAccessor();
        services.AddScoped<DelegatedAccess>();
        services.AddScoped<BusinessMcpReceiver>();
        services.AddAuthentication().AddJwtBearer(BusinessOAuthResource.Scheme, options =>
        {
            options.Authority = resource.Issuer.AbsoluteUri;
            options.Audience = resource.Resource.AbsoluteUri;
            options.MapInboundClaims = false;
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, ValidIssuer = resource.Issuer.AbsoluteUri,
                ValidateAudience = true, ValidAudience = resource.Resource.AbsoluteUri,
                ValidateIssuerSigningKey = true, RequireSignedTokens = true,
                ValidateLifetime = true, RequireExpirationTime = true, ClockSkew = TimeSpan.FromSeconds(30)
            };
            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    try { await context.HttpContext.RequestServices.GetRequiredService<DelegatedAccess>()
                        .RequireAsync(context.Principal!, context.HttpContext.RequestAborted); }
                    catch (BusinessAccessException) { context.Fail("invalid_token"); }
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 401;
                    context.Response.Headers.WWWAuthenticate = $"Bearer resource_metadata=\"{MetadataUri(resource)}\", scope=\"business:discover\"";
                    return Task.CompletedTask;
                }
            };
        });
        services.AddAuthorization(options => options.AddPolicy(BusinessOAuthResource.Policy, policy =>
            policy.AddAuthenticationSchemes(BusinessOAuthResource.Scheme).RequireAuthenticatedUser()));
        services.AddMcpServer(options => options.ServerInfo = new Implementation { Name = "yeshua-business", Version = "1.0.0" })
            .WithHttpTransport(options => options.SessionMode = HttpServerSessionMode.Stateless)
            .WithListToolsHandler((_, _) => ValueTask.FromResult(new ListToolsResult { Tools = Tools() }))
            .WithCallToolHandler(async (context, ct) =>
            {
                var http = context.Services!.GetRequiredService<IHttpContextAccessor>().HttpContext!;
                var receiver = context.Services!.GetRequiredService<BusinessMcpReceiver>();
                var args = JsonSerializer.SerializeToElement(context.Params?.Arguments);
                object result;
                try
                {
                    var tool = Tools().SingleOrDefault(t => t.Name == context.Params!.Name);
                    if (tool is null) return Error("unknown_tool");
                    if (args.ValueKind != JsonValueKind.Object ||
                        !JsonSchema.FromText(tool.InputSchema.GetRawText()).Evaluate(JsonNode.Parse(args.GetRawText())).IsValid)
                        return Error("invalid_arguments");
                    result = context.Params!.Name switch
                    {
                        "yeshua_business_applications" => await receiver.ApplicationsAsync(http.User, ct),
                        "yeshua_business_operations" => await receiver.OperationsAsync(http.User, args.GetProperty("application").GetString(), ct),
                        "yeshua_business_execute" => await receiver.ExecuteAsync(http.User,
                            new(args.GetProperty("application").GetString()!, args.GetProperty("operation").GetString()!, args.GetProperty("parameters")), ct),
                        _ => throw new BusinessAccessException("unknown_tool")
                    };
                }
                catch (BusinessAccessException e) { return Error(e.Message); }
                catch (Exception e) when (e is KeyNotFoundException or InvalidOperationException or JsonException)
                { return Error("invalid_arguments"); }
                catch (Exception) { return Error("service_unavailable_outcome_unknown"); }
                var json = JsonSerializer.Serialize(result, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return new CallToolResult { Content = [new TextContentBlock { Text = json }],
                    IsError = result is BusinessResult execution && execution.Outcome is not ("completed" or "accepted") };
            });
        return services;
    }

    public static void MapCentralBusinessMcp(this WebApplication app)
    {
        var resource = app.Services.GetRequiredService<BusinessOAuthResource>();
        // Resolve mandatory security adapters before exposing even discovery.
        using (var scope = app.Services.CreateScope()) scope.ServiceProvider.GetRequiredService<BusinessMcpReceiver>();
        app.Use(async (context, next) =>
        {
            if (context.Request.Path == resource.Resource.AbsolutePath)
            {
                var origin = context.Request.Headers.Origin;
                if (origin.Count > 0 && (origin.Count != 1 || origin[0] != resource.Resource.GetLeftPart(UriPartial.Authority)))
                { context.Response.StatusCode = 403; return; }
                if (context.Request.ContentLength > 131072)
                { context.Response.StatusCode = 413; return; }
                var bodyLimit = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
                if (bodyLimit is { IsReadOnly: false }) bodyLimit.MaxRequestBodySize = 131072;
            }
            await next(context);
        });
        app.MapGet(new Uri(MetadataUri(resource)).AbsolutePath, (HttpContext context) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            return Results.Json(resource.Metadata());
        }).AllowAnonymous();
        app.MapMcp(resource.Resource.AbsolutePath).RequireAuthorization(BusinessOAuthResource.Policy);
    }
    private static string MetadataUri(BusinessOAuthResource resource) =>
        resource.Resource.GetLeftPart(UriPartial.Authority) + "/.well-known/oauth-protected-resource" + resource.Resource.AbsolutePath;
    private static CallToolResult Error(string code) => new()
        { IsError = true, Content = [new TextContentBlock { Text = JsonSerializer.Serialize(new { error = code }) }] };
    private static List<Tool> Tools() =>
    [
        Tool("yeshua_business_applications", "Aplicativos de negocio autorizados para esta delegacao.", """{"type":"object","properties":{},"additionalProperties":false}"""),
        Tool("yeshua_business_operations", "Operacoes autorizadas e contratos completos do aplicativo.", """{"type":"object","properties":{"application":{"type":"string"}},"required":["application"],"additionalProperties":false}"""),
        Tool("yeshua_business_execute", "Executa um Command autorizado. accepted significa somente aceite, nunca conclusao. Nao repetir automaticamente em timeout.", """{"type":"object","properties":{"application":{"type":"string"},"operation":{"type":"string"},"parameters":{"type":"object"}},"required":["application","operation","parameters"],"additionalProperties":false}""")
    ];
    private static Tool Tool(string name, string description, string schema) => new()
        { Name = name, Description = description, InputSchema = JsonDocument.Parse(schema).RootElement.Clone(),
            Annotations = new ToolAnnotations { ReadOnlyHint = name != "yeshua_business_execute",
                DestructiveHint = name == "yeshua_business_execute", IdempotentHint = name != "yeshua_business_execute" } };
}
