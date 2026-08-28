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
    public static partial class OrderTrackDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOrderTrackEntity ordertrack, DomainOperationContext context)
        {
            PrepareCustom(ordertrack, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ordertrack, context, result.Errors);
            ValidateCustom(ordertrack, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ordertrack, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOrderTrackEntity ordertrack, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ordertrack.isValidInsert(),
                DomainOperation.Alteracao => ordertrack.isValidUpdate(),
                DomainOperation.Remocao => ordertrack.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ordertrack.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOrderTrackEntity ordertrack, DomainOperationContext context);
        static partial void ValidateCustom(IOrderTrackEntity ordertrack, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOrderTrackEntity ordertrack, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration