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
    public static partial class RoteiroPedidoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRoteiroPedidoEntity roteiropedido, DomainOperationContext context)
        {
            PrepareCustom(roteiropedido, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(roteiropedido, context, result.Errors);
            ValidateCustom(roteiropedido, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(roteiropedido, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRoteiroPedidoEntity roteiropedido, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => roteiropedido.isValidInsert(),
                DomainOperation.Alteracao => roteiropedido.isValidUpdate(),
                DomainOperation.Remocao => roteiropedido.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(roteiropedido.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRoteiroPedidoEntity roteiropedido, DomainOperationContext context);
        static partial void ValidateCustom(IRoteiroPedidoEntity roteiropedido, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRoteiroPedidoEntity roteiropedido, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration