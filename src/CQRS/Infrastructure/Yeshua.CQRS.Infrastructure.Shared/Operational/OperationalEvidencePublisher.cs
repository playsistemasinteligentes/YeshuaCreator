using Dominio.Operational;
using System.Buffers;
using System.Text.Json;

namespace Shared.Operational;

public sealed class OperationalEvidencePublisher
{
    private readonly IOperationalLogSink _sink;
    private readonly RuntimeIdentity? _runtimeIdentity;

    public OperationalEvidencePublisher(
        IOperationalLogSink sink,
        RuntimeIdentity? runtimeIdentity = null)
    {
        _sink = sink;
        _runtimeIdentity = runtimeIdentity;
    }

    public void Publish(
        in OperationalEvidenceEnvelope envelope,
        ReadOnlySpan<OperationalEvidenceField> fields)
    {
        try
        {
            var buffer = new ArrayBufferWriter<byte>(512);
            using var writer = new Utf8JsonWriter(buffer);

            writer.WriteStartObject();
            writer.WriteString("TimestampUtc", DateTimeOffset.UtcNow);
            writer.WriteString("Level", envelope.Severity.ToString());
            writer.WriteString("Category", envelope.Component);
            writer.WriteString("Depth", envelope.Depth.ToString());
            writer.WriteString("Mode", envelope.Mode.ToString());
            writer.WriteString("TechnicalOutcome", envelope.TechnicalOutcome.ToString());
            writer.WriteString("BusinessOutcome", envelope.BusinessOutcome.ToString());
            if (_runtimeIdentity is { } identity)
            {
                writer.WriteString("Application", identity.Application);
                writer.WriteString("Environment", identity.Environment);
                writer.WriteString("Version", identity.Version);
                writer.WriteString("CommitSha", identity.CommitSha);
                if (identity.BuiltAtUtc is { } builtAtUtc)
                    writer.WriteString("BuildTimestampUtc", builtAtUtc);
            }
            writer.WritePropertyName("Data");
            writer.WriteStartObject();
            writer.WriteString("Operation", envelope.Operation);
            WriteOptional(writer, "TraceId", envelope.TraceId);
            WriteOptional(writer, "RootOperationId", envelope.RootOperationId);
            WriteOptional(writer, "OperationId", envelope.OperationId);
            WriteOptional(writer, "ExecutionId", envelope.ExecutionId);
            WriteOptional(writer, "CausationId", envelope.CausationId);
            WriteOptional(writer, "OperationalEntityId", envelope.OperationalEntityId);
            WriteOptional(writer, "ErrorCode", envelope.ErrorCode);

            foreach (ref readonly var field in fields)
            {
                if (!OperationalEvidenceProtection.CanPublish(field, envelope.Depth))
                    continue;

                WriteValue(writer, field.Name, field.Value);
            }

            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
            _sink.Write(envelope.Severity.ToString(), envelope.Component, buffer.WrittenSpan);
        }
        catch
        {
            // Evidencia operacional nunca interrompe o fluxo de negocio.
        }
    }

    private static void WriteOptional(Utf8JsonWriter writer, string name, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            writer.WriteString(name, value);
    }

    private static void WriteValue(Utf8JsonWriter writer, string name, object? value)
    {
        switch (value)
        {
            case null: writer.WriteNull(name); break;
            case string item: writer.WriteString(name, item); break;
            case bool item: writer.WriteBoolean(name, item); break;
            case byte item: writer.WriteNumber(name, item); break;
            case short item: writer.WriteNumber(name, item); break;
            case int item: writer.WriteNumber(name, item); break;
            case long item: writer.WriteNumber(name, item); break;
            case float item: writer.WriteNumber(name, item); break;
            case double item: writer.WriteNumber(name, item); break;
            case decimal item: writer.WriteNumber(name, item); break;
            case DateTime item: writer.WriteString(name, item); break;
            case DateTimeOffset item: writer.WriteString(name, item); break;
            default: writer.WriteString(name, value.ToString()); break;
        }
    }
}

public static class OperationalEvidenceProtection
{
    private static readonly string[] ForbiddenNames =
    [
        "password",
        "senha",
        "secret",
        "segredo",
        "token",
        "authorization",
        "cookie",
        "connectionstring",
        "privatekey",
        "chaveprivada",
        "pfx",
        "certificatebytes",
        "certificadobytes",
        "rawxml",
        "xmlintegral",
        "rawpayload",
        "payloadbruto"
    ];

    public static bool CanPublish(
        in OperationalEvidenceField field,
        OperationalDepth depth)
    {
        if (field.Classification == OperationalDataClassification.NeverCapture ||
            IsForbiddenName(field.Name))
        {
            return false;
        }

        return field.Classification switch
        {
            OperationalDataClassification.Public => true,
            OperationalDataClassification.Internal => true,
            OperationalDataClassification.Confidential => depth >= OperationalDepth.D1,
            OperationalDataClassification.Restricted => depth >= OperationalDepth.D2,
            _ => false
        };
    }

    public static bool IsForbiddenName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return true;

        foreach (var forbidden in ForbiddenNames)
        {
            if (name.Contains(forbidden, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }
}
