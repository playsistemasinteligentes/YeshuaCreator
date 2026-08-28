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
    public static partial class ClienteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IClienteEntity cliente, DomainOperationContext context)
        {
            PrepareCustom(cliente, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cliente, context, result.Errors);
            ValidateCustom(cliente, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cliente, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IClienteEntity cliente, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cliente.isValidInsert(),
                DomainOperation.Alteracao => cliente.isValidUpdate(),
                DomainOperation.Remocao => cliente.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cliente.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IClienteEntity cliente, DomainOperationContext context);
        static partial void ValidateCustom(IClienteEntity cliente, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IClienteEntity cliente, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration