using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed record ObservabilityDashboardCatalogResult(
    DateTimeOffset GeneratedAtUtc,
    IReadOnlyList<ObservabilityDashboardSummary> Dashboards,
    IReadOnlyList<string> Warnings);

public sealed record ObservabilityDashboardSummary(
    string Uid,
    string Title,
    int Version,
    int PanelCount,
    IReadOnlyList<string> Tags,
    string SourceFile);

public sealed record ObservabilityDashboardContract(
    DateTimeOffset GeneratedAtUtc,
    string Uid,
    string Title,
    string Description,
    int Version,
    int SchemaVersion,
    int PanelCount,
    IReadOnlyList<string> Tags,
    string SourceFile,
    IReadOnlyList<ObservabilityDashboardVariable> Variables,
    IReadOnlyList<ObservabilityPanelContract> Panels,
    IReadOnlyList<string> Warnings);

public sealed record ObservabilityDashboardVariable(
    string Name,
    string Label,
    string Type,
    string? Query,
    bool IncludeAll,
    bool Multi);

public sealed record ObservabilityPanelContract(
    int Id,
    string Title,
    string Type,
    string Description,
    IReadOnlyDictionary<string, string> SemanticSections,
    string NormalizationStatus,
    ObservabilityPanelLayout Layout,
    ObservabilityPanelTechnicalContract Technical,
    IReadOnlyList<string> ReviewHints,
    JsonElement? RawConfiguration);

public sealed record ObservabilityPanelLayout(int X, int Y, int Width, int Height);

public sealed record ObservabilityPanelTechnicalContract(
    string? Unit,
    double? Minimum,
    double? Maximum,
    IReadOnlyList<string> Reducers,
    IReadOnlyList<ObservabilityThreshold> Thresholds,
    IReadOnlyList<ObservabilityFieldOverride> FieldOverrides,
    IReadOnlyList<ObservabilityQueryTarget> Targets);

public sealed record ObservabilityThreshold(string Color, double? Value);

public sealed record ObservabilityFieldOverride(
    string Matcher,
    string? MatchValue,
    string? Unit,
    double? Minimum,
    double? Maximum);

public sealed record ObservabilityQueryTarget(
    string RefId,
    string? Datasource,
    string QueryLanguage,
    string? Query,
    string QueryMode,
    string? Legend,
    string? Interval);

public sealed class ObservabilityDashboardCatalog(IOptions<McpOptions> options)
{
    private const long MaximumDashboardBytes = 4 * 1024 * 1024;
    private static readonly Regex DescriptionSection = new(
        @"\*\*(?<label>[^:*]+):\*\*\s*(?<value>.*?)(?=(?:\r?\n){2}\*\*[^:*]+:\*\*|\z)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
    private readonly string _catalogPath = options.Value.DashboardCatalogPath;

    public async Task<ObservabilityDashboardCatalogResult> ListAsync(CancellationToken cancellationToken)
    {
        var loaded = await LoadAsync(cancellationToken);
        var dashboards = loaded.Dashboards
            .Select(item => new ObservabilityDashboardSummary(
                RequiredText(item.Root, "uid", Path.GetFileNameWithoutExtension(item.SourceFile)),
                RequiredText(item.Root, "title", Path.GetFileNameWithoutExtension(item.SourceFile)),
                Integer(item.Root, "version"),
                Array(item.Root, "panels").Count,
                Strings(item.Root, "tags"),
                item.SourceFile))
            .OrderBy(item => item.Title, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return new(DateTimeOffset.UtcNow, dashboards, loaded.Warnings);
    }

    public async Task<ObservabilityDashboardContract?> GetAsync(
        string uid,
        bool includeRaw,
        CancellationToken cancellationToken)
    {
        var loaded = await LoadAsync(cancellationToken);
        var dashboard = loaded.Dashboards.FirstOrDefault(item =>
            string.Equals(Text(item.Root, "uid"), uid, StringComparison.OrdinalIgnoreCase));
        if (dashboard is null)
            return null;

        var root = dashboard.Root;
        var panels = Array(root, "panels")
            .Select(panel => NormalizePanel(panel, includeRaw))
            .OrderBy(panel => panel.Layout.Y)
            .ThenBy(panel => panel.Layout.X)
            .ThenBy(panel => panel.Id)
            .ToArray();
        var warnings = loaded.Warnings.ToList();
        var partial = panels.Count(panel => panel.NormalizationStatus == "partial");
        if (partial > 0)
            warnings.Add($"{partial} panel(s) have partial semantic or technical normalization.");

        return new(
            DateTimeOffset.UtcNow,
            RequiredText(root, "uid", uid),
            RequiredText(root, "title", uid),
            Text(root, "description") ?? string.Empty,
            Integer(root, "version"),
            Integer(root, "schemaVersion"),
            panels.Length,
            Strings(root, "tags"),
            dashboard.SourceFile,
            Variables(root),
            panels,
            warnings);
    }

    private async Task<LoadedCatalog> LoadAsync(CancellationToken cancellationToken)
    {
        var warnings = new List<string>();
        var dashboards = new List<LoadedDashboard>();
        if (string.IsNullOrWhiteSpace(_catalogPath))
            return new(dashboards, ["Dashboard catalog path is not configured."]);
        if (!Directory.Exists(_catalogPath))
            return new(dashboards, ["Dashboard catalog directory is unavailable."]);

        foreach (var path in Directory.EnumerateFiles(_catalogPath, "*.json", SearchOption.TopDirectoryOnly)
                     .OrderBy(path => path, StringComparer.OrdinalIgnoreCase))
        {
            cancellationToken.ThrowIfCancellationRequested();
            var file = new FileInfo(path);
            if (file.Length > MaximumDashboardBytes)
            {
                warnings.Add($"Dashboard {file.Name} exceeds the catalog size limit.");
                continue;
            }

            try
            {
                var content = await File.ReadAllTextAsync(path, cancellationToken);
                using var document = JsonDocument.Parse(content, new JsonDocumentOptions { MaxDepth = 64 });
                if (document.RootElement.ValueKind != JsonValueKind.Object ||
                    string.IsNullOrWhiteSpace(Text(document.RootElement, "uid")))
                {
                    warnings.Add($"Dashboard {file.Name} has no uid and was ignored.");
                    continue;
                }
                dashboards.Add(new(file.Name, document.RootElement.Clone()));
            }
            catch (JsonException)
            {
                warnings.Add($"Dashboard {file.Name} contains invalid JSON.");
            }
            catch (IOException)
            {
                warnings.Add($"Dashboard {file.Name} could not be read.");
            }
        }

        return new(dashboards, warnings);
    }

    private static ObservabilityPanelContract NormalizePanel(JsonElement panel, bool includeRaw)
    {
        var description = Text(panel, "description") ?? string.Empty;
        var sections = ParseSections(description);
        var technical = Technical(panel);
        var hints = ReviewHints(panel, sections, technical);
        var complete = !string.IsNullOrWhiteSpace(Text(panel, "title")) &&
                       sections.ContainsKey("whatItMeasures") &&
                       sections.ContainsKey("howToInterpret") &&
                       technical.Targets.Count > 0 &&
                       technical.Targets.All(target => !string.IsNullOrWhiteSpace(target.Query));
        var grid = Object(panel, "gridPos");

        return new(
            Integer(panel, "id"),
            RequiredText(panel, "title", $"Panel {Integer(panel, "id")}"),
            RequiredText(panel, "type", "unknown"),
            description,
            sections,
            complete ? "complete" : "partial",
            new(Integer(grid, "x"), Integer(grid, "y"), Integer(grid, "w"), Integer(grid, "h")),
            technical,
            hints,
            includeRaw ? panel.Clone() : null);
    }

    private static ObservabilityPanelTechnicalContract Technical(JsonElement panel)
    {
        var fieldConfig = Object(panel, "fieldConfig");
        var defaults = Object(fieldConfig, "defaults");
        var options = Object(panel, "options");
        var reducers = Array(Object(options, "reduceOptions"), "calcs")
            .Where(item => item.ValueKind == JsonValueKind.String)
            .Select(item => item.GetString()!)
            .ToArray();
        var thresholds = Array(Object(defaults, "thresholds"), "steps")
            .Select(step => new ObservabilityThreshold(
                Text(step, "color") ?? "unknown",
                NullableDouble(step, "value")))
            .ToArray();
        var overrides = Array(fieldConfig, "overrides").Select(FieldOverride).ToArray();
        var panelDatasource = Datasource(panel);
        var panelType = Text(panel, "type") ?? "unknown";
        var targets = Array(panel, "targets")
            .Select(target => QueryTarget(target, panelDatasource, panelType))
            .ToArray();

        return new(
            Text(defaults, "unit"),
            NullableDouble(defaults, "min"),
            NullableDouble(defaults, "max"),
            reducers,
            thresholds,
            overrides,
            targets);
    }

    private static ObservabilityFieldOverride FieldOverride(JsonElement item)
    {
        var matcher = Object(item, "matcher");
        string? unit = null;
        double? minimum = null;
        double? maximum = null;
        foreach (var property in Array(item, "properties"))
        {
            var id = Text(property, "id");
            if (!property.TryGetProperty("value", out var value))
                continue;
            if (id == "unit" && value.ValueKind == JsonValueKind.String) unit = value.GetString();
            if (id == "min" && value.TryGetDouble(out var min)) minimum = min;
            if (id == "max" && value.TryGetDouble(out var max)) maximum = max;
        }

        return new(
            Text(matcher, "id") ?? "unknown",
            matcher.TryGetProperty("options", out var matchValue) ? matchValue.ToString() : null,
            unit,
            minimum,
            maximum);
    }

    private static ObservabilityQueryTarget QueryTarget(
        JsonElement target,
        string? panelDatasource,
        string panelType)
    {
        var datasource = Datasource(target) ?? panelDatasource;
        var query = Text(target, "expr") ?? Text(target, "query") ?? Text(target, "rawSql");
        var instant = Boolean(target, "instant");
        var range = target.TryGetProperty("range", out var rangeValue)
            ? rangeValue.ValueKind == JsonValueKind.True
            : !instant && panelType is "timeseries" or "stat";
        var mode = instant ? "instant" : range ? "range" : "unspecified";

        return new(
            Text(target, "refId") ?? "?",
            datasource,
            QueryLanguage(datasource),
            query,
            mode,
            Text(target, "legendFormat"),
            Text(target, "interval"));
    }

    private static IReadOnlyList<string> ReviewHints(
        JsonElement panel,
        IReadOnlyDictionary<string, string> sections,
        ObservabilityPanelTechnicalContract technical)
    {
        var hints = new List<string>();
        if (!sections.ContainsKey("whatItMeasures"))
            hints.Add("Describe what the panel measures.");
        if (!sections.ContainsKey("howToInterpret"))
            hints.Add("Describe how an operator should interpret the panel.");
        if (!sections.ContainsKey("source"))
            hints.Add("Declare the signal source when it is not obvious from the query.");
        if (technical.Targets.Count == 0 || technical.Targets.Any(target => string.IsNullOrWhiteSpace(target.Query)))
            hints.Add("One or more panel queries could not be normalized.");
        if (string.Equals(Text(panel, "type"), "stat", StringComparison.OrdinalIgnoreCase) &&
            technical.Reducers.Contains("lastNotNull", StringComparer.OrdinalIgnoreCase) &&
            technical.Targets.Any(target => target.QueryMode == "range"))
        {
            hints.Add("The displayed last value depends on the range query resolution; use an instant query when the semantic promise is current value.");
        }
        if (technical.Targets.Count > 1 && technical.FieldOverrides.Select(item => item.Unit).Where(item => item is not null).Distinct().Count() > 1)
            hints.Add("The panel combines multiple units; verify axes and legends remain unambiguous.");
        return hints;
    }

    private static IReadOnlyDictionary<string, string> ParseSections(string description)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in DescriptionSection.Matches(description))
        {
            var key = NormalizeSectionName(match.Groups["label"].Value);
            var value = match.Groups["value"].Value.Trim();
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                result[key] = value;
        }
        return result;
    }

    private static string NormalizeSectionName(string label)
    {
        var normalized = RemoveDiacritics(label).Trim().ToLowerInvariant();
        return normalized switch
        {
            "pergunta" => "question",
            "o que mede" => "whatItMeasures",
            "como interpretar" => "howToInterpret",
            "fonte" => "source",
            "limitacoes" => "limitations",
            "acao recomendada" => "recommendedAction",
            "cuidado" => "caution",
            "importante" => "important",
            "categorias" => "categories",
            "custo" => "cost",
            _ => CamelCase(normalized)
        };
    }

    private static string RemoveDiacritics(string value)
    {
        var builder = new StringBuilder();
        foreach (var character in value.Normalize(NormalizationForm.FormD))
            if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                builder.Append(character);
        return builder.ToString().Normalize(NormalizationForm.FormC);
    }

    private static string CamelCase(string value)
    {
        var words = Regex.Split(value, @"[^a-z0-9]+").Where(word => word.Length > 0).ToArray();
        if (words.Length == 0) return string.Empty;
        return words[0] + string.Concat(words.Skip(1).Select(word => char.ToUpperInvariant(word[0]) + word[1..]));
    }

    private static IReadOnlyList<ObservabilityDashboardVariable> Variables(JsonElement root) =>
        Array(Object(root, "templating"), "list")
            .Select(item =>
            {
                var query = item.TryGetProperty("query", out var queryValue)
                    ? queryValue.ValueKind == JsonValueKind.String
                        ? queryValue.GetString()
                        : Text(queryValue, "query")
                    : null;
                return new ObservabilityDashboardVariable(
                    Text(item, "name") ?? string.Empty,
                    Text(item, "label") ?? Text(item, "name") ?? string.Empty,
                    Text(item, "type") ?? "unknown",
                    query,
                    Boolean(item, "includeAll"),
                    Boolean(item, "multi"));
            })
            .ToArray();

    private static string? Datasource(JsonElement element)
    {
        if (!element.TryGetProperty("datasource", out var datasource)) return null;
        return datasource.ValueKind == JsonValueKind.String ? datasource.GetString() : Text(datasource, "type");
    }

    private static string QueryLanguage(string? datasource) => datasource?.ToLowerInvariant() switch
    {
        "prometheus" => "PromQL",
        "loki" => "LogQL",
        "tempo" => "TraceQL",
        _ => "unknown"
    };

    private static string RequiredText(JsonElement element, string name, string fallback) =>
        Text(element, name) ?? fallback;
    private static string? Text(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String
            ? value.GetString()
            : null;
    private static int Integer(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) &&
        value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var result)
            ? result
            : 0;
    private static double? NullableDouble(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) &&
        value.ValueKind == JsonValueKind.Number && value.TryGetDouble(out var result)
            ? result
            : null;
    private static bool Boolean(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.True;
    private static JsonElement Object(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.Object
            ? value
            : default;
    private static IReadOnlyList<JsonElement> Array(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.Array
            ? value.EnumerateArray().ToArray()
            : [];
    private static IReadOnlyList<string> Strings(JsonElement element, string name) =>
        Array(element, name).Where(item => item.ValueKind == JsonValueKind.String).Select(item => item.GetString()!).ToArray();

    private sealed record LoadedDashboard(string SourceFile, JsonElement Root);
    private sealed record LoadedCatalog(IReadOnlyList<LoadedDashboard> Dashboards, IReadOnlyList<string> Warnings);
}
