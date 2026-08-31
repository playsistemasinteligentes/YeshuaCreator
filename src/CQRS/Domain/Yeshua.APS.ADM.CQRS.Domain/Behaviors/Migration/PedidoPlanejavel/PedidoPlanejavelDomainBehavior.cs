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
    public static partial class PedidoPlanejavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPedidoPlanejavelEntity pedidoplanejavel, DomainOperationContext context)
        {
            PrepareCustom(pedidoplanejavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(pedidoplanejavel, context, result.Errors);
            ValidateCustom(pedidoplanejavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(pedidoplanejavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPedidoPlanejavelEntity pedidoplanejavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => pedidoplanejavel.isValidInsert(),
                DomainOperation.Alteracao => pedidoplanejavel.isValidUpdate(),
                DomainOperation.Remocao => pedidoplanejavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(pedidoplanejavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPedidoPlanejavelEntity pedidoplanejavel, DomainOperationContext context);
        static partial void ValidateCustom(IPedidoPlanejavelEntity pedidoplanejavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPedidoPlanejavelEntity pedidoplanejavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration