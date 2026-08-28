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
    public static partial class GrupoProdutoAbstratoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoProdutoAbstratoEntity grupoprodutoabstrato, DomainOperationContext context)
        {
            PrepareCustom(grupoprodutoabstrato, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(grupoprodutoabstrato, context, result.Errors);
            ValidateCustom(grupoprodutoabstrato, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(grupoprodutoabstrato, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoProdutoAbstratoEntity grupoprodutoabstrato, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => grupoprodutoabstrato.isValidInsert(),
                DomainOperation.Alteracao => grupoprodutoabstrato.isValidUpdate(),
                DomainOperation.Remocao => grupoprodutoabstrato.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(grupoprodutoabstrato.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoProdutoAbstratoEntity grupoprodutoabstrato, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoProdutoAbstratoEntity grupoprodutoabstrato, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoProdutoAbstratoEntity grupoprodutoabstrato, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration