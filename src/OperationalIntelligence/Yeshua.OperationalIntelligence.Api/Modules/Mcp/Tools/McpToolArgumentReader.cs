using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class McpToolArgumentReader
{
    private readonly McpOptions _options;

    public McpToolArgumentReader(IOptions<McpOptions> options)
    {
        _options = options.Value;
    }

    public string? String(JsonElement arguments, string name)
    {
        if (!arguments.TryGetProperty(name, out var value) ||
            value.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        return value.ValueKind == JsonValueKind.String
            ? value.GetString()
            : value.GetRawText();
    }

    public int? Integer(JsonElement arguments, string name)
    {
        if (!arguments.TryGetProperty(name, out var value) ||
            value.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        return value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var parsed)
            ? parsed
            : null;
    }

    public DateTimeOffset? DateTime(JsonElement arguments, string name)
    {
        var raw = String(arguments, name);
        return System.DateTimeOffset.TryParse(raw, out var parsed)
            ? parsed.ToUniversalTime()
            : null;
    }

    public int Limit(JsonElement arguments)
    {
        var requested = Integer(arguments, "limit") ?? _options.DefaultLimit;
        return Math.Clamp(requested, 1, Math.Max(1, _options.MaxLimit));
    }

    public int ClampedInteger(
        JsonElement arguments,
        string name,
        int defaultValue,
        int minimum,
        int maximum)
    {
        var requested = Integer(arguments, name) ?? defaultValue;
        return Math.Clamp(requested, minimum, maximum);
    }

    public bool Boolean(JsonElement arguments, string name, bool defaultValue = false)
    {
        if (!arguments.TryGetProperty(name, out var value) ||
            value.ValueKind == JsonValueKind.Null)
        {
            return defaultValue;
        }

        return value.ValueKind switch
        {
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.String when bool.TryParse(value.GetString(), out var parsed) => parsed,
            _ => defaultValue
        };
    }

    public (DateTimeOffset FromUtc, DateTimeOffset ToUtc, string? Error) TimeRange(
        JsonElement arguments)
    {
        var toUtc = DateTime(arguments, "toUtc") ?? System.DateTimeOffset.UtcNow;
        var fromUtc = DateTime(arguments, "fromUtc") ??
                      toUtc.AddHours(-Math.Min(1, _options.MaxTimeRangeHours));

        if (fromUtc > toUtc)
            return (fromUtc, toUtc, "fromUtc must be before toUtc.");

        var maximum = TimeSpan.FromHours(Math.Max(1, _options.MaxTimeRangeHours));
        if (toUtc - fromUtc > maximum)
            return (fromUtc, toUtc, $"Time range cannot exceed {_options.MaxTimeRangeHours} hours.");

        return (fromUtc, toUtc, null);
    }

    public string RequiredString(JsonElement arguments, string name)
    {
        var value = String(arguments, name);
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{name} is required.");

        return value;
    }
}
