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
    public static partial class EstruturaImpressaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEstruturaImpressaoEntity estruturaimpressao, DomainOperationContext context)
        {
            PrepareCustom(estruturaimpressao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(estruturaimpressao, context, result.Errors);
            ValidateCustom(estruturaimpressao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(estruturaimpressao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEstruturaImpressaoEntity estruturaimpressao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => estruturaimpressao.isValidInsert(),
                DomainOperation.Alteracao => estruturaimpressao.isValidUpdate(),
                DomainOperation.Remocao => estruturaimpressao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(estruturaimpressao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEstruturaImpressaoEntity estruturaimpressao, DomainOperationContext context);
        static partial void ValidateCustom(IEstruturaImpressaoEntity estruturaimpressao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEstruturaImpressaoEntity estruturaimpressao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration