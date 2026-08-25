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
    public static partial class MovimentacaoFinanceiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMovimentacaoFinanceiraEntity movimentacaofinanceira, DomainOperationContext context)
        {
            PrepareCustom(movimentacaofinanceira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(movimentacaofinanceira, context, result.Errors);
            ValidateCustom(movimentacaofinanceira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(movimentacaofinanceira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMovimentacaoFinanceiraEntity movimentacaofinanceira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => movimentacaofinanceira.isValidInsert(),
                DomainOperation.Alteracao => movimentacaofinanceira.isValidUpdate(),
                DomainOperation.Remocao => movimentacaofinanceira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(movimentacaofinanceira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMovimentacaoFinanceiraEntity movimentacaofinanceira, DomainOperationContext context);
        static partial void ValidateCustom(IMovimentacaoFinanceiraEntity movimentacaofinanceira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMovimentacaoFinanceiraEntity movimentacaofinanceira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration