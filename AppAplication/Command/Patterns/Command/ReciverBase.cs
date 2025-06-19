using RepositoryInterfaces.Patterns.Command;

namespace Command.Patterns.Command
{
    public abstract class ReciverBase<T> : IReceiver<ICommand, T>
    {
        protected abstract State<T> Action(ICommand command);

        public State<T> Execute(ICommand command)
        {
            return Action(command);
        }

        protected static State<T> Error(string message, T data = default, bool propagation = true)
            => new State<T>(500, message, data, propagation);

        protected static State<T> Error(Exception exception, T data = default)
            => new State<T>(500, exception, data, false);

        protected static State<T> Success(string message, T data = default)
            => new State<T>(200, message, data);

        protected static State<T> Created(string message, T data = default)
            => new State<T>(201, message, data);

        protected static State<T> ValidationError(string message, T data = default)
            => new State<T>(400, message, data);

        protected static State<T> ValidationError(List<string> messages, ICommand c, T data = default)
            => new State<T>(400, messages, data);

    }
}
