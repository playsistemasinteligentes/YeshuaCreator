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

public interface IMessage
{
    String Destination { get; set; }
    String Body { get; set; }
    String Subject { get; set; }
    Byte[] Attachment { get; set; }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers