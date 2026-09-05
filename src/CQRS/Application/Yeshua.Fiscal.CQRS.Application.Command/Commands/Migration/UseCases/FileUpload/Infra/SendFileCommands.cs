// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record SendFileInputCommand : ICommand
{
    public string token { get; set; }
    public int ChunkIndex { get; set; }
    public bool IsFinalChunk { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public IFormFile FileStream { get; set; }
}

public partial record SendFileOutputCommand : ICommand
{
    public bool Success { get; set; }
    public int ChunkIndex { get; set; }
    public bool IsFinalized { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup