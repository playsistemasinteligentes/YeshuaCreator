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
    public static partial class TemplateTipoInspecaoVisualDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual, DomainOperationContext context)
        {
            PrepareCustom(templatetipoinspecaovisual, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(templatetipoinspecaovisual, context, result.Errors);
            ValidateCustom(templatetipoinspecaovisual, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(templatetipoinspecaovisual, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => templatetipoinspecaovisual.isValidInsert(),
                DomainOperation.Alteracao => templatetipoinspecaovisual.isValidUpdate(),
                DomainOperation.Remocao => templatetipoinspecaovisual.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(templatetipoinspecaovisual.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual, DomainOperationContext context);
        static partial void ValidateCustom(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemplateTipoInspecaoVisualEntity templatetipoinspecaovisual, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration