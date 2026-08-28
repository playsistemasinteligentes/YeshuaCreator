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
    public static partial class CompensacaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICompensacaoEntity compensacao, DomainOperationContext context)
        {
            PrepareCustom(compensacao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(compensacao, context, result.Errors);
            ValidateCustom(compensacao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(compensacao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICompensacaoEntity compensacao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => compensacao.isValidInsert(),
                DomainOperation.Alteracao => compensacao.isValidUpdate(),
                DomainOperation.Remocao => compensacao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(compensacao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICompensacaoEntity compensacao, DomainOperationContext context);
        static partial void ValidateCustom(ICompensacaoEntity compensacao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICompensacaoEntity compensacao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration