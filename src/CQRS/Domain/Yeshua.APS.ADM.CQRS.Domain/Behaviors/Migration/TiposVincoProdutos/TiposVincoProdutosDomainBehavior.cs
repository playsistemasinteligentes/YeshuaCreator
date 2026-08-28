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
    public static partial class TiposVincoProdutosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITiposVincoProdutosEntity tiposvincoprodutos, DomainOperationContext context)
        {
            PrepareCustom(tiposvincoprodutos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tiposvincoprodutos, context, result.Errors);
            ValidateCustom(tiposvincoprodutos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tiposvincoprodutos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITiposVincoProdutosEntity tiposvincoprodutos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tiposvincoprodutos.isValidInsert(),
                DomainOperation.Alteracao => tiposvincoprodutos.isValidUpdate(),
                DomainOperation.Remocao => tiposvincoprodutos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tiposvincoprodutos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITiposVincoProdutosEntity tiposvincoprodutos, DomainOperationContext context);
        static partial void ValidateCustom(ITiposVincoProdutosEntity tiposvincoprodutos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITiposVincoProdutosEntity tiposvincoprodutos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration