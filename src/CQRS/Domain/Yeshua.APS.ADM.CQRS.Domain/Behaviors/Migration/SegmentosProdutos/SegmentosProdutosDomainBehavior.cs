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
    public static partial class SegmentosProdutosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISegmentosProdutosEntity segmentosprodutos, DomainOperationContext context)
        {
            PrepareCustom(segmentosprodutos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(segmentosprodutos, context, result.Errors);
            ValidateCustom(segmentosprodutos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(segmentosprodutos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISegmentosProdutosEntity segmentosprodutos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => segmentosprodutos.isValidInsert(),
                DomainOperation.Alteracao => segmentosprodutos.isValidUpdate(),
                DomainOperation.Remocao => segmentosprodutos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(segmentosprodutos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISegmentosProdutosEntity segmentosprodutos, DomainOperationContext context);
        static partial void ValidateCustom(ISegmentosProdutosEntity segmentosprodutos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISegmentosProdutosEntity segmentosprodutos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration