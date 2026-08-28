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
    public static partial class MovimentoEstoqueDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMovimentoEstoqueEntity movimentoestoque, DomainOperationContext context)
        {
            PrepareCustom(movimentoestoque, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(movimentoestoque, context, result.Errors);
            ValidateCustom(movimentoestoque, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(movimentoestoque, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMovimentoEstoqueEntity movimentoestoque, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => movimentoestoque.isValidInsert(),
                DomainOperation.Alteracao => movimentoestoque.isValidUpdate(),
                DomainOperation.Remocao => movimentoestoque.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(movimentoestoque.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMovimentoEstoqueEntity movimentoestoque, DomainOperationContext context);
        static partial void ValidateCustom(IMovimentoEstoqueEntity movimentoestoque, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMovimentoEstoqueEntity movimentoestoque, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration