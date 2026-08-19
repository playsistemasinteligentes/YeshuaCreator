using System.Diagnostics;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Collectors;
using Yeshua.OperationalIntelligence.Api.Configuration;
using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Application;

public sealed class OperationalContextOrchestrator
{
    private readonly IReadOnlyList<IContextCollector> _collectors;
    private readonly OperationalIntelligenceOptions _options;
    private readonly ILogger<OperationalContextOrchestrator> _logger;

    public OperationalContextOrchestrator(
        IEnumerable<IContextCollector> collectors,
        IOptions<OperationalIntelligenceOptions> options,
        ILogger<OperationalContextOrchestrator> logger)
    {
        _collectors = collectors.ToArray();
        _options = options.Value;
        _logger = logger;
    }

    public async Task<InvestigationResponse> InvestigateAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var startedAt = DateTimeOffset.UtcNow;
        var stopwatch = Stopwatch.StartNew();
        var selected = _collectors
            .Where(collector => IsRequested(collector, request) && collector.CanCollect(request))
            .ToArray();

        if (selected.Length == 0)
        {
            return new InvestigationResponse(
                request.Application,
                request.Version,
                startedAt,
                stopwatch.Elapsed,
                [],
                [],
                ["No collector accepted the investigation request."]);
        }

        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(TimeSpan.FromSeconds(Math.Max(1, _options.CollectorTimeoutSeconds)));

        var results = await Task.WhenAll(
            selected.Select(collector => CollectSafelyAsync(collector, request, timeout.Token)));
        stopwatch.Stop();

        var evidence = results
            .SelectMany(result => result.Evidence)
            .GroupBy(item => $"{item.Source}|{item.EvidenceType}|{item.Description}", StringComparer.Ordinal)
            .Select(group => group.First())
            .ToArray();
        var warnings = results.SelectMany(result => result.Warnings).Distinct().ToArray();

        return new InvestigationResponse(
            request.Application,
            request.Version,
            startedAt,
            stopwatch.Elapsed,
            results,
            evidence,
            warnings);
    }

    private async Task<CollectorResult> CollectSafelyAsync(
        IContextCollector collector,
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await collector.CollectAsync(request, cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return new CollectorResult(
                collector.Name,
                [],
                [$"Collector '{collector.Name}' exceeded its time budget or was cancelled."],
                stopwatch.Elapsed);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Context collector {Collector} failed", collector.Name);
            return new CollectorResult(
                collector.Name,
                [],
                [$"Collector '{collector.Name}' failed: {exception.Message}"],
                stopwatch.Elapsed);
        }
    }

    private static bool IsRequested(IContextCollector collector, InvestigationRequest request)
        => request.Sources == null || request.Sources.Count == 0 ||
           request.Sources.Contains(collector.Name, StringComparer.OrdinalIgnoreCase);
}
