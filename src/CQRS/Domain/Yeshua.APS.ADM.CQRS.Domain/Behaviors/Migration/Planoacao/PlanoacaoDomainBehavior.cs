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
    public static partial class PlanoacaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlanoacaoEntity planoacao, DomainOperationContext context)
        {
            PrepareCustom(planoacao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(planoacao, context, result.Errors);
            ValidateCustom(planoacao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(planoacao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlanoacaoEntity planoacao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => planoacao.isValidInsert(),
                DomainOperation.Alteracao => planoacao.isValidUpdate(),
                DomainOperation.Remocao => planoacao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(planoacao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlanoacaoEntity planoacao, DomainOperationContext context);
        static partial void ValidateCustom(IPlanoacaoEntity planoacao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlanoacaoEntity planoacao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration