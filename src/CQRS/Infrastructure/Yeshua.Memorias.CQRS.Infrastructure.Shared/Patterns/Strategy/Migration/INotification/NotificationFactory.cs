// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;
using Shered.Patterns.Strategy;

namespace Shered.Patterns.Strategy;

public class NotificationFactory : IINotificationFactory
{
    private readonly EmailNotification _emailnotification;
    private readonly SMSNotification _smsnotification;
    private readonly WhatsappNotification _whatsappnotification;

    public NotificationFactory(
        EmailNotification emailnotification,
        SMSNotification smsnotification,
        WhatsappNotification whatsappnotification
    )
    {
        _emailnotification = emailnotification;
        _smsnotification = smsnotification;
        _whatsappnotification = whatsappnotification;
    }

    public INotification GetType(TypeNotification type)
    {
        return type switch
        {
            TypeNotification.Email => _emailnotification,
            TypeNotification.SMS => _smsnotification,
            TypeNotification.Whatsapp => _whatsappnotification,
            _ => throw new ArgumentException("Invalid Type")
        };
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers