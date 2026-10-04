namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

public sealed class LokiClient : McpHttpClientBase
{
    public LokiClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<RawTelemetryResult> QueryRangeAsync(
        string logql,
        DateTimeOffset fromUtc,
        DateTimeOffset toUtc,
        int limit,
        CancellationToken cancellationToken)
    {
        var query = QueryString(
            ("query", logql),
            ("start", ToUnixNanoseconds(fromUtc).ToString()),
            ("end", ToUnixNanoseconds(toUtc).ToString()),
            ("limit", limit.ToString()),
            ("direction", "BACKWARD"));

        return GetJsonAsync(
            "Loki",
            logql,
            $"/loki/api/v1/query_range?{query}",
            fromUtc,
            toUtc,
            cancellationToken);
    }

    public Task<string> CheckAsync(CancellationToken cancellationToken) =>
        CheckAsync("/ready", cancellationToken);

    private static long ToUnixNanoseconds(DateTimeOffset value) =>
        value.ToUnixTimeMilliseconds() * 1_000_000;
}
