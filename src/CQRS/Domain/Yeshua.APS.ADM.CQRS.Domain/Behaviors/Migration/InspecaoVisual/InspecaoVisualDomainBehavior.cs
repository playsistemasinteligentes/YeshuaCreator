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
    public static partial class InspecaoVisualDomainBehavior
    {
        public static DomainBehaviorResult Apply(IInspecaoVisualEntity inspecaovisual, DomainOperationContext context)
        {
            PrepareCustom(inspecaovisual, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(inspecaovisual, context, result.Errors);
            ValidateCustom(inspecaovisual, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(inspecaovisual, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IInspecaoVisualEntity inspecaovisual, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => inspecaovisual.isValidInsert(),
                DomainOperation.Alteracao => inspecaovisual.isValidUpdate(),
                DomainOperation.Remocao => inspecaovisual.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(inspecaovisual.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IInspecaoVisualEntity inspecaovisual, DomainOperationContext context);
        static partial void ValidateCustom(IInspecaoVisualEntity inspecaovisual, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IInspecaoVisualEntity inspecaovisual, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration