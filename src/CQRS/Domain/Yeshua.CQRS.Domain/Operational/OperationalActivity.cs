using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Operational;

public static class OperationalActivity
{
    public const string SourceName = "Yeshua.Operational";
    public const string SourceVersion = "1.0.0";

    public static readonly ActivitySource Source = new(SourceName, SourceVersion);

    public static Activity? StartRoot(string name, ActivityKind kind = ActivityKind.Internal)
    {
        var parent = Activity.Current;
        try
        {
            Activity.Current = null;
            return Source.StartActivity(name, kind);
        }
        finally
        {
            Activity.Current = parent;
        }
    }

    public static void SetIdentity(
        Activity? activity,
        OperationalExecutionIdentity identity)
    {
        if (activity is null)
            return;

        activity.SetTag("yeshua.root_operation_id", identity.RootOperationId);
        activity.SetTag("yeshua.operation_id", identity.OperationId);
        activity.SetTag("yeshua.execution_id", identity.ExecutionId);
        activity.SetTag("yeshua.causation_id", identity.CausationId);
    }

    public static void SetDiagnosticSession(
        Activity? activity,
        string? diagnosticSessionId)
    {
        if (activity is null || string.IsNullOrWhiteSpace(diagnosticSessionId))
            return;

        activity.SetTag("yeshua.diagnostic_session_id", diagnosticSessionId);
        RequireRetention(activity, "diagnostic");
    }

    public static void RequireRetention(Activity? activity, string reason)
    {
        if (activity is null)
            return;

        activity.SetTag("yeshua.trace.retention", "required");
        activity.SetTag("yeshua.trace.retention.reason", reason);
    }

    public static void RecordException(
        Activity? activity,
        Exception exception,
        OperationalDepth depth = OperationalDepth.D0)
    {
        if (activity is null)
            return;

        activity.AddEvent(new ActivityEvent(
            "exception",
            tags: new ActivityTagsCollection
            {
                { "exception.type", exception.GetType().FullName },
                { "yeshua.depth", depth.ToString() },
                { "yeshua.exception.detail_omitted", true }
            }));
    }

    public static void RecordFailure(
        Activity? activity,
        Exception exception,
        in OperationalFailureClassification classification,
        string component,
        string operation,
        bool terminal,
        OperationalDepth depth = OperationalDepth.D0)
    {
        if (activity is null)
            return;

        RecordException(activity, exception, depth);
        activity.SetTag("yeshua.failure.nature", Name(classification.Nature));
        activity.SetTag("yeshua.failure.transience", Name(classification.Transience));
        activity.SetTag("yeshua.failure.origin", Name(classification.Origin));
        activity.SetTag("yeshua.failure.retryable", classification.Retryable);
        activity.SetTag("yeshua.failure.terminal", terminal);
        activity.SetTag("yeshua.failure.code", classification.StableCode);
        activity.SetTag(
            "yeshua.failure.signature",
            CreateFailureSignature(
                exception.GetType().FullName ?? exception.GetType().Name,
                component,
                operation,
                classification.StableCode));
        activity.SetTag(
            "yeshua.item.health",
            terminal ? "terminal_failure" : "retry_scheduled");
        RequireRetention(activity, terminal ? "terminal_failure" : "retry");
    }

    public static void RecordRecovery(Activity? activity, int retryCount)
    {
        if (activity is null || retryCount <= 0)
            return;

        activity.SetTag("yeshua.item.health", "recovered");
        activity.SetTag("yeshua.item.recovery.retry_count", retryCount);
        RequireRetention(activity, "recovery");
    }

    private static string CreateFailureSignature(
        string exceptionType,
        string component,
        string operation,
        string stableCode)
    {
        var source = $"{exceptionType}|{component}|{operation}|{stableCode}";
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(source));
        return Convert.ToHexString(hash.AsSpan(0, 12)).ToLowerInvariant();
    }

    private static string Name(OperationalFailureNature value) => value switch
    {
        OperationalFailureNature.Business => "business",
        OperationalFailureNature.ExternalRejection => "external_rejection",
        OperationalFailureNature.Cancellation => "cancellation",
        _ => "technical"
    };

    private static string Name(OperationalFailureTransience value) => value switch
    {
        OperationalFailureTransience.Transient => "transient",
        OperationalFailureTransience.Permanent => "permanent",
        _ => "unknown"
    };

    private static string Name(OperationalFailureOrigin value) => value switch
    {
        OperationalFailureOrigin.Application => "application",
        OperationalFailureOrigin.Database => "database",
        OperationalFailureOrigin.Http => "http",
        OperationalFailureOrigin.Queue => "queue",
        OperationalFailureOrigin.ExternalProvider => "external_provider",
        OperationalFailureOrigin.Configuration => "configuration",
        _ => "unknown"
    };
}
