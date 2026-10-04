namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

public sealed class TempoClient : McpHttpClientBase
{
    public TempoClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<RawTelemetryResult> QueryAsync(
        string? traceId,
        string? traceql,
        DateTimeOffset? fromUtc,
        DateTimeOffset? toUtc,
        int limit,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(traceId))
        {
            return GetJsonAsync(
                "Tempo",
                traceId,
                $"/api/traces/{Uri.EscapeDataString(traceId)}",
                null,
                null,
                cancellationToken);
        }

        var query = QueryString(
            ("q", traceql),
            ("start", fromUtc?.ToUnixTimeSeconds().ToString()),
            ("end", toUtc?.ToUnixTimeSeconds().ToString()),
            ("limit", limit.ToString()));

        return GetJsonAsync(
            "Tempo",
            traceql ?? string.Empty,
            $"/api/search?{query}",
            fromUtc,
            toUtc,
            cancellationToken);
    }

    public Task<string> CheckAsync(CancellationToken cancellationToken) =>
        CheckAsync("/ready", cancellationToken);
}
