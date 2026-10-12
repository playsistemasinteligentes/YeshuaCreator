using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Collectors;

public sealed class LokiRuntimeEvidenceProvider : IRuntimeEvidenceProvider
{
    private readonly LokiClient _loki;

    public LokiRuntimeEvidenceProvider(LokiClient loki)
    {
        _loki = loki;
    }

    public async Task<RuntimeEvidenceResponse> QueryAsync(
        RuntimeEvidenceQuery query,
        CancellationToken cancellationToken)
    {
        var logql = LogQueryBuilder.BuildRuntime(
            query.Application,
            query.Environment,
            query.Version,
            query.RootOperationId,
            query.OperationId,
            query.OperationalEntityId,
            query.TraceId);
        var result = await _loki.QueryRangeAsync(
            logql,
            query.FromUtc,
            query.ToUtc,
            query.Limit,
            cancellationToken);
        var labels = ReadRuntimeLabels(result.Data);
        var warnings = result.Warnings.ToList();
        var resolvedVersion = ResolveSingleLabel(
            labels.Versions,
            query.Version,
            "service version",
            warnings);
        var resolvedCommitSha = ResolveSingleLabel(
            labels.CommitShas,
            null,
            "service commit",
            warnings);

        return new RuntimeEvidenceResponse(
            result.Source,
            result.Query,
            query.FromUtc,
            query.ToUtc,
            result.HttpStatusCode,
            CountRecords(result.Data),
            resolvedVersion,
            resolvedCommitSha,
            result.Data,
            warnings);
    }

    private static RuntimeLabels ReadRuntimeLabels(JsonElement? payload)
    {
        var versions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var commits = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (payload is not { ValueKind: JsonValueKind.Object } root ||
            !root.TryGetProperty("data", out var data) ||
            !data.TryGetProperty("result", out var streams) ||
            streams.ValueKind != JsonValueKind.Array)
        {
            return new RuntimeLabels(versions, commits);
        }

        foreach (var entry in streams.EnumerateArray())
        {
            if (!entry.TryGetProperty("stream", out var stream) ||
                stream.ValueKind != JsonValueKind.Object)
            {
                continue;
            }

            AddLabel(stream, "service_version", versions);
            AddLabel(stream, "service_commit_sha", commits);
        }

        return new RuntimeLabels(versions, commits);
    }

    private static void AddLabel(
        JsonElement labels,
        string name,
        HashSet<string> values)
    {
        if (labels.TryGetProperty(name, out var value) &&
            value.ValueKind == JsonValueKind.String &&
            !string.IsNullOrWhiteSpace(value.GetString()))
        {
            values.Add(value.GetString()!);
        }
    }

    private static string? ResolveSingleLabel(
        IReadOnlyCollection<string> values,
        string? requested,
        string label,
        List<string> warnings)
    {
        if (!string.IsNullOrWhiteSpace(requested))
            return requested;
        if (values.Count == 1)
            return values.Single();
        if (values.Count > 1)
            warnings.Add($"Runtime query returned multiple {label} values; narrow the query before correlating source code.");
        else
            warnings.Add($"Runtime query did not return a {label} label.");
        return null;
    }

    private static int CountRecords(JsonElement? payload)
    {
        if (payload is not { ValueKind: JsonValueKind.Object } root ||
            !root.TryGetProperty("data", out var data) ||
            !data.TryGetProperty("result", out var streams) ||
            streams.ValueKind != JsonValueKind.Array)
        {
            return 0;
        }

        var count = 0;
        foreach (var stream in streams.EnumerateArray())
        {
            if (stream.TryGetProperty("values", out var values) &&
                values.ValueKind == JsonValueKind.Array)
            {
                count += values.GetArrayLength();
            }
        }

        return count;
    }

    private sealed record RuntimeLabels(
        IReadOnlyCollection<string> Versions,
        IReadOnlyCollection<string> CommitShas);
}
