using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Patterns.Command
{
    public abstract class ReciverBase<TCommand, TResponse>
        : IReceiver<TCommand, TResponse>
        where TCommand : ICommand
    {
        private readonly ILogger _logger;
        private readonly IExecutionContext _context;

        protected ReciverBase(ILogger logger, IExecutionContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected abstract State<TResponse> Action(TCommand command);

        public State<TResponse> Execute(TCommand command)
        {
            var commandName = typeof(TCommand).Name;
            var traceId = _context.TraceId;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            _logger.Command(commandName, traceId, "iniciado");

            try
            {
                var result = Action(command);
                sw.Stop();

                _logger.Command(commandName, traceId,
                    result.StatusCode == 200 || result.StatusCode == 201
                        ? "concluido"
                        : "falhou",
                    sw.ElapsedMilliseconds);

                return result;
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.Error(commandName, traceId, ex);
                throw;
            }
        }

        protected static State<TResponse> Error(
            string message,
            TResponse data = default,
            bool propagation = true)
            => new State<TResponse>(500, message, data, propagation);

        protected static State<TResponse> Error(
            Exception exception,
            TResponse data = default)
            => new State<TResponse>(500, exception, data, false);

        protected static State<TResponse> Success(
            string message,
            TResponse data = default)
            => new State<TResponse>(200, message, data);

        protected static State<TResponse> Created(
            string message,
            TResponse data = default)
            => new State<TResponse>(201, message, data);

        protected static State<TResponse> ValidationError(
            string message,
            TResponse data = default)
            => new State<TResponse>(400, message, data);

        protected static State<TResponse> ValidationError(
            List<string> messages,
            TResponse data = default)
            => new State<TResponse>(400, messages, data);
    }
}