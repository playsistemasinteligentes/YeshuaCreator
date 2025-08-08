using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
namespace Command.UseCase
{
public partial record ContasLoginUseCaseInputCommand : ICommand
{
    public string email { get; set; }
    public string password { get; set; }
}

public partial record ContasLoginUseCaseOutputCommand : ICommand
{
    public List<string> modulos { get; set; }
    public int UserId { get; set; }
    public string email { get; set; }
    public int tenantId { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup