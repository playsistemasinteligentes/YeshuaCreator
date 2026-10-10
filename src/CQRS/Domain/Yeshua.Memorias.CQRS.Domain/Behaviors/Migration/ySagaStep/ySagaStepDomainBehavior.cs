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
    public static partial class ySagaStepDomainBehavior
    {
        public static DomainBehaviorResult Apply(IySagaStepEntity ysagastep, DomainOperationContext context)
        {
            PrepareCustom(ysagastep, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ysagastep, context, result.Errors);
            ValidateCustom(ysagastep, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ysagastep, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IySagaStepEntity ysagastep, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ysagastep.isValidInsert(),
                DomainOperation.Alteracao => ysagastep.isValidUpdate(),
                DomainOperation.Remocao => ysagastep.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ysagastep.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IySagaStepEntity ysagastep, DomainOperationContext context);
        static partial void ValidateCustom(IySagaStepEntity ysagastep, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IySagaStepEntity ysagastep, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration