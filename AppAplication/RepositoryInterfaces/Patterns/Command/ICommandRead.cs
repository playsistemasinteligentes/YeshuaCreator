

namespace RepositoryInterfaces.Patterns.Command
{
    public interface ICommandRead : ICommand
    {
        Pagination Paginacao { get; set; }
    }
}
