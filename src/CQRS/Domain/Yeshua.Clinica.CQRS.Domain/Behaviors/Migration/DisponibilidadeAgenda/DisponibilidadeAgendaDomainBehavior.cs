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
    public static partial class DisponibilidadeAgendaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IDisponibilidadeAgendaEntity disponibilidadeagenda, DomainOperationContext context)
        {
            PrepareCustom(disponibilidadeagenda, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(disponibilidadeagenda, context, result.Errors);
            ValidateCustom(disponibilidadeagenda, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(disponibilidadeagenda, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IDisponibilidadeAgendaEntity disponibilidadeagenda, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => disponibilidadeagenda.isValidInsert(),
                DomainOperation.Alteracao => disponibilidadeagenda.isValidUpdate(),
                DomainOperation.Remocao => disponibilidadeagenda.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(disponibilidadeagenda.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IDisponibilidadeAgendaEntity disponibilidadeagenda, DomainOperationContext context);
        static partial void ValidateCustom(IDisponibilidadeAgendaEntity disponibilidadeagenda, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IDisponibilidadeAgendaEntity disponibilidadeagenda, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration