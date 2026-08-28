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
    public static partial class RotaRealizadaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRotaRealizadaEntity rotarealizada, DomainOperationContext context)
        {
            PrepareCustom(rotarealizada, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(rotarealizada, context, result.Errors);
            ValidateCustom(rotarealizada, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(rotarealizada, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRotaRealizadaEntity rotarealizada, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => rotarealizada.isValidInsert(),
                DomainOperation.Alteracao => rotarealizada.isValidUpdate(),
                DomainOperation.Remocao => rotarealizada.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(rotarealizada.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRotaRealizadaEntity rotarealizada, DomainOperationContext context);
        static partial void ValidateCustom(IRotaRealizadaEntity rotarealizada, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRotaRealizadaEntity rotarealizada, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration