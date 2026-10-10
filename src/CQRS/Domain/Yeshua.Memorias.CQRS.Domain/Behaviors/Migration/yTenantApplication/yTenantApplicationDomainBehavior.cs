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
    public static partial class yTenantApplicationDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyTenantApplicationEntity ytenantapplication, DomainOperationContext context)
        {
            PrepareCustom(ytenantapplication, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ytenantapplication, context, result.Errors);
            ValidateCustom(ytenantapplication, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ytenantapplication, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyTenantApplicationEntity ytenantapplication, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ytenantapplication.isValidInsert(),
                DomainOperation.Alteracao => ytenantapplication.isValidUpdate(),
                DomainOperation.Remocao => ytenantapplication.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ytenantapplication.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyTenantApplicationEntity ytenantapplication, DomainOperationContext context);
        static partial void ValidateCustom(IyTenantApplicationEntity ytenantapplication, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyTenantApplicationEntity ytenantapplication, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration