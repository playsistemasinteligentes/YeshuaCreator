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
    public static partial class OpcaoPlanejamentoTransporteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte, DomainOperationContext context)
        {
            PrepareCustom(opcaoplanejamentotransporte, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(opcaoplanejamentotransporte, context, result.Errors);
            ValidateCustom(opcaoplanejamentotransporte, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(opcaoplanejamentotransporte, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => opcaoplanejamentotransporte.isValidInsert(),
                DomainOperation.Alteracao => opcaoplanejamentotransporte.isValidUpdate(),
                DomainOperation.Remocao => opcaoplanejamentotransporte.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(opcaoplanejamentotransporte.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte, DomainOperationContext context);
        static partial void ValidateCustom(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration