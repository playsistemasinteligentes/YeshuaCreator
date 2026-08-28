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
    public static partial class CargaPrevistaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICargaPrevistaEntity cargaprevista, DomainOperationContext context)
        {
            PrepareCustom(cargaprevista, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cargaprevista, context, result.Errors);
            ValidateCustom(cargaprevista, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cargaprevista, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICargaPrevistaEntity cargaprevista, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cargaprevista.isValidInsert(),
                DomainOperation.Alteracao => cargaprevista.isValidUpdate(),
                DomainOperation.Remocao => cargaprevista.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cargaprevista.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICargaPrevistaEntity cargaprevista, DomainOperationContext context);
        static partial void ValidateCustom(ICargaPrevistaEntity cargaprevista, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICargaPrevistaEntity cargaprevista, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration