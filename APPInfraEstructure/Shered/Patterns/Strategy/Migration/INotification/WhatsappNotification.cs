using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;

namespace Shered.Patterns.Strategy;

public partial class WhatsappNotification : INotification
{
    public TypeNotification Type => TypeNotification.Whatsapp;

    public partial void SendNotification(IMessage menssege);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase