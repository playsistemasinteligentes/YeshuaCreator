using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class QueueHealthQueryTool(
    QueueHealthProjection projection,
    McpToolArgumentReader arguments) : IMcpTool
{
    public string Name => "yeshua.queue.health.query";
    public string Description =>
        "Starts queue investigation at the macro level: classifies queue flow and item health separately, then identifies which diseases require drill-down.";
    public object InputSchema => McpToolSchemas.QueueHealthQuery();

    public async Task<McpToolResult> CallAsync(
        JsonElement input,
        CancellationToken cancellationToken)
    {
        var result = await projection.QueryAsync(
            new QueueHealthQuery(
                arguments.String(input, "environment"),
                arguments.String(input, "service"),
                arguments.String(input, "queue")),
            cancellationToken);
        return McpToolResult.Ok(
            "Queue health classified from macro status to disease counts.",
            result);
    }
}

public sealed record QueueItemHealthEvidence(
    DateTimeOffset? ObservedAtUtc,
    int TenantId,
    string Queue,
    string ItemType,
    string ItemReference,
    string Disease,
    string Severity,
    long EligibleAgeSeconds,
    long ProcessingAgeSeconds,
    int ExecutionCount,
    int RetryCount,
    string LastOutcome,
    string? OperationalEntityId,
    string? RootOperationId,
    string? ExecutionId,
    string? ErrorSignature);

public sealed record QueueItemTraceCorrelation(
    string Status,
    string? Query,
    int MatchCount,
    string? ExecutionId,
    string? RootOperationId,
    JsonElement? Data);

public sealed record QueueItemDiagnosisResult(
    DateTimeOffset GeneratedAtUtc,
    string Queue,
    string ItemReference,
    string HealthStatus,
    string Disease,
    string DiseaseMeaning,
    string CauseClassification,
    string CauseConfidence,
    string Explanation,
    QueueItemHealthEvidence? LatestEvidence,
    QueueItemTraceCorrelation Trace,
    IReadOnlyList<string> RecommendedActions,
    IReadOnlyList<string> Warnings);

public sealed record QueueSickItemsResult(
    DateTimeOffset GeneratedAtUtc,
    string Queue,
    string HealthStatus,
    int ItemCount,
    IReadOnlyDictionary<string, int> DiseaseCounts,
    IReadOnlyList<QueueItemHealthEvidence> Items,
    string RecommendedNextStep,
    IReadOnlyList<string> Warnings);

public sealed class QueueItemDiagnoseTool(
    LokiClient loki,
    TempoClient tempo,
    McpToolArgumentReader arguments) : IMcpTool
{
    public string Name => "yeshua.queue.item.diagnose";
    public string Description =>
        "Lists a queue's sick items by disease; with itemReference, drills into one item and correlates its sanitized evidence with retained Tempo traces.";
    public object InputSchema => McpToolSchemas.QueueItemDiagnose();

    public async Task<McpToolResult> CallAsync(
        JsonElement input,
        CancellationToken cancellationToken)
    {
        var queue = arguments.RequiredString(input, "queue").Trim();
        var itemReference = arguments.String(input, "itemReference")?.Trim();
        var tenantId = arguments.Integer(input, "tenantId");
        if (tenantId is <= 0)
            return McpToolResult.Error("tenantId must be greater than zero when supplied.");
        var range = arguments.TimeRange(input, 24);
        if (range.Error is not null)
            return McpToolResult.Error(range.Error);

        var logql = BuildLogQuery(
            arguments.String(input, "service"),
            arguments.String(input, "environment"),
            queue,
            itemReference,
            tenantId);
        var logs = await loki.QueryRangeAsync(
            logql,
            range.FromUtc,
            range.ToUtc,
            Math.Min(arguments.Limit(input), 100),
            cancellationToken);
        if (string.IsNullOrWhiteSpace(itemReference))
        {
            var items = QueueItemEvidenceParser.List(logs.Data, queue, 25);
            var listWarnings = logs.Warnings.ToList();
            if (!tenantId.HasValue)
                listWarnings.Add("tenantId was omitted; results can include evidence from more than one tenant.");
            if (items.Count == 0)
                listWarnings.Add("Nenhuma evidencia individual recente foi encontrada; a metrica agregada pode continuar positiva ate o proximo snapshot.");
            var list = new QueueSickItemsResult(
                DateTimeOffset.UtcNow,
                queue,
                items.Count > 0 ? "sick" : "unknown",
                items.Count,
                items.GroupBy(item => item.Disease, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(group => group.Key, group => group.Count(), StringComparer.OrdinalIgnoreCase),
                items,
                items.Count > 0
                    ? "Escolha um itemReference e chame este mesmo metodo novamente para correlacionar evidencia e trace."
                    : "Confirme a contagem agregada e amplie o periodo dentro da retencao disponivel.",
                listWarnings);
            return McpToolResult.Ok("Sick queue items listed by disease.", list);
        }

        var evidence = QueueItemEvidenceParser.Latest(logs.Data, queue, itemReference);
        var warnings = logs.Warnings.ToList();
        if (!tenantId.HasValue)
            warnings.Add("tenantId was omitted; the evidence was not isolated by tenant.");
        if (evidence is null)
        {
            warnings.Add("Nenhuma evidencia individual foi encontrada no periodo. Ela pode ter expirado, sido deduplicada ou o item pode nao estar doente.");
            return McpToolResult.Ok(
                "No queue item disease evidence was found in the selected period.",
                Unknown(queue, itemReference, warnings));
        }

        var trace = await CorrelateTraceAsync(evidence, range, cancellationToken);
        if (trace.Status != "found")
            warnings.Add("Nenhum trace retido foi localizado pela identidade causal; isso nao elimina a evidencia operacional da doenca.");

        var cause = Cause(evidence);
        return McpToolResult.Ok(
            "Queue item diagnosis correlated with operational evidence and retained traces.",
            new QueueItemDiagnosisResult(
                DateTimeOffset.UtcNow,
                queue,
                itemReference,
                "sick",
                evidence.Disease,
                Meaning(evidence.Disease),
                cause.Classification,
                cause.Confidence,
                Explanation(evidence, trace),
                evidence,
                trace,
                Actions(evidence, trace),
                warnings));
    }

    private async Task<QueueItemTraceCorrelation> CorrelateTraceAsync(
        QueueItemHealthEvidence evidence,
        (DateTimeOffset FromUtc, DateTimeOffset ToUtc, string? Error) range,
        CancellationToken cancellationToken)
    {
        // Item-health snapshots are emitted outside the original Activity and may
        // carry an older ExecutionId. RootOperationId is stable across retries and
        // therefore is the primary macro-to-micro correlation key.
        var attribute = !string.IsNullOrWhiteSpace(evidence.RootOperationId)
            ? "yeshua.root_operation_id"
            : !string.IsNullOrWhiteSpace(evidence.ExecutionId)
                ? "yeshua.execution_id"
                : null;
        var value = !string.IsNullOrWhiteSpace(evidence.RootOperationId)
            ? evidence.RootOperationId
            : evidence.ExecutionId;
        if (attribute is null || string.IsNullOrWhiteSpace(value))
        {
            return new QueueItemTraceCorrelation(
                "identity_missing", null, 0, evidence.ExecutionId, evidence.RootOperationId, null);
        }

        var traceql = $"{{ span.{attribute} = \"{EscapeTraceQl(value)}\" }}";
        var result = await tempo.QueryAsync(
            null,
            traceql,
            range.FromUtc,
            range.ToUtc,
            20,
            cancellationToken);
        var count = CountTraceMatches(result.Data);
        return new QueueItemTraceCorrelation(
            count > 0 ? "found" : result.Warnings.Count > 0 ? "unavailable" : "not_found",
            traceql,
            count,
            evidence.ExecutionId,
            evidence.RootOperationId,
            result.Data);
    }

    private static QueueItemDiagnosisResult Unknown(
        string queue,
        string itemReference,
        IReadOnlyList<string> warnings) =>
        new(
            DateTimeOffset.UtcNow,
            queue,
            itemReference,
            "unknown",
            "not_found",
            "Nao foi possivel classificar a doenca no periodo consultado.",
            "unknown",
            "none",
            "Sem evidencia individual nao e seguro inferir doenca ou causa.",
            null,
            new QueueItemTraceCorrelation("not_searched", null, 0, null, null, null),
            ["Confirme o item pela consulta macro e amplie o periodo dentro da retencao disponivel."],
            warnings);

    private static string BuildLogQuery(
        string? service,
        string? environment,
        string queue,
        string? itemReference,
        int? tenantId)
    {
        var selectors = new List<string>
        {
            $"service_name=~\"{RegexLabel(service)}\""
        };
        if (!string.IsNullOrWhiteSpace(environment))
            selectors.Add($"deployment_environment_name=~\"^{EscapeLog(Regex.Escape(environment.Trim()))}$\"");
        return "{" + string.Join(',', selectors) + "}" +
               " |= \"QueueItem.HealthChanged\"" +
               (tenantId.HasValue
                   ? $" |= \"\\\"TenantId\\\":{tenantId.Value}\""
                   : string.Empty) +
               $" |= \"{EscapeLog(queue)}\"" +
               (string.IsNullOrWhiteSpace(itemReference)
                   ? string.Empty
                   : $" |= \"{EscapeLog(itemReference)}\"");
    }

    private static string RegexLabel(string? value) => string.IsNullOrWhiteSpace(value)
        ? ".+"
        : $"^{EscapeLog(Regex.Escape(value.Trim()))}$";

    private static string EscapeLog(string value) =>
        value.Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal)
            .Replace("\r", string.Empty, StringComparison.Ordinal)
            .Replace("\n", string.Empty, StringComparison.Ordinal);

    private static string EscapeTraceQl(string value) => EscapeLog(value);

    private static int CountTraceMatches(JsonElement? data)
    {
        if (data is not { } root)
            return 0;
        if (root.TryGetProperty("traces", out var direct) && direct.ValueKind == JsonValueKind.Array)
            return direct.GetArrayLength();
        if (root.TryGetProperty("data", out var nested) &&
            nested.TryGetProperty("traces", out var traces) &&
            traces.ValueKind == JsonValueKind.Array)
        {
            return traces.GetArrayLength();
        }
        return 0;
    }

    private static (string Classification, string Confidence) Cause(QueueItemHealthEvidence evidence) =>
        evidence.Disease switch
        {
            "TerminalFailure" when !string.IsNullOrWhiteSpace(evidence.ErrorSignature) => ("technical_failure_signature", "medium"),
            "RepeatedFailure" when !string.IsNullOrWhiteSpace(evidence.ErrorSignature) => ("repeated_technical_failure", "medium"),
            "StaleProcessing" => ("abandoned_processing", "high"),
            "RecurrentExecution" => ("recurrent_execution", "high"),
            "ExcessiveWait" => ("queue_wait", "high"),
            _ => ("unknown", "low")
        };

    private static string Meaning(string disease) => disease switch
    {
        "TerminalFailure" => "O item terminou em falha e nao possui retomada automatica pendente.",
        "RepeatedFailure" => "O item repetiu falhas acima do limite operacional.",
        "StaleProcessing" => "O item permaneceu marcado como em processamento alem do limite esperado.",
        "RecurrentExecution" => "O item voltou a executar mais vezes do que o esperado.",
        "ExcessiveWait" => "O item permaneceu elegivel sem ser processado alem do limite esperado.",
        _ => "Doenca operacional ainda nao reconhecida pelo diagnostico."
    };

    private static string Explanation(
        QueueItemHealthEvidence evidence,
        QueueItemTraceCorrelation trace) =>
        $"O item foi classificado como {evidence.Disease} com severidade {evidence.Severity}. " +
        (trace.Status == "found"
            ? $"Foram localizados {trace.MatchCount} trace(s) pela identidade da execucao."
            : "A evidencia esta preservada, mas nenhum trace correspondente foi localizado no periodo.");

    private static IReadOnlyList<string> Actions(
        QueueItemHealthEvidence evidence,
        QueueItemTraceCorrelation trace)
    {
        var actions = new List<string>();
        if (trace.Status == "found")
            actions.Add("Abrir o trace correlacionado e localizar o span mais lento ou marcado com falha.");
        if (!string.IsNullOrWhiteSpace(evidence.ErrorSignature))
            actions.Add("Agrupar outros itens pela mesma assinatura sanitizada para medir o alcance da falha.");
        actions.Add(evidence.Disease switch
        {
            "ExcessiveWait" => "Comparar backlog, vazao e disponibilidade do conjunto de Workers da fila.",
            "StaleProcessing" => "Verificar lock abandonado, encerramento abrupto do Worker e dependencia bloqueada.",
            "RecurrentExecution" => "Verificar idempotencia, retomadas e motivo de reentrada do item.",
            "RepeatedFailure" => "Localizar o primeiro span de falha e confirmar se o retry ainda faz sentido.",
            "TerminalFailure" => "Classificar a falha antes de decidir correcao, descarte ou retry manual.",
            _ => "Consultar logs e traces correlacionados antes de executar qualquer acao."
        });
        return actions;
    }
}

public static class QueueItemEvidenceParser
{
    public static QueueItemHealthEvidence? Latest(
        JsonElement? lokiResponse,
        string queue,
        string itemReference)
    {
        return List(lokiResponse, queue, 1, itemReference).FirstOrDefault();
    }

    public static IReadOnlyList<QueueItemHealthEvidence> List(
        JsonElement? lokiResponse,
        string queue,
        int limit,
        string? itemReference = null)
    {
        if (lokiResponse is not { } root ||
            !root.TryGetProperty("data", out var data) ||
            !data.TryGetProperty("result", out var result) ||
            result.ValueKind != JsonValueKind.Array)
        {
            return [];
        }

        var found = new List<QueueItemHealthEvidence>();
        var references = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var stream in result.EnumerateArray())
        {
            if (!stream.TryGetProperty("values", out var values) || values.ValueKind != JsonValueKind.Array)
                continue;
            foreach (var entry in values.EnumerateArray())
            {
                if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() < 2)
                    continue;
                var line = entry[1].GetString();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                try
                {
                    using var document = JsonDocument.Parse(line);
                    var candidate = FindEvidence(document.RootElement, queue, itemReference, null);
                    if (candidate is not null && references.Add(candidate.ItemReference))
                    {
                        found.Add(candidate);
                        if (found.Count >= Math.Max(1, limit))
                            return found;
                    }
                }
                catch (JsonException)
                {
                    // Loki may contain unrelated non-JSON lines; they are not health evidence.
                }
            }
        }
        return found;
    }

    private static QueueItemHealthEvidence? FindEvidence(
        JsonElement element,
        string queue,
        string? itemReference,
        DateTimeOffset? inheritedObservedAt)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            var observedAt = Date(element, "TimestampUtc") ?? inheritedObservedAt;
            var foundQueue = Text(element, "Queue");
            var foundItem = Text(element, "ItemReference");
            if (string.Equals(foundQueue, queue, StringComparison.OrdinalIgnoreCase) &&
                (string.IsNullOrWhiteSpace(itemReference) ||
                 string.Equals(foundItem, itemReference, StringComparison.OrdinalIgnoreCase)))
            {
                return new QueueItemHealthEvidence(
                    observedAt,
                    Integer(element, "TenantId"),
                    foundQueue!,
                    Text(element, "ItemType") ?? "unknown",
                    foundItem!,
                    Text(element, "Disease") ?? "unknown",
                    Text(element, "Severity") ?? "unknown",
                    Long(element, "EligibleAgeSeconds"),
                    Long(element, "ProcessingAgeSeconds"),
                    Integer(element, "ExecutionCount"),
                    Integer(element, "RetryCount"),
                    Text(element, "LastOutcome") ?? "unknown",
                    Text(element, "OperationalEntityId"),
                    Text(element, "RootOperationId"),
                    Text(element, "ExecutionId"),
                    Text(element, "ErrorSignature"));
            }

            foreach (var property in element.EnumerateObject())
            {
                if (property.Value.ValueKind is JsonValueKind.Object or JsonValueKind.Array)
                {
                    var nested = FindEvidence(property.Value, queue, itemReference, observedAt);
                    if (nested is not null)
                        return nested;
                }
                else if (property.Value.ValueKind == JsonValueKind.String &&
                         property.Value.GetString() is { } raw &&
                         raw.StartsWith('{'))
                {
                    try
                    {
                        using var nestedDocument = JsonDocument.Parse(raw);
                        var nested = FindEvidence(nestedDocument.RootElement, queue, itemReference, observedAt);
                        if (nested is not null)
                            return nested;
                    }
                    catch (JsonException)
                    {
                    }
                }
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var child in element.EnumerateArray())
            {
                var nested = FindEvidence(child, queue, itemReference, inheritedObservedAt);
                if (nested is not null)
                    return nested;
            }
        }
        return null;
    }

    private static JsonElement? Property(JsonElement value, string name)
    {
        foreach (var property in value.EnumerateObject())
            if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                return property.Value;
        return null;
    }

    private static string? Text(JsonElement value, string name)
    {
        var property = Property(value, name);
        return property is { ValueKind: JsonValueKind.String }
            ? property.Value.GetString()
            : property?.ToString();
    }

    private static long Long(JsonElement value, string name)
    {
        var property = Property(value, name);
        if (property is { ValueKind: JsonValueKind.Number } && property.Value.TryGetInt64(out var number))
            return number;
        return long.TryParse(property?.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out number)
            ? number
            : 0;
    }

    private static int Integer(JsonElement value, string name) =>
        (int)Math.Clamp(Long(value, name), int.MinValue, int.MaxValue);

    private static DateTimeOffset? Date(JsonElement value, string name) =>
        DateTimeOffset.TryParse(Text(value, name), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var parsed)
            ? parsed.ToUniversalTime()
            : null;
}
