using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;

namespace Shered.Patterns.Strategy;

public partial class EmailNotification : INotification
{
    public TypeNotification Type => TypeNotification.Email;

    public partial void SendNotification(IMessage menssege);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers