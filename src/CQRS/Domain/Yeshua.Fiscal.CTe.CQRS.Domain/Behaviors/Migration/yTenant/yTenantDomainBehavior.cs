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
    public static partial class yTenantDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyTenantEntity ytenant, DomainOperationContext context)
        {
            PrepareCustom(ytenant, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ytenant, context, result.Errors);
            ValidateCustom(ytenant, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ytenant, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyTenantEntity ytenant, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ytenant.isValidInsert(),
                DomainOperation.Alteracao => ytenant.isValidUpdate(),
                DomainOperation.Remocao => ytenant.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ytenant.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyTenantEntity ytenant, DomainOperationContext context);
        static partial void ValidateCustom(IyTenantEntity ytenant, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyTenantEntity ytenant, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration