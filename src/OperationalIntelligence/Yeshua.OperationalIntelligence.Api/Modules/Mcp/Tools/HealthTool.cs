using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class HealthTool : IMcpTool
{
    private readonly LokiClient _loki;
    private readonly TempoClient _tempo;
    private readonly PrometheusClient _prometheus;

    public HealthTool(
        LokiClient loki,
        TempoClient tempo,
        PrometheusClient prometheus)
    {
        _loki = loki;
        _tempo = tempo;
        _prometheus = prometheus;
    }

    public string Name => "yeshua.health";
    public string Description => "Checks the Yeshua MCP layer and telemetry backends.";
    public object InputSchema => McpToolSchemas.Empty();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var result = new
        {
            mcp = "healthy",
            loki = await _loki.CheckAsync(cancellationToken),
            tempo = await _tempo.CheckAsync(cancellationToken),
            prometheus = await _prometheus.CheckAsync(cancellationToken)
        };

        return McpToolResult.Ok("Yeshua MCP health check completed.", result);
    }
}
