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
    public static partial class ItemInspecaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItemInspecaoEntity iteminspecao, DomainOperationContext context)
        {
            PrepareCustom(iteminspecao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(iteminspecao, context, result.Errors);
            ValidateCustom(iteminspecao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(iteminspecao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItemInspecaoEntity iteminspecao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => iteminspecao.isValidInsert(),
                DomainOperation.Alteracao => iteminspecao.isValidUpdate(),
                DomainOperation.Remocao => iteminspecao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(iteminspecao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItemInspecaoEntity iteminspecao, DomainOperationContext context);
        static partial void ValidateCustom(IItemInspecaoEntity iteminspecao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItemInspecaoEntity iteminspecao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration