namespace RepositoryInterfaces.Patterns.Command
{
    public class ReceiverException<T> : Exception
    {
        public State<T> State { get; }

        public ReceiverException(State<T> state) : base(state.Message)
        {
            State = state;
        }
    }
}
