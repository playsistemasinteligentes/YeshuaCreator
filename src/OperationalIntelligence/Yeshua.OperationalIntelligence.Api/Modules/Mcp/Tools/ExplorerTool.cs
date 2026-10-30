using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class ExplorerTool(ExplorerDocument document) : IMcpTool
{
    public string Name => "yeshua_explorer";
    public bool IsPublic => true;
    public string Description => "Start here to discover how to investigate Yeshua applications using available tools. Returns the exploration guide, application orientation map, purpose, architecture, examples and current capability gaps. Does not query application data or source code.";
    public object InputSchema => McpToolSchemas.Empty();

    public Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (arguments.ValueKind != JsonValueKind.Object || arguments.EnumerateObject().Any())
            return Task.FromResult(McpToolResult.Error("Explorer não recebe parâmetros nesta versão. Leia o guia para escolher a consulta seguinte."));
        return Task.FromResult(McpToolResult.Ok(document.Text));
    }
}
