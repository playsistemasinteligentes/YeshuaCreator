
using Dominio.Enum.Strategy;
namespace Dominio.Interfaces.Strategy;

public interface IMessage
{
    String Destination { get; set; }
    String Body { get; set; }
    String Subject { get; set; }
    Byte[] Attachment { get; set; }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers