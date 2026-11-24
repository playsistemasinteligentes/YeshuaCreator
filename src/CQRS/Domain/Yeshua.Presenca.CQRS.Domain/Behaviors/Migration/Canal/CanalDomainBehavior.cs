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
    public static partial class CanalDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICanalEntity canal, DomainOperationContext context)
        {
            PrepareCustom(canal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(canal, context, result.Errors);
            ValidateCustom(canal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(canal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICanalEntity canal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => canal.isValidInsert(),
                DomainOperation.Alteracao => canal.isValidUpdate(),
                DomainOperation.Remocao => canal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(canal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICanalEntity canal, DomainOperationContext context);
        static partial void ValidateCustom(ICanalEntity canal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICanalEntity canal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration