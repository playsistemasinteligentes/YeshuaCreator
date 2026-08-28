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
    public static partial class T_AGENDA_SCHEDULEDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_AGENDA_SCHEDULEEntity t_agenda_schedule, DomainOperationContext context)
        {
            PrepareCustom(t_agenda_schedule, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_agenda_schedule, context, result.Errors);
            ValidateCustom(t_agenda_schedule, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_agenda_schedule, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_AGENDA_SCHEDULEEntity t_agenda_schedule, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_agenda_schedule.isValidInsert(),
                DomainOperation.Alteracao => t_agenda_schedule.isValidUpdate(),
                DomainOperation.Remocao => t_agenda_schedule.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_agenda_schedule.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_AGENDA_SCHEDULEEntity t_agenda_schedule, DomainOperationContext context);
        static partial void ValidateCustom(IT_AGENDA_SCHEDULEEntity t_agenda_schedule, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_AGENDA_SCHEDULEEntity t_agenda_schedule, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration