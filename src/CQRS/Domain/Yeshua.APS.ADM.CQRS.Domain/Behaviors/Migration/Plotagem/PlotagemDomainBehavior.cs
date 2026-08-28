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
    public static partial class PlotagemDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlotagemEntity plotagem, DomainOperationContext context)
        {
            PrepareCustom(plotagem, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(plotagem, context, result.Errors);
            ValidateCustom(plotagem, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(plotagem, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlotagemEntity plotagem, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => plotagem.isValidInsert(),
                DomainOperation.Alteracao => plotagem.isValidUpdate(),
                DomainOperation.Remocao => plotagem.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(plotagem.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlotagemEntity plotagem, DomainOperationContext context);
        static partial void ValidateCustom(IPlotagemEntity plotagem, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlotagemEntity plotagem, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration