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
            using System.Collections.Concurrent;

            namespace Yeshua.Generated.OperationalControl;

            public sealed record OperationalLoggingPolicy(
                string Application,
                string Environment,
                string Revision,
                string DefaultLevel,
                string DefaultDepth,
                IReadOnlyList<DiagnosticTarget> Targets,
                DateTimeOffset UpdatedAtUtc,
                string Source)
            {
                public IReadOnlyList<DiagnosticPolicyAuditEntry> DiagnosticAudit { get; init; } = [];
            }

            public sealed record DiagnosticPolicyAuditEntry(
                string DiagnosticSessionId,
                string Action,
                DateTimeOffset OccurredAtUtc,
                string RequestedBy,
                string ApprovedBy,
                string Justification);

            public sealed record OperationalLoggingPolicyUpdate(
                string DefaultLevel,
                string DefaultDepth,
                IReadOnlyList<DiagnosticTarget>? Targets);

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
                public string? OperationId { get; init; }
                public string? DiagnosticSessionId { get; init; }
                public string? RequestedBy { get; init; }
                public string? ApprovedBy { get; init; }
                public string? Justification { get; init; }
                public DateTimeOffset? StartsAtUtc { get; init; }
                public int? MaximumCaptures { get; init; }
                public IReadOnlyList<string>? AuthorizedFields { get; init; }
            }

            public readonly record struct OperationalLoggingContext(
                string? Component,
                string? Operation,
                string? Entity,
                string? RecordId)
            {
                public string? Field { get; init; }
                public string? OperationId { get; init; }
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
                private readonly ConcurrentDictionary<string, int> _diagnosticCaptureCounts =
                    new(StringComparer.OrdinalIgnoreCase);

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

                public OperationalLoggingPolicy Current => RefreshExpiredTargets();

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
                    RemoveInactiveCaptureCounters(policy);
                }

                public OperationalLoggingPolicy ApplyLocal(OperationalLoggingPolicyUpdate update)
                {
                    var current = Current;
                    var now = DateTimeOffset.UtcNow;
                    var defaultLevel = string.IsNullOrWhiteSpace(update.DefaultLevel)
                        ? current.DefaultLevel
                        : update.DefaultLevel.Trim();
                    var defaultDepth = string.IsNullOrWhiteSpace(update.DefaultDepth)
                        ? current.DefaultDepth
                        : update.DefaultDepth.Trim();
                    var targets = NormalizeAndValidateTargets(
                        defaultLevel,
                        defaultDepth,
                        update.Targets ?? [],
                        now);
                    var policy = current with
                    {
                        Revision = Guid.NewGuid().ToString("N"),
                        DefaultLevel = defaultLevel,
                        DefaultDepth = defaultDepth,
                        Targets = targets,
                        UpdatedAtUtc = now,
                        Source = "LocalRuntime",
                        DiagnosticAudit = BuildDiagnosticAudit(current, targets, now)
                    };

                    Replace(policy);
                    return policy;
                }

            public OperationalLoggingDecision Evaluate(OperationalLoggingContext context)
            {
                return Evaluate(
                    context.Component,
                    context.Operation,
                    context.Entity,
                    context.RecordId,
                    context.Field,
                    context.OperationId);
            }

            private OperationalLoggingDecision Evaluate(
                string? component,
                string? operation,
                string? entity,
                string? recordId,
                string? field = null,
                string? operationId = null)
            {
                return Evaluate(
                    Current,
                    component,
                    operation,
                    entity,
                    recordId,
                    field,
                    operationId,
                    true,
                    true);
            }

            private OperationalLoggingDecision Evaluate(
                OperationalLoggingPolicy policy,
                string? component,
                string? operation,
                string? entity,
                string? recordId,
                string? field,
                string? operationId,
                bool useDefault,
                bool consumeDiagnosticCapture)
            {
                DiagnosticTarget? target = null;
                if (policy.Targets.Count > 0)
                {
                    var now = DateTimeOffset.UtcNow;
                    var highestSpecificity = -1;
                    foreach (var candidate in policy.Targets)
                    {
                        if ((candidate.ExpiresAtUtc is not null && candidate.ExpiresAtUtc <= now) ||
                            (candidate.StartsAtUtc is not null && candidate.StartsAtUtc > now) ||
                            !Matches(candidate.Component, component) ||
                            !Matches(candidate.Operation, operation) ||
                            !Matches(candidate.OperationId, operationId) ||
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

                    if (target is not null &&
                        consumeDiagnosticCapture &&
                        !TryConsumeDiagnosticCapture(target))
                    {
                        target = null;
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
                        decision.Depth,
                        decision.MatchedTarget?.DiagnosticSessionId,
                        decision.MatchedTarget?.AuthorizedFields);
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
                        decision.Depth,
                        decision.MatchedTarget?.DiagnosticSessionId,
                        decision.MatchedTarget?.AuthorizedFields);
                }

                OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
                    string component,
                    string? operation,
                    string? entity,
                    string? recordId,
                    string? field,
                    string? operationId)
                {
                    var decision = Evaluate(
                        component,
                        operation,
                        entity,
                        recordId,
                        field,
                        operationId);
                    return new OperationalTelemetryDecision(
                        decision.Enabled,
                        decision.Level,
                        decision.Depth,
                        decision.MatchedTarget?.DiagnosticSessionId,
                        decision.MatchedTarget?.AuthorizedFields);
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
                    if (!string.IsNullOrWhiteSpace(target.OperationId)) score += 4;
                    if (!string.IsNullOrWhiteSpace(target.Entity)) score += 8;
                    if (!string.IsNullOrWhiteSpace(target.RecordId)) score += 16;
                    if (!string.IsNullOrWhiteSpace(target.Field)) score += 32;
                    return score;
                }

                private bool TryConsumeDiagnosticCapture(DiagnosticTarget target)
                {
                    if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (string.IsNullOrWhiteSpace(target.DiagnosticSessionId) ||
                        target.MaximumCaptures is not > 0)
                    {
                        return false;
                    }

                    var sessionId = target.DiagnosticSessionId;
                    var maximum = target.MaximumCaptures.Value;
                    while (true)
                    {
                        var current = _diagnosticCaptureCounts.GetOrAdd(sessionId, 0);
                        if (current >= maximum)
                            return false;
                        if (_diagnosticCaptureCounts.TryUpdate(sessionId, current + 1, current))
                            return true;
                    }
                }

                private void RemoveInactiveCaptureCounters(OperationalLoggingPolicy policy)
                {
                    foreach (var sessionId in _diagnosticCaptureCounts.Keys)
                    {
                        var active = false;
                        foreach (var target in policy.Targets)
                        {
                            if (string.Equals(
                                    target.DiagnosticSessionId,
                                    sessionId,
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                active = true;
                                break;
                            }
                        }

                        if (!active)
                            _diagnosticCaptureCounts.TryRemove(sessionId, out _);
                    }
                }

                private static IReadOnlyList<DiagnosticTarget> NormalizeAndValidateTargets(
                    string defaultLevel,
                    string defaultDepth,
                    IReadOnlyList<DiagnosticTarget> targets,
                    DateTimeOffset now)
                {
                    if (!IsLevel(defaultLevel))
                        throw new ArgumentException($"Invalid log level '{defaultLevel}'.");
                    if (!IsBaselineDepth(defaultDepth))
                        throw new ArgumentException("Default depth must be D0 or D1. D2 requires a directed diagnostic session.");

                    var normalized = new DiagnosticTarget[targets.Count];
                    for (var index = 0; index < targets.Count; index++)
                    {
                        var target = targets[index];
                        if (!IsLevel(target.Level))
                            throw new ArgumentException($"Invalid log level '{target.Level}'.");
                        if (!IsTargetDepth(target.Depth))
                            throw new ArgumentException("Target depth must be D0, D1 or D2.");
                        if (target.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) &&
                            target.ExpiresAtUtc is null)
                        {
                            throw new ArgumentException("Debug targets require expiration.");
                        }

                        if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase))
                        {
                            normalized[index] = target;
                            continue;
                        }

                        var authorizedFields = (target.AuthorizedFields ?? [])
                            .Where(field => !string.IsNullOrWhiteSpace(field))
                            .Select(field => field.Trim())
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .ToArray();
                        if (!string.IsNullOrWhiteSpace(target.Field) &&
                            !authorizedFields.Contains(target.Field, StringComparer.OrdinalIgnoreCase))
                        {
                            authorizedFields = [.. authorizedFields, target.Field.Trim()];
                        }

                        var normalizedTarget = target with
                        {
                            DiagnosticSessionId = string.IsNullOrWhiteSpace(target.DiagnosticSessionId)
                                ? Guid.NewGuid().ToString("N")
                                : target.DiagnosticSessionId.Trim(),
                            StartsAtUtc = target.StartsAtUtc ?? now,
                            RequestedBy = target.RequestedBy?.Trim(),
                            ApprovedBy = target.ApprovedBy?.Trim(),
                            Justification = target.Justification?.Trim(),
                            AuthorizedFields = authorizedFields
                        };
                        ValidateDiagnosticTarget(normalizedTarget, now);
                        normalized[index] = normalizedTarget;
                    }

                    return normalized;
                }

                private static void ValidateDiagnosticTarget(
                    DiagnosticTarget target,
                    DateTimeOffset now)
                {
                    if (string.IsNullOrWhiteSpace(target.Component) &&
                        string.IsNullOrWhiteSpace(target.Operation) &&
                        string.IsNullOrWhiteSpace(target.OperationId) &&
                        string.IsNullOrWhiteSpace(target.Entity) &&
                        string.IsNullOrWhiteSpace(target.RecordId) &&
                        string.IsNullOrWhiteSpace(target.Field))
                    {
                        throw new ArgumentException("D2 requires at least one explicit target selector.");
                    }
                    if (string.IsNullOrWhiteSpace(target.RequestedBy) ||
                        string.IsNullOrWhiteSpace(target.ApprovedBy) ||
                        string.IsNullOrWhiteSpace(target.Justification))
                    {
                        throw new ArgumentException("D2 requires requester, approver and justification.");
                    }
                    if (target.StartsAtUtc is null ||
                        target.ExpiresAtUtc is null ||
                        target.ExpiresAtUtc <= target.StartsAtUtc ||
                        target.ExpiresAtUtc <= now)
                    {
                        throw new ArgumentException("D2 requires a valid start and future expiration.");
                    }
                    if (target.MaximumCaptures is not > 0)
                        throw new ArgumentException("D2 requires a positive capture limit.");
                    if (target.AuthorizedFields is not { Count: > 0 })
                        throw new ArgumentException("D2 requires at least one explicitly authorized field.");
                }

                private static IReadOnlyList<DiagnosticPolicyAuditEntry> BuildDiagnosticAudit(
                    OperationalLoggingPolicy current,
                    IReadOnlyList<DiagnosticTarget> targets,
                    DateTimeOffset now)
                {
                    var audit = current.DiagnosticAudit.ToList();
                    foreach (var target in targets)
                    {
                        if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                            current.Targets.Any(candidate => string.Equals(
                                candidate.DiagnosticSessionId,
                                target.DiagnosticSessionId,
                                StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        audit.Add(new DiagnosticPolicyAuditEntry(
                            target.DiagnosticSessionId!,
                            "Activated",
                            now,
                            target.RequestedBy!,
                            target.ApprovedBy!,
                            target.Justification!));
                    }

                    foreach (var target in current.Targets)
                    {
                        if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                            targets.Any(candidate => string.Equals(
                                candidate.DiagnosticSessionId,
                                target.DiagnosticSessionId,
                                StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        audit.Add(new DiagnosticPolicyAuditEntry(
                            target.DiagnosticSessionId!,
                            "Ended",
                            now,
                            target.RequestedBy ?? "unknown",
                            target.ApprovedBy ?? "unknown",
                            target.Justification ?? "not informed"));
                    }

                    if (audit.Count > 200)
                        audit.RemoveRange(0, audit.Count - 200);
                    return audit.ToArray();
                }

                private OperationalLoggingPolicy RefreshExpiredTargets()
                {
                    while (true)
                    {
                        var current = Volatile.Read(ref _current);
                        var now = DateTimeOffset.UtcNow;
                        var expired = current.Targets
                            .Where(target => target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)
                            .ToArray();
                        if (expired.Length == 0)
                            return current;

                        var active = current.Targets
                            .Where(target => target.ExpiresAtUtc is null || target.ExpiresAtUtc > now)
                            .ToArray();
                        var audit = current.DiagnosticAudit.ToList();
                        foreach (var target in expired)
                        {
                            if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                                audit.Any(entry =>
                                    entry.DiagnosticSessionId.Equals(
                                        target.DiagnosticSessionId,
                                        StringComparison.OrdinalIgnoreCase) &&
                                    entry.Action.Equals("Expired", StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }

                            audit.Add(new DiagnosticPolicyAuditEntry(
                                target.DiagnosticSessionId!,
                                "Expired",
                                now,
                                target.RequestedBy ?? "unknown",
                                target.ApprovedBy ?? "unknown",
                                target.Justification ?? "not informed"));
                        }

                        if (audit.Count > 200)
                            audit.RemoveRange(0, audit.Count - 200);
                        var updated = current with
                        {
                            Targets = active,
                            DiagnosticAudit = audit.ToArray()
                        };
                        if (ReferenceEquals(
                                Interlocked.CompareExchange(ref _current, updated, current),
                                current))
                        {
                            RemoveInactiveCaptureCounters(updated);
                            return updated;
                        }
                    }
                }

                private static bool IsLevel(string value) =>
                    value.Equals("Trace", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("Information", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("Warning", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("Error", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("Critical", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("None", StringComparison.OrdinalIgnoreCase);

                private static bool IsBaselineDepth(string value) =>
                    value.Equals("D0", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("D1", StringComparison.OrdinalIgnoreCase);

                private static bool IsTargetDepth(string value) =>
                    IsBaselineDepth(value) || value.Equals("D2", StringComparison.OrdinalIgnoreCase);

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
        sb.AppendLine("                        null,");
        sb.AppendLine("                        false,");
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
        sb.AppendLine("                        if (target.StartsAtUtc is not null && target.StartsAtUtc > now)");
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
            }
            """);
    }

    protected override StringBuilder GenerateCustonCode() => new();

    public void WriteGeneratedCode(string filePath)
    {
        WriteCode(GenerateCode(), filePath, false, false);
    }
}
