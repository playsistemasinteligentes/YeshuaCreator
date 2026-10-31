using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Endpoints;

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
            var format = "text";
            try
            {
                format = PublicReadQuery.Format(context.Request.Query);
                if (context.Request.Query.Any(pair => !PublicReadQuery.IsAttribution(pair.Key) &&
                    (pair.Value.Count != 1 || pair.Key is not ("application" or "screen" or "format"))))
                    return PublicReadQuery.Error("Use apenas application, screen e format, com um valor cada.", format);
                var result = await explorer.Explore(new(application, screen), cancellationToken);
                return PublicReadQuery.Reply(JsonSerializer.Serialize(result, PublicAppExplorerJson.Default.PublicAppExploration), format);
            }
            catch (ArgumentException exception) { return PublicReadQuery.Error(exception.Message, format); }
            catch (Exception exception) when (exception is HttpRequestException or JsonException or IOException or OperationCanceledException && !cancellationToken.IsCancellationRequested)
            {
                return PublicReadQuery.Error("Não foi possível ler a interface pública agora. Nenhum dado de conta foi consultado.", format, 502);
            }
        }).AllowAnonymous().WithName("ExplorePublicYeshuaApp");
        app.MapGet("/explorer", (HttpContext context, ExplorerDocument document) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            var format = "text";
            try
            {
                format = PublicReadQuery.Format(context.Request.Query);
                return context.Request.Query.All(pair => PublicReadQuery.IsAttribution(pair.Key) || pair.Key == "format" ||
                    (pair.Key == "refresh" && pair.Value.Count == 1 && pair.Value.ToString().Length <= 64))
                    ? format == "json" ? PublicReadQuery.Reply(JsonSerializer.Serialize(document.Text), format)
                        : Results.Text(document.Text, "text/plain; charset=utf-8")
                    : PublicReadQuery.Error("Explorer aceita somente refresh (até 64 caracteres), format e parâmetros utm de navegação. Consulte o guia para escolher a pesquisa seguinte.", format);
            }
            catch (ArgumentException exception) { return PublicReadQuery.Error(exception.Message, format); }
        }).AllowAnonymous().WithName("GetYeshuaExplorer");
        app.MapGet("/health", async (
            HttpContext context, McpToolRegistry tools, CancellationToken cancellationToken) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            string format;
            try { format = PublicReadQuery.Format(context.Request.Query); }
            catch (ArgumentException exception) { return PublicReadQuery.Error(exception.Message, "text"); }
            var messages = context.Request.Query["mensagem"];
            if (messages.Count > 1 || messages.ToString().Length > 200)
                return PublicReadQuery.Error("Informe uma unica mensagem com ate 200 caracteres.", format);

            // Keep GET limited to connectivity, even when invoked through the private listener.
            var result = await tools.CallAsync("yeshua_health",
                JsonSerializer.SerializeToElement(new { }), cancellationToken);
            return PublicReadQuery.Reply(JsonSerializer.Serialize(new
            {
                tool = "yeshua_health",
                status = result.IsError == true ? "unavailable" : "ok",
                message = result.IsError == true
                    ? "Nao foi possivel confirmar a conexao com o Yeshua."
                    : "Conexao com o Yeshua confirmada.",
                received = messages.Count == 0 ? null : messages.ToString(),
                checkedAtUtc = DateTimeOffset.UtcNow
            }), format, statusCode: result.IsError == true
                ? StatusCodes.Status503ServiceUnavailable
                : StatusCodes.Status200OK);
        }).AllowAnonymous().WithName("GetPublicYeshuaHealth");
    }
}
