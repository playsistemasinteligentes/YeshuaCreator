using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.OperationalControl;

public sealed class OperationalPolicyState
{
    private static readonly HashSet<string> Levels = new(StringComparer.OrdinalIgnoreCase)
    {
        "Trace", "Debug", "Information", "Warning", "Error", "Critical", "None"
    };

    private static readonly HashSet<string> BaselineDepths = new(StringComparer.OrdinalIgnoreCase)
    {
        "D0", "D1"
    };

    private static readonly HashSet<string> TargetDepths = new(StringComparer.OrdinalIgnoreCase)
    {
        "D0", "D1", "D2"
    };

    private readonly object _sync = new();
    private readonly Dictionary<string, OperationalLoggingPolicy> _baselines;
    private readonly Dictionary<string, OperationalLoggingPolicy> _overrides =
        new(StringComparer.OrdinalIgnoreCase);

    public OperationalPolicyState(IOptions<OperationalControlOptions> options)
    {
        _baselines = new Dictionary<string, OperationalLoggingPolicy>(
            StringComparer.OrdinalIgnoreCase);
        foreach (var application in options.Value.Applications)
        {
            foreach (var environment in application.Value)
            {
                _baselines[Key(application.Key, environment.Key)] = CreatePolicy(
                    application.Key,
                    environment.Key,
                    environment.Value.DefaultLevel,
                    environment.Value.DefaultDepth,
                    environment.Value.Targets,
                    "Configuration");
            }
        }
    }

    public OperationalLoggingPolicy? Get(string application, string environment)
    {
        var key = Key(application, environment);
        lock (_sync)
        {
            if (_overrides.TryGetValue(key, out var policy))
                return RemoveExpiredTargets(policy);

            return _baselines.TryGetValue(key, out policy)
                ? RemoveExpiredTargets(policy)
                : null;
        }
    }

    public OperationalLoggingPolicy Replace(
        string application,
        string environment,
        OperationalLoggingPolicyUpdate update)
    {
        var now = DateTimeOffset.UtcNow;
        var targets = NormalizeAndValidateTargets(
            update.DefaultLevel,
            update.DefaultDepth,
            update.Targets ?? [],
            now);
        var policy = CreatePolicy(
            application,
            environment,
            update.DefaultLevel,
            update.DefaultDepth,
            targets,
            "RuntimeOverride",
            now);

        lock (_sync)
        {
            var key = Key(application, environment);
            var current = _overrides.TryGetValue(key, out var overridden)
                ? overridden
                : _baselines.GetValueOrDefault(key);
            if (current is not null)
            {
                policy = policy with
                {
                    DiagnosticAudit = BuildDiagnosticAudit(current, targets, now)
                };
            }
            _overrides[Key(application, environment)] = policy;
        }

        return policy;
    }

    public OperationalLoggingPolicy? Reset(string application, string environment)
    {
        var key = Key(application, environment);
        lock (_sync)
        {
            _overrides.Remove(key);
            if (!_baselines.TryGetValue(key, out var baseline))
                return null;

            baseline = baseline with
            {
                Revision = NewRevision(),
                UpdatedAtUtc = DateTimeOffset.UtcNow
            };
            _baselines[key] = baseline;
            return RemoveExpiredTargets(baseline);
        }
    }

    private static OperationalLoggingPolicy CreatePolicy(
        string application,
        string environment,
        string defaultLevel,
        string defaultDepth,
        IEnumerable<DiagnosticTarget> targets,
        string source,
        DateTimeOffset? nowOverride = null)
    {
        var now = nowOverride ?? DateTimeOffset.UtcNow;
        var targetList = NormalizeAndValidateTargets(
            defaultLevel,
            defaultDepth,
            targets.ToArray(),
            now);
        var policy = new OperationalLoggingPolicy(
            application,
            environment,
            NewRevision(),
            Normalize(defaultLevel),
            Normalize(defaultDepth),
            targetList,
            now,
            source);

        if (targetList.Any(IsD2))
        {
            policy = policy with
            {
                DiagnosticAudit = targetList
                    .Where(IsD2)
                    .Select(target => NewAudit(target, "Activated", now))
                    .ToArray()
            };
        }

        return policy;
    }

    private static IReadOnlyList<DiagnosticTarget> NormalizeAndValidateTargets(
        string defaultLevel,
        string defaultDepth,
        IReadOnlyList<DiagnosticTarget> targets,
        DateTimeOffset now)
    {
        if (!Levels.Contains(defaultLevel))
            throw new ArgumentException($"Invalid log level '{defaultLevel}'.");
        if (!BaselineDepths.Contains(defaultDepth))
            throw new ArgumentException("Default depth must be D0 or D1. D2 requires a directed diagnostic session.");

        var normalized = new DiagnosticTarget[targets.Count];
        for (var index = 0; index < targets.Count; index++)
        {
            var target = targets[index];
            if (!Levels.Contains(target.Level))
                throw new ArgumentException($"Invalid log level '{target.Level}'.");
            if (!TargetDepths.Contains(target.Depth))
                throw new ArgumentException($"Invalid diagnostic depth '{target.Depth}'.");
            if ((target.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                 IsD2(target)) &&
                target.ExpiresAtUtc is null)
            {
                throw new ArgumentException("Debug and D2 targets require expiration.");
            }

            if (!IsD2(target))
            {
                normalized[index] = target;
                continue;
            }

            var authorizedFields = (target.AuthorizedFields ?? [])
                .Where(field => !string.IsNullOrWhiteSpace(field))
                .Select(field => field.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            if (!string.IsNullOrWhiteSpace(target.Field) &&
                !authorizedFields.Contains(target.Field, StringComparer.OrdinalIgnoreCase))
            {
                authorizedFields.Add(target.Field.Trim());
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

    private static OperationalLoggingPolicy RemoveExpiredTargets(OperationalLoggingPolicy policy)
    {
        var now = DateTimeOffset.UtcNow;
        var expiredTargets = policy.Targets
            .Where(target => target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)
            .ToArray();
        var activeTargets = policy.Targets
            .Where(target => target.ExpiresAtUtc is null || target.ExpiresAtUtc > now)
            .ToArray();
        if (activeTargets.Length == policy.Targets.Count)
            return policy;

        var audit = policy.DiagnosticAudit.ToList();
        foreach (var target in expiredTargets.Where(IsD2))
        {
            if (!audit.Any(entry =>
                    entry.DiagnosticSessionId.Equals(
                        target.DiagnosticSessionId,
                        StringComparison.OrdinalIgnoreCase) &&
                    entry.Action.Equals("Expired", StringComparison.OrdinalIgnoreCase)))
            {
                audit.Add(NewAudit(target, "Expired", now));
            }
        }

        return policy with
        {
            Targets = activeTargets,
            DiagnosticAudit = KeepLatestAudit(audit)
        };
    }

    private static string Normalize(string value) => value.Trim();

    private static string Key(string application, string environment)
    {
        return $"{application.Trim()}::{environment.Trim()}";
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
        foreach (var target in targets.Where(IsD2))
        {
            if (!current.Targets.Any(candidate => SameSession(candidate, target)))
                audit.Add(NewAudit(target, "Activated", now));
        }

        foreach (var target in current.Targets.Where(IsD2))
        {
            if (!targets.Any(candidate => SameSession(candidate, target)))
                audit.Add(NewAudit(target, "Ended", now));
        }

        return KeepLatestAudit(audit);
    }

    private static DiagnosticPolicyAuditEntry NewAudit(
        DiagnosticTarget target,
        string action,
        DateTimeOffset now) =>
        new(
            target.DiagnosticSessionId ?? "unknown",
            action,
            now,
            target.RequestedBy ?? "unknown",
            target.ApprovedBy ?? "unknown",
            target.Justification ?? "not informed");

    private static IReadOnlyList<DiagnosticPolicyAuditEntry> KeepLatestAudit(
        List<DiagnosticPolicyAuditEntry> audit) =>
        audit.Count <= 200
            ? audit.ToArray()
            : audit.Skip(audit.Count - 200).ToArray();

    private static bool SameSession(DiagnosticTarget left, DiagnosticTarget right) =>
        !string.IsNullOrWhiteSpace(left.DiagnosticSessionId) &&
        left.DiagnosticSessionId.Equals(
            right.DiagnosticSessionId,
            StringComparison.OrdinalIgnoreCase);

    private static bool IsD2(DiagnosticTarget target) =>
        target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase);

    private static string NewRevision() => Guid.NewGuid().ToString("N");
}
