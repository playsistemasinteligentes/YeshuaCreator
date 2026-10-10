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
    public static partial class yGrantDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyGrantEntity ygrant, DomainOperationContext context)
        {
            PrepareCustom(ygrant, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ygrant, context, result.Errors);
            ValidateCustom(ygrant, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ygrant, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyGrantEntity ygrant, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ygrant.isValidInsert(),
                DomainOperation.Alteracao => ygrant.isValidUpdate(),
                DomainOperation.Remocao => ygrant.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ygrant.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyGrantEntity ygrant, DomainOperationContext context);
        static partial void ValidateCustom(IyGrantEntity ygrant, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyGrantEntity ygrant, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration