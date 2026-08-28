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
    public static partial class ItenCalendarioDisponibilidadeVeiculosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItenCalendarioDisponibilidadeVeiculosEntity itencalendariodisponibilidadeveiculos, DomainOperationContext context)
        {
            PrepareCustom(itencalendariodisponibilidadeveiculos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itencalendariodisponibilidadeveiculos, context, result.Errors);
            ValidateCustom(itencalendariodisponibilidadeveiculos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itencalendariodisponibilidadeveiculos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItenCalendarioDisponibilidadeVeiculosEntity itencalendariodisponibilidadeveiculos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itencalendariodisponibilidadeveiculos.isValidInsert(),
                DomainOperation.Alteracao => itencalendariodisponibilidadeveiculos.isValidUpdate(),
                DomainOperation.Remocao => itencalendariodisponibilidadeveiculos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itencalendariodisponibilidadeveiculos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItenCalendarioDisponibilidadeVeiculosEntity itencalendariodisponibilidadeveiculos, DomainOperationContext context);
        static partial void ValidateCustom(IItenCalendarioDisponibilidadeVeiculosEntity itencalendariodisponibilidadeveiculos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItenCalendarioDisponibilidadeVeiculosEntity itencalendariodisponibilidadeveiculos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration