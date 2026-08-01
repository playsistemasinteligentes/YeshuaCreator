

namespace RepositoryInterfaces.Patterns.Command
{
    public interface IReceiver<C, T>
        where C : ICommand
    {
        State<T> Execute(C command);
    }

}
