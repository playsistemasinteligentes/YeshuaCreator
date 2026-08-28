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
    public static partial class LotesDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILotesEntity lotes, DomainOperationContext context)
        {
            PrepareCustom(lotes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(lotes, context, result.Errors);
            ValidateCustom(lotes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(lotes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILotesEntity lotes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => lotes.isValidInsert(),
                DomainOperation.Alteracao => lotes.isValidUpdate(),
                DomainOperation.Remocao => lotes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(lotes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILotesEntity lotes, DomainOperationContext context);
        static partial void ValidateCustom(ILotesEntity lotes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILotesEntity lotes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration