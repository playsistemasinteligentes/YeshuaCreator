using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class PublicAppExploreTool(PublicAppExplorer explorer) : IMcpTool
{
    public string Name => "yeshua_app_explore";
    public bool IsPublic => true;
    public bool IsOpenWorld => true;
    public string Description => "Discovers apps, access URLs and available screens from the live public Front catalog. With application and screen, reads only allowlisted public HTML/JavaScript so the agent can derive fields, actions and client behavior. Does not access private records or server sources.";
    public object InputSchema => new
    {
        type = "object",
        properties = new { application = new { type = "string", maxLength = 60 }, screen = new { type = "string", maxLength = 60 } },
        additionalProperties = false
    };
    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        PublicAppExploreRequest request;
        try { request = arguments.Deserialize(PublicAppExplorerJson.Default.PublicAppExploreRequest) ?? new(); }
        catch (JsonException) { return McpToolResult.Error("Informe apenas application e screen como textos."); }
        var result = await explorer.Explore(request, cancellationToken);
        return McpToolResult.Ok(JsonSerializer.Serialize(result, PublicAppExplorerJson.Default.PublicAppExploration), result);
    }
}
