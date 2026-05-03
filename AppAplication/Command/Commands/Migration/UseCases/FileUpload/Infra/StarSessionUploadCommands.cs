using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record StarSessionUploadInputCommand : ICommand
{
        public string token { get; set; }
        public string entityType { get; set; }
        public string entityId { get; set; }
}

public partial record StarSessionUploadOutputCommand : ICommand
{
    public string uploadToken { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup