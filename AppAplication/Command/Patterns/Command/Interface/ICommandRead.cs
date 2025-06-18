using RepositoryInterfaces.Patterns.Repository;

namespace Comandos.Pateners.Command
{
    public interface ICommandRead : ICommand
    {
        Pagination Paginacao { get; set; }
    }
}
