using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
namespace Command.Commands
{
    public partial struct ContasCreateContaUseCaseCommand : ICommand
    {
    public string idcompany { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string password { get; set; }
    public string confirmpassword { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup