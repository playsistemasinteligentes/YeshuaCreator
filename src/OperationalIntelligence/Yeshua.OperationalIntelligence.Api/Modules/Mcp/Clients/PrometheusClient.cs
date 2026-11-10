namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

public sealed class PrometheusClient : McpHttpClientBase
{
    public PrometheusClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<RawTelemetryResult> QueryRangeAsync(
        string promql,
        DateTimeOffset fromUtc,
        DateTimeOffset toUtc,
        string step,
        CancellationToken cancellationToken)
    {
        var query = QueryString(
            ("query", promql),
            ("start", fromUtc.ToUnixTimeSeconds().ToString()),
            ("end", toUtc.ToUnixTimeSeconds().ToString()),
            ("step", string.IsNullOrWhiteSpace(step) ? "60s" : step));

        return GetJsonAsync(
            "Prometheus",
            promql,
            $"/api/v1/query_range?{query}",
            fromUtc,
            toUtc,
            cancellationToken);
    }

    public Task<RawTelemetryResult> QueryInstantAsync(
        string promql,
        DateTimeOffset atUtc,
        CancellationToken cancellationToken)
    {
        var query = QueryString(
            ("query", promql),
            ("time", atUtc.ToUnixTimeSeconds().ToString()));

        return GetJsonAsync(
            "Prometheus",
            promql,
            $"/api/v1/query?{query}",
            atUtc,
            atUtc,
            cancellationToken);
    }

    public Task<string> CheckAsync(CancellationToken cancellationToken) =>
        CheckAsync("/-/ready", cancellationToken);
}
