using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;
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
            var traceId = _context.TraceId;
            var startedAt = System.Diagnostics.Stopwatch.GetTimestamp();

            _logger.CommandStarted(CommandName);

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
                    workerCycle);

                return result;
            }
            catch (Exception ex)
            {
                _logger.CommandFailed(
                    CommandName,
                    traceId,
                    ex,
                    ElapsedMilliseconds(startedAt));
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
