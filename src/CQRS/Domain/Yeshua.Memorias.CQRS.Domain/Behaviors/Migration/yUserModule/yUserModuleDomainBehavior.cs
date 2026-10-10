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
    public static partial class yUserModuleDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyUserModuleEntity yusermodule, DomainOperationContext context)
        {
            PrepareCustom(yusermodule, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yusermodule, context, result.Errors);
            ValidateCustom(yusermodule, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yusermodule, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyUserModuleEntity yusermodule, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yusermodule.isValidInsert(),
                DomainOperation.Alteracao => yusermodule.isValidUpdate(),
                DomainOperation.Remocao => yusermodule.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yusermodule.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyUserModuleEntity yusermodule, DomainOperationContext context);
        static partial void ValidateCustom(IyUserModuleEntity yusermodule, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyUserModuleEntity yusermodule, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration