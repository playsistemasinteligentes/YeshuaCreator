using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class ObservabilityDashboardsListTool(ObservabilityDashboardCatalog catalog) : IMcpTool
{
    public string Name => "yeshua.observability.dashboards.list";
    public string Description => "Lists the versioned Yeshua observability dashboards available for semantic and technical review. Private and read-only.";
    public object InputSchema => McpToolSchemas.Empty();

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        var result = await catalog.ListAsync(cancellationToken);
        return McpToolResult.Ok("Observability semantic catalog listed.", result);
    }
}

public sealed class ObservabilityDashboardGetTool(
    ObservabilityDashboardCatalog catalog,
    McpToolArgumentReader arguments) : IMcpTool
{
    public string Name => "yeshua.observability.dashboard.get";
    public string Description => "Returns the semantic contract, queries, units, reducers, thresholds, variables and review hints for every panel in one versioned Grafana dashboard. New panels are discovered automatically. Private and read-only.";
    public object InputSchema => McpToolSchemas.ObservabilityDashboardGet();

    public async Task<McpToolResult> CallAsync(JsonElement input, CancellationToken cancellationToken)
    {
        var uid = arguments.RequiredString(input, "uid");
        var result = await catalog.GetAsync(uid, arguments.Boolean(input, "includeRaw"), cancellationToken);
        return result is null
            ? McpToolResult.Error($"Dashboard '{uid}' was not found in the versioned catalog.")
            : McpToolResult.Ok("Observability semantic contract loaded.", result);
    }
}
