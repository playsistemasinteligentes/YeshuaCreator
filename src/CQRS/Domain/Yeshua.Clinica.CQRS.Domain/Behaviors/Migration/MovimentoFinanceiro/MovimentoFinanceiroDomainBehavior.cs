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
    public static partial class MovimentoFinanceiroDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMovimentoFinanceiroEntity movimentofinanceiro, DomainOperationContext context)
        {
            PrepareCustom(movimentofinanceiro, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(movimentofinanceiro, context, result.Errors);
            ValidateCustom(movimentofinanceiro, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(movimentofinanceiro, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMovimentoFinanceiroEntity movimentofinanceiro, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => movimentofinanceiro.isValidInsert(),
                DomainOperation.Alteracao => movimentofinanceiro.isValidUpdate(),
                DomainOperation.Remocao => movimentofinanceiro.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(movimentofinanceiro.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMovimentoFinanceiroEntity movimentofinanceiro, DomainOperationContext context);
        static partial void ValidateCustom(IMovimentoFinanceiroEntity movimentofinanceiro, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMovimentoFinanceiroEntity movimentofinanceiro, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration