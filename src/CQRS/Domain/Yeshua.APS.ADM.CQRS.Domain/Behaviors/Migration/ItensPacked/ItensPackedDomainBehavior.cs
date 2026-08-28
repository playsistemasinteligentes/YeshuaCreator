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
    public static partial class ItensPackedDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItensPackedEntity itenspacked, DomainOperationContext context)
        {
            PrepareCustom(itenspacked, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itenspacked, context, result.Errors);
            ValidateCustom(itenspacked, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itenspacked, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItensPackedEntity itenspacked, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itenspacked.isValidInsert(),
                DomainOperation.Alteracao => itenspacked.isValidUpdate(),
                DomainOperation.Remocao => itenspacked.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itenspacked.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItensPackedEntity itenspacked, DomainOperationContext context);
        static partial void ValidateCustom(IItensPackedEntity itenspacked, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItensPackedEntity itenspacked, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration