using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public static class McpEndpoints
{
    public static void MapMcpEndpoints(this WebApplication app)
    {
        if (app.Configuration.GetValue<bool?>("Mcp:Enabled") == false)
            return;

        app.MapMcp("/mcp");
        app.MapGet("/explorer", (HttpContext context, ExplorerDocument document) =>
        {
            context.Response.Headers.CacheControl = "no-cache";
            return context.Request.Query.Count == 0
                ? Results.Text(document.Text, "text/plain; charset=utf-8")
                : Results.BadRequest(new { error = "Explorer não recebe parâmetros nesta versão. Leia o guia para escolher a consulta seguinte." });
        }).AllowAnonymous().WithName("GetYeshuaExplorer");
        app.MapGet("/health", async (
            HttpContext context, McpToolRegistry tools, CancellationToken cancellationToken) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            var messages = context.Request.Query["mensagem"];
            if (messages.Count > 1 || messages.ToString().Length > 200)
                return Results.BadRequest(new { error = "Informe uma unica mensagem com ate 200 caracteres." });

            // Keep GET limited to connectivity, even when invoked through the private listener.
            var result = await tools.CallAsync("yeshua_health",
                JsonSerializer.SerializeToElement(new { }), cancellationToken);
            return Results.Json(new
            {
                tool = "yeshua_health",
                status = result.IsError == true ? "unavailable" : "ok",
                message = result.IsError == true
                    ? "Nao foi possivel confirmar a conexao com o Yeshua."
                    : "Conexao com o Yeshua confirmada.",
                received = messages.Count == 0 ? null : messages.ToString(),
                checkedAtUtc = DateTimeOffset.UtcNow
            }, statusCode: result.IsError == true
                ? StatusCodes.Status503ServiceUnavailable
                : StatusCodes.Status200OK);
        }).AllowAnonymous().WithName("GetPublicYeshuaHealth");
    }
}
