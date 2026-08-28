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
    public static partial class EstruturaProdutoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEstruturaProdutoEntity estruturaproduto, DomainOperationContext context)
        {
            PrepareCustom(estruturaproduto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(estruturaproduto, context, result.Errors);
            ValidateCustom(estruturaproduto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(estruturaproduto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEstruturaProdutoEntity estruturaproduto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => estruturaproduto.isValidInsert(),
                DomainOperation.Alteracao => estruturaproduto.isValidUpdate(),
                DomainOperation.Remocao => estruturaproduto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(estruturaproduto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEstruturaProdutoEntity estruturaproduto, DomainOperationContext context);
        static partial void ValidateCustom(IEstruturaProdutoEntity estruturaproduto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEstruturaProdutoEntity estruturaproduto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration