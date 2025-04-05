namespace Comandos.Pateners.Command
{
    public class ReceiverException : Exception
    {
        public State State { get; }

        public ReceiverException(State state) : base(state.Message)
        {
            State = state;
        }
    }
}
