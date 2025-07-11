
using Dominio.Enum.Strategy;
namespace Dominio.Interfaces.Strategy;

public interface INotification
{
    TypeNotification Type { get; }
    void SendNotification(IMessage menssege);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase