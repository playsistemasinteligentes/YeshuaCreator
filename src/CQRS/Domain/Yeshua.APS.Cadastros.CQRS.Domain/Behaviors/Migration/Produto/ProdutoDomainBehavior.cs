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
    public static partial class ProdutoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IProdutoEntity produto, DomainOperationContext context)
        {
            PrepareCustom(produto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(produto, context, result.Errors);
            ValidateCustom(produto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(produto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IProdutoEntity produto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => produto.isValidInsert(),
                DomainOperation.Alteracao => produto.isValidUpdate(),
                DomainOperation.Remocao => produto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(produto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IProdutoEntity produto, DomainOperationContext context);
        static partial void ValidateCustom(IProdutoEntity produto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IProdutoEntity produto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration