using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class LogSourceContextTool : IMcpTool
{
    private readonly LogKnowledgeReferenceResolver _resolver;
    private readonly McpToolArgumentReader _arguments;

    public LogSourceContextTool(
        LogKnowledgeReferenceResolver resolver,
        McpToolArgumentReader arguments)
    {
        _resolver = resolver;
        _arguments = arguments;
    }

    public string Name => "yeshua.logs.source_context";
    public string Description => "Extracts source clues from raw logs and returns related indexed source files for bug analysis.";
    public object InputSchema => McpToolSchemas.LogSourceContext();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var logs = ReadLogs(arguments);
        if (logs.Count == 0)
            return McpToolResult.Error("log or logs is required.");

        try
        {
            var result = await _resolver.ResolveAsync(
                _arguments.RequiredString(arguments, "application"),
                _arguments.String(arguments, "version"),
                logs,
                _arguments.Boolean(arguments, "includeContent", defaultValue: true),
                _arguments.ClampedInteger(arguments, "maxSignals", 12, 1, 50),
                _arguments.ClampedInteger(arguments, "maxFiles", 5, 1, 20),
                _arguments.ClampedInteger(arguments, "maxContentChars", 30_000, 1_000, 200_000),
                _arguments.Integer(arguments, "maxDepth"),
                _arguments.Integer(arguments, "maxResults"),
                cancellationToken);

            return McpToolResult.Ok("Source context inferred from logs.", result);
        }
        catch (KeyNotFoundException exception)
        {
            return McpToolResult.Error(exception.Message);
        }
    }

    private static IReadOnlyList<string> ReadLogs(JsonElement arguments)
    {
        var logs = new List<string>();
        if (arguments.TryGetProperty("log", out var log) &&
            log.ValueKind != JsonValueKind.Null)
        {
            logs.Add(log.ValueKind == JsonValueKind.String
                ? log.GetString() ?? string.Empty
                : log.GetRawText());
        }

        if (arguments.TryGetProperty("logs", out var entries) &&
            entries.ValueKind == JsonValueKind.Array)
        {
            foreach (var entry in entries.EnumerateArray())
            {
                logs.Add(entry.ValueKind == JsonValueKind.String
                    ? entry.GetString() ?? string.Empty
                    : entry.GetRawText());
            }
        }

        return logs.Where(log => !string.IsNullOrWhiteSpace(log)).ToArray();
    }
}

public sealed record LogSourceContextResponse(
    IReadOnlyList<LogSourceSignal> ExtractedSignals,
    object? Context,
    IReadOnlyList<LogSourceFileContent> SourceContents,
    IReadOnlyList<string> Warnings);

public sealed record LogSourceFileContent(
    string File,
    int Score,
    IReadOnlyList<string> Reasons,
    IReadOnlyList<int> RelevantLines,
    string ArtifactKind,
    string SourceRole,
    string Ownership,
    bool Editable,
    string SourceOfTruth,
    string Content,
    bool Truncated);

