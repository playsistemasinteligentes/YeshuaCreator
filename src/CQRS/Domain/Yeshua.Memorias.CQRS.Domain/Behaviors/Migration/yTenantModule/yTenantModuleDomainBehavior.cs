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
    public static partial class yTenantModuleDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyTenantModuleEntity ytenantmodule, DomainOperationContext context)
        {
            PrepareCustom(ytenantmodule, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ytenantmodule, context, result.Errors);
            ValidateCustom(ytenantmodule, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ytenantmodule, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyTenantModuleEntity ytenantmodule, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ytenantmodule.isValidInsert(),
                DomainOperation.Alteracao => ytenantmodule.isValidUpdate(),
                DomainOperation.Remocao => ytenantmodule.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ytenantmodule.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyTenantModuleEntity ytenantmodule, DomainOperationContext context);
        static partial void ValidateCustom(IyTenantModuleEntity ytenantmodule, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyTenantModuleEntity ytenantmodule, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration