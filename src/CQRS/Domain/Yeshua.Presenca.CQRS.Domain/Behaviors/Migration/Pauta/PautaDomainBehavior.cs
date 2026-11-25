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
    public static partial class PautaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPautaEntity pauta, DomainOperationContext context)
        {
            PrepareCustom(pauta, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(pauta, context, result.Errors);
            ValidateCustom(pauta, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(pauta, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPautaEntity pauta, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => pauta.isValidInsert(),
                DomainOperation.Alteracao => pauta.isValidUpdate(),
                DomainOperation.Remocao => pauta.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(pauta.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPautaEntity pauta, DomainOperationContext context);
        static partial void ValidateCustom(IPautaEntity pauta, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPautaEntity pauta, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration