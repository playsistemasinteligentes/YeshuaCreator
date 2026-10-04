using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class TracesQueryTool : IMcpTool
{
    private readonly TempoClient _tempo;
    private readonly McpToolArgumentReader _arguments;

    public TracesQueryTool(
        TempoClient tempo,
        McpToolArgumentReader arguments)
    {
        _tempo = tempo;
        _arguments = arguments;
    }

    public string Name => "yeshua.traces.query";
    public string Description => "Queries raw traces in Tempo by traceId or TraceQL.";
    public object InputSchema => McpToolSchemas.TracesQuery();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var traceId = _arguments.String(arguments, "traceId");
        var traceql = _arguments.String(arguments, "query");
        if (string.IsNullOrWhiteSpace(traceId) && string.IsNullOrWhiteSpace(traceql))
            return McpToolResult.Error("traceId or query is required.");

        var range = _arguments.TimeRange(arguments);
        if (string.IsNullOrWhiteSpace(traceId) && range.Error is not null)
            return McpToolResult.Error(range.Error);

        var result = await _tempo.QueryAsync(
            traceId,
            traceql,
            string.IsNullOrWhiteSpace(traceId) ? range.FromUtc : null,
            string.IsNullOrWhiteSpace(traceId) ? range.ToUtc : null,
            _arguments.Limit(arguments),
            cancellationToken);

        return McpToolResult.Ok("Raw traces query completed.", result);
    }
}
