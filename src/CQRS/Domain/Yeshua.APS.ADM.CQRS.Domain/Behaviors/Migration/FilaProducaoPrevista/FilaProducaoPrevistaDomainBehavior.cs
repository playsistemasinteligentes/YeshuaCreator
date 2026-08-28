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
    public static partial class FilaProducaoPrevistaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IFilaProducaoPrevistaEntity filaproducaoprevista, DomainOperationContext context)
        {
            PrepareCustom(filaproducaoprevista, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(filaproducaoprevista, context, result.Errors);
            ValidateCustom(filaproducaoprevista, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(filaproducaoprevista, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IFilaProducaoPrevistaEntity filaproducaoprevista, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => filaproducaoprevista.isValidInsert(),
                DomainOperation.Alteracao => filaproducaoprevista.isValidUpdate(),
                DomainOperation.Remocao => filaproducaoprevista.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(filaproducaoprevista.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IFilaProducaoPrevistaEntity filaproducaoprevista, DomainOperationContext context);
        static partial void ValidateCustom(IFilaProducaoPrevistaEntity filaproducaoprevista, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IFilaProducaoPrevistaEntity filaproducaoprevista, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration