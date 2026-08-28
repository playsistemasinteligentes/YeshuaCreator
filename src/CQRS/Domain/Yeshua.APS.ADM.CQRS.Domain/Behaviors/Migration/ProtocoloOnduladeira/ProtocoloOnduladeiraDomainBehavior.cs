// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class ProtocoloOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IProtocoloOnduladeiraEntity protocoloonduladeira, DomainOperationContext context)
        {
            PrepareCustom(protocoloonduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(protocoloonduladeira, context, result.Errors);
            ValidateCustom(protocoloonduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(protocoloonduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IProtocoloOnduladeiraEntity protocoloonduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => protocoloonduladeira.isValidInsert(),
                DomainOperation.Alteracao => protocoloonduladeira.isValidUpdate(),
                DomainOperation.Remocao => protocoloonduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(protocoloonduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IProtocoloOnduladeiraEntity protocoloonduladeira, DomainOperationContext context);
        static partial void ValidateCustom(IProtocoloOnduladeiraEntity protocoloonduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IProtocoloOnduladeiraEntity protocoloonduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration