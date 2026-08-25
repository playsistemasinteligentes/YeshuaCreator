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
    public static partial class PacienteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPacienteEntity paciente, DomainOperationContext context)
        {
            PrepareCustom(paciente, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(paciente, context, result.Errors);
            ValidateCustom(paciente, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(paciente, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPacienteEntity paciente, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => paciente.isValidInsert(),
                DomainOperation.Alteracao => paciente.isValidUpdate(),
                DomainOperation.Remocao => paciente.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(paciente.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPacienteEntity paciente, DomainOperationContext context);
        static partial void ValidateCustom(IPacienteEntity paciente, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPacienteEntity paciente, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration