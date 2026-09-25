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

namespace Dominio.Interfaces.Strategy;

public interface IINotificationFactory
{
    INotification GetType(TypeNotification type);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers