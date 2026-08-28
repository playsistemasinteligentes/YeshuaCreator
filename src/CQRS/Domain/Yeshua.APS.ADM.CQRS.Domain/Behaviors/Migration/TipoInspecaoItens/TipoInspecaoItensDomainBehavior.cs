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
    public static partial class TipoInspecaoItensDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoInspecaoItensEntity tipoinspecaoitens, DomainOperationContext context)
        {
            PrepareCustom(tipoinspecaoitens, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoinspecaoitens, context, result.Errors);
            ValidateCustom(tipoinspecaoitens, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoinspecaoitens, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoInspecaoItensEntity tipoinspecaoitens, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoinspecaoitens.isValidInsert(),
                DomainOperation.Alteracao => tipoinspecaoitens.isValidUpdate(),
                DomainOperation.Remocao => tipoinspecaoitens.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoinspecaoitens.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoInspecaoItensEntity tipoinspecaoitens, DomainOperationContext context);
        static partial void ValidateCustom(ITipoInspecaoItensEntity tipoinspecaoitens, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoInspecaoItensEntity tipoinspecaoitens, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration