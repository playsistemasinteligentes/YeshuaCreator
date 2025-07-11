using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;

namespace Dominio.Interfaces.Strategy;

public interface IINotificationFactory
{
    INotification GetType(TypeNotification type);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase