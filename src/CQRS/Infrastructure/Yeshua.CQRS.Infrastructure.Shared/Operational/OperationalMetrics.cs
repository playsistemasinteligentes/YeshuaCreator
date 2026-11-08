using Dominio.Interfaces;
using Dominio.Operational;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Shared.Operational;

public static class OperationalMetrics
{
    public const string MeterName = "Yeshua.Operational";
    public const string MeterVersion = "1.0.0";

    private static readonly Meter Meter = new(MeterName, MeterVersion);
    private static readonly Counter<long> Executions = Meter.CreateCounter<long>(
        "yeshua.operation.executions",
        "{execution}",
        "Quantidade de execucoes operacionais concluidas.");
    private static readonly Histogram<double> Duration = Meter.CreateHistogram<double>(
        "yeshua.operation.duration",
        "ms",
        "Duracao das execucoes operacionais em milissegundos.");
    private static readonly UpDownCounter<long> Active = Meter.CreateUpDownCounter<long>(
        "yeshua.operation.active",
        "{execution}",
        "Quantidade atual de execucoes operacionais em andamento.");
    private static readonly Counter<long> WorkerCycles = Meter.CreateCounter<long>(
        "yeshua.worker.cycles",
        "{cycle}",
        "Quantidade de ciclos de Worker concluidos.");
    private static readonly Counter<long> WorkerItems = Meter.CreateCounter<long>(
        "yeshua.worker.items",
        "{item}",
        "Quantidade de itens encontrados, reservados, processados ou falhos pelo Worker.");
    private static readonly Counter<long> WorkerSaturatedCycles = Meter.CreateCounter<long>(
        "yeshua.worker.saturated.cycles",
        "{cycle}",
        "Ciclos em que o Worker atingiu o limite do lote e pode haver backlog remanescente.");
    private static readonly Counter<long> SagaRetries = Meter.CreateCounter<long>(
        "yeshua.saga.retries",
        "{retry}",
        "Quantidade de retries agendados por saga e step.");
    private static readonly ConcurrentDictionary<CurrentValueKey, long> CurrentValues = new();
    private static readonly ConcurrentDictionary<WorkerCurrentValueKey, long> WorkerCurrentValues = new();
    private static readonly ConcurrentDictionary<QueueCurrentValueKey, long> QueueCurrentValues = new();
    private static readonly ObservableGauge<long> CurrentValue = Meter.CreateObservableGauge(
        "yeshua.operational.current",
        ObserveCurrentValues,
        "{value}",
        "Valor operacional atual informado por componente e metrica.");
    private static readonly ObservableGauge<long> WorkerCurrentValue = Meter.CreateObservableGauge(
        "yeshua.worker.current",
        ObserveWorkerCurrentValues,
        "{item}",
        "Valores do ultimo ciclo de cada Worker, sem multiplicar consultas de fila.");
    private static readonly ObservableGauge<long> QueueCurrentValue = Meter.CreateObservableGauge(
        "yeshua.queue.current",
        ObserveQueueCurrentValues,
        "{value}",
        "Snapshot atual da fila coletado por diagnostico de baixa frequencia.");

    public static bool QueueHealthEnabled => QueueCurrentValue.Enabled;

    public static void CommandStarted(string operation)
    {
        if (!Active.Enabled)
            return;

        try
        {
            var tags = CreateActiveTags("Command", operation);
            Active.Add(1, tags);
        }
        catch
        {
            // Metricas nunca interrompem a operacao principal.
        }
    }

    public static void CommandCompleted(
        string operation,
        long durationMs,
        OperationalTechnicalOutcome technicalOutcome,
        OperationalBusinessOutcome businessOutcome,
        WorkerCycleTelemetry? workerCycle = null)
    {
        if (!Executions.Enabled &&
            !Duration.Enabled &&
            !Active.Enabled &&
            !WorkerCycles.Enabled &&
            !WorkerItems.Enabled &&
            !WorkerSaturatedCycles.Enabled &&
            !WorkerCurrentValue.Enabled)
        {
            return;
        }

        try
        {
            var tags = CreateTags("Command", operation, technicalOutcome, businessOutcome);
            Active.Add(-1, CreateActiveTags("Command", operation));
            Executions.Add(1, tags);
            Duration.Record(durationMs, tags);

            if (workerCycle is { } cycle)
                RecordWorkerCycle(operation, cycle, technicalOutcome);
        }
        catch
        {
            // Metricas nunca interrompem a operacao principal.
        }
    }

    public static void RepositoryCompleted(
        string operation,
        long durationMs,
        OperationalTechnicalOutcome technicalOutcome)
    {
        if (!Executions.Enabled && !Duration.Enabled)
            return;

        RecordCompleted(
            "Repository",
            operation,
            durationMs,
            technicalOutcome,
            OperationalBusinessOutcome.NotEvaluated);
    }

    public static void SagaTransition(
        string saga,
        string step,
        string phase,
        long durationMs,
        OperationalTechnicalOutcome technicalOutcome,
        OperationalBusinessOutcome businessOutcome)
    {
        if (!Executions.Enabled && !Duration.Enabled && !SagaRetries.Enabled)
            return;

        try
        {
            if (string.Equals(phase, "RetryScheduled", StringComparison.Ordinal))
            {
                SagaRetries.Add(
                    1,
                    new TagList
                    {
                        { "saga", saga },
                        { "step", step }
                    });
            }

            if (IsMeasuredSagaPhase(phase))
            {
                RecordCompleted(
                    "Saga",
                    $"{saga}.{step}",
                    durationMs,
                    technicalOutcome,
                    businessOutcome);
            }
        }
        catch
        {
            // Metricas nunca interrompem a saga.
        }
    }

    public static void Transition(in OperationalEvidenceTransition transition)
    {
        if (!Executions.Enabled && !Duration.Enabled)
            return;

        RecordCompleted(
            transition.Component,
            transition.Operation,
            transition.DurationMs,
            transition.TechnicalOutcome,
            transition.BusinessOutcome);
    }

    public static void SetCurrentValue(string component, string metric, long value)
    {
        if (!CurrentValue.Enabled)
            return;

        try
        {
            CurrentValues[new CurrentValueKey(component, metric)] = value;
        }
        catch
        {
            // Metricas nunca interrompem a operacao principal.
        }
    }

    public static void WorkerCycleStarted(string operation)
    {
        if (!WorkerCurrentValue.Enabled)
            return;

        try
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            SetWorkerCurrentValue(operation, "last_heartbeat_unix_seconds", now);
            SetWorkerCurrentValue(operation, "last_cycle_started_unix_seconds", now);
            SetWorkerCurrentValue(operation, "cycle_in_progress", 1);
        }
        catch
        {
            // Saude do Worker nunca interrompe o ciclo principal.
        }
    }

    public static void WorkerCycleCompleted(
        string operation,
        bool succeeded,
        int? claimed)
    {
        if (!WorkerCurrentValue.Enabled)
            return;

        try
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            SetWorkerCurrentValue(operation, "last_heartbeat_unix_seconds", now);
            SetWorkerCurrentValue(operation, "last_cycle_completed_unix_seconds", now);
            SetWorkerCurrentValue(operation, "cycle_in_progress", 0);

            if (succeeded)
                SetWorkerCurrentValue(operation, "last_success_unix_seconds", now);

            if (claimed.HasValue)
            {
                var emptyCyclesKey = new WorkerCurrentValueKey(
                    operation,
                    "consecutive_empty_cycles");
                if (claimed.Value == 0)
                {
                    WorkerCurrentValues.AddOrUpdate(
                        emptyCyclesKey,
                        1,
                        static (_, current) => current + 1);
                }
                else
                {
                    WorkerCurrentValues[emptyCyclesKey] = 0;
                }
            }
        }
        catch
        {
            // Saude do Worker nunca interrompe o ciclo principal.
        }
    }

    public static void WorkerCycleAborted(string operation)
    {
        if (!WorkerCurrentValue.Enabled)
            return;

        try
        {
            SetWorkerCurrentValue(operation, "cycle_in_progress", 0);
        }
        catch
        {
            // Saude do Worker nunca interrompe o encerramento do host.
        }
    }

    public static void SetQueueHealthSnapshot(
        string queue,
        string operation,
        long eligibleBacklog,
        long oldestEligibleAgeSeconds)
    {
        if (!QueueCurrentValue.Enabled)
            return;

        try
        {
            SetQueueCurrentValue(queue, operation, "eligible_backlog", Math.Max(0, eligibleBacklog));
            SetQueueCurrentValue(
                queue,
                operation,
                "oldest_eligible_age_seconds",
                Math.Max(0, oldestEligibleAgeSeconds));
            SetQueueCurrentValue(
                queue,
                operation,
                "sampled_at_unix_seconds",
                DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            SetQueueCurrentValue(queue, operation, "sample_failed", 0);
        }
        catch
        {
            // Diagnostico da fila nunca interrompe o Worker.
        }
    }

    public static void SetQueueItemHealthSnapshot(
        string queue,
        string operation,
        long sickItems,
        long excessiveWait,
        long staleProcessing,
        long recurrentExecution,
        long repeatedFailure,
        long terminalFailure)
    {
        if (!QueueCurrentValue.Enabled)
            return;

        try
        {
            SetQueueCurrentValue(queue, operation, "sick_items", Math.Max(0, sickItems));
            SetQueueCurrentValue(
                queue,
                operation,
                "sick_item_excessive_wait",
                Math.Max(0, excessiveWait));
            SetQueueCurrentValue(
                queue,
                operation,
                "sick_item_stale_processing",
                Math.Max(0, staleProcessing));
            SetQueueCurrentValue(
                queue,
                operation,
                "sick_item_recurrent_execution",
                Math.Max(0, recurrentExecution));
            SetQueueCurrentValue(
                queue,
                operation,
                "sick_item_repeated_failure",
                Math.Max(0, repeatedFailure));
            SetQueueCurrentValue(
                queue,
                operation,
                "sick_item_terminal_failure",
                Math.Max(0, terminalFailure));
        }
        catch
        {
            // A classificacao agregada nunca interrompe o Worker.
        }
    }

    public static void SetQueueHealthProbeFailure(string queue, string operation)
    {
        if (!QueueCurrentValue.Enabled)
            return;

        try
        {
            SetQueueCurrentValue(queue, operation, "sample_failed", 1);
        }
        catch
        {
            // Diagnostico da fila nunca interrompe o Worker.
        }
    }

    private static void RecordCompleted(
        string component,
        string operation,
        long durationMs,
        OperationalTechnicalOutcome technicalOutcome,
        OperationalBusinessOutcome businessOutcome)
    {
        try
        {
            var tags = CreateTags(component, operation, technicalOutcome, businessOutcome);
            Executions.Add(1, tags);
            Duration.Record(durationMs, tags);
        }
        catch
        {
            // Metricas nunca interrompem a operacao principal.
        }
    }

    private static void RecordWorkerCycle(
        string operation,
        WorkerCycleTelemetry cycle,
        OperationalTechnicalOutcome technicalOutcome)
    {
        var cycleTags = new TagList
        {
            { "operation", operation },
            { "outcome", Outcome(technicalOutcome) }
        };
        WorkerCycles.Add(1, cycleTags);

        SetWorkerCurrentValue(operation, "batch_limit", cycle.BatchLimit);
        SetWorkerCurrentValue(operation, "claimed", cycle.Claimed);
        SetWorkerCurrentValue(operation, "processed", cycle.Processed);
        SetWorkerCurrentValue(operation, "failed", cycle.Failed);

        if (cycle.BatchLimit > 0 && cycle.Claimed >= cycle.BatchLimit)
            WorkerSaturatedCycles.Add(1, cycleTags);

        RecordWorkerItems(operation, "batch_limit", cycle.BatchLimit);
        RecordWorkerItems(operation, "claimed", cycle.Claimed);
        RecordWorkerItems(operation, "processed", cycle.Processed);
        RecordWorkerItems(operation, "failed", cycle.Failed);
    }

    private static void RecordWorkerItems(string operation, string state, long value)
    {
        if (value <= 0)
            return;

        var tags = new TagList
        {
            { "operation", operation },
            { "state", state }
        };
        WorkerItems.Add(value, tags);
    }

    private static void SetWorkerCurrentValue(string operation, string state, long value)
    {
        WorkerCurrentValues[new WorkerCurrentValueKey(operation, state)] = value;
    }

    private static void SetQueueCurrentValue(
        string queue,
        string operation,
        string metric,
        long value)
    {
        QueueCurrentValues[new QueueCurrentValueKey(queue, operation, metric)] = value;
    }

    private static TagList CreateTags(
        string component,
        string operation,
        OperationalTechnicalOutcome technicalOutcome = OperationalTechnicalOutcome.NotEvaluated,
        OperationalBusinessOutcome businessOutcome = OperationalBusinessOutcome.NotEvaluated)
    {
        return new TagList
        {
            { "component", component },
            { "operation", operation },
            { "outcome", Outcome(technicalOutcome) },
            { "business_outcome", BusinessOutcome(businessOutcome) }
        };
    }

    private static TagList CreateActiveTags(string component, string operation)
    {
        return new TagList
        {
            { "component", component },
            { "operation", operation }
        };
    }

    private static string Outcome(OperationalTechnicalOutcome outcome) => outcome switch
    {
        OperationalTechnicalOutcome.Succeeded => "succeeded",
        OperationalTechnicalOutcome.Failed => "failed",
        OperationalTechnicalOutcome.TimedOut => "timed_out",
        OperationalTechnicalOutcome.Cancelled => "cancelled",
        OperationalTechnicalOutcome.Unavailable => "unavailable",
        _ => "not_evaluated"
    };

    private static string BusinessOutcome(OperationalBusinessOutcome outcome) => outcome switch
    {
        OperationalBusinessOutcome.Accepted => "accepted",
        OperationalBusinessOutcome.Rejected => "rejected",
        OperationalBusinessOutcome.PartiallyAccepted => "partially_accepted",
        _ => "not_evaluated"
    };

    private static bool IsMeasuredSagaPhase(string phase) => phase is
        "Waiting" or
        "StepCompleted" or
        "SagaCompleted" or
        "Failed" or
        "RetryScheduled";

    private static IEnumerable<Measurement<long>> ObserveCurrentValues()
    {
        foreach (var item in CurrentValues)
        {
            yield return new Measurement<long>(
                item.Value,
                new KeyValuePair<string, object?>("component", item.Key.Component),
                new KeyValuePair<string, object?>("metric", item.Key.Metric));
        }
    }

    private static IEnumerable<Measurement<long>> ObserveWorkerCurrentValues()
    {
        foreach (var item in WorkerCurrentValues)
        {
            yield return new Measurement<long>(
                item.Value,
                new KeyValuePair<string, object?>("operation", item.Key.Operation),
                new KeyValuePair<string, object?>("state", item.Key.State));
        }
    }

    private static IEnumerable<Measurement<long>> ObserveQueueCurrentValues()
    {
        foreach (var item in QueueCurrentValues)
        {
            yield return new Measurement<long>(
                item.Value,
                new KeyValuePair<string, object?>("queue", item.Key.Queue),
                new KeyValuePair<string, object?>("operation", item.Key.Operation),
                new KeyValuePair<string, object?>("metric", item.Key.Metric));
        }
    }

    private readonly record struct CurrentValueKey(string Component, string Metric);
    private readonly record struct WorkerCurrentValueKey(string Operation, string State);
    private readonly record struct QueueCurrentValueKey(
        string Queue,
        string Operation,
        string Metric);
}
