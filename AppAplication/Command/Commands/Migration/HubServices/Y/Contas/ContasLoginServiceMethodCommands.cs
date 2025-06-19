using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
namespace Command.Commands
{
    public partial struct ContasLoginServiceMethodCommand : ICommand
    {
    public string email { get; set; }
    public string password { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsHub