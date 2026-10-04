using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class LogKnowledgeReferenceEnricher
{
    private const int DefaultMaxTelemetryLogs = 100;

    private readonly LogKnowledgeReferenceResolver _resolver;
    private readonly McpToolArgumentReader _arguments;

    public LogKnowledgeReferenceEnricher(
        LogKnowledgeReferenceResolver resolver,
        McpToolArgumentReader arguments)
    {
        _resolver = resolver;
        _arguments = arguments;
    }

    public async Task<object> BuildStructuredContentAsync(
        JsonElement arguments,
        RawTelemetryResult telemetry,
        CancellationToken cancellationToken)
    {
        if (!_arguments.Boolean(arguments, "includeKnowledgeReferences"))
            return telemetry;

        var warnings = new List<string>(telemetry.Warnings);
        var application = _arguments.String(arguments, "application");
        if (string.IsNullOrWhiteSpace(application))
        {
            warnings.Add("application is required when includeKnowledgeReferences is true.");
            return new LogTelemetryWithKnowledgeReferences(telemetry, null, warnings);
        }

        var logs = LogKnowledgeReferenceResolver.ExtractLogsFromTelemetry(
            telemetry,
            DefaultMaxTelemetryLogs);
        if (logs.Count == 0)
        {
            warnings.Add("No log lines were returned by telemetry query to infer knowledge references.");
            return new LogTelemetryWithKnowledgeReferences(telemetry, null, warnings);
        }

        try
        {
            var references = await _resolver.ResolveAsync(
                application,
                _arguments.String(arguments, "version"),
                logs,
                _arguments.Boolean(arguments, "includeSourceContent", defaultValue: true),
                _arguments.ClampedInteger(arguments, "knowledgeMaxSignals", 12, 1, 50),
                _arguments.ClampedInteger(arguments, "knowledgeMaxFiles", 5, 1, 20),
                _arguments.ClampedInteger(arguments, "knowledgeMaxContentChars", 30_000, 1_000, 200_000),
                _arguments.Integer(arguments, "maxDepth"),
                _arguments.Integer(arguments, "maxResults"),
                cancellationToken);

            warnings.AddRange(references.Warnings);
            return new LogTelemetryWithKnowledgeReferences(
                telemetry,
                references,
                warnings.Distinct(StringComparer.Ordinal).ToArray());
        }
        catch (KeyNotFoundException exception)
        {
            warnings.Add(exception.Message);
            return new LogTelemetryWithKnowledgeReferences(telemetry, null, warnings);
        }
    }
}

public sealed record LogTelemetryWithKnowledgeReferences(
    RawTelemetryResult Telemetry,
    LogSourceContextResponse? KnowledgeReferences,
    IReadOnlyList<string> Warnings);

