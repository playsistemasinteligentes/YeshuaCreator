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
    public static partial class LoockDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILoockEntity loock, DomainOperationContext context)
        {
            PrepareCustom(loock, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(loock, context, result.Errors);
            ValidateCustom(loock, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(loock, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILoockEntity loock, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => loock.isValidInsert(),
                DomainOperation.Alteracao => loock.isValidUpdate(),
                DomainOperation.Remocao => loock.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(loock.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILoockEntity loock, DomainOperationContext context);
        static partial void ValidateCustom(ILoockEntity loock, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILoockEntity loock, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration