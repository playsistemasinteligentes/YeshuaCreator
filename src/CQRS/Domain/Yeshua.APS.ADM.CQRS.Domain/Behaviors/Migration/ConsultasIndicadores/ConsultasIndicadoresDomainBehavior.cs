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
    public static partial class ConsultasIndicadoresDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConsultasIndicadoresEntity consultasindicadores, DomainOperationContext context)
        {
            PrepareCustom(consultasindicadores, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(consultasindicadores, context, result.Errors);
            ValidateCustom(consultasindicadores, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(consultasindicadores, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConsultasIndicadoresEntity consultasindicadores, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => consultasindicadores.isValidInsert(),
                DomainOperation.Alteracao => consultasindicadores.isValidUpdate(),
                DomainOperation.Remocao => consultasindicadores.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(consultasindicadores.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConsultasIndicadoresEntity consultasindicadores, DomainOperationContext context);
        static partial void ValidateCustom(IConsultasIndicadoresEntity consultasindicadores, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConsultasIndicadoresEntity consultasindicadores, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration