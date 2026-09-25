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
    public static partial class yInboxDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyInboxEntity yinbox, DomainOperationContext context)
        {
            PrepareCustom(yinbox, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yinbox, context, result.Errors);
            ValidateCustom(yinbox, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yinbox, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyInboxEntity yinbox, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yinbox.isValidInsert(),
                DomainOperation.Alteracao => yinbox.isValidUpdate(),
                DomainOperation.Remocao => yinbox.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yinbox.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyInboxEntity yinbox, DomainOperationContext context);
        static partial void ValidateCustom(IyInboxEntity yinbox, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyInboxEntity yinbox, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration