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
    public static partial class TurnoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITurnoEntity turno, DomainOperationContext context)
        {
            PrepareCustom(turno, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(turno, context, result.Errors);
            ValidateCustom(turno, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(turno, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITurnoEntity turno, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => turno.isValidInsert(),
                DomainOperation.Alteracao => turno.isValidUpdate(),
                DomainOperation.Remocao => turno.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(turno.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITurnoEntity turno, DomainOperationContext context);
        static partial void ValidateCustom(ITurnoEntity turno, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITurnoEntity turno, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration