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
    public static partial class yUserGrantDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyUserGrantEntity yusergrant, DomainOperationContext context)
        {
            PrepareCustom(yusergrant, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yusergrant, context, result.Errors);
            ValidateCustom(yusergrant, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yusergrant, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyUserGrantEntity yusergrant, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yusergrant.isValidInsert(),
                DomainOperation.Alteracao => yusergrant.isValidUpdate(),
                DomainOperation.Remocao => yusergrant.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yusergrant.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyUserGrantEntity yusergrant, DomainOperationContext context);
        static partial void ValidateCustom(IyUserGrantEntity yusergrant, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyUserGrantEntity yusergrant, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration