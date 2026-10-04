using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class MetricsQueryTool : IMcpTool
{
    private readonly PrometheusClient _prometheus;
    private readonly McpToolArgumentReader _arguments;

    public MetricsQueryTool(
        PrometheusClient prometheus,
        McpToolArgumentReader arguments)
    {
        _prometheus = prometheus;
        _arguments = arguments;
    }

    public string Name => "yeshua.metrics.query";
    public string Description => "Queries raw Prometheus metrics using PromQL.";
    public object InputSchema => McpToolSchemas.MetricsQuery();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var promql = _arguments.String(arguments, "query");
        if (string.IsNullOrWhiteSpace(promql))
            return McpToolResult.Error("query is required.");

        var range = _arguments.TimeRange(arguments);
        if (range.Error is not null)
            return McpToolResult.Error(range.Error);

        var result = await _prometheus.QueryRangeAsync(
            promql,
            range.FromUtc,
            range.ToUtc,
            _arguments.String(arguments, "step") ?? "60s",
            cancellationToken);

        return McpToolResult.Ok("Raw metrics query completed.", result);
    }
}
