using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class HostDiskUsageTool(HostDiskUsageReader reader) : IMcpTool
{
    public string Name => "yeshua.storage.usage";
    public string Description => "Returns host disk capacity, directory sizes and Docker image/volume/build-cache usage from the read-only host report. No shell commands required. Inspect timestamps, partial sections and overlapping scopes. Private, read-only; never cleans files or accepts paths.";
    public object InputSchema => McpToolSchemas.Empty();

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        try
        {
            return McpToolResult.Ok("Host disk usage report loaded.", await reader.ReadAsync(cancellationToken));
        }
        catch (Exception error) when (error is IOException or InvalidDataException or UnauthorizedAccessException or JsonException)
        {
            return McpToolResult.Error("Host disk report unavailable or invalid. Check the host collector and its read-only mount; no cleanup was performed.");
        }
    }
}
