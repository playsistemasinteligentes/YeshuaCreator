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

    public static void RecordException(Activity? activity, Exception exception)
    {
        if (activity is null)
            return;

        activity.AddEvent(new ActivityEvent(
            "exception",
            tags: new ActivityTagsCollection
            {
                { "exception.type", exception.GetType().FullName },
                { "exception.message", exception.Message },
                { "exception.stacktrace", exception.StackTrace }
            }));
    }
}
