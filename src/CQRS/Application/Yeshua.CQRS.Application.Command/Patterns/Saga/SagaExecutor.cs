using Command.Interfaces;
using Dominio.Interfaces;
using Dominio.Operational;
using Dominio.Patterns.Saga;
using RepositoryInterfaces.Patterns.Saga;
using System;
using System.Diagnostics;
using System.Linq;

namespace Command.Patterns
{
    public class SagaExecutor : ISagaExecutor
    {
        private readonly ILogger _logger;

        public SagaExecutor(ILogger logger)
        {
            _logger = logger;
        }

        public void Execute(SagaBase saga, ISagaHandlerResolver resolver)
        {
            saga.BeginExecutionAttempt();
            var step = saga.GetCurrent();

            if (step == null)
                return;

            if (step.Status == SagaStepStatus.Pending && step.NextExecutionAt > DateTime.UtcNow)
                return;

            var handlers = resolver.GetHandlers();

            if (!handlers.TryGetValue(step.Key, out var handler))
                throw new Exception($"Handler não encontrado: {step.Key}");

            var telemetry = _logger.Evaluate(
                "Saga",
                saga.Type,
                step.Key,
                saga.CorrelationId.ToString("D"),
                step.OperationId ?? saga.OperationId ?? step.Key);
            var startedTimestamp = telemetry.Enabled ? Stopwatch.GetTimestamp() : 0;
            var attempt = step.Status == SagaStepStatus.Pending
                ? step.ExecutionCount + 1
                : Math.Max(1, step.ExecutionCount);
            var executionIdentity = telemetry.Enabled
                ? CreateExecutionIdentity(saga, step, attempt)
                : default;
            using var activity = telemetry.Enabled
                ? OperationalActivity.Source.StartActivity(
                    $"{saga.Type}.{step.Key}",
                    ActivityKind.Internal)
                : null;
            activity?.SetTag("yeshua.component", "Saga");
            activity?.SetTag("yeshua.saga", saga.Type);
            activity?.SetTag("yeshua.saga.step", step.Key);
            OperationalActivity.SetIdentity(activity, executionIdentity);
            OperationalActivity.SetDiagnosticSession(activity, telemetry.DiagnosticSessionId);

            try
            {
                // 🔒 não faz nada
                if (step.Status == SagaStepStatus.WaitingResponse)
                    return;

                // ▶ EXECUTA
                if (step.Status == SagaStepStatus.Pending)
                {
                    var sagaStarting = step.Order == 1 && step.ExecutionCount == 0;

                    step.SetInProgress();
                    if (telemetry.Enabled && sagaStarting)
                        Record(saga, step, "SagaStarted", telemetry, executionIdentity, 0);

                    if (telemetry.Enabled)
                        Record(saga, step, "StepStarted", telemetry, executionIdentity, 0);

                    handler.Execute(saga, step);

                    if (telemetry.Enabled && step.Status == SagaStepStatus.WaitingResponse)
                        Record(
                            saga,
                            step,
                            "Waiting",
                            telemetry,
                            executionIdentity,
                            ElapsedMilliseconds(startedTimestamp));
                }

                // 📥 APLICA
                if (step.Status == SagaStepStatus.PendingApply)
                {
                    if (telemetry.Enabled)
                        Record(saga, step, "Resumed", telemetry, executionIdentity, 0);

                    handler.ApplyResponse(saga, step, step.Payload);

                    if (step.Status == SagaStepStatus.PendingApply)
                        saga.CompleteCurrentStep(step.Payload);

                    if (telemetry.Enabled && step.Status == SagaStepStatus.Completed)
                        Record(
                            saga,
                            step,
                            "StepCompleted",
                            telemetry,
                            executionIdentity,
                            ElapsedMilliseconds(startedTimestamp),
                            businessOutcome: OperationalBusinessOutcome.Accepted);
                }

                if (telemetry.Enabled && saga.Status == SagaStatus.Completed)
                    Record(
                        saga,
                        step,
                        "SagaCompleted",
                        telemetry,
                        executionIdentity,
                        ElapsedMilliseconds(startedTimestamp),
                        businessOutcome: OperationalBusinessOutcome.Accepted);

                activity?.SetTag("yeshua.saga.status", saga.Status.ToString());
                activity?.SetTag("yeshua.saga.step.status", step.Status.ToString());
                activity?.SetStatus(ActivityStatusCode.Ok);
            }
            catch (SagaStepExecutionException e)
            {
                activity?.SetStatus(ActivityStatusCode.Error, e.GetType().Name);
                OperationalActivity.RecordException(activity, e, telemetry.DiagnosticDepth);
                HandleFailure(saga, step, e, e.Retryable);
                if (telemetry.Enabled)
                    RecordFailure(
                        saga,
                        step,
                        saga.Status == SagaStatus.Failed ? "Failed" : "RetryScheduled",
                        telemetry,
                        executionIdentity,
                        startedTimestamp,
                        e);
            }
            catch (Exception e)
            {
                activity?.SetStatus(ActivityStatusCode.Error, e.GetType().Name);
                OperationalActivity.RecordException(activity, e, telemetry.DiagnosticDepth);
                HandleFailure(saga, step, e, retryable: true);
                if (telemetry.Enabled)
                {
                    RecordFailure(
                        saga,
                        step,
                        saga.Status == SagaStatus.Failed
                            ? "Failed"
                            : "RetryScheduled",
                        telemetry,
                        executionIdentity,
                        startedTimestamp,
                        e);
                }
            }
        }

        public void ExecuteUntilWait(SagaBase saga, ISagaHandlerResolver resolver, int maxSteps = 25)
        {
            if (saga == null)
                throw new ArgumentNullException(nameof(saga));

            if (resolver == null)
                throw new ArgumentNullException(nameof(resolver));

            if (maxSteps <= 0)
                maxSteps = 25;

            for (var i = 0; i < maxSteps; i++)
            {
                var step = saga.GetCurrent();

                if (step == null || step.Status == SagaStepStatus.WaitingResponse)
                    return;

                var previousStep = step;
                var previousStatus = step.Status;

                Execute(saga, resolver);

                if (saga.Status != SagaStatus.InProgress)
                    return;

                var current = saga.GetCurrent();

                if (current == null || current.Status == SagaStepStatus.WaitingResponse)
                    return;

                if (ReferenceEquals(previousStep, current) && previousStatus == current.Status)
                    return;
            }
        }

        private void HandleFailure(SagaBase saga, SagaStepBase step, Exception e, bool retryable)
        {
            saga.MarkExecutionAttemptFailed();
            if (retryable)
            {
                step.IncrementRetry();
                if (step.CanRetry())
                {
                    var delay = TimeSpan.FromSeconds(5 * step.RetryCount);
                    step.SetPending(DateTime.UtcNow.Add(delay));
                    saga.NextExecutionAt = step.NextExecutionAt.Value;
                    return;
                }
            }

            step.SetFailed(e.Message);
            saga.MarkFailed(e.Message);
        }

        private void RecordFailure(
            SagaBase saga,
            SagaStepBase step,
            string phase,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity,
            long startedTimestamp,
            Exception exception)
        {
            Record(
                saga,
                step,
                phase,
                telemetry,
                executionIdentity,
                ElapsedMilliseconds(startedTimestamp),
                OperationalTechnicalOutcome.Failed,
                errorCode: exception.GetType().Name,
                errorSummary: $"Saga step failed with {exception.GetType().Name}.",
                nextExecutionAtUtc: step.NextExecutionAt);
        }

        private void Record(
            SagaBase saga,
            SagaStepBase step,
            string phase,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity,
            long durationMs,
            OperationalTechnicalOutcome technicalOutcome = OperationalTechnicalOutcome.Succeeded,
            OperationalBusinessOutcome businessOutcome = OperationalBusinessOutcome.NotEvaluated,
            string? errorCode = null,
            string? errorSummary = null,
            DateTimeOffset? nextExecutionAtUtc = null)
        {
            _logger.Saga(new SagaOperationalTransition(
                saga.Type,
                step.Key,
                saga.CorrelationId.ToString("D"),
                phase,
                step.ExecutionCount,
                durationMs,
                technicalOutcome,
                businessOutcome,
                telemetry,
                executionIdentity,
                saga.CorrelationId.ToString("D"),
                ErrorCode: errorCode,
                ErrorSummary: errorSummary,
                NextExecutionAtUtc: nextExecutionAtUtc));
        }

        private static OperationalExecutionIdentity CreateExecutionIdentity(
            SagaBase saga,
            SagaStepBase step,
            int attempt)
        {
            var rootOperationId = step.RootOperationId
                ?? saga.RootOperationId
                ?? saga.CorrelationId.ToString("D");
            var operationId = step.OperationId
                ?? saga.OperationId
                ?? $"{saga.Type}.{step.Key}";
            var executionId = $"{step.CorrelationId}:{attempt}";
            var causationId = step.ExecutionId
                ?? saga.ExecutionId
                ?? step.CausationId
                ?? saga.CausationId;

            return new OperationalExecutionIdentity(
                rootOperationId,
                operationId,
                executionId,
                causationId);
        }

        private static long ElapsedMilliseconds(long startedTimestamp) =>
            startedTimestamp == 0
                ? 0
                : (long)Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds;
    }
}
