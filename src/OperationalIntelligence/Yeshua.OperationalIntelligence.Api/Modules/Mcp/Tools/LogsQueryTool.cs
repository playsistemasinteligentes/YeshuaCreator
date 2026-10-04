using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class LogsQueryTool : IMcpTool
{
    private readonly LokiClient _loki;
    private readonly McpToolArgumentReader _arguments;
    private readonly LogKnowledgeReferenceEnricher _knowledgeReferences;

    public LogsQueryTool(
        LokiClient loki,
        McpToolArgumentReader arguments,
        LogKnowledgeReferenceEnricher knowledgeReferences)
    {
        _loki = loki;
        _arguments = arguments;
        _knowledgeReferences = knowledgeReferences;
    }

    public string Name => "yeshua.logs.query";
    public string Description => "Queries raw operational logs in Loki using LogQL or safe filters.";
    public object InputSchema => McpToolSchemas.LogsQuery();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var range = _arguments.TimeRange(arguments);
        if (range.Error is not null)
            return McpToolResult.Error(range.Error);

        var logql = _arguments.String(arguments, "query");
        if (string.IsNullOrWhiteSpace(logql))
        {
            logql = LogQueryBuilder.Build(
                _arguments.String(arguments, "application"),
                _arguments.String(arguments, "environment"),
                _arguments.String(arguments, "text"),
                errorsOnly: false);
        }

        var result = await _loki.QueryRangeAsync(
            logql,
            range.FromUtc,
            range.ToUtc,
            _arguments.Limit(arguments),
            cancellationToken);

        var structuredContent = await _knowledgeReferences.BuildStructuredContentAsync(
            arguments,
            result,
            cancellationToken);

        return McpToolResult.Ok("Raw logs query completed.", structuredContent);
    }
}
