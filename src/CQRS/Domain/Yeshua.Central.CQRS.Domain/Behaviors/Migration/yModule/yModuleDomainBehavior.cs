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
    public static partial class yModuleDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyModuleEntity ymodule, DomainOperationContext context)
        {
            PrepareCustom(ymodule, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ymodule, context, result.Errors);
            ValidateCustom(ymodule, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ymodule, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyModuleEntity ymodule, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ymodule.isValidInsert(),
                DomainOperation.Alteracao => ymodule.isValidUpdate(),
                DomainOperation.Remocao => ymodule.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ymodule.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyModuleEntity ymodule, DomainOperationContext context);
        static partial void ValidateCustom(IyModuleEntity ymodule, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyModuleEntity ymodule, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration