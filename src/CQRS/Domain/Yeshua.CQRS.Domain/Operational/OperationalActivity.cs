using System.Diagnostics;

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
}
