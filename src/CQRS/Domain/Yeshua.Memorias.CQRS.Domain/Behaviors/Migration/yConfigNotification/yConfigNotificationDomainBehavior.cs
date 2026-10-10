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
    public static partial class yConfigNotificationDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyConfigNotificationEntity yconfignotification, DomainOperationContext context)
        {
            PrepareCustom(yconfignotification, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yconfignotification, context, result.Errors);
            ValidateCustom(yconfignotification, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yconfignotification, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyConfigNotificationEntity yconfignotification, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yconfignotification.isValidInsert(),
                DomainOperation.Alteracao => yconfignotification.isValidUpdate(),
                DomainOperation.Remocao => yconfignotification.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yconfignotification.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyConfigNotificationEntity yconfignotification, DomainOperationContext context);
        static partial void ValidateCustom(IyConfigNotificationEntity yconfignotification, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyConfigNotificationEntity yconfignotification, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration