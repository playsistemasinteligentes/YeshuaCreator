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
    public static partial class ClinicaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IClinicaEntity clinica, DomainOperationContext context)
        {
            PrepareCustom(clinica, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(clinica, context, result.Errors);
            ValidateCustom(clinica, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(clinica, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IClinicaEntity clinica, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => clinica.isValidInsert(),
                DomainOperation.Alteracao => clinica.isValidUpdate(),
                DomainOperation.Remocao => clinica.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(clinica.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IClinicaEntity clinica, DomainOperationContext context);
        static partial void ValidateCustom(IClinicaEntity clinica, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IClinicaEntity clinica, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration