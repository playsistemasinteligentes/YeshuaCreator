using System.Diagnostics;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Collectors;

public sealed class RuntimeContextCollector : IContextCollector
{
    private readonly IRuntimeEvidenceProvider _provider;
    private readonly McpOptions _options;
    private readonly LogKnowledgeReferenceResolver _knowledgeReferences;
    private readonly ILogger<RuntimeContextCollector> _logger;

    public RuntimeContextCollector(
        IRuntimeEvidenceProvider provider,
        IOptions<McpOptions> options,
        LogKnowledgeReferenceResolver knowledgeReferences,
        ILogger<RuntimeContextCollector> logger)
    {
        _provider = provider;
        _options = options.Value;
        _knowledgeReferences = knowledgeReferences;
        _logger = logger;
    }

    public string Name => "runtime";

    public bool CanCollect(InvestigationRequest request) =>
        !string.IsNullOrWhiteSpace(request.Application) &&
        (IsExplicitlyRequested(request) || HasRuntimeSelector(request));

    public async Task<CollectorResult> CollectAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var toUtc = request.ToUtc ?? DateTimeOffset.UtcNow;
        var fromUtc = request.FromUtc ?? toUtc.AddHours(-1);
        var warnings = new List<string>();

        if (fromUtc >= toUtc)
        {
            return new CollectorResult(
                Name,
                [],
                ["Runtime evidence requires FromUtc to be earlier than ToUtc."],
                stopwatch.Elapsed);
        }

        var maximumRange = TimeSpan.FromHours(_options.MaxTimeRangeHours);
        if (toUtc - fromUtc > maximumRange)
        {
            fromUtc = toUtc - maximumRange;
            warnings.Add($"Runtime time range was limited to {_options.MaxTimeRangeHours} hours.");
        }

        var limit = Math.Clamp(
            request.MaxResults ?? _options.DefaultLimit,
            1,
            _options.MaxLimit);
        var query = new RuntimeEvidenceQuery(
            request.Application,
            request.Version,
            request.Environment,
            request.RootOperationId,
            request.OperationId,
            request.OperationalEntityId,
            request.TraceId,
            fromUtc,
            toUtc,
            limit);

        _logger.LogInformation(
            "Collecting runtime evidence for {Application} {Environment} operation {OperationId} from {FromUtc} to {ToUtc}",
            query.Application,
            query.Environment,
            query.OperationId,
            query.FromUtc,
            query.ToUtc);

        var result = await _provider.QueryAsync(query, cancellationToken);
        warnings.AddRange(result.Warnings);
        var knowledgeReferences = await ResolveKnowledgeReferencesAsync(
            request,
            result,
            warnings,
            cancellationToken);
        stopwatch.Stop();

        var facts = BuildFacts(result);
        var inferences = BuildInferences(knowledgeReferences);
        var gaps = BuildGaps(result, knowledgeReferences, warnings);
        var evidence = new List<ContextEvidence>();
        if (result.Data.HasValue)
        {
            evidence.Add(new ContextEvidence(
                Name,
                "RUNTIME_OPERATIONAL_EVIDENCE",
                $"{result.Provider}: {result.RecordCount} runtime records for the selected operational scope.",
                request.Application,
                result.ResolvedVersion ?? request.Version ?? string.Empty,
                DateTimeOffset.UtcNow,
                result.HttpStatusCode is >= 200 and < 300 ? 1.0 : 0.0,
                new RuntimeInvestigationEvidence(
                    result,
                    knowledgeReferences,
                    facts,
                    inferences,
                    gaps)));
        }

        if (knowledgeReferences is not null)
            evidence.AddRange(knowledgeReferences.Evidence);

        return new CollectorResult(Name, evidence, warnings.Distinct().ToArray(), stopwatch.Elapsed);
    }

    private async Task<LogSourceContextResponse?> ResolveKnowledgeReferencesAsync(
        InvestigationRequest request,
        RuntimeEvidenceResponse runtime,
        List<string> warnings,
        CancellationToken cancellationToken)
    {
        if (!request.IncludeKnowledgeReferences || runtime.Data is null)
            return null;

        var version = runtime.ResolvedVersion ?? request.Version;
        if (string.IsNullOrWhiteSpace(version))
        {
            warnings.Add("Source correlation was skipped because the runtime version could not be resolved.");
            return null;
        }

        var telemetry = new RawTelemetryResult(
            runtime.Provider,
            runtime.Query,
            runtime.FromUtc,
            runtime.ToUtc,
            runtime.HttpStatusCode,
            runtime.Data,
            runtime.Warnings);
        var logs = LogKnowledgeReferenceResolver.ExtractLogsFromTelemetry(telemetry, 100);
        if (logs.Count == 0)
        {
            warnings.Add("Source correlation was skipped because no runtime log lines were returned.");
            return null;
        }

        try
        {
            var references = await _knowledgeReferences.ResolveAsync(
                request.Application,
                version,
                logs,
                request.IncludeSourceContent,
                12,
                5,
                30_000,
                request.MaxDepth,
                request.MaxResults,
                cancellationToken);
            warnings.AddRange(references.Warnings);
            return references;
        }
        catch (KeyNotFoundException exception)
        {
            warnings.Add(exception.Message);
            return null;
        }
    }

    private static IReadOnlyList<string> BuildFacts(RuntimeEvidenceResponse runtime)
    {
        var facts = new List<string>
        {
            $"Provider {runtime.Provider} returned {runtime.RecordCount} records between {runtime.FromUtc:O} and {runtime.ToUtc:O}."
        };
        if (!string.IsNullOrWhiteSpace(runtime.ResolvedVersion))
            facts.Add($"Runtime version: {runtime.ResolvedVersion}.");
        if (!string.IsNullOrWhiteSpace(runtime.ResolvedCommitSha))
            facts.Add($"Runtime commit: {runtime.ResolvedCommitSha}.");
        return facts;
    }

    private static IReadOnlyList<string> BuildInferences(LogSourceContextResponse? references)
    {
        if (references is null)
            return [];

        return references.ExtractedSignals
            .Select(signal =>
                $"{signal.Kind} '{signal.Symbol}' inferred from {signal.Evidence} with confidence {signal.Confidence:0.00}.")
            .ToArray();
    }

    private static IReadOnlyList<string> BuildGaps(
        RuntimeEvidenceResponse runtime,
        LogSourceContextResponse? references,
        IReadOnlyList<string> warnings)
    {
        var gaps = new List<string>(warnings);
        if (runtime.RecordCount == 0)
            gaps.Add("No runtime records matched the selected scope.");
        if (references is not null && references.Evidence.Count == 0)
            gaps.Add("Runtime signals were extracted, but no indexed source symbol was resolved.");
        return gaps.Distinct(StringComparer.Ordinal).ToArray();
    }

    private static bool IsExplicitlyRequested(InvestigationRequest request) =>
        request.Sources?.Contains("runtime", StringComparer.OrdinalIgnoreCase) == true;

    private static bool HasRuntimeSelector(InvestigationRequest request) =>
        !string.IsNullOrWhiteSpace(request.Environment) ||
        !string.IsNullOrWhiteSpace(request.RootOperationId) ||
        !string.IsNullOrWhiteSpace(request.OperationId) ||
        !string.IsNullOrWhiteSpace(request.OperationalEntityId) ||
        !string.IsNullOrWhiteSpace(request.TraceId) ||
        request.FromUtc.HasValue ||
        request.ToUtc.HasValue;
}
