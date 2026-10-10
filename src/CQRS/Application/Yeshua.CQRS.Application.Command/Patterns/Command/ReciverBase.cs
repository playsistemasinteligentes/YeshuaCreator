using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using Dominio.Operational;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Patterns.Command
{
    public abstract class ReciverBase<TCommand, TResponse>
        : IReceiver<TCommand, TResponse>
        where TCommand : ICommand
    {
        private static readonly string CommandName =
            typeof(TCommand).FullName ?? typeof(TCommand).Name;

        private readonly ILogger _logger;
        private readonly IExecutionContext _context;

        protected ReciverBase(ILogger logger, IExecutionContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected abstract Task<State<TResponse>> ActionAsync(
            TCommand command,
            CancellationToken cancellationToken = default);

        public async Task<State<TResponse>> ExecuteAsync(
            TCommand command,
            CancellationToken cancellationToken = default)
        {
            // OBS: F-EXP-00 - encerra o caminho de telemetria antes de medir ou alocar.
            string? entity = null;
            string? recordId = null;
            if (command is IOperationalTelemetryCommand operationalCommand)
            {
                entity = operationalCommand.OperationalEntity;
                recordId = operationalCommand.OperationalRecordId;
            }

            var telemetry = _logger.Evaluate("Command", CommandName, entity, recordId);
            if (!telemetry.Enabled)
                return await ActionAsync(command, cancellationToken);

            using var executionScope = _context.BeginOperationalExecution(CommandName);
            var executionIdentity = _context.OperationalIdentity;
            var traceId = _context.TraceId;
            var startedAt = Stopwatch.GetTimestamp();
            using var activity = OperationalActivity.Source.StartActivity(
                CommandName,
                ActivityKind.Internal);
            activity?.SetTag("yeshua.component", "Command");
            activity?.SetTag("yeshua.operation", CommandName);
            activity?.SetTag("yeshua.trace_id", traceId);
            activity?.SetTag("yeshua.entity", entity);
            activity?.SetTag("yeshua.operational_entity_id", recordId);
            activity?.SetTag("yeshua.depth", telemetry.DiagnosticDepth.ToString());
            activity?.SetTag("yeshua.mode", telemetry.ExecutionMode.ToString());
            OperationalActivity.SetIdentity(activity, executionIdentity);

            _logger.CommandStarted(
                CommandName,
                traceId,
                telemetry,
                executionIdentity,
                recordId);

            try
            {
                var result = await ActionAsync(command, cancellationToken);

                WorkerCycleTelemetry? workerCycle = null;
                if (result.Data is IWorkerCycleResult progress)
                {
                    workerCycle = new WorkerCycleTelemetry(
                        progress.BatchLimit,
                        progress.Claimed,
                        progress.Processed,
                        progress.Failed);
                }

                _logger.CommandFinished(
                    CommandName,
                    traceId,
                    result.StatusCode is >= 200 and < 300,
                    ElapsedMilliseconds(startedAt),
                    result.StatusCode,
                    workerCycle,
                    telemetry,
                    executionIdentity,
                    recordId);

                activity?.SetTag("http.response.status_code", result.StatusCode);
                activity?.SetTag(
                    "yeshua.technical_outcome",
                    result.StatusCode >= 500 ? "Failed" : "Succeeded");
                activity?.SetTag(
                    "yeshua.business_outcome",
                    result.StatusCode switch
                    {
                        >= 200 and < 400 => "Accepted",
                        >= 400 and < 500 => "Rejected",
                        _ => "NotEvaluated"
                    });
                activity?.SetStatus(
                    result.StatusCode < 500
                        ? ActivityStatusCode.Ok
                        : ActivityStatusCode.Error,
                    result.StatusCode >= 500 ? "Technical failure" : null);

                return result;
            }
            catch (Exception ex)
            {
                _logger.CommandFailed(
                    CommandName,
                    traceId,
                    ex,
                    ElapsedMilliseconds(startedAt),
                    telemetry,
                    executionIdentity,
                    recordId);
                activity?.SetTag("yeshua.technical_outcome", "Failed");
                activity?.SetTag("yeshua.business_outcome", "NotEvaluated");
                activity?.SetStatus(ActivityStatusCode.Error, ex.GetType().Name);
                OperationalActivity.RecordException(activity, ex, telemetry.DiagnosticDepth);
                throw;
            }
        }

        private static long ElapsedMilliseconds(long startedAt)
        {
            return (long)System.Diagnostics.Stopwatch
                .GetElapsedTime(startedAt)
                .TotalMilliseconds;
        }

        protected static State<TResponse> Error(
            string message,
            TResponse data = default!,
            bool propagation = true)
            => new State<TResponse>(500, message, data, propagation);

        protected static State<TResponse> Error(
            Exception exception,
            TResponse data = default!)
            => new State<TResponse>(500, exception, data, false);

        protected static State<TResponse> Success(
            string message,
            TResponse data = default!)
            => new State<TResponse>(200, message, data);

        protected static State<TResponse> Created(
            string message,
            TResponse data = default!)
            => new State<TResponse>(201, message, data);

        protected static State<TResponse> Accepted(
            string message,
            TResponse data = default!)
            => new State<TResponse>(202, message, data);

        protected static State<TResponse> ValidationError(
            string message,
            TResponse data = default!)
            => new State<TResponse>(400, message, data);

        protected static State<TResponse> ValidationError(
            List<string> messages,
            TResponse data = default!)
            => new State<TResponse>(400, messages, data);
    }
}
