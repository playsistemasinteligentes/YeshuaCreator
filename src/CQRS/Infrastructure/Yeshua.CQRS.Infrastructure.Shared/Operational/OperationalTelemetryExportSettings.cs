using Microsoft.Extensions.Configuration;

namespace Shared.Operational;

public enum OperationalTelemetryExportMode
{
    ConsoleJsonl,
    Otlp
}

public sealed record OperationalTelemetryExportSettings(
    OperationalTelemetryExportMode Mode,
    Uri? OtlpEndpoint)
{
    public static OperationalTelemetryExportSettings FromConfiguration(
        IConfiguration configuration)
    {
        var rawMode = configuration["OpenTelemetry:ExportMode"];
        var rawEndpoint = configuration["OpenTelemetry:Otlp:Endpoint"];

        var mode = ResolveMode(rawMode, rawEndpoint);
        if (mode == OperationalTelemetryExportMode.ConsoleJsonl)
            return new OperationalTelemetryExportSettings(mode, null);

        if (!Uri.TryCreate(rawEndpoint, UriKind.Absolute, out var endpoint))
        {
            throw new InvalidOperationException(
                "OpenTelemetry:Otlp:Endpoint deve ser uma URI absoluta quando OpenTelemetry:ExportMode=Otlp.");
        }

        return new OperationalTelemetryExportSettings(mode, endpoint);
    }

    private static OperationalTelemetryExportMode ResolveMode(
        string? rawMode,
        string? rawEndpoint)
    {
        if (string.IsNullOrWhiteSpace(rawMode))
        {
            return string.IsNullOrWhiteSpace(rawEndpoint)
                ? OperationalTelemetryExportMode.ConsoleJsonl
                : OperationalTelemetryExportMode.Otlp;
        }

        if (rawMode.Equals("ConsoleJsonl", StringComparison.OrdinalIgnoreCase) ||
            rawMode.Equals("Jsonl", StringComparison.OrdinalIgnoreCase) ||
            rawMode.Equals("Console", StringComparison.OrdinalIgnoreCase))
        {
            return OperationalTelemetryExportMode.ConsoleJsonl;
        }

        if (rawMode.Equals("Otlp", StringComparison.OrdinalIgnoreCase))
            return OperationalTelemetryExportMode.Otlp;

        throw new InvalidOperationException(
            "OpenTelemetry:ExportMode deve ser ConsoleJsonl ou Otlp.");
    }
}
