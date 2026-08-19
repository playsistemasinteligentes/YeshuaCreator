using System.Diagnostics;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Collectors;

public sealed class SourceCodeContextCollector : IContextCollector
{
    private readonly ISourceContextRepository _repository;

    public SourceCodeContextCollector(ISourceContextRepository repository)
    {
        _repository = repository;
    }

    public string Name => "source-code";

    public bool CanCollect(InvestigationRequest request)
        => !string.IsNullOrWhiteSpace(request.Field) ||
           !string.IsNullOrWhiteSpace(request.Class) ||
           !string.IsNullOrWhiteSpace(request.Function);

    public async Task<CollectorResult> CollectAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var searches = new List<Task<(string Type, SourceContextResponse Result)>>();

        if (!string.IsNullOrWhiteSpace(request.Field))
        {
            searches.Add(SearchFieldAsync(request, cancellationToken));
        }

        if (!string.IsNullOrWhiteSpace(request.Class))
        {
            searches.Add(SearchClassAsync(request, cancellationToken));
        }

        if (!string.IsNullOrWhiteSpace(request.Function))
        {
            searches.Add(SearchFunctionAsync(request, cancellationToken));
        }

        var results = await Task.WhenAll(searches);
        var evidence = results.Select(item => new ContextEvidence(
                Name,
                item.Type,
                Describe(item.Type, item.Result),
                item.Result.Build.Application,
                item.Result.Build.Version,
                DateTimeOffset.UtcNow,
                item.Result.Matches.Count > 0 ? 1.0 : 0.0,
                item.Result))
            .ToArray();
        var warnings = results.SelectMany(item => item.Result.Warnings).Distinct().ToArray();

        stopwatch.Stop();
        return new CollectorResult(Name, evidence, warnings, stopwatch.Elapsed);
    }

    private async Task<(string, SourceContextResponse)> SearchFieldAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.SearchFieldAsync(
            new FieldSearchRequest
            {
                Application = request.Application,
                Version = request.Version,
                Field = request.Field!,
                MaxDepth = request.MaxDepth,
                MaxResults = request.MaxResults
            },
            cancellationToken);
        return ("FIELD_SOURCE_CONTEXT", result);
    }

    private async Task<(string, SourceContextResponse)> SearchClassAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.SearchClassAsync(
            new ClassSearchRequest
            {
                Application = request.Application,
                Version = request.Version,
                Class = request.Class!,
                MaxDepth = request.MaxDepth,
                MaxResults = request.MaxResults
            },
            cancellationToken);
        return ("CLASS_SOURCE_CONTEXT", result);
    }

    private async Task<(string, SourceContextResponse)> SearchFunctionAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.SearchFunctionAsync(
            new FunctionSearchRequest
            {
                Application = request.Application,
                Version = request.Version,
                Function = request.Function!,
                File = request.File,
                Line = request.Line,
                MaxDepth = request.MaxDepth,
                MaxResults = request.MaxResults
            },
            cancellationToken);
        return ("FUNCTION_SOURCE_CONTEXT", result);
    }

    private static string Describe(string type, SourceContextResponse result)
        => $"{type}: {result.Matches.Count} symbol matches, {result.References.Count} references, " +
           $"{result.Chains.Count} call chains and {result.SourceFiles.Count} candidate source files.";
}
