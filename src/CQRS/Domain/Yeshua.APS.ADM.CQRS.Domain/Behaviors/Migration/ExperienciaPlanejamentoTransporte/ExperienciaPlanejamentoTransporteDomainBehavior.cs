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
    public static partial class ExperienciaPlanejamentoTransporteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte, DomainOperationContext context)
        {
            PrepareCustom(experienciaplanejamentotransporte, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(experienciaplanejamentotransporte, context, result.Errors);
            ValidateCustom(experienciaplanejamentotransporte, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(experienciaplanejamentotransporte, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => experienciaplanejamentotransporte.isValidInsert(),
                DomainOperation.Alteracao => experienciaplanejamentotransporte.isValidUpdate(),
                DomainOperation.Remocao => experienciaplanejamentotransporte.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(experienciaplanejamentotransporte.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte, DomainOperationContext context);
        static partial void ValidateCustom(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration