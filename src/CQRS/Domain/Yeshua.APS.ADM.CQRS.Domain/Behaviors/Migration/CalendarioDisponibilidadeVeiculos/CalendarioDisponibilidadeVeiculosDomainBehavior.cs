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
    public static partial class CalendarioDisponibilidadeVeiculosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos, DomainOperationContext context)
        {
            PrepareCustom(calendariodisponibilidadeveiculos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(calendariodisponibilidadeveiculos, context, result.Errors);
            ValidateCustom(calendariodisponibilidadeveiculos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(calendariodisponibilidadeveiculos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => calendariodisponibilidadeveiculos.isValidInsert(),
                DomainOperation.Alteracao => calendariodisponibilidadeveiculos.isValidUpdate(),
                DomainOperation.Remocao => calendariodisponibilidadeveiculos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(calendariodisponibilidadeveiculos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos, DomainOperationContext context);
        static partial void ValidateCustom(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration