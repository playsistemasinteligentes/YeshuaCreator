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
    public static partial class EmissaoFiscalTransporteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEmissaoFiscalTransporteEntity emissaofiscaltransporte, DomainOperationContext context)
        {
            PrepareCustom(emissaofiscaltransporte, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(emissaofiscaltransporte, context, result.Errors);
            ValidateCustom(emissaofiscaltransporte, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(emissaofiscaltransporte, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEmissaoFiscalTransporteEntity emissaofiscaltransporte, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => emissaofiscaltransporte.isValidInsert(),
                DomainOperation.Alteracao => emissaofiscaltransporte.isValidUpdate(),
                DomainOperation.Remocao => emissaofiscaltransporte.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(emissaofiscaltransporte.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEmissaoFiscalTransporteEntity emissaofiscaltransporte, DomainOperationContext context);
        static partial void ValidateCustom(IEmissaoFiscalTransporteEntity emissaofiscaltransporte, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEmissaoFiscalTransporteEntity emissaofiscaltransporte, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration