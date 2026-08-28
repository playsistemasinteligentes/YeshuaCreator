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
    public static partial class ItemTestavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItemTestavelEntity itemtestavel, DomainOperationContext context)
        {
            PrepareCustom(itemtestavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itemtestavel, context, result.Errors);
            ValidateCustom(itemtestavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itemtestavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItemTestavelEntity itemtestavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itemtestavel.isValidInsert(),
                DomainOperation.Alteracao => itemtestavel.isValidUpdate(),
                DomainOperation.Remocao => itemtestavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itemtestavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItemTestavelEntity itemtestavel, DomainOperationContext context);
        static partial void ValidateCustom(IItemTestavelEntity itemtestavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItemTestavelEntity itemtestavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration