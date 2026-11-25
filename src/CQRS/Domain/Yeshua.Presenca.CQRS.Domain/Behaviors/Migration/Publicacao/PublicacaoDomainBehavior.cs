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
    public static partial class PublicacaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPublicacaoEntity publicacao, DomainOperationContext context)
        {
            PrepareCustom(publicacao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(publicacao, context, result.Errors);
            ValidateCustom(publicacao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(publicacao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPublicacaoEntity publicacao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => publicacao.isValidInsert(),
                DomainOperation.Alteracao => publicacao.isValidUpdate(),
                DomainOperation.Remocao => publicacao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(publicacao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPublicacaoEntity publicacao, DomainOperationContext context);
        static partial void ValidateCustom(IPublicacaoEntity publicacao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPublicacaoEntity publicacao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration