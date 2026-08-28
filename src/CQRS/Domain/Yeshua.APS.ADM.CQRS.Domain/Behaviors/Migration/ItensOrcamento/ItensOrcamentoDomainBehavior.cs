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
    public static partial class ItensOrcamentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItensOrcamentoEntity itensorcamento, DomainOperationContext context)
        {
            PrepareCustom(itensorcamento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itensorcamento, context, result.Errors);
            ValidateCustom(itensorcamento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itensorcamento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItensOrcamentoEntity itensorcamento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itensorcamento.isValidInsert(),
                DomainOperation.Alteracao => itensorcamento.isValidUpdate(),
                DomainOperation.Remocao => itensorcamento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itensorcamento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItensOrcamentoEntity itensorcamento, DomainOperationContext context);
        static partial void ValidateCustom(IItensOrcamentoEntity itensorcamento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItensOrcamentoEntity itensorcamento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration