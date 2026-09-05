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
    public static partial class CertificadoDigitalDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICertificadoDigitalEntity certificadodigital, DomainOperationContext context)
        {
            PrepareCustom(certificadodigital, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(certificadodigital, context, result.Errors);
            ValidateCustom(certificadodigital, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(certificadodigital, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICertificadoDigitalEntity certificadodigital, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => certificadodigital.isValidInsert(),
                DomainOperation.Alteracao => certificadodigital.isValidUpdate(),
                DomainOperation.Remocao => certificadodigital.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(certificadodigital.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICertificadoDigitalEntity certificadodigital, DomainOperationContext context);
        static partial void ValidateCustom(ICertificadoDigitalEntity certificadodigital, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICertificadoDigitalEntity certificadodigital, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration