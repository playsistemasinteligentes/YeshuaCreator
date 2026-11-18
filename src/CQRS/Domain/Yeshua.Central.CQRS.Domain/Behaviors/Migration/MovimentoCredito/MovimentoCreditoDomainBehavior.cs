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
    public static partial class MovimentoCreditoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMovimentoCreditoEntity movimentocredito, DomainOperationContext context)
        {
            PrepareCustom(movimentocredito, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(movimentocredito, context, result.Errors);
            ValidateCustom(movimentocredito, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(movimentocredito, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMovimentoCreditoEntity movimentocredito, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => movimentocredito.isValidInsert(),
                DomainOperation.Alteracao => movimentocredito.isValidUpdate(),
                DomainOperation.Remocao => movimentocredito.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(movimentocredito.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMovimentoCreditoEntity movimentocredito, DomainOperationContext context);
        static partial void ValidateCustom(IMovimentoCreditoEntity movimentocredito, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMovimentoCreditoEntity movimentocredito, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration