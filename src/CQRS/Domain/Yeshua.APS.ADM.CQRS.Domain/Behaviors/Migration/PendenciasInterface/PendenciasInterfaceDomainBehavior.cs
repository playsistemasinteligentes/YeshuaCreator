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
    public static partial class PendenciasInterfaceDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPendenciasInterfaceEntity pendenciasinterface, DomainOperationContext context)
        {
            PrepareCustom(pendenciasinterface, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(pendenciasinterface, context, result.Errors);
            ValidateCustom(pendenciasinterface, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(pendenciasinterface, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPendenciasInterfaceEntity pendenciasinterface, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => pendenciasinterface.isValidInsert(),
                DomainOperation.Alteracao => pendenciasinterface.isValidUpdate(),
                DomainOperation.Remocao => pendenciasinterface.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(pendenciasinterface.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPendenciasInterfaceEntity pendenciasinterface, DomainOperationContext context);
        static partial void ValidateCustom(IPendenciasInterfaceEntity pendenciasinterface, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPendenciasInterfaceEntity pendenciasinterface, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration