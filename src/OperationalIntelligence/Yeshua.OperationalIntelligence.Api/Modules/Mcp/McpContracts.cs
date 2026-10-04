using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed record McpContentItem(string Type, string Text)
{
    public static McpContentItem TextItem(string text) => new("text", text);
}

public sealed record McpToolResult(
    IReadOnlyList<McpContentItem> Content,
    object? StructuredContent = null,
    bool IsError = false)
{
    public static McpToolResult Ok(string text, object? structuredContent = null) =>
        new([McpContentItem.TextItem(text)], structuredContent);

    public static McpToolResult Error(string text, object? structuredContent = null) =>
        new([McpContentItem.TextItem(text)], structuredContent, true);
}

public sealed record RawTelemetryResult(
    string Source,
    string Query,
    DateTimeOffset? FromUtc,
    DateTimeOffset? ToUtc,
    int? HttpStatusCode,
    JsonElement? Data,
    IReadOnlyList<string> Warnings);

public sealed record McpToolDescriptor(
    string Name,
    string Description,
    object InputSchema);

public interface IMcpTool
{
    string Name { get; }
    string Description { get; }
    object InputSchema { get; }
    Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken);
}
