// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlSynchronizerMigration
// </yeshua>

using Shared.Operational;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Yeshua.Generated.OperationalControl;

public sealed class OperationalPolicySynchronizer : BackgroundService
{
    private readonly OperationalLoggingPolicyState _state;
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;
    private readonly TimeSpan _refreshInterval;
    private readonly bool _enabled;
    private bool _applicationApiAvailable = true;

    public OperationalPolicySynchronizer(
        OperationalLoggingPolicyState state,
        IConfiguration configuration)
    {
        _state = state;
        _endpoint = configuration["OperationalControl:ApplicationApiBaseUrl"] is { Length: > 0 } baseUrl
            ? $"{baseUrl.TrimEnd('/')}/yapi/operational/logging-policy"
            : "http://localhost:7214/yapi/operational/logging-policy";
        _enabled = !bool.TryParse(
                configuration["OperationalControl:Enabled"],
                out var enabled) || enabled;
        _refreshInterval = TimeSpan.FromSeconds(
            int.TryParse(configuration["OperationalControl:RefreshSeconds"], out var seconds)
                ? Math.Max(5, seconds)
                : 30);
        _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!_enabled)
            return;

        while (!stoppingToken.IsCancellationRequested)
        {
            await RefreshAsync(stoppingToken);
            await Task.Delay(_refreshInterval, stoppingToken);
        }
    }

    private async Task RefreshAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var response = await _httpClient.GetAsync(_endpoint, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                MarkApplicationApiUnavailable(
                    $"Application API returned HTTP {(int)response.StatusCode}.");
                return;
            }

            var policy = await response.Content.ReadFromJsonAsync(
                OperationalLoggingJsonContext.Default.OperationalLoggingPolicy,
                cancellationToken);
            if (policy is null)
            {
                MarkApplicationApiUnavailable("Application API returned an empty policy.");
                return;
            }

            _state.Replace(policy);
            MarkApplicationApiAvailable();
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception exception)
        {
            MarkApplicationApiUnavailable(exception.Message);
        }
    }

    private void MarkApplicationApiUnavailable(string reason)
    {
        if (!_applicationApiAvailable)
            return;

        _applicationApiAvailable = false;
        Console.WriteLine(
            $"[OperationalControl] application API unavailable. Worker local policy remains active. Reason={reason}");
    }

    private void MarkApplicationApiAvailable()
    {
        if (_applicationApiAvailable)
            return;

        _applicationApiAvailable = true;
        Console.WriteLine("[OperationalControl] application API connection restored.");
    }

}

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(OperationalLoggingPolicy))]
internal partial class OperationalLoggingJsonContext : JsonSerializerContext
{
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlSynchronizerMigration