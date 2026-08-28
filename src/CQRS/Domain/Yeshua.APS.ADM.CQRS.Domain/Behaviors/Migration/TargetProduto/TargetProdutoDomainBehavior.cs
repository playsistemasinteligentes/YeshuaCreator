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
    public static partial class TargetProdutoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITargetProdutoEntity targetproduto, DomainOperationContext context)
        {
            PrepareCustom(targetproduto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(targetproduto, context, result.Errors);
            ValidateCustom(targetproduto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(targetproduto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITargetProdutoEntity targetproduto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => targetproduto.isValidInsert(),
                DomainOperation.Alteracao => targetproduto.isValidUpdate(),
                DomainOperation.Remocao => targetproduto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(targetproduto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITargetProdutoEntity targetproduto, DomainOperationContext context);
        static partial void ValidateCustom(ITargetProdutoEntity targetproduto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITargetProdutoEntity targetproduto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration