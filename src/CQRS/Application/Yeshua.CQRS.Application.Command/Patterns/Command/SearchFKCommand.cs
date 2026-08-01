using RepositoryInterfaces.Patterns.Command;


namespace Command.Patterns.Command
{
    public struct SearchFKCommand : ICommand
    {
        public string searchFK { get; set; }
    }
}
