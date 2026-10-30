using Microsoft.Extensions.Options;
using System.Text.Json;
using ModelContextProtocol.AspNetCore;
using ModelContextProtocol.Protocol;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;
using Yeshua.OperationalIntelligence.Api.Application;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public static class McpServiceCollectionExtensions
{
    public static IServiceCollection AddYeshuaMcp(this IServiceCollection services)
    {
        services
            .AddOptions<McpOptions>()
            .BindConfiguration(McpOptions.SectionName)
            .Validate(options => options.DefaultLimit > 0, "MCP default limit must be positive.")
            .Validate(options => options.MaxLimit > 0, "MCP max limit must be positive.")
            .Validate(options => options.MaxLimit >= options.DefaultLimit, "MCP max limit must be greater than or equal to default limit.")
            .Validate(options => options.TimeoutSeconds > 0, "MCP timeout must be positive.")
            .Validate(options => options.MaxTimeRangeHours > 0, "MCP max time range must be positive.")
            .Validate(options => options.PrivatePort is > 0 and <= 65535, "MCP private port must be valid.")
            .Validate(options => options.DatabaseQuery.MaxRows > 0, "MCP database max rows must be positive.")
            .Validate(options => options.DatabaseQuery.CommandTimeoutSeconds > 0, "MCP database timeout must be positive.")
            .Validate(options => options.DatabaseQuery.MaxSqlLength > 0, "MCP database max SQL length must be positive.")
            .Validate(options => IsAbsoluteHttpUrl(options.LokiBaseUrl), "MCP Loki URL must be absolute.")
            .Validate(options => IsAbsoluteHttpUrl(options.TempoBaseUrl), "MCP Tempo URL must be absolute.")
            .Validate(options => IsAbsoluteHttpUrl(options.PrometheusBaseUrl), "MCP Prometheus URL must be absolute.")
            .Validate(options => options.DatabaseQuery.Connections.All(IsConfiguredConnection), "MCP database connections must have a name and value.")
            .ValidateOnStart();

        services.AddHttpClient<LokiClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<McpOptions>>().Value;
            client.BaseAddress = new Uri(options.LokiBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });
        services.AddHttpClient<TempoClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<McpOptions>>().Value;
            client.BaseAddress = new Uri(options.TempoBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });
        services.AddHttpClient<PrometheusClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<McpOptions>>().Value;
            client.BaseAddress = new Uri(options.PrometheusBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });

        services.AddScoped<IMcpTool, HealthTool>();
        services.AddSingleton(new ExplorerDocument());
        services.AddScoped<IMcpTool, ExplorerTool>();
        services.AddHttpClient<PublicAppExplorer>((sp, client) =>
        {
            client.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["Mcp:PublicSiteUrl"] ?? "https://playsis.com.br/");
            client.Timeout = TimeSpan.FromSeconds(10);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false });
        services.AddScoped<IMcpTool, PublicAppExploreTool>();
        services.AddScoped<IMcpTool, DatabaseSelectTool>();
        services.AddScoped<IMcpTool, ErrorsQueryTool>();
        services.AddScoped<IMcpTool, LogSourceContextTool>();
        services.AddScoped<IMcpTool, LogsQueryTool>();
        services.AddScoped<IMcpTool, TracesQueryTool>();
        services.AddScoped<IMcpTool, MetricsQueryTool>();
        services.AddScoped<IMcpTool, SourceSearchTool>();
        services.AddScoped<McpToolArgumentReader>();
        services.AddScoped<LogSourceEvidenceExtractor>();
        services.AddScoped<LogKnowledgeReferenceResolver>();
        services.AddScoped<LogKnowledgeReferenceEnricher>();
        services.AddScoped<DatabaseReadOnlySqlGuard>();
        services.AddScoped<McpToolRegistry>();
        services.AddHttpContextAccessor();
        services.AddScoped<McpAccessPolicy>();
        services.AddOptions<McpTunnelOptions>().BindConfiguration("McpTunnel")
            .Validate(options => string.IsNullOrWhiteSpace(options.Id) ||
                (options.Id.StartsWith("tunnel_", StringComparison.Ordinal) && options.Id.Length <= 100 &&
                 !string.IsNullOrWhiteSpace(options.ApiKey)), "MCP tunnel requires its ID and a runtime API key.")
            .ValidateOnStart();
        services.AddHostedService<McpTunnelWorker>();
        services.AddMcpServer(options =>
            {
                options.ServerInfo = new Implementation { Name = "yeshua-operational-intelligence", Version = "1.0.0" };
                options.ServerInstructions = AgentTaskProtocol.Instructions;
            })
            .WithHttpTransport(options => options.SessionMode = HttpServerSessionMode.Stateless)
            .WithListToolsHandler((context, _) => ValueTask.FromResult(new ListToolsResult
            {
                Tools = context.Services!.GetRequiredService<McpToolRegistry>().List()
            }))
            .WithCallToolHandler(async (context, cancellationToken) =>
            {
                var arguments = JsonSerializer.SerializeToElement(context.Params?.Arguments);
                if (arguments.ValueKind != JsonValueKind.Object)
                    arguments = JsonSerializer.SerializeToElement(new Dictionary<string, string>());
                return await context.Services!.GetRequiredService<McpToolRegistry>()
                    .CallAsync(context.Params!.Name, arguments, cancellationToken);
            });
        return services;
    }

    private static bool IsAbsoluteHttpUrl(string value) =>
        Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
        (uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
         uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));

    private static bool IsConfiguredConnection(KeyValuePair<string, string> connection) =>
        !string.IsNullOrWhiteSpace(connection.Key) &&
        !string.IsNullOrWhiteSpace(connection.Value);
}
