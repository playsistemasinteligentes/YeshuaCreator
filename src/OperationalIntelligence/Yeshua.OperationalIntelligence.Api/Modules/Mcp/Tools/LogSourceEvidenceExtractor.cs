using System.Text.Json;
using System.Text.RegularExpressions;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class LogSourceEvidenceExtractor
{
    private const int MaximumTextLength = 200_000;

    private static readonly Regex StackFrameRegex = new(
        @"\bat\s+(?<symbol>[A-Za-z_][\w`]*(?:[.+][A-Za-z_][\w`<>]*)+)\s*\([^)]*\)(?:\s+in\s+(?<file>.*?\.cs):line\s+(?<line>\d+))?",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex FileLineRegex = new(
        @"(?:^|\s|[""']|in\s+)(?<file>(?:[A-Za-z]:\\|/|[A-Za-z0-9_.-]+[\\/])[^""'\r\n]+?\.cs)(?:(?::line\s+|:)(?<line>\d+))?",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    private static readonly Regex ExceptionTypeRegex = new(
        @"\b(?<symbol>(?:[A-Za-z_][\w]*\.)+[A-Za-z_][\w]*(?:Exception|Error))\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex QualifiedClassRegex = new(
        @"\b(?<symbol>(?:[A-Za-z_][\w]*\.)+[A-Z][A-Za-z0-9_]*(?:Receiver|Handler|Command|Query|Repository|Service|Worker|Controller|Endpoint|Entity|Behavior|Factory|Strategy|Saga|Step))\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public IReadOnlyList<LogSourceSignal> Extract(IReadOnlyList<string> logs)
    {
        var builder = new SignalBuilder();
        foreach (var log in logs)
        {
            if (string.IsNullOrWhiteSpace(log))
                continue;

            var text = log.Length > MaximumTextLength
                ? log[..MaximumTextLength]
                : log;

            ExtractFromText(text, builder);
            ExtractFromJson(text, builder);
        }

        return builder.ToArray();
    }

    private static void ExtractFromJson(string text, SignalBuilder builder)
    {
        try
        {
            using var document = JsonDocument.Parse(text);
            VisitJson(document.RootElement, builder);
        }
        catch (JsonException)
        {
        }
    }

    private static void VisitJson(JsonElement element, SignalBuilder builder)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                ExtractFromJsonObject(element, builder);
                foreach (var property in element.EnumerateObject())
                    VisitJson(property.Value, builder);
                break;
            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                    VisitJson(item, builder);
                break;
            case JsonValueKind.String:
                ExtractFromText(element.GetString() ?? string.Empty, builder);
                break;
        }
    }

    private static void ExtractFromJsonObject(JsonElement element, SignalBuilder builder)
    {
        var sourceContext = ReadFirstString(
            element,
            "SourceContext",
            "sourceContext",
            "CategoryName",
            "categoryName",
            "logger",
            "Logger",
            "category");
        var exceptionType = ReadFirstString(
            element,
            "exception.type",
            "ExceptionType",
            "exceptionType",
            "type");
        var codeNamespace = ReadFirstString(
            element,
            "code.namespace",
            "CodeNamespace",
            "namespace",
            "Namespace");
        var codeFunction = ReadFirstString(
            element,
            "code.function",
            "CodeFunction",
            "method",
            "Method",
            "methodName",
            "function",
            "Function",
            "functionName");
        var file = NormalizeFile(ReadFirstString(
            element,
            "code.filepath",
            "CodeFilePath",
            "file",
            "File",
            "filePath",
            "filepath",
            "path"));
        var line = ReadFirstInt(
            element,
            "code.lineno",
            "CodeLineNumber",
            "line",
            "Line",
            "lineNumber");

        if (!string.IsNullOrWhiteSpace(sourceContext))
            builder.Add("class", sourceContext, file, line, "json-source-context", 0.86);

        if (!string.IsNullOrWhiteSpace(exceptionType))
            builder.Add("class", exceptionType, file, line, "json-exception-type", 0.82);

        if (!string.IsNullOrWhiteSpace(codeFunction))
        {
            var function = !string.IsNullOrWhiteSpace(codeNamespace) &&
                           !codeFunction.Contains('.', StringComparison.Ordinal)
                ? codeNamespace + "." + codeFunction
                : codeFunction;
            builder.Add("function", function, file, line, "json-code-function", 0.92);
        }
    }

    private static string? ReadFirstString(JsonElement element, params string[] names)
    {
        foreach (var name in names)
        {
            if (!TryGetPropertyCaseInsensitive(element, name, out var property))
                continue;

            if (property.ValueKind == JsonValueKind.String)
                return property.GetString();
            if (property.ValueKind is JsonValueKind.Number or JsonValueKind.True or JsonValueKind.False)
                return property.GetRawText();
        }

        return null;
    }

    private static int? ReadFirstInt(JsonElement element, params string[] names)
    {
        foreach (var name in names)
        {
            if (!TryGetPropertyCaseInsensitive(element, name, out var property))
                continue;

            if (property.ValueKind == JsonValueKind.Number && property.TryGetInt32(out var number))
                return number;
            if (property.ValueKind == JsonValueKind.String &&
                int.TryParse(property.GetString(), out var parsed))
            {
                return parsed;
            }
        }

        return null;
    }

    private static bool TryGetPropertyCaseInsensitive(
        JsonElement element,
        string name,
        out JsonElement property)
    {
        foreach (var candidate in element.EnumerateObject())
        {
            if (candidate.NameEquals(name) ||
                string.Equals(candidate.Name, name, StringComparison.OrdinalIgnoreCase))
            {
                property = candidate.Value;
                return true;
            }
        }

        property = default;
        return false;
    }

    private static void ExtractFromText(string text, SignalBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;

        foreach (Match match in StackFrameRegex.Matches(text))
        {
            builder.Add(
                "function",
                match.Groups["symbol"].Value,
                NormalizeFile(match.Groups["file"].Value),
                ParseLine(match.Groups["line"].Value),
                "dotnet-stack-frame",
                0.98);
        }

        foreach (Match match in FileLineRegex.Matches(text))
        {
            builder.Add(
                "file",
                NormalizeFile(match.Groups["file"].Value),
                NormalizeFile(match.Groups["file"].Value),
                ParseLine(match.Groups["line"].Value),
                "source-file-path",
                0.64);
        }

        foreach (Match match in ExceptionTypeRegex.Matches(text))
        {
            builder.Add(
                "class",
                match.Groups["symbol"].Value,
                null,
                null,
                "exception-type",
                0.72);
        }

        foreach (Match match in QualifiedClassRegex.Matches(text))
        {
            builder.Add(
                "class",
                match.Groups["symbol"].Value,
                null,
                null,
                "qualified-type-name",
                0.68);
        }
    }

    private static string? NormalizeFile(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var normalized = value.Trim().Trim('"').Replace('\\', '/');
        var inIndex = normalized.LastIndexOf(" in ", StringComparison.OrdinalIgnoreCase);
        if (inIndex >= 0)
            normalized = normalized[(inIndex + 4)..];

        var marker = "/src/";
        var srcIndex = normalized.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
        if (srcIndex >= 0)
            normalized = normalized[(srcIndex + 1)..];

        return normalized;
    }

    private static int? ParseLine(string value) =>
        int.TryParse(value, out var line) ? line : null;

    private sealed class SignalBuilder
    {
        private readonly Dictionary<string, LogSourceSignal> _signals =
            new(StringComparer.OrdinalIgnoreCase);

        public void Add(
            string kind,
            string? symbol,
            string? file,
            int? line,
            string evidence,
            double confidence)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                return;

            var cleanSymbol = symbol.Trim().Trim('"');
            var cleanFile = NormalizeFile(file);
            var key = $"{kind}|{cleanSymbol}|{cleanFile}|{line}";
            if (_signals.TryGetValue(key, out var existing) &&
                existing.Confidence >= confidence)
            {
                return;
            }

            _signals[key] = new LogSourceSignal(
                kind,
                cleanSymbol,
                cleanFile,
                line,
                evidence,
                confidence);
        }

        public IReadOnlyList<LogSourceSignal> ToArray() =>
            _signals.Values
                .OrderByDescending(signal => signal.Confidence)
                .ThenBy(signal => signal.Kind, StringComparer.OrdinalIgnoreCase)
                .ThenBy(signal => signal.Symbol, StringComparer.OrdinalIgnoreCase)
                .ToArray();
    }
}
