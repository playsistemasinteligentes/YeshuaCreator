using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class SourceSearchTool(SourceSearch search) : IMcpTool
{
    public string Name => "yeshua.source.search";
    public string Description => "Explore indexed applications/builds, original DSL, metadata, screens/actions and source snippets. Open next.url directly for GET, or reuse next.arguments for MCP/POST, preserving build and filters. Text matches are candidates, not runtime facts.";
    public object InputSchema => McpToolSchemas.SourceSearch();
    public bool IsPublic => true;

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        SourceExplorationRequest request;
        try
        {
            request = arguments.Deserialize(SourceExplorationJson.Default.SourceExplorationRequest)
                ?? throw new ArgumentException("Informe os filtros da pesquisa.");
        }
        catch (JsonException) { throw new ArgumentException("Filtros desconhecidos ou tipos inválidos. Consulte o schema de yeshua_source_search."); }
        var response = await search.SearchAsync(request, cancellationToken);
        return McpToolResult.Ok("Evidências do snapshot indexado; abra next.url pelo GET ou use next.arguments pelo MCP.", response);
    }
}
