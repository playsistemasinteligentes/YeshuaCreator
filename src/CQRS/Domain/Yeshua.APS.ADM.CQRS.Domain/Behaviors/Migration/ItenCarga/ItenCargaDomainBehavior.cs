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
    public static partial class ItenCargaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItenCargaEntity itencarga, DomainOperationContext context)
        {
            PrepareCustom(itencarga, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itencarga, context, result.Errors);
            ValidateCustom(itencarga, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itencarga, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItenCargaEntity itencarga, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itencarga.isValidInsert(),
                DomainOperation.Alteracao => itencarga.isValidUpdate(),
                DomainOperation.Remocao => itencarga.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itencarga.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItenCargaEntity itencarga, DomainOperationContext context);
        static partial void ValidateCustom(IItenCargaEntity itencarga, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItenCargaEntity itencarga, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration