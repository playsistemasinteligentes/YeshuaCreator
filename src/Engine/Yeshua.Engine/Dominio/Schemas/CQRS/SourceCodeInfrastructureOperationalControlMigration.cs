using Migration.Dominio;
using System.Linq;
using System.Text;

namespace Dominio.Schemas.CQRS;

public sealed class SourceCodeInfrastructureOperationalControlStateMigration : SourceCodeBase
{
    private readonly Migration.MigrationBase? _migration;

    public SourceCodeInfrastructureOperationalControlStateMigration(
        Migration.MigrationBase? migration = null)
    {
        _migration = migration;
    }

    protected override StringBuilder GenerateCode()
    {
        var domainTrackingMaskMethods = GenerateDomainTrackingMaskMethods();

        return new StringBuilder(
            $$"""
            using Dominio.Interfaces;
            using Dominio.Entitys;

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
                DateTimeOffset? ExpiresAtUtc)
            {
                public string? Field { get; init; }
            }

            public readonly record struct OperationalLoggingContext(
                string? Component,
                string? Operation,
                string? Entity,
                string? RecordId)
            {
                public string? Field { get; init; }
            }

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
                IOperationalTelemetryPolicy,
                IDomainTrackingPolicy
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
                    context.RecordId,
                    context.Field);
            }

            private OperationalLoggingDecision Evaluate(
                string? component,
                string? operation,
                string? entity,
                string? recordId,
                string? field = null)
            {
                return Evaluate(Current, component, operation, entity, recordId, field, true);
            }

            private OperationalLoggingDecision Evaluate(
                OperationalLoggingPolicy policy,
                string? component,
                string? operation,
                string? entity,
                string? recordId,
                string? field,
                bool useDefault)
            {
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
                            !Matches(candidate.RecordId, recordId) ||
                            !Matches(candidate.Field, field))
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

                    if (!useDefault && target is null)
                    {
                        return new OperationalLoggingDecision(
                            false,
                            "None",
                            "D0",
                            null);
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

                OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
                    string component,
                    string? operation,
                    string? entity,
                    string? recordId,
                    string? field)
                {
                var decision = Evaluate(
                    component,
                    operation,
                    entity,
                    recordId,
                    field);
                    return new OperationalTelemetryDecision(
                        decision.Enabled,
                        decision.Level,
                        decision.Depth);
                }

            {{domainTrackingMaskMethods}}

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
                    if (!string.IsNullOrWhiteSpace(target.Field)) score += 16;
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

    private string GenerateDomainTrackingMaskMethods()
    {
        var sb = new StringBuilder();

        sb.AppendLine("                public ulong GetMask(");
        sb.AppendLine("                    string entity,");
        sb.AppendLine("                    string? operation = null,");
        sb.AppendLine("                    string? recordId = null)");
        sb.AppendLine("                {");
        sb.AppendLine("                    var policy = Current;");
        sb.AppendLine("                    if (policy.Targets.Count == 0)");
        sb.AppendLine("                        return 0UL;");
        sb.AppendLine("                    if (!HasDomainTrackingTargets(policy))");
        sb.AppendLine("                        return 0UL;");
        sb.AppendLine();

        if (_migration is null || !_migration.Entitys.Any())
        {
            sb.AppendLine("                    return 0UL;");
            sb.AppendLine("                }");
            return sb.ToString();
        }

        sb.AppendLine("                    return entity switch");
        sb.AppendLine("                    {");
        foreach (var entity in _migration.Entitys)
        {
            sb.AppendLine($"                        \"{entity.EntityName}\" => Get{entity.EntityName}Mask(policy, operation, recordId),");
        }
        sb.AppendLine("                        _ => 0UL");
        sb.AppendLine("                    };");
        sb.AppendLine("                }");
        sb.AppendLine();

        foreach (var entity in _migration.Entitys)
        {
            var fields = entity.AddColumns
                .Where(column => !column.IsBackEndField)
                .Take(64)
                .ToList();

            sb.AppendLine($"                private ulong Get{entity.EntityName}Mask(");
            sb.AppendLine("                    OperationalLoggingPolicy policy,");
            sb.AppendLine("                    string? operation,");
            sb.AppendLine("                    string? recordId)");
            sb.AppendLine("                {");
            sb.AppendLine("                    ulong mask = 0UL;");
            foreach (var field in fields)
            {
                sb.AppendLine($"                    if (DomainFieldTracked(policy, \"{entity.EntityName}\", operation, recordId, \"{field.Name}\"))");
                sb.AppendLine($"                        mask |= {entity.EntityName}TrackingFields.{field.Name};");
            }
            sb.AppendLine("                    return mask;");
            sb.AppendLine("                }");
            sb.AppendLine();
        }

        sb.AppendLine("                private bool DomainFieldTracked(");
        sb.AppendLine("                    OperationalLoggingPolicy policy,");
        sb.AppendLine("                    string entity,");
        sb.AppendLine("                    string? operation,");
        sb.AppendLine("                    string? recordId,");
        sb.AppendLine("                    string field)");
        sb.AppendLine("                {");
        sb.AppendLine("                    var decision = Evaluate(");
        sb.AppendLine("                        policy,");
        sb.AppendLine("                        \"DomainTracker\",");
        sb.AppendLine("                        operation,");
        sb.AppendLine("                        entity,");
        sb.AppendLine("                        recordId,");
        sb.AppendLine("                        field,");
        sb.AppendLine("                        false);");
        sb.AppendLine();
        sb.AppendLine("                    return decision.MatchedTarget is { } target &&");
        sb.AppendLine("                           string.Equals(target.Component, \"DomainTracker\", StringComparison.OrdinalIgnoreCase) &&");
        sb.AppendLine("                           decision.Enabled &&");
        sb.AppendLine("                           !decision.Depth.Equals(\"D0\", StringComparison.OrdinalIgnoreCase);");
        sb.AppendLine("                }");
        sb.AppendLine();
        sb.AppendLine("                private static bool HasDomainTrackingTargets(OperationalLoggingPolicy policy)");
        sb.AppendLine("                {");
        sb.AppendLine("                    var now = DateTimeOffset.UtcNow;");
        sb.AppendLine("                    foreach (var target in policy.Targets)");
        sb.AppendLine("                    {");
        sb.AppendLine("                        if (target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)");
        sb.AppendLine("                            continue;");
        sb.AppendLine("                        if (!string.Equals(target.Component, \"DomainTracker\", StringComparison.OrdinalIgnoreCase))");
        sb.AppendLine("                            continue;");
        sb.AppendLine("                        if (string.Equals(target.Level, \"None\", StringComparison.OrdinalIgnoreCase))");
        sb.AppendLine("                            continue;");
        sb.AppendLine("                        if (string.Equals(target.Depth, \"D0\", StringComparison.OrdinalIgnoreCase))");
        sb.AppendLine("                            continue;");
        sb.AppendLine();
        sb.AppendLine("                        return true;");
        sb.AppendLine("                    }");
        sb.AppendLine();
        sb.AppendLine("                    return false;");
        sb.AppendLine("                }");

        return sb.ToString();
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
