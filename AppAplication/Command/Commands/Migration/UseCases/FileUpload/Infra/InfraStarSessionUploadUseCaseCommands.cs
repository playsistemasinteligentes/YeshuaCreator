using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
namespace Command.UseCase
{
public partial record InfraStarSessionUploadUseCaseInputCommand : ICommand
{
    public string token { get; set; }
}

public partial record InfraStarSessionUploadUseCaseOutputCommand : ICommand
{
    public string uploadToken { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup