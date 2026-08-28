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
    public static partial class CargosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICargosEntity cargos, DomainOperationContext context)
        {
            PrepareCustom(cargos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cargos, context, result.Errors);
            ValidateCustom(cargos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cargos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICargosEntity cargos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cargos.isValidInsert(),
                DomainOperation.Alteracao => cargos.isValidUpdate(),
                DomainOperation.Remocao => cargos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cargos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICargosEntity cargos, DomainOperationContext context);
        static partial void ValidateCustom(ICargosEntity cargos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICargosEntity cargos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration