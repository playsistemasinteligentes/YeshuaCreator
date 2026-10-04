using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

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
        services.AddScoped<McpJsonRpcRouter>();
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
