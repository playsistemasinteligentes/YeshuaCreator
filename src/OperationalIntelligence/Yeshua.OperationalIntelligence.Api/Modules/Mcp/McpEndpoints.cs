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
        app.MapGet("/explorer/apps", async (HttpContext context, PublicAppExplorer explorer,
            string? application, string? screen, CancellationToken cancellationToken) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            if (context.Request.Query.Any(pair => pair.Value.Count != 1 || pair.Key is not ("application" or "screen")))
                return Results.BadRequest(new { error = "Use apenas application e screen, com um valor cada." });
            try
            {
                var result = await explorer.Explore(new(application, screen), cancellationToken);
                return Results.Json(result, PublicAppExplorerJson.Default.PublicAppExploration);
            }
            catch (ArgumentException exception) { return Results.BadRequest(new { error = exception.Message }); }
            catch (Exception exception) when (exception is HttpRequestException or JsonException or IOException or OperationCanceledException && !cancellationToken.IsCancellationRequested)
            {
                return Results.Json(new { error = "Não foi possível ler a interface pública agora. Nenhum dado de conta foi consultado." }, statusCode: 502);
            }
        }).AllowAnonymous().WithName("ExplorePublicYeshuaApp");
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
