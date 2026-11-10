using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed record QueueHealthQuery(
    string? Environment,
    string? Service,
    string? Queue);

public sealed record QueueDiseaseCounts(
    long Total,
    long ExcessiveWait,
    long StaleProcessing,
    long RecurrentExecution,
    long RepeatedFailure,
    long TerminalFailure);

public sealed record QueueHealthSignals(
    string Environment,
    string Service,
    string Operation,
    string Queue,
    long EligibleBacklog,
    long OldestEligibleAgeSeconds,
    long SampleAgeSeconds,
    bool SampleFailed,
    long? HeartbeatAgeSeconds,
    double ProcessedLastFiveMinutes,
    QueueDiseaseCounts Diseases);

public sealed record QueueHealthView(
    string Environment,
    string Service,
    string Operation,
    string Queue,
    string OverallStatus,
    string OverallLabel,
    string QueueStatus,
    string QueueStatusLabel,
    string ItemStatus,
    string ItemStatusLabel,
    string Reason,
    string RecommendedAction,
    long EligibleBacklog,
    long OldestEligibleAgeSeconds,
    long SampleAgeSeconds,
    long? HeartbeatAgeSeconds,
    double ProcessedLastFiveMinutes,
    QueueDiseaseCounts Diseases);

public sealed record QueueHealthSummary(
    int TotalQueues,
    int HealthyQueues,
    int DegradedQueues,
    int SickQueues,
    int UnavailableQueues,
    long TotalSickItems);

public sealed record QueueHealthProjectionResult(
    DateTimeOffset GeneratedAtUtc,
    QueueHealthSummary Summary,
    IReadOnlyList<QueueHealthView> Queues,
    IReadOnlyList<string> Warnings);

public static class QueueHealthClassifier
{
    private const long FreshnessSeconds = 180;
    private const long NoProgressGraceSeconds = 120;
    private const long ExcessiveQueueAgeSeconds = 900;

    public static QueueHealthView Classify(QueueHealthSignals signals)
    {
        var queue = QueueAxis(signals);
        var items = ItemAxis(signals.Diseases);
        var overall = Worst(queue.Code, items.Code);
        var reason = Reason(signals, queue.Code, items.Code);

        return new QueueHealthView(
            signals.Environment,
            signals.Service,
            signals.Operation,
            signals.Queue,
            overall,
            Label(overall),
            queue.Code,
            Label(queue.Code),
            items.Code,
            Label(items.Code),
            reason,
            Action(signals, queue.Code, items.Code),
            signals.EligibleBacklog,
            signals.OldestEligibleAgeSeconds,
            signals.SampleAgeSeconds,
            signals.HeartbeatAgeSeconds,
            Math.Round(signals.ProcessedLastFiveMinutes, 2),
            signals.Diseases);
    }

    private static (string Code, string Detail) QueueAxis(QueueHealthSignals signals)
    {
        if (signals.SampleFailed || signals.SampleAgeSeconds > FreshnessSeconds)
            return ("unavailable", "queue snapshot is missing or stale");

        if (signals.EligibleBacklog <= 0)
            return ("healthy", "queue is idle with no eligible backlog");

        if (!signals.HeartbeatAgeSeconds.HasValue || signals.HeartbeatAgeSeconds > FreshnessSeconds)
            return ("sick", "eligible backlog exists without a fresh worker heartbeat");

        if (signals.ProcessedLastFiveMinutes <= 0 &&
            signals.OldestEligibleAgeSeconds >= NoProgressGraceSeconds)
        {
            return ("sick", "eligible backlog exists without progress in the last five minutes");
        }

        if (signals.OldestEligibleAgeSeconds >= ExcessiveQueueAgeSeconds)
            return ("degraded", "the queue is progressing but its oldest eligible item is late");

        return ("healthy", "the queue has active workers and recent progress");
    }

    private static (string Code, string Detail) ItemAxis(QueueDiseaseCounts diseases)
    {
        if (diseases.TerminalFailure > 0 || diseases.StaleProcessing > 0)
            return ("sick", "critical item diseases are present");
        if (diseases.Total > 0)
            return ("degraded", "one or more individually sick items are present");
        return ("healthy", "no sick items were classified");
    }

    private static string Reason(
        QueueHealthSignals signals,
        string queueStatus,
        string itemStatus)
    {
        if (queueStatus == "unavailable")
            return "Nao ha amostra recente e confiavel para avaliar a fila.";
        if (queueStatus == "sick" && signals.EligibleBacklog > 0)
            return signals.HeartbeatAgeSeconds is null or > FreshnessSeconds
                ? "Existe backlog elegivel, mas nenhum Worker ativo foi confirmado."
                : "Existe backlog elegivel sem vazao recente; a fila nao esta avancando.";
        if (itemStatus == "sick")
            return $"A fila pode continuar operando, mas possui {signals.Diseases.Total} item(ns) doente(s), incluindo doenca critica.";
        if (itemStatus == "degraded")
            return $"A fila esta operando, mas possui {signals.Diseases.Total} item(ns) que precisam de investigacao.";
        if (signals.EligibleBacklog == 0)
            return "Fila ociosa e sem itens doentes.";
        return "Fila com Workers ativos, progresso recente e sem itens doentes.";
    }

    private static string Action(
        QueueHealthSignals signals,
        string queueStatus,
        string itemStatus)
    {
        if (queueStatus == "unavailable")
            return "Verificar o probe da fila e a chegada das metricas pelo Collector.";
        if (queueStatus == "sick" && signals.HeartbeatAgeSeconds is null or > FreshnessSeconds)
            return "Verificar disponibilidade das replicas do Worker antes de investigar itens.";
        if (queueStatus == "sick")
            return "Investigar bloqueio comum da fila: banco, dependencia externa, lock ou capacidade.";
        if (itemStatus is "sick" or "degraded")
            return "Abrir as doencas e diagnosticar os itens afetados pelas evidencias e traces correlacionados.";
        return "Nenhuma acao corretiva; acompanhar a tendencia.";
    }

    private static string Worst(string left, string right) =>
        Rank(left) >= Rank(right) ? left : right;

    private static int Rank(string value) => value switch
    {
        "unavailable" => 4,
        "sick" => 3,
        "degraded" => 2,
        _ => 1
    };

    private static string Label(string value) => value switch
    {
        "unavailable" => "Sem diagnostico",
        "sick" => "Doente",
        "degraded" => "Degradada",
        _ => "Saudavel"
    };
}

public sealed class QueueHealthProjection(PrometheusClient prometheus)
{
    public async Task<QueueHealthProjectionResult> QueryAsync(
        QueueHealthQuery query,
        CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var queueSelector = Selector(
            "yeshua_queue_current(_value)?",
            query.Environment,
            query.Service,
            query.Queue,
            null);
        var workerSelector = Selector(
            "yeshua_worker_current(_item)?",
            query.Environment,
            query.Service,
            null,
            "last_heartbeat_unix_seconds");
        var processedSelector = Selector(
            "yeshua_worker_items(_item)?(_total)?",
            query.Environment,
            query.Service,
            null,
            "processed");

        var queueTask = prometheus.QueryInstantAsync(
            $"max by (deployment_environment_name, service_name, operation, queue, metric) ({queueSelector})",
            now,
            cancellationToken);
        var heartbeatTask = prometheus.QueryInstantAsync(
            $"time() - max by (deployment_environment_name, service_name, operation) ({workerSelector})",
            now,
            cancellationToken);
        var processedTask = prometheus.QueryInstantAsync(
            $"sum by (deployment_environment_name, service_name, operation) (increase({processedSelector}[5m]))",
            now,
            cancellationToken);
        await Task.WhenAll(queueTask, heartbeatTask, processedTask);

        var warnings = queueTask.Result.Warnings
            .Concat(heartbeatTask.Result.Warnings)
            .Concat(processedTask.Result.Warnings)
            .Distinct(StringComparer.Ordinal)
            .ToList();
        var heartbeats = ValuesByWorker(heartbeatTask.Result.Data);
        var processed = ValuesByWorker(processedTask.Result.Data);
        var queueValues = Vector(queueTask.Result.Data)
            .Where(item => item.Labels.ContainsKey("queue") && item.Labels.ContainsKey("metric"))
            .GroupBy(item => new QueueKey(
                Label(item, "deployment_environment_name", "unknown"),
                Label(item, "service_name", "unknown"),
                Label(item, "operation", "unknown"),
                Label(item, "queue", "unknown")))
            .Select(group => BuildSignals(group.Key, group, heartbeats, processed, now))
            .Select(QueueHealthClassifier.Classify)
            .OrderByDescending(item => StatusRank(item.OverallStatus))
            .ThenBy(item => item.Queue, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (queueValues.Length == 0 && warnings.Count == 0)
            warnings.Add("Nenhuma fila publicou snapshot no recorte selecionado.");

        var summary = new QueueHealthSummary(
            queueValues.Length,
            queueValues.Count(item => item.OverallStatus == "healthy"),
            queueValues.Count(item => item.OverallStatus == "degraded"),
            queueValues.Count(item => item.OverallStatus == "sick"),
            queueValues.Count(item => item.OverallStatus == "unavailable"),
            queueValues.Sum(item => item.Diseases.Total));
        return new QueueHealthProjectionResult(now, summary, queueValues, warnings);
    }

    private static QueueHealthSignals BuildSignals(
        QueueKey key,
        IEnumerable<VectorValue> values,
        IReadOnlyDictionary<WorkerKey, double> heartbeats,
        IReadOnlyDictionary<WorkerKey, double> processed,
        DateTimeOffset now)
    {
        var metrics = values
            .GroupBy(item => Label(item, "metric", string.Empty), StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.Last().Value, StringComparer.Ordinal);
        var worker = new WorkerKey(key.Environment, key.Service, key.Operation);
        var sampledAt = Long(metrics, "sampled_at_unix_seconds");
        return new QueueHealthSignals(
            key.Environment,
            key.Service,
            key.Operation,
            key.Queue,
            Long(metrics, "eligible_backlog"),
            Long(metrics, "oldest_eligible_age_seconds"),
            sampledAt <= 0 ? long.MaxValue : Math.Max(0, now.ToUnixTimeSeconds() - sampledAt),
            Long(metrics, "sample_failed") > 0,
            heartbeats.TryGetValue(worker, out var heartbeat) ? Math.Max(0, (long)heartbeat) : null,
            processed.GetValueOrDefault(worker),
            new QueueDiseaseCounts(
                Long(metrics, "sick_items"),
                Long(metrics, "sick_item_excessive_wait"),
                Long(metrics, "sick_item_stale_processing"),
                Long(metrics, "sick_item_recurrent_execution"),
                Long(metrics, "sick_item_repeated_failure"),
                Long(metrics, "sick_item_terminal_failure")));
    }

    private static Dictionary<WorkerKey, double> ValuesByWorker(JsonElement? data) =>
        Vector(data)
            .GroupBy(item => new WorkerKey(
                Label(item, "deployment_environment_name", "unknown"),
                Label(item, "service_name", "unknown"),
                Label(item, "operation", "unknown")))
            .ToDictionary(group => group.Key, group => group.Max(item => item.Value));

    private static IReadOnlyList<VectorValue> Vector(JsonElement? root)
    {
        if (root is not { } json ||
            !json.TryGetProperty("data", out var data) ||
            !data.TryGetProperty("result", out var result) ||
            result.ValueKind != JsonValueKind.Array)
        {
            return [];
        }

        var values = new List<VectorValue>();
        foreach (var item in result.EnumerateArray())
        {
            if (!item.TryGetProperty("metric", out var metric) ||
                !item.TryGetProperty("value", out var value) ||
                value.ValueKind != JsonValueKind.Array ||
                value.GetArrayLength() < 2)
            {
                continue;
            }

            var raw = value[1].ValueKind == JsonValueKind.String
                ? value[1].GetString()
                : value[1].GetRawText();
            if (!double.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
                continue;

            var labels = metric.EnumerateObject().ToDictionary(
                property => property.Name,
                property => property.Value.GetString() ?? string.Empty,
                StringComparer.Ordinal);
            values.Add(new VectorValue(labels, number));
        }

        return values;
    }

    private static string Selector(
        string metricRegex,
        string? environment,
        string? service,
        string? queue,
        string? state)
    {
        var filters = new List<string> { $"__name__=~\"{metricRegex}\"" };
        AddRegex(filters, "deployment_environment_name", environment);
        AddRegex(filters, "service_name", service);
        AddRegex(filters, "queue", queue);
        if (!string.IsNullOrWhiteSpace(state))
            filters.Add($"state=\"{Escape(state)}\"");
        return "{" + string.Join(',', filters) + "}";
    }

    private static void AddRegex(ICollection<string> filters, string label, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            filters.Add($"{label}=~\"^{Escape(Regex.Escape(value.Trim()))}$\"");
    }

    private static string Escape(string value) =>
        value.Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal);

    private static string Label(VectorValue item, string name, string fallback) =>
        item.Labels.TryGetValue(name, out var value) && !string.IsNullOrWhiteSpace(value)
            ? value
            : fallback;

    private static long Long(IReadOnlyDictionary<string, double> values, string name) =>
        values.TryGetValue(name, out var value) && double.IsFinite(value)
            ? Math.Max(0, (long)value)
            : 0;

    private static int StatusRank(string value) => value switch
    {
        "unavailable" => 4,
        "sick" => 3,
        "degraded" => 2,
        _ => 1
    };

    private sealed record VectorValue(IReadOnlyDictionary<string, string> Labels, double Value);
    private sealed record QueueKey(string Environment, string Service, string Operation, string Queue);
    private sealed record WorkerKey(string Environment, string Service, string Operation);
}
