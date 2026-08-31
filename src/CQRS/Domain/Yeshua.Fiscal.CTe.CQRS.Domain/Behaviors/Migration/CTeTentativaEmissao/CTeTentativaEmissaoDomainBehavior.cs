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
    public static partial class CTeTentativaEmissaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeTentativaEmissaoEntity ctetentativaemissao, DomainOperationContext context)
        {
            PrepareCustom(ctetentativaemissao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ctetentativaemissao, context, result.Errors);
            ValidateCustom(ctetentativaemissao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ctetentativaemissao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeTentativaEmissaoEntity ctetentativaemissao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ctetentativaemissao.isValidInsert(),
                DomainOperation.Alteracao => ctetentativaemissao.isValidUpdate(),
                DomainOperation.Remocao => ctetentativaemissao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ctetentativaemissao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeTentativaEmissaoEntity ctetentativaemissao, DomainOperationContext context);
        static partial void ValidateCustom(ICTeTentativaEmissaoEntity ctetentativaemissao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeTentativaEmissaoEntity ctetentativaemissao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration