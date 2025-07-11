using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;
namespace Shered.Patterns.Strategy;

public partial class SMSNotification
{
    public partial void SendNotification(IMessage menssege)
    {
        throw new NotImplementedException();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase