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
    public static partial class CobrancaCreditoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICobrancaCreditoEntity cobrancacredito, DomainOperationContext context)
        {
            PrepareCustom(cobrancacredito, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cobrancacredito, context, result.Errors);
            ValidateCustom(cobrancacredito, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cobrancacredito, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICobrancaCreditoEntity cobrancacredito, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cobrancacredito.isValidInsert(),
                DomainOperation.Alteracao => cobrancacredito.isValidUpdate(),
                DomainOperation.Remocao => cobrancacredito.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cobrancacredito.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICobrancaCreditoEntity cobrancacredito, DomainOperationContext context);
        static partial void ValidateCustom(ICobrancaCreditoEntity cobrancacredito, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICobrancaCreditoEntity cobrancacredito, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration