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
    public static partial class yUsageConsumptionDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyUsageConsumptionEntity yusageconsumption, DomainOperationContext context)
        {
            PrepareCustom(yusageconsumption, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yusageconsumption, context, result.Errors);
            ValidateCustom(yusageconsumption, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yusageconsumption, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyUsageConsumptionEntity yusageconsumption, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yusageconsumption.isValidInsert(),
                DomainOperation.Alteracao => yusageconsumption.isValidUpdate(),
                DomainOperation.Remocao => yusageconsumption.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yusageconsumption.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyUsageConsumptionEntity yusageconsumption, DomainOperationContext context);
        static partial void ValidateCustom(IyUsageConsumptionEntity yusageconsumption, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyUsageConsumptionEntity yusageconsumption, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration