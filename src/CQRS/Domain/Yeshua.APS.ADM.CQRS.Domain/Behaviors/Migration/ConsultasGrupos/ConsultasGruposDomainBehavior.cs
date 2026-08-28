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
    public static partial class ConsultasGruposDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConsultasGruposEntity consultasgrupos, DomainOperationContext context)
        {
            PrepareCustom(consultasgrupos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(consultasgrupos, context, result.Errors);
            ValidateCustom(consultasgrupos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(consultasgrupos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConsultasGruposEntity consultasgrupos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => consultasgrupos.isValidInsert(),
                DomainOperation.Alteracao => consultasgrupos.isValidUpdate(),
                DomainOperation.Remocao => consultasgrupos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(consultasgrupos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConsultasGruposEntity consultasgrupos, DomainOperationContext context);
        static partial void ValidateCustom(IConsultasGruposEntity consultasgrupos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConsultasGruposEntity consultasgrupos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration