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
    public static partial class TransportadoraDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITransportadoraEntity transportadora, DomainOperationContext context)
        {
            PrepareCustom(transportadora, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(transportadora, context, result.Errors);
            ValidateCustom(transportadora, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(transportadora, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITransportadoraEntity transportadora, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => transportadora.isValidInsert(),
                DomainOperation.Alteracao => transportadora.isValidUpdate(),
                DomainOperation.Remocao => transportadora.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(transportadora.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITransportadoraEntity transportadora, DomainOperationContext context);
        static partial void ValidateCustom(ITransportadoraEntity transportadora, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITransportadoraEntity transportadora, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration