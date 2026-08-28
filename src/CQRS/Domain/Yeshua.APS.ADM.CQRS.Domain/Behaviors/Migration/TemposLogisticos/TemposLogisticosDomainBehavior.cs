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
    public static partial class TemposLogisticosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemposLogisticosEntity temposlogisticos, DomainOperationContext context)
        {
            PrepareCustom(temposlogisticos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(temposlogisticos, context, result.Errors);
            ValidateCustom(temposlogisticos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(temposlogisticos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemposLogisticosEntity temposlogisticos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => temposlogisticos.isValidInsert(),
                DomainOperation.Alteracao => temposlogisticos.isValidUpdate(),
                DomainOperation.Remocao => temposlogisticos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(temposlogisticos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemposLogisticosEntity temposlogisticos, DomainOperationContext context);
        static partial void ValidateCustom(ITemposLogisticosEntity temposlogisticos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemposLogisticosEntity temposlogisticos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration