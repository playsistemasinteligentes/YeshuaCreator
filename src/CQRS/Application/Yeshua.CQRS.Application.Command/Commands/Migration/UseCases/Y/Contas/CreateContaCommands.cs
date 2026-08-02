using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record CreateContaInputCommand : ICommand
{
    public string CpfCnpj { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string password { get; set; }
    public string confirmpassword { get; set; }
}

public partial record CreateContaOutputCommand : ICommand
{
    public int TenantId { get; set; }
    public int UserId { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup