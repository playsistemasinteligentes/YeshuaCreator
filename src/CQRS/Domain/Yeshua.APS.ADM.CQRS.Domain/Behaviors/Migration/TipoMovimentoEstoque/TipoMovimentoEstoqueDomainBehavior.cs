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
    public static partial class TipoMovimentoEstoqueDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoMovimentoEstoqueEntity tipomovimentoestoque, DomainOperationContext context)
        {
            PrepareCustom(tipomovimentoestoque, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipomovimentoestoque, context, result.Errors);
            ValidateCustom(tipomovimentoestoque, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipomovimentoestoque, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoMovimentoEstoqueEntity tipomovimentoestoque, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipomovimentoestoque.isValidInsert(),
                DomainOperation.Alteracao => tipomovimentoestoque.isValidUpdate(),
                DomainOperation.Remocao => tipomovimentoestoque.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipomovimentoestoque.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoMovimentoEstoqueEntity tipomovimentoestoque, DomainOperationContext context);
        static partial void ValidateCustom(ITipoMovimentoEstoqueEntity tipomovimentoestoque, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoMovimentoEstoqueEntity tipomovimentoestoque, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration