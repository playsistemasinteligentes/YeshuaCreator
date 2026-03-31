using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record InfraSendFileUseCaseInputCommand : ICommand
{
    public string token { get; set; }
    public int ChunkIndex { get; set; }
    public bool IsFinalChunk { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public IFormFile FileStream { get; set; }
}

public partial record InfraSendFileUseCaseOutputCommand : ICommand
{
    public bool Success { get; set; }
    public int ChunkIndex { get; set; }
    public bool IsFinalized { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup