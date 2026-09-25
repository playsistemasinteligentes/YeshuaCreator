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
    public static partial class yTokenDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyTokenEntity ytoken, DomainOperationContext context)
        {
            PrepareCustom(ytoken, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ytoken, context, result.Errors);
            ValidateCustom(ytoken, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ytoken, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyTokenEntity ytoken, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ytoken.isValidInsert(),
                DomainOperation.Alteracao => ytoken.isValidUpdate(),
                DomainOperation.Remocao => ytoken.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ytoken.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyTokenEntity ytoken, DomainOperationContext context);
        static partial void ValidateCustom(IyTokenEntity ytoken, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyTokenEntity ytoken, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration