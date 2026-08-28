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
    public static partial class ItensCalendarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItensCalendarioEntity itenscalendario, DomainOperationContext context)
        {
            PrepareCustom(itenscalendario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itenscalendario, context, result.Errors);
            ValidateCustom(itenscalendario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itenscalendario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItensCalendarioEntity itenscalendario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itenscalendario.isValidInsert(),
                DomainOperation.Alteracao => itenscalendario.isValidUpdate(),
                DomainOperation.Remocao => itenscalendario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itenscalendario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItensCalendarioEntity itenscalendario, DomainOperationContext context);
        static partial void ValidateCustom(IItensCalendarioEntity itenscalendario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItensCalendarioEntity itenscalendario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration