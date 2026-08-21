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

namespace Shered.Patterns.Strategy;

public partial class SMSNotification : INotification
{
    public TypeNotification Type => TypeNotification.SMS;

    public partial void SendNotification(IMessage menssege);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers