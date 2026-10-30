using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class SourceSearchTool(SourceSearch search) : IMcpTool
{
    public string Name => "yeshua.source.search";
    public string Description => "Explore indexed applications/builds, original DSL, metadata, screens/actions and source snippets. Reuse next.arguments to preserve build and filters. Text matches are candidates, not runtime facts. Same read-only query as GET/POST api/source-context/search.";
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
        return McpToolResult.Ok("Evidências do snapshot indexado; use next.arguments para continuar.", response);
    }
}
