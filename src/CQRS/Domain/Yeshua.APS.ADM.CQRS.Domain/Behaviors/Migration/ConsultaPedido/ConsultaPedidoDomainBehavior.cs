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
    public static partial class ConsultaPedidoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConsultaPedidoEntity consultapedido, DomainOperationContext context)
        {
            PrepareCustom(consultapedido, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(consultapedido, context, result.Errors);
            ValidateCustom(consultapedido, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(consultapedido, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConsultaPedidoEntity consultapedido, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => consultapedido.isValidInsert(),
                DomainOperation.Alteracao => consultapedido.isValidUpdate(),
                DomainOperation.Remocao => consultapedido.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(consultapedido.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConsultaPedidoEntity consultapedido, DomainOperationContext context);
        static partial void ValidateCustom(IConsultaPedidoEntity consultapedido, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConsultaPedidoEntity consultapedido, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration