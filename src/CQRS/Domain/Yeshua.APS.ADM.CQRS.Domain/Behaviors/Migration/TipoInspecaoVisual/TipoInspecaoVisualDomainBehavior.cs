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
    public static partial class TipoInspecaoVisualDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoInspecaoVisualEntity tipoinspecaovisual, DomainOperationContext context)
        {
            PrepareCustom(tipoinspecaovisual, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoinspecaovisual, context, result.Errors);
            ValidateCustom(tipoinspecaovisual, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoinspecaovisual, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoInspecaoVisualEntity tipoinspecaovisual, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoinspecaovisual.isValidInsert(),
                DomainOperation.Alteracao => tipoinspecaovisual.isValidUpdate(),
                DomainOperation.Remocao => tipoinspecaovisual.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoinspecaovisual.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoInspecaoVisualEntity tipoinspecaovisual, DomainOperationContext context);
        static partial void ValidateCustom(ITipoInspecaoVisualEntity tipoinspecaovisual, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoInspecaoVisualEntity tipoinspecaovisual, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration