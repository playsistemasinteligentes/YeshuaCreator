using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

internal static class CodexAccountProjection
{
    public static CodexAccountInfo? Account(JsonElement result)
    {
        if (!result.TryGetProperty("account", out var account) || account.ValueKind == JsonValueKind.Null) return null;
        var type = Text(account, "type", 40);
        return type == "chatgpt"
            ? new(type, Text(account, "email", 254), Text(account, "planType", 60))
            : new("Other", null, null);
    }

    public static IReadOnlyList<CodexRateLimit> Limits(JsonElement result)
    {
        var limits = new List<CodexRateLimit>();
        if (result.TryGetProperty("rateLimitsByLimitId", out var buckets) && buckets.ValueKind == JsonValueKind.Object)
            foreach (var bucket in buckets.EnumerateObject().Take(10))
                Add(bucket.Value, bucket.Name);
        else if (result.TryGetProperty("rateLimits", out var single) && single.ValueKind == JsonValueKind.Object)
            Add(single, Text(single, "limitId", 100) ?? "codex");
        return limits;

        void Add(JsonElement bucket, string id)
        {
            if (id.Length is 0 or > 100 || id.Any(char.IsControl)) return;
            limits.Add(new(id, Window(bucket, "primary"), Window(bucket, "secondary")));
        }
    }

    public static string? Text(JsonElement source, string name, int maxLength)
    {
        if (!source.TryGetProperty(name, out var value) || value.ValueKind == JsonValueKind.Null) return null;
        var text = value.GetString();
        if (text?.Length > maxLength || text?.Any(char.IsControl) == true)
            throw new InvalidOperationException("Invalid account response.");
        return text;
    }

    private static CodexRateWindow? Window(JsonElement source, string name)
    {
        if (!source.TryGetProperty(name, out var window) || window.ValueKind != JsonValueKind.Object ||
            !window.TryGetProperty("usedPercent", out var used) || !used.TryGetDouble(out var percent) ||
            !double.IsFinite(percent) || percent is < 0 or > 100) return null;
        int? duration = window.TryGetProperty("windowDurationMins", out var minutes) && minutes.TryGetInt32(out var m) && m > 0 ? m : null;
        long? reset = window.TryGetProperty("resetsAt", out var time) && time.TryGetInt64(out var seconds) && seconds > 0 ? seconds : null;
        return new(percent, duration, reset);
    }
}
