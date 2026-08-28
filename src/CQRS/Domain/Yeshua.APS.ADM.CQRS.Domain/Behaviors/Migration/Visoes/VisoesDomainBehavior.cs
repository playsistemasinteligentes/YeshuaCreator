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
    public static partial class VisoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVisoesEntity visoes, DomainOperationContext context)
        {
            PrepareCustom(visoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(visoes, context, result.Errors);
            ValidateCustom(visoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(visoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVisoesEntity visoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => visoes.isValidInsert(),
                DomainOperation.Alteracao => visoes.isValidUpdate(),
                DomainOperation.Remocao => visoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(visoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVisoesEntity visoes, DomainOperationContext context);
        static partial void ValidateCustom(IVisoesEntity visoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVisoesEntity visoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration