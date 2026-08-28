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
    public static partial class CondicaoPagamentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICondicaoPagamentoEntity condicaopagamento, DomainOperationContext context)
        {
            PrepareCustom(condicaopagamento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(condicaopagamento, context, result.Errors);
            ValidateCustom(condicaopagamento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(condicaopagamento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICondicaoPagamentoEntity condicaopagamento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => condicaopagamento.isValidInsert(),
                DomainOperation.Alteracao => condicaopagamento.isValidUpdate(),
                DomainOperation.Remocao => condicaopagamento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(condicaopagamento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICondicaoPagamentoEntity condicaopagamento, DomainOperationContext context);
        static partial void ValidateCustom(ICondicaoPagamentoEntity condicaopagamento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICondicaoPagamentoEntity condicaopagamento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration