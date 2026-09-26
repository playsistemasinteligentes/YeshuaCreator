using OpenTelemetry;
using System.Buffers;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Shared.Operational;

public sealed class YeshuaJsonlActivityExporter : BaseExporter<Activity>
{
    private static readonly object ConsoleSync = new();
    private readonly IRuntimeIdentityProvider _identityProvider;

    public YeshuaJsonlActivityExporter(IRuntimeIdentityProvider identityProvider)
    {
        _identityProvider = identityProvider;
    }

    public override ExportResult Export(in Batch<Activity> batch)
    {
        try
        {
            var identity = _identityProvider.Current;
            foreach (var activity in batch)
                Write(activity, identity);

            return ExportResult.Success;
        }
        catch
        {
            return ExportResult.Failure;
        }
    }

    private static void Write(Activity activity, RuntimeIdentity identity)
    {
        var buffer = new ArrayBufferWriter<byte>(1024);
        using (var json = new Utf8JsonWriter(buffer))
        {
            json.WriteStartObject();
            json.WriteString("timestamp", activity.StartTimeUtc);
            json.WriteString("signal", "trace");
            json.WriteString("source", activity.Source.Name);
            json.WriteString("name", activity.DisplayName);
            json.WriteString("kind", activity.Kind.ToString());
            json.WriteString("traceId", activity.TraceId.ToHexString());
            json.WriteString("spanId", activity.SpanId.ToHexString());
            if (activity.ParentSpanId != default)
                json.WriteString("parentSpanId", activity.ParentSpanId.ToHexString());
            json.WriteNumber("durationMs", activity.Duration.TotalMilliseconds);
            json.WriteString("status", activity.Status.ToString());
            if (!string.IsNullOrWhiteSpace(activity.StatusDescription))
                json.WriteString("statusDescription", activity.StatusDescription);

            json.WriteStartObject("resource");
            json.WriteString("service.name", identity.Application);
            json.WriteString("deployment.environment.name", identity.Environment);
            json.WriteString("service.version", identity.Version);
            if (!string.IsNullOrWhiteSpace(identity.CommitSha))
                json.WriteString("service.commit.sha", identity.CommitSha);
            json.WriteEndObject();

            json.WriteStartObject("attributes");
            foreach (var tag in activity.TagObjects)
                WriteTag(json, tag.Key, tag.Value);
            json.WriteEndObject();

            if (activity.Events.Any())
            {
                json.WriteStartArray("events");
                foreach (var activityEvent in activity.Events)
                {
                    json.WriteStartObject();
                    json.WriteString("name", activityEvent.Name);
                    json.WriteString("timestamp", activityEvent.Timestamp);
                    foreach (var tag in activityEvent.Tags)
                        WriteTag(json, tag.Key, tag.Value);
                    json.WriteEndObject();
                }
                json.WriteEndArray();
            }

            json.WriteEndObject();
        }

        var line = Encoding.UTF8.GetString(buffer.WrittenSpan);
        lock (ConsoleSync)
            Console.WriteLine(line);
    }

    private static void WriteTag(Utf8JsonWriter json, string name, object? value)
    {
        switch (value)
        {
            case null: json.WriteNull(name); break;
            case bool item: json.WriteBoolean(name, item); break;
            case byte item: json.WriteNumber(name, item); break;
            case short item: json.WriteNumber(name, item); break;
            case int item: json.WriteNumber(name, item); break;
            case long item: json.WriteNumber(name, item); break;
            case float item: json.WriteNumber(name, item); break;
            case double item: json.WriteNumber(name, item); break;
            case decimal item: json.WriteNumber(name, item); break;
            default:
                json.WriteString(name, Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture));
                break;
        }
    }
}
