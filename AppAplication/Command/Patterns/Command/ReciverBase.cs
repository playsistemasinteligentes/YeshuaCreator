
using RepositoryInterfaces.Patterns.Command;

namespace Command.Patterns.Command
{
    public abstract class ReciverBase<TCommand, TResponse>
        : IReceiver<TCommand, TResponse>
        where TCommand : ICommand
    {
        protected abstract State<TResponse> Action(TCommand command);

        public State<TResponse> Execute(TCommand command)
        {
            return Action(command);
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


