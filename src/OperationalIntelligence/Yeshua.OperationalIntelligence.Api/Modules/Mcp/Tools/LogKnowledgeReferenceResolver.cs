using System.Diagnostics;
using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class LogKnowledgeReferenceResolver
{
    private readonly ISourceContextRepository _repository;
    private readonly QuestionContextBuilder _contextBuilder;
    private readonly LogSourceEvidenceExtractor _extractor;

    public LogKnowledgeReferenceResolver(
        ISourceContextRepository repository,
        QuestionContextBuilder contextBuilder,
        LogSourceEvidenceExtractor extractor)
    {
        _repository = repository;
        _contextBuilder = contextBuilder;
        _extractor = extractor;
    }

    public async Task<LogSourceContextResponse> ResolveAsync(
        string application,
        string? version,
        IReadOnlyList<string> logs,
        bool includeContent,
        int maxSignals,
        int maxFiles,
        int maxContentChars,
        int? maxDepth,
        int? maxResults,
        CancellationToken cancellationToken)
    {
        var signals = _extractor.Extract(logs).Take(maxSignals).ToArray();
        if (signals.Length == 0)
        {
            return new LogSourceContextResponse(
                signals,
                null,
                [],
                ["No function, class, exception type or source file path was found in the supplied logs."]);
        }

        var startedAt = DateTimeOffset.UtcNow;
        var stopwatch = Stopwatch.StartNew();
        var warnings = new List<string>();
        var evidence = new List<ContextEvidence>();

        foreach (var signal in signals)
        {
            try
            {
                var response = await SearchAsync(
                    application,
                    version,
                    signal,
                    maxDepth,
                    maxResults,
                    cancellationToken);

                warnings.AddRange(response.Warnings.Select(warning => $"{signal.Symbol}: {warning}"));
                if (response.SourceFiles.Count == 0 &&
                    response.Matches.Count == 0 &&
                    response.References.Count == 0)
                {
                    continue;
                }

                evidence.Add(new ContextEvidence(
                    "mcp-log-source",
                    "SourceContext",
                    $"{signal.Kind} '{signal.Symbol}' extracted from {signal.Evidence}.",
                    response.Build.Application,
                    response.Build.Version,
                    DateTimeOffset.UtcNow,
                    signal.Confidence,
                    response));
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                warnings.Add($"{signal.Symbol}: source lookup failed: {exception.Message}");
            }
        }

        stopwatch.Stop();
        var investigation = new InvestigationResponse(
            application,
            version,
            startedAt,
            stopwatch.Elapsed,
            [
                new CollectorResult(
                    "mcp-log-source",
                    evidence,
                    warnings,
                    stopwatch.Elapsed)
            ],
            evidence,
            warnings);
        var context = _contextBuilder.Build(
            new InvestigationRequest
            {
                Application = application,
                Version = version,
                Purpose = "BugDiagnosis",
                Question = "Quais fontes do snapshot indexado estao relacionados aos logs capturados?",
                MaxDepth = maxDepth,
                MaxResults = maxResults
            },
            investigation);
        var selectedContext = context with
        {
            SourceFiles = context.SourceFiles.Take(maxFiles).ToArray(),
            Warnings = context.Warnings.Concat(warnings).Distinct(StringComparer.Ordinal).ToArray()
        };

        var sourceContents = includeContent && selectedContext.BuildId != Guid.Empty
            ? await LoadSourceContentsAsync(selectedContext, maxContentChars, cancellationToken)
            : [];

        return new LogSourceContextResponse(
            signals,
            selectedContext,
            sourceContents,
            selectedContext.Warnings);
    }

    public static IReadOnlyList<string> ExtractLogsFromTelemetry(
        RawTelemetryResult telemetry,
        int maxLogs)
    {
        if (telemetry.Data is null)
            return [];

        var logs = new List<string>();
        ExtractFromElement(telemetry.Data.Value, logs, maxLogs);
        return logs;
    }

    private async Task<SourceContextResponse> SearchAsync(
        string application,
        string? version,
        LogSourceSignal signal,
        int? maxDepth,
        int? maxResults,
        CancellationToken cancellationToken)
    {
        return signal.Kind.ToLowerInvariant() switch
        {
            "function" => await _repository.SearchFunctionAsync(
                new FunctionSearchRequest
                {
                    Application = application,
                    Version = version,
                    Function = signal.Symbol,
                    File = signal.File,
                    Line = signal.Line,
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            "class" => await _repository.SearchClassAsync(
                new ClassSearchRequest
                {
                    Application = application,
                    Version = version,
                    Class = signal.Symbol,
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            "file" => await _repository.SearchFilesAsync(
                new FileSearchRequest
                {
                    Application = application,
                    Version = version,
                    Files = [signal.Symbol],
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            _ => throw new ArgumentException($"Unsupported log source signal kind '{signal.Kind}'.")
        };
    }

    private async Task<IReadOnlyList<LogSourceFileContent>> LoadSourceContentsAsync(
        QuestionContextResponse context,
        int maxContentChars,
        CancellationToken cancellationToken)
    {
        var files = context.SourceFiles.Select(file => file.File).ToArray();
        var contents = await _repository.GetSourceContentsAsync(
            context.BuildId,
            files,
            cancellationToken);
        var byPath = contents.ToDictionary(content => content.File, StringComparer.OrdinalIgnoreCase);

        return context.SourceFiles
            .Select(file =>
            {
                if (!byPath.TryGetValue(file.File, out var content))
                {
                    return new LogSourceFileContent(
                        file.File,
                        file.Score,
                        file.Reasons,
                        file.RelevantLines,
                        file.ArtifactKind,
                        file.SourceRole,
                        file.Ownership,
                        file.Editable,
                        file.SourceOfTruth,
                        "SOURCE_CONTENT_NOT_FOUND_IN_SNAPSHOT",
                        false);
                }

                var truncated = content.Content.Length > maxContentChars;
                var text = truncated
                    ? content.Content[..maxContentChars] + "\n/* SOURCE_CONTENT_TRUNCATED */"
                    : content.Content;

                return new LogSourceFileContent(
                    file.File,
                    file.Score,
                    file.Reasons,
                    file.RelevantLines,
                    file.ArtifactKind,
                    file.SourceRole,
                    file.Ownership,
                    file.Editable,
                    file.SourceOfTruth,
                    text,
                    truncated);
            })
            .ToArray();
    }

    private static void ExtractFromElement(
        JsonElement element,
        List<string> logs,
        int maxLogs)
    {
        if (logs.Count >= maxLogs)
            return;

        if (element.ValueKind == JsonValueKind.Object)
        {
            if (element.TryGetProperty("values", out var values) &&
                values.ValueKind == JsonValueKind.Array)
            {
                foreach (var value in values.EnumerateArray())
                {
                    if (logs.Count >= maxLogs)
                        return;

                    if (TryReadLokiLogLine(value, out var line))
                        logs.Add(line);
                }
            }

            if (element.TryGetProperty("value", out var singleValue) &&
                TryReadLokiLogLine(singleValue, out var singleLine))
            {
                logs.Add(singleLine);
            }

            foreach (var property in element.EnumerateObject())
                ExtractFromElement(property.Value, logs, maxLogs);
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
                ExtractFromElement(item, logs, maxLogs);
        }
    }

    private static bool TryReadLokiLogLine(JsonElement value, out string line)
    {
        line = string.Empty;
        if (value.ValueKind != JsonValueKind.Array ||
            value.GetArrayLength() < 2)
        {
            return false;
        }

        var message = value[1];
        if (message.ValueKind != JsonValueKind.String)
            return false;

        line = message.GetString() ?? string.Empty;
        return !string.IsNullOrWhiteSpace(line);
    }
}

