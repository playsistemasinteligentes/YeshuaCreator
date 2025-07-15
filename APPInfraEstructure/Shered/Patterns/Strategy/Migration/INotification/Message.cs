
namespace Shered.Patterns.Strategy;

using Dominio.Interfaces.Strategy;
public partial class Message : IMessage
{
    public string Destination { get; set; }
    public string Body { get; set; }
    public string Subject { get; set; }
    public byte[] Attachment { get; set; }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase