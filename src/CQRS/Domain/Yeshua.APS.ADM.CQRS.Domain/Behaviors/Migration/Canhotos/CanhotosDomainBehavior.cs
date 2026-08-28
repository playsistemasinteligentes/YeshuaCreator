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
    public static partial class CanhotosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICanhotosEntity canhotos, DomainOperationContext context)
        {
            PrepareCustom(canhotos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(canhotos, context, result.Errors);
            ValidateCustom(canhotos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(canhotos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICanhotosEntity canhotos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => canhotos.isValidInsert(),
                DomainOperation.Alteracao => canhotos.isValidUpdate(),
                DomainOperation.Remocao => canhotos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(canhotos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICanhotosEntity canhotos, DomainOperationContext context);
        static partial void ValidateCustom(ICanhotosEntity canhotos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICanhotosEntity canhotos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration