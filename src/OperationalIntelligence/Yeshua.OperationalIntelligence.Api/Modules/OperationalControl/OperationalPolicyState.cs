using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.OperationalControl;

public sealed class OperationalPolicyState
{
    private static readonly HashSet<string> Levels = new(StringComparer.OrdinalIgnoreCase)
    {
        "Trace", "Debug", "Information", "Warning", "Error", "Critical", "None"
    };

    private static readonly HashSet<string> Depths = new(StringComparer.OrdinalIgnoreCase)
    {
        "D0", "D1", "D2", "D3", "D4"
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
        Validate(update.DefaultLevel, update.DefaultDepth, update.Targets ?? []);
        var policy = CreatePolicy(
            application,
            environment,
            update.DefaultLevel,
            update.DefaultDepth,
            update.Targets ?? [],
            "RuntimeOverride");

        lock (_sync)
            _overrides[Key(application, environment)] = policy;

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
        string source)
    {
        var targetList = targets.ToArray();
        Validate(defaultLevel, defaultDepth, targetList);
        return new OperationalLoggingPolicy(
            application,
            environment,
            NewRevision(),
            Normalize(defaultLevel),
            Normalize(defaultDepth),
            targetList,
            DateTimeOffset.UtcNow,
            source);
    }

    private static void Validate(
        string defaultLevel,
        string defaultDepth,
        IEnumerable<DiagnosticTarget> targets)
    {
        if (!Levels.Contains(defaultLevel))
            throw new ArgumentException($"Invalid log level '{defaultLevel}'.");
        if (!Depths.Contains(defaultDepth))
            throw new ArgumentException($"Invalid diagnostic depth '{defaultDepth}'.");

        foreach (var target in targets)
        {
            if (!Levels.Contains(target.Level))
                throw new ArgumentException($"Invalid log level '{target.Level}'.");
            if (!Depths.Contains(target.Depth))
                throw new ArgumentException($"Invalid diagnostic depth '{target.Depth}'.");
            if ((target.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                 IsDeepDiagnostic(target.Depth)) &&
                target.ExpiresAtUtc is null)
            {
                throw new ArgumentException("Debug and D2-D4 targets require expiration.");
            }
        }
    }

    private static OperationalLoggingPolicy RemoveExpiredTargets(OperationalLoggingPolicy policy)
    {
        var now = DateTimeOffset.UtcNow;
        var activeTargets = policy.Targets
            .Where(target => target.ExpiresAtUtc is null || target.ExpiresAtUtc > now)
            .ToArray();
        return activeTargets.Length == policy.Targets.Count
            ? policy
            : policy with { Targets = activeTargets };
    }

    private static string Normalize(string value) => value.Trim();

    private static string Key(string application, string environment)
    {
        return $"{application.Trim()}::{environment.Trim()}";
    }

    private static bool IsDeepDiagnostic(string depth)
    {
        return depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
               depth.Equals("D3", StringComparison.OrdinalIgnoreCase) ||
               depth.Equals("D4", StringComparison.OrdinalIgnoreCase);
    }

    private static string NewRevision() => Guid.NewGuid().ToString("N");
}
