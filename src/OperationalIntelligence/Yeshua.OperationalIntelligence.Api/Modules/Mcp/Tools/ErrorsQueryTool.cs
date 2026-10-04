using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class ErrorsQueryTool : IMcpTool
{
    private readonly LokiClient _loki;
    private readonly McpToolArgumentReader _arguments;
    private readonly LogKnowledgeReferenceEnricher _knowledgeReferences;

    public ErrorsQueryTool(
        LokiClient loki,
        McpToolArgumentReader arguments,
        LogKnowledgeReferenceEnricher knowledgeReferences)
    {
        _loki = loki;
        _arguments = arguments;
        _knowledgeReferences = knowledgeReferences;
    }

    public string Name => "yeshua.errors.query";
    public string Description => "Queries operational error logs in Loki with a default error/failure filter.";
    public object InputSchema => McpToolSchemas.ErrorsQuery();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var range = _arguments.TimeRange(arguments);
        if (range.Error is not null)
            return McpToolResult.Error(range.Error);

        var logql = LogQueryBuilder.Build(
            _arguments.String(arguments, "application"),
            _arguments.String(arguments, "environment"),
            _arguments.String(arguments, "text"),
            errorsOnly: true);

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

        return McpToolResult.Ok("Raw error logs query completed.", structuredContent);
    }
}
