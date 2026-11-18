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
    public static partial class yUsageRightDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyUsageRightEntity yusageright, DomainOperationContext context)
        {
            PrepareCustom(yusageright, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yusageright, context, result.Errors);
            ValidateCustom(yusageright, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yusageright, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyUsageRightEntity yusageright, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yusageright.isValidInsert(),
                DomainOperation.Alteracao => yusageright.isValidUpdate(),
                DomainOperation.Remocao => yusageright.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yusageright.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyUsageRightEntity yusageright, DomainOperationContext context);
        static partial void ValidateCustom(IyUsageRightEntity yusageright, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyUsageRightEntity yusageright, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration