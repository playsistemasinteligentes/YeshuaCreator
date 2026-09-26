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
            var step = saga.GetCurrent();

            if (step == null)
                return;

            var handlers = resolver.GetHandlers();

            if (!handlers.TryGetValue(step.Key, out var handler))
                throw new Exception($"Handler não encontrado: {step.Key}");

            var telemetry = _logger.Evaluate("Saga", saga.Type, step.Key);
            using var activity = telemetry.Enabled
                ? OperationalActivity.Source.StartActivity(
                    $"{saga.Type}.{step.Key}",
                    ActivityKind.Internal)
                : null;
            activity?.SetTag("yeshua.component", "Saga");
            activity?.SetTag("yeshua.saga", saga.Type);
            activity?.SetTag("yeshua.saga.step", step.Key);
            activity?.SetTag("yeshua.root_operation_id", saga.CorrelationId.ToString("D"));

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
                        Record(saga, step, "SagaStarted");

                    if (telemetry.Enabled)
                        Record(saga, step, "StepStarted");

                    handler.Execute(saga, step);

                    if (telemetry.Enabled && step.Status == SagaStepStatus.WaitingResponse)
                        Record(saga, step, "Waiting");
                }

                // 📥 APLICA
                if (step.Status == SagaStepStatus.PendingApply)
                {
                    if (telemetry.Enabled)
                        Record(saga, step, "Resumed");

                    handler.ApplyResponse(saga, step, step.Payload);

                    if (step.Status == SagaStepStatus.PendingApply)
                        saga.CompleteCurrentStep(step.Payload);

                    if (telemetry.Enabled && step.Status == SagaStepStatus.Completed)
                        Record(saga, step, "StepCompleted");
                }

                if (telemetry.Enabled && saga.Status == SagaStatus.Completed)
                    Record(saga, step, "SagaCompleted");

                activity?.SetTag("yeshua.saga.status", saga.Status.ToString());
                activity?.SetTag("yeshua.saga.step.status", step.Status.ToString());
                activity?.SetStatus(ActivityStatusCode.Ok);
            }
            catch (SagaStepExecutionException e)
            {
                activity?.SetStatus(ActivityStatusCode.Error, e.Message);
                OperationalActivity.RecordException(activity, e);
                HandleFailure(saga, step, e, e.Retryable);
                if (telemetry.Enabled)
                    Record(saga, step, saga.Status == SagaStatus.Failed ? "Failed" : "RetryScheduled");
            }
            catch (Exception e)
            {
                activity?.SetStatus(ActivityStatusCode.Error, e.Message);
                OperationalActivity.RecordException(activity, e);
                HandleFailure(saga, step, e, retryable: true);
                if (telemetry.Enabled)
                {
                    Record(
                        saga,
                        step,
                        saga.Status == SagaStatus.Failed
                            ? "Failed"
                            : "RetryScheduled");
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
            if (retryable)
            {
                step.IncrementRetry();
                if (step.CanRetry())
                {
                    var delay = TimeSpan.FromSeconds(5 * step.RetryCount);
                    step.SetPending(DateTime.UtcNow.Add(delay));
                    return;
                }
            }

            step.SetFailed(e.Message);
            saga.MarkFailed(e.Message);
        }

        private void Record(SagaBase saga, SagaStepBase step, string phase)
        {
            _logger.Saga(
                saga.Type,
                step.Key,
                saga.CorrelationId.ToString("D"),
                phase,
                step.ExecutionCount,
                step.CorrelationId + ":" + step.ExecutionCount);
        }
    }
}
