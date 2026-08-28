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
    public static partial class T_HORARIO_RECEBIMENTODomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento, DomainOperationContext context)
        {
            PrepareCustom(t_horario_recebimento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_horario_recebimento, context, result.Errors);
            ValidateCustom(t_horario_recebimento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_horario_recebimento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_horario_recebimento.isValidInsert(),
                DomainOperation.Alteracao => t_horario_recebimento.isValidUpdate(),
                DomainOperation.Remocao => t_horario_recebimento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_horario_recebimento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento, DomainOperationContext context);
        static partial void ValidateCustom(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration