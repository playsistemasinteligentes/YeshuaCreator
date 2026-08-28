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
    public static partial class ItensEstruturaImpressaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IItensEstruturaImpressaoEntity itensestruturaimpressao, DomainOperationContext context)
        {
            PrepareCustom(itensestruturaimpressao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(itensestruturaimpressao, context, result.Errors);
            ValidateCustom(itensestruturaimpressao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(itensestruturaimpressao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IItensEstruturaImpressaoEntity itensestruturaimpressao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => itensestruturaimpressao.isValidInsert(),
                DomainOperation.Alteracao => itensestruturaimpressao.isValidUpdate(),
                DomainOperation.Remocao => itensestruturaimpressao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(itensestruturaimpressao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IItensEstruturaImpressaoEntity itensestruturaimpressao, DomainOperationContext context);
        static partial void ValidateCustom(IItensEstruturaImpressaoEntity itensestruturaimpressao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IItensEstruturaImpressaoEntity itensestruturaimpressao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration