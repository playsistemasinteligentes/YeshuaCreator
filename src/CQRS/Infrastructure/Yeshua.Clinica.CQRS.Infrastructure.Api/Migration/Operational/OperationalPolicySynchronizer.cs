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
    private readonly IRuntimeIdentityProvider _identityProvider;
    private readonly ILogger<OperationalPolicySynchronizer> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;
    private readonly TimeSpan _refreshInterval;
    private readonly bool _enabled;
    private bool _centralAvailable = true;

    public OperationalPolicySynchronizer(
        OperationalLoggingPolicyState state,
        IRuntimeIdentityProvider identityProvider,
        IConfiguration configuration,
        ILogger<OperationalPolicySynchronizer> logger)
    {
        _state = state;
        _identityProvider = identityProvider;
        _logger = logger;
        _endpoint = (configuration["OperationalControl:Endpoint"] ?? "http://localhost:5728")
            .TrimEnd('/');
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
            var application = _identityProvider.Current.Application;
            var environment = _identityProvider.Current.Environment;
            var revision = Uri.EscapeDataString(_state.Current.Revision);
            var url = $"{_endpoint}/api/operational-control/{Uri.EscapeDataString(application)}/{Uri.EscapeDataString(environment)}?currentRevision={revision}";
            using var response = await _httpClient.GetAsync(url, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                MarkCentralAvailable();
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                MarkCentralUnavailable(
                    $"Operational control returned HTTP {(int)response.StatusCode}.");
                return;
            }

            var policy = await response.Content.ReadFromJsonAsync(
                OperationalLoggingJsonContext.Default.OperationalLoggingPolicy,
                cancellationToken);
            if (policy is null)
            {
                MarkCentralUnavailable("Operational control returned an empty policy.");
                return;
            }

            _state.Replace(policy);
            MarkCentralAvailable();
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception exception)
        {
            MarkCentralUnavailable(exception.Message);
        }
    }

    private void MarkCentralUnavailable(string reason)
    {
        if (!_centralAvailable)
            return;

        _centralAvailable = false;
        _logger.LogWarning(
            "Operational control unavailable. Local policy remains active. Reason={Reason}",
            reason);
    }

    private void MarkCentralAvailable()
    {
        if (_centralAvailable)
            return;

        _centralAvailable = true;
        _logger.LogInformation("Operational control connection restored.");
    }

}

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(OperationalLoggingPolicy))]
internal partial class OperationalLoggingJsonContext : JsonSerializerContext
{
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlSynchronizerMigration