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
    public static partial class yOutboxDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyOutboxEntity youtbox, DomainOperationContext context)
        {
            PrepareCustom(youtbox, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(youtbox, context, result.Errors);
            ValidateCustom(youtbox, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(youtbox, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyOutboxEntity youtbox, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => youtbox.isValidInsert(),
                DomainOperation.Alteracao => youtbox.isValidUpdate(),
                DomainOperation.Remocao => youtbox.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(youtbox.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyOutboxEntity youtbox, DomainOperationContext context);
        static partial void ValidateCustom(IyOutboxEntity youtbox, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyOutboxEntity youtbox, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration