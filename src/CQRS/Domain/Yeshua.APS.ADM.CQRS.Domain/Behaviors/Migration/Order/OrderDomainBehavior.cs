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
    public static partial class OrderDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOrderEntity order, DomainOperationContext context)
        {
            PrepareCustom(order, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(order, context, result.Errors);
            ValidateCustom(order, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(order, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOrderEntity order, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => order.isValidInsert(),
                DomainOperation.Alteracao => order.isValidUpdate(),
                DomainOperation.Remocao => order.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(order.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOrderEntity order, DomainOperationContext context);
        static partial void ValidateCustom(IOrderEntity order, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOrderEntity order, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration