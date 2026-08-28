

using System.Threading;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Command
{
    public interface IReceiver<C, T>
        where C : ICommand
    {
        Task<State<T>> ExecuteAsync(C command, CancellationToken cancellationToken = default);
    }

}
