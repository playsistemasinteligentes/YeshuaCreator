using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class HostDiskUsageReader(string path = "/host-diagnostics/disk-usage.json")
{
    public async Task<HostDiskUsageResult> ReadAsync(CancellationToken cancellationToken)
    {
        await using var stream = new FileStream(path, FileMode.Open, FileAccess.Read,
            FileShare.ReadWrite | FileShare.Delete, 4096, useAsync: true);
        if (stream.Length > 256 * 1024)
            throw new InvalidDataException("Host disk report exceeds its size limit.");
        using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
        var report = document.RootElement;
        if (report.ValueKind != JsonValueKind.Object ||
            !report.TryGetProperty("collectedAtUtc", out var timestamp) ||
            timestamp.ValueKind != JsonValueKind.String ||
            !timestamp.TryGetDateTimeOffset(out var collectedAt) ||
            !report.TryGetProperty("status", out var status) ||
            status.ValueKind != JsonValueKind.String ||
            !report.TryGetProperty("filesystem", out _) ||
            !report.TryGetProperty("sections", out _) ||
            !report.TryGetProperty("docker", out _))
            throw new InvalidDataException("Host disk report is invalid.");
        var now = DateTimeOffset.UtcNow;
        var age = Math.Max(0, (now - collectedAt).TotalSeconds);
        List<string> warnings = [];
        if (age > 20 * 60) warnings.Add("The report is older than twenty minutes; host collection may be unavailable.");
        if (status.GetString() != "complete") warnings.Add("Collection is partial; inspect each section before drawing conclusions.");
        return new(path, now, age, age > 20 * 60, report.Clone(), warnings);
    }
}

public sealed record HostDiskUsageResult(
    string ReportPath, DateTimeOffset RetrievedAtUtc, double AgeSeconds,
    bool IsStale, JsonElement Report, IReadOnlyList<string> Warnings);
