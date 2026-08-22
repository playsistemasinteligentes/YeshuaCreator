using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS;

public sealed class SourceCodeInfrastructureOperationalControlStateMigration : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder(
            """
            using Dominio.Interfaces;

            namespace Yeshua.Generated.OperationalControl;

            public sealed record OperationalLoggingPolicy(
                string Application,
                string Environment,
                string Revision,
                string DefaultLevel,
                string DefaultDepth,
                IReadOnlyList<DiagnosticTarget> Targets,
                DateTimeOffset UpdatedAtUtc,
                string Source);

            public sealed record DiagnosticTarget(
                string? Component,
                string? Operation,
                string? Entity,
                string? RecordId,
                string Level,
                string Depth,
                DateTimeOffset? ExpiresAtUtc);

            public readonly record struct OperationalLoggingContext(
                string? Component,
                string? Operation,
                string? Entity,
                string? RecordId);

            public readonly record struct OperationalLoggingDecision(
                bool Enabled,
                string Level,
                string Depth,
                DiagnosticTarget? MatchedTarget);

            public interface IOperationalLoggingPolicyAccessor
            {
                OperationalLoggingPolicy Current { get; }
                OperationalLoggingDecision Evaluate(OperationalLoggingContext context);
            }

            public sealed class OperationalLoggingPolicyState :
                IOperationalLoggingPolicyAccessor,
                IOperationalTelemetryPolicy
            {
                private OperationalLoggingPolicy _current;

                public OperationalLoggingPolicyState(string application, string environment)
                {
                    _current = new OperationalLoggingPolicy(
                        application,
                        environment,
                        "LOCAL-BASELINE",
                        "Information",
                        "D0",
                        [],
                        DateTimeOffset.UtcNow,
                        "LocalBaseline");
                }

                public OperationalLoggingPolicy Current => Volatile.Read(ref _current);

                public void Replace(OperationalLoggingPolicy policy)
                {
                    if (!string.Equals(
                            policy.Application,
                            Current.Application,
                            StringComparison.OrdinalIgnoreCase) ||
                        !string.Equals(
                            policy.Environment,
                            Current.Environment,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException(
                            $"Policy for '{policy.Application}/{policy.Environment}' cannot replace policy for '{Current.Application}/{Current.Environment}'.");
                    }

                    Interlocked.Exchange(ref _current, policy);
                }

            public OperationalLoggingDecision Evaluate(OperationalLoggingContext context)
            {
                return Evaluate(
                    context.Component,
                    context.Operation,
                    context.Entity,
                    context.RecordId);
            }

            private OperationalLoggingDecision Evaluate(
                string? component,
                string? operation,
                string? entity,
                string? recordId)
            {
                var policy = Current;
                DiagnosticTarget? target = null;
                if (policy.Targets.Count > 0)
                {
                    var now = DateTimeOffset.UtcNow;
                    var highestSpecificity = -1;
                    foreach (var candidate in policy.Targets)
                    {
                        if ((candidate.ExpiresAtUtc is not null && candidate.ExpiresAtUtc <= now) ||
                            !Matches(candidate.Component, component) ||
                            !Matches(candidate.Operation, operation) ||
                            !Matches(candidate.Entity, entity) ||
                            !Matches(candidate.RecordId, recordId))
                        {
                            continue;
                        }

                        var specificity = Specificity(candidate);
                        if (specificity <= highestSpecificity)
                            continue;

                        highestSpecificity = specificity;
                        target = candidate;
                    }
                }

                    var level = target?.Level ?? policy.DefaultLevel;
                    var depth = target?.Depth ?? policy.DefaultDepth;
                    return new OperationalLoggingDecision(
                        !level.Equals("None", StringComparison.OrdinalIgnoreCase),
                        level,
                        depth,
                        target);
                }

                OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
                    string component,
                    string? operation,
                    string? entity,
                    string? recordId)
                {
                var decision = Evaluate(
                    component,
                    operation,
                    entity,
                    recordId);
                    return new OperationalTelemetryDecision(
                        decision.Enabled,
                        decision.Level,
                        decision.Depth);
                }

                private static bool Matches(string? expected, string? actual)
                {
                    return string.IsNullOrWhiteSpace(expected) ||
                           string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase);
                }

                private static int Specificity(DiagnosticTarget target)
                {
                    var score = 0;
                    if (!string.IsNullOrWhiteSpace(target.Component)) score++;
                    if (!string.IsNullOrWhiteSpace(target.Operation)) score += 2;
                    if (!string.IsNullOrWhiteSpace(target.Entity)) score += 4;
                    if (!string.IsNullOrWhiteSpace(target.RecordId)) score += 8;
                    return score;
                }
            }
            """);
    }

    protected override StringBuilder GenerateCustonCode() => new();

    public void WriteGeneratedCode(string filePath)
    {
        WriteCode(GenerateCode(), filePath, false, false);
    }
}

public sealed class SourceCodeInfrastructureOperationalControlSynchronizerMigration : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder(
            """
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
            }
            """);
    }

    protected override StringBuilder GenerateCustonCode() => new();

    public void WriteGeneratedCode(string filePath)
    {
        WriteCode(GenerateCode(), filePath, false, false);
    }
}
