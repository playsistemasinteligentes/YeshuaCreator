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
    public static partial class LoteTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILoteTesteEntity loteteste, DomainOperationContext context)
        {
            PrepareCustom(loteteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(loteteste, context, result.Errors);
            ValidateCustom(loteteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(loteteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILoteTesteEntity loteteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => loteteste.isValidInsert(),
                DomainOperation.Alteracao => loteteste.isValidUpdate(),
                DomainOperation.Remocao => loteteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(loteteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILoteTesteEntity loteteste, DomainOperationContext context);
        static partial void ValidateCustom(ILoteTesteEntity loteteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILoteTesteEntity loteteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration