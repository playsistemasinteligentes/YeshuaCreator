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
    public static partial class CarteiraCreditoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICarteiraCreditoEntity carteiracredito, DomainOperationContext context)
        {
            PrepareCustom(carteiracredito, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(carteiracredito, context, result.Errors);
            ValidateCustom(carteiracredito, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(carteiracredito, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICarteiraCreditoEntity carteiracredito, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => carteiracredito.isValidInsert(),
                DomainOperation.Alteracao => carteiracredito.isValidUpdate(),
                DomainOperation.Remocao => carteiracredito.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(carteiracredito.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICarteiraCreditoEntity carteiracredito, DomainOperationContext context);
        static partial void ValidateCustom(ICarteiraCreditoEntity carteiracredito, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICarteiraCreditoEntity carteiracredito, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration