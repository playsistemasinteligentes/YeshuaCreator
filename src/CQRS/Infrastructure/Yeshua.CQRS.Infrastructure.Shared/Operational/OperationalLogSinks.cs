using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using System.Text;

namespace Shared.Operational;

public interface IOperationalLogSink
{
    void Write(string level, string category, ReadOnlySpan<byte> payload);
}

public sealed class ConsoleJsonlOperationalLogSink : IOperationalLogSink
{
    public static readonly ConsoleJsonlOperationalLogSink Instance = new();
    private static readonly object ConsoleSync = new();

    private ConsoleJsonlOperationalLogSink()
    {
    }

    public void Write(string level, string category, ReadOnlySpan<byte> payload)
    {
        var line = Encoding.UTF8.GetString(payload);
        lock (ConsoleSync)
            Console.WriteLine(line);
    }
}

public sealed class OtlpOperationalLogSink : IOperationalLogSink, IDisposable
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger _logger;

    public OtlpOperationalLogSink(Uri endpoint, RuntimeIdentity identity)
    {
        _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.AddOpenTelemetry(options =>
            {
                options.IncludeFormattedMessage = true;
                options.ParseStateValues = true;
                options.SetResourceBuilder(
                    ResourceBuilder
                        .CreateDefault()
                        .AddService(identity.Application, serviceVersion: identity.Version)
                        .AddAttributes([
                            new KeyValuePair<string, object>(
                                "deployment.environment.name",
                                identity.Environment),
                            new KeyValuePair<string, object>(
                                "service.commit.sha",
                                identity.CommitSha)
                        ]));
                options.AddOtlpExporter(exporter => exporter.Endpoint = endpoint);
            });
        });
        _logger = _loggerFactory.CreateLogger("Yeshua.Operational");
    }

    public void Write(string level, string category, ReadOnlySpan<byte> payload)
    {
        var message = Encoding.UTF8.GetString(payload);
        _logger.Log(
            ToLogLevel(level),
            new EventId(0, category),
            new OperationalJsonLogState(category, message),
            null,
            static (state, _) => state.Payload);
    }

    public void Dispose() => _loggerFactory.Dispose();

    private static LogLevel ToLogLevel(string level)
    {
        if (level.Equals("Trace", StringComparison.OrdinalIgnoreCase))
            return LogLevel.Trace;
        if (level.Equals("Debug", StringComparison.OrdinalIgnoreCase))
            return LogLevel.Debug;
        if (level.Equals("Warning", StringComparison.OrdinalIgnoreCase))
            return LogLevel.Warning;
        if (level.Equals("Error", StringComparison.OrdinalIgnoreCase))
            return LogLevel.Error;
        if (level.Equals("Critical", StringComparison.OrdinalIgnoreCase))
            return LogLevel.Critical;

        return LogLevel.Information;
    }

    private sealed class OperationalJsonLogState :
        IReadOnlyList<KeyValuePair<string, object?>>
    {
        public OperationalJsonLogState(string category, string payload)
        {
            Category = category;
            Payload = payload;
        }

        public string Category { get; }
        public string Payload { get; }

        public int Count => 3;

        public KeyValuePair<string, object?> this[int index] => index switch
        {
            0 => new KeyValuePair<string, object?>("yeshua.log.category", Category),
            1 => new KeyValuePair<string, object?>("yeshua.log.payload", Payload),
            2 => new KeyValuePair<string, object?>("{OriginalFormat}", "{YeshuaOperationalPayload}"),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (var index = 0; index < Count; index++)
                yield return this[index];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}

public static class OperationalLogSinkFactory
{
    public static IOperationalLogSink Create(
        OperationalTelemetryExportSettings settings,
        IRuntimeIdentityProvider identityProvider)
    {
        if (settings.Mode == OperationalTelemetryExportMode.Otlp)
            return new OtlpOperationalLogSink(settings.OtlpEndpoint!, identityProvider.Current);

        return ConsoleJsonlOperationalLogSink.Instance;
    }
}
