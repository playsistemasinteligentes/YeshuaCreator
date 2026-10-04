using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

public abstract class McpHttpClientBase
{
    private readonly HttpClient _httpClient;

    protected McpHttpClientBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<RawTelemetryResult> GetJsonAsync(
        string source,
        string query,
        string path,
        DateTimeOffset? fromUtc,
        DateTimeOffset? toUtc,
        CancellationToken cancellationToken)
    {
        try
        {
            using var response = await _httpClient.GetAsync(path, cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            JsonElement? data = null;
            if (!string.IsNullOrWhiteSpace(body))
            {
                using var document = JsonDocument.Parse(body);
                data = document.RootElement.Clone();
            }

            var warnings = response.IsSuccessStatusCode
                ? Array.Empty<string>()
                : [$"{source} returned HTTP {(int)response.StatusCode}."];

            return new RawTelemetryResult(
                source,
                query,
                fromUtc,
                toUtc,
                (int)response.StatusCode,
                data,
                warnings);
        }
        catch (Exception exception)
        {
            return new RawTelemetryResult(
                source,
                query,
                fromUtc,
                toUtc,
                null,
                null,
                [$"{source} request failed: {exception.Message}"]);
        }
    }

    protected async Task<string> CheckAsync(
        string path,
        CancellationToken cancellationToken)
    {
        try
        {
            using var response = await _httpClient.GetAsync(path, cancellationToken);
            return response.IsSuccessStatusCode
                ? "healthy"
                : $"unhealthy: HTTP {(int)response.StatusCode}";
        }
        catch (Exception exception)
        {
            return $"unreachable: {exception.Message}";
        }
    }

    protected static string QueryString(
        params (string Key, string? Value)[] values)
    {
        var parts = values
            .Where(item => !string.IsNullOrWhiteSpace(item.Value))
            .Select(item =>
                $"{Uri.EscapeDataString(item.Key)}={Uri.EscapeDataString(item.Value!)}");

        return string.Join("&", parts);
    }
}
