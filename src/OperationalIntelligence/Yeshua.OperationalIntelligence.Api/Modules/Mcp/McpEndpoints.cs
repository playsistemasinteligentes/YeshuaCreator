using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public static class McpEndpoints
{
    public static void MapMcpEndpoints(this WebApplication app)
    {
        app.MapPost("/mcp", async (
                JsonElement request,
                McpJsonRpcRouter router,
                CancellationToken cancellationToken) =>
            await router.HandleAsync(request, cancellationToken))
            .WithName("McpJsonRpcEndpoint")
            .Accepts<JsonElement>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}
