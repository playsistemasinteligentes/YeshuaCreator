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
    public static partial class AprovacaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IAprovacaoEntity aprovacao, DomainOperationContext context)
        {
            PrepareCustom(aprovacao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(aprovacao, context, result.Errors);
            ValidateCustom(aprovacao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(aprovacao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IAprovacaoEntity aprovacao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => aprovacao.isValidInsert(),
                DomainOperation.Alteracao => aprovacao.isValidUpdate(),
                DomainOperation.Remocao => aprovacao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(aprovacao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IAprovacaoEntity aprovacao, DomainOperationContext context);
        static partial void ValidateCustom(IAprovacaoEntity aprovacao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IAprovacaoEntity aprovacao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration