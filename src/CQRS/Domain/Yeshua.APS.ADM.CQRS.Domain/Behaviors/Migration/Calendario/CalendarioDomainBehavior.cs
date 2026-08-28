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
    public static partial class CalendarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICalendarioEntity calendario, DomainOperationContext context)
        {
            PrepareCustom(calendario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(calendario, context, result.Errors);
            ValidateCustom(calendario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(calendario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICalendarioEntity calendario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => calendario.isValidInsert(),
                DomainOperation.Alteracao => calendario.isValidUpdate(),
                DomainOperation.Remocao => calendario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(calendario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICalendarioEntity calendario, DomainOperationContext context);
        static partial void ValidateCustom(ICalendarioEntity calendario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICalendarioEntity calendario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration