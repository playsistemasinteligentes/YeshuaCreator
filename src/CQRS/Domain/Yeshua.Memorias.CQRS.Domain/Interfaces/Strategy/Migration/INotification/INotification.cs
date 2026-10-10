// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>


using Dominio.Enum.Strategy;
namespace Dominio.Interfaces.Strategy;

public interface INotification
{
    TypeNotification Type { get; }
    void SendNotification(IMessage menssege);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers